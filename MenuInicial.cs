using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDasDamas
{
    public partial class MenuInicial : Form
    {
        public String nomeJogador1;
        public String nomeJogador2;

        public MenuInicial()
        {
            InitializeComponent();
        }
        private void btnJogar_Click(object sender, EventArgs e)
        {
            if (tbNomeJogador1.Text != "" && tbNomeJogador2.Text != "")
            {
                nomeJogador1 = tbNomeJogador1.Text;
                nomeJogador2 = tbNomeJogador2.Text;
                Jogo form1 = new Jogo(nomeJogador1, nomeJogador2, this);

                this.Hide();
                form1.Show();
                
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Historico historico = new Historico(this); 
            this.Hide();
            historico.Show();
        }
    }
}
