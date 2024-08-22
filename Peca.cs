using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDasDamas
{
    public enum TipoPeca { Vazio, Jogador1, Jogador2, DamaJogador1, DamaJogador2 }
    internal class Peca
    {

        public TipoPeca Tipo { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Peca(TipoPeca tipo, int x, int y)
        {
            Tipo = tipo;
            X = x;
            Y = y;
        }
    }
}

