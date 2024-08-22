using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JogoDasDamas
{
    public partial class Jogo : Form
    {
        private Tabuleiro tabuleiro;
        private PictureBox[,] pictureBoxes;
        private int origemX = -1;
        private int origemY = -1;
        private int click = 0;
        private int jogadasTotais = 0;
        private PictureBox pbOrigem = null;
        MenuInicial menuInicial;
        private String caminhoXML = @"..\..\Resources\Historico.xml";
        private XmlDocument docxml = new XmlDocument();
        public Jogo(String nomeJogador1, String nomeJogador2, MenuInicial menuInicial)
        {
            InitializeComponent();
            tabuleiro = new Tabuleiro();
            InicializarTabuleiroUI();
            lblNomeJogador1.Text = nomeJogador1.ToUpper();
            lblNomeJogador2.Text = nomeJogador2.ToUpper();
            JogadorAJogar.Text = "Ronda: " + lblNomeJogador1.Text;

            this.menuInicial = menuInicial;
            this.FormClosing += new FormClosingEventHandler(menuInicialFechar);
        }
        private void menuInicialFechar(object sender, FormClosingEventArgs e)
        {
            menuInicial.Close();
        }
        private void InicializarTabuleiroUI()
        {
            pictureBoxes = new PictureBox[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PictureBox pb = new PictureBox
                    {
                        Enabled = false,
                        Dock = DockStyle.Fill,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = (i + j) % 2 == 0 ? Color.White : Color.Black,
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    pb.Click += new EventHandler(PictureBox_Click);
                    tableLayoutPanel1.Controls.Add(pb, j, i);
                    pictureBoxes[i, j] = pb;

                    // Definir imagem da peça
                    AtualizarImagemPeca(i, j);
                }
            }
            AtualizarInteracoes();



        }

        private void AtualizarImagemPeca(int i, int j)
        {
            TipoPeca tipo = tabuleiro.Casas[i, j].Tipo;
            switch (tipo)
            {
                case TipoPeca.Jogador1:
                    pictureBoxes[i, j].Image = Properties.Resources.White;
                    break;
                case TipoPeca.Jogador2:
                    pictureBoxes[i, j].Image = Properties.Resources.Black;
                    break;
                case TipoPeca.DamaJogador1:
                    pictureBoxes[i, j].Image = Properties.Resources.WhiteKing;
                    break;
                case TipoPeca.DamaJogador2:
                    pictureBoxes[i, j].Image = Properties.Resources.BlackKing;
                    break;
                default:
                    pictureBoxes[i, j].Image = null;
                    break;
            }
        }

        private void AtualizarInteracoes()
        {
            if (tabuleiro.JogadorAtual == 1)
            {
                JogadorAJogar.Text = "Ronda: " + lblNomeJogador1.Text;
            }
            else
            {
                JogadorAJogar.Text = "Ronda: " + lblNomeJogador2.Text;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    TipoPeca tipo = tabuleiro.Casas[i, j].Tipo;
                    if (tipo == TipoPeca.Vazio)
                    {
                        pictureBoxes[i, j].Enabled = true;
                    }
                    else if ((tipo == TipoPeca.Jogador1 || tipo == TipoPeca.DamaJogador1) && tabuleiro.JogadorAtual == 1)
                    {
                        pictureBoxes[i, j].Enabled = true;
                    }
                    else if ((tipo == TipoPeca.Jogador2 || tipo == TipoPeca.DamaJogador2) && tabuleiro.JogadorAtual == 2)
                    {
                        pictureBoxes[i, j].Enabled = true;
                    }
                    else
                    {
                        pictureBoxes[i, j].Enabled = false;
                    }
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            int x = tableLayoutPanel1.GetRow(pb);
            int y = tableLayoutPanel1.GetColumn(pb);

            if (tabuleiro.Casas[x, y].Tipo != TipoPeca.Vazio)// 1º vez
            {

                if (this.click == 1)
                {
                    pbOrigem.BackColor = Color.Black;
                }
                origemX = x;
                origemY = y;
                this.click = 1;
                pbOrigem = pb;
                pbOrigem.BackColor = Color.Gray;
                return;
            }

            else if (this.click == 1 && tabuleiro.MoverPeca(origemX, origemY, x, y, tabuleiro.JogadorAtual))
            {
                pbOrigem.BackColor = Color.Black;

                origemX = -1;
                origemY = -1;
                AtualizarTabuleiroUI();
                AtualizarInteracoes();
                lblPontosJogador1.Text = tabuleiro.pecasComidasPretas.ToString();
                lblPontosJogador2.Text = tabuleiro.pecasComidasBrancas.ToString();

                if (tabuleiro.GanharJogo())
                {
                    if (tabuleiro.JogadorAtual == 2)
                    {
                        MessageBox.Show(lblNomeJogador1.Text + " ganhou o jogo!");
                        this.docxml.Load(caminhoXML);
                        XmlNode noHistoricoJogo = docxml.SelectSingleNode("/HistoricoJogo");
                        XmlElement jogo = docxml.CreateElement("Jogo");
                        noHistoricoJogo.AppendChild(jogo);

                        XmlElement jogador1 = docxml.CreateElement("Jogador1");
                        XmlElement jogador2 = docxml.CreateElement("Jogador2");
                        XmlElement jogadas = docxml.CreateElement("Jogadas");
                        XmlElement vencedor = docxml.CreateElement("Vencedor");
                        jogador1.InnerText = lblNomeJogador1.Text;
                        jogador2.InnerText = lblNomeJogador2.Text;
                        jogadas.InnerText = jogadasTotais.ToString();
                        vencedor.InnerText = lblNomeJogador1.Text;
                        jogo.AppendChild(jogador1);
                        jogo.AppendChild(jogador2);
                        jogo.AppendChild(jogadas);
                        jogo.AppendChild(vencedor);
                        docxml.Save(caminhoXML);
                        this.Hide();
                        menuInicial.Show();
                    }
                    else
                    {
                        MessageBox.Show(lblNomeJogador2.Text + " ganhou o jogo!");
                        this.docxml.Load(caminhoXML);
                        XmlNode noHistoricoJogo = docxml.SelectSingleNode("/HistoricoJogo");
                        XmlElement jogo = docxml.CreateElement("Jogo");
                        noHistoricoJogo.AppendChild(jogo);

                        XmlElement jogador1 = docxml.CreateElement("Jogador1");
                        XmlElement jogador2 = docxml.CreateElement("Jogador2");
                        XmlElement jogadas = docxml.CreateElement("Jogadas");
                        XmlElement vencedor = docxml.CreateElement("Vencedor");
                        jogador1.InnerText = lblNomeJogador1.Text;
                        jogador2.InnerText = lblNomeJogador2.Text;
                        jogadas.InnerText = jogadasTotais.ToString();
                        vencedor.InnerText = lblNomeJogador2.Text;
                        jogo.AppendChild(jogador1);
                        jogo.AppendChild(jogador2);
                        jogo.AppendChild(jogadas);
                        jogo.AppendChild(vencedor);
                        docxml.Save(caminhoXML);
                        this.Hide();
                        menuInicial.Show();
                    }
                }
                this.click = 0;
                this.jogadasTotais += 1;
            }
        }

        private void AtualizarTabuleiroUI()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    AtualizarImagemPeca(i, j);
                }
            }
        }

    }



}


