using JogoDasDamas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JogoDasDamas
{
    public partial class Historico : Form
    {
        private String caminhoXML = @"..\..\Resources\Historico.xml";
        private XmlDocument docxml = new XmlDocument();
        MenuInicial menuInicial;
        int contadorDeJogos = 1;
        public Historico(MenuInicial menuInicial)
        {
            InitializeComponent();
            LerXml();
            this.menuInicial = menuInicial;
            this.FormClosing += new FormClosingEventHandler(menuInicialFechar);
            richTextBox1.ReadOnly = true;
        }
        private void menuInicialFechar(object sender, FormClosingEventArgs e)
        {
            menuInicial.Close();
        }
        private void LerXml()
        {
            this.docxml.Load(caminhoXML);
            XmlNodeList noHistoricoJogo = docxml.SelectNodes("HistoricoJogo/Jogo");


            foreach (XmlNode jogo in noHistoricoJogo)
            {
                XmlNode jogador1 = jogo.SelectSingleNode("Jogador1");
                XmlNode jogador2 = jogo.SelectSingleNode("Jogador2");
                XmlNode jogadas = jogo.SelectSingleNode("Jogadas");
                XmlNode vencedor = jogo.SelectSingleNode("Vencedor");
                richTextBox1.AppendText("---------------Jogo " + contadorDeJogos + "---------------" + "\nJogador1: " + jogador1.InnerText + "\nJogador2: " + jogador2.InnerText + "\nJogadas Totais: " + jogadas.InnerText + "\nVencedor: " + vencedor.InnerText + "\n\n\n");
                contadorDeJogos++;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuInicial.Show();
            this.Hide();
        }
    }
}
