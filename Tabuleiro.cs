using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace JogoDasDamas
{
    internal class Tabuleiro
    {



        public Peca[,] Casas { get; private set; }
        public int JogadorAtual { get; private set; }
        public int pecasComidasBrancas { get; private set; }
        public int pecasComidasPretas { get; private set; }

        /// <summary>
        /// Construtor da classe Tabuleiro que inicializa o tabuleiro e define o jogador atual como 1.
        /// </summary>
        public Tabuleiro()
        {
            Casas = new Peca[8, 8];
            JogadorAtual = 1;
            InicializarTabuleiro();
        }

        /// <summary>
        /// Inicializa o tabuleiro com as peças dos jogadores e espaços vazios.
        /// As peças são colocadas nas posições iniciais de acordo com as regras do jogo.
        /// </summary>
        private void InicializarTabuleiro()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        if (i < 3)
                        {
                            Casas[i, j] = new Peca(TipoPeca.Jogador2, i, j);
                            continue;
                        }
                        else if (i > 4)
                        {
                            Casas[i, j] = new Peca(TipoPeca.Jogador1, i, j);
                            continue;
                        }
                        else
                        {
                            Casas[i, j] = new Peca(TipoPeca.Vazio, i, j);
                            continue;
                        }
                    }
                    else
                    {
                        Casas[i, j] = new Peca(TipoPeca.Vazio, i, j);
                        continue;
                    }
                }
            }
        }
        
        /// <summary>
        /// Verifica se o jogo foi ganho por algum dos jogadores.
        /// O jogo é ganho se um jogador come todas as peças do oponente.
        /// </summary>
        /// <returns>Retorna true se um jogador ganhou o jogo, caso contrário, retorna false.</returns>
        public bool GanharJogo() 
        {
            if (pecasComidasPretas == 12)
            {
                return true;
            }
            else if (pecasComidasBrancas == 12)
            {
                return true;

            }
            return false;
        }

        /// <summary>
        /// Remove uma peça do tabuleiro quando ela é capturada.
        /// Atualiza a contagem de peças comidas do jogador adversário.
        /// </summary>
        /// <param name="origemX">A coordenada X da peça original.</param>
        /// <param name="origemY">A coordenada Y da peça original.</param>
        /// <param name="destinoX">A coordenada X do destino da peça.</param>
        /// <param name="destinoY">A coordenada Y do destino da peça.</param>
        private void RetirarPeca(int origemX, int origemY, int destinoX, int destinoY)
        {
            Point destino = new Point(destinoX, destinoY);
            Point aux = new Point((destinoX + origemX) / 2, (destinoY + origemY) / 2);
            if (destino.X != origemX + 1 && (destino.X != origemX - 1))
            {
                Casas[aux.X, aux.Y].Tipo = TipoPeca.Vazio;
            }
            if (JogadorAtual == 1)
            {
                pecasComidasPretas += 1;
            }
            else
            {
                pecasComidasBrancas += 1;
            }
        }
        
        /// <summary>
        /// Verifica os movimentos possíveis para uma peça simples de um jogador.
        /// </summary>
        /// <param name="x">A coordenada X da peça.</param>
        /// <param name="y">A coordenada Y da peça.</param>
        /// <param name="jogador">O número do jogador (1 ou 2).</param>
        /// <returns>Uma lista de pontos representando os movimentos possíveis.</returns>
        public List<Point> VerificarMovimentosSimples(int x, int y, int jogador)
        {
            List<Point> movPossiveisSimples = new List<Point>();
            if (jogador == 1)
            {
                if (x - 1 >= 0)
                {
                    if ((y - 1 >= 0) && Casas[x - 1, y - 1].Tipo == TipoPeca.Vazio)
                        movPossiveisSimples.Add(new Point(x - 1, y - 1));

                    if ((y + 1 < 8) && Casas[x - 1, y + 1].Tipo == TipoPeca.Vazio)
                        movPossiveisSimples.Add(new Point(x - 1, y + 1));
                }
                return movPossiveisSimples;
            }
            if (jogador == 2)
            {
                if (x + 1 < 8)
                {
                    if ((y - 1 >= 0) && Casas[x + 1, y - 1].Tipo == TipoPeca.Vazio)
                        movPossiveisSimples.Add(new Point(x + 1, y - 1));

                    if ((y + 1 < 8) && Casas[x + 1, y + 1].Tipo == TipoPeca.Vazio)
                        movPossiveisSimples.Add(new Point(x + 1, y + 1));
                }
                return movPossiveisSimples;

            }


            return null;
        }
        
        /// <summary>
        /// Verifica os movimentos possíveis de captura para uma peça.
        /// </summary>
        /// <param name="x">A coordenada X da peça.</param>
        /// <param name="y">A coordenada Y da peça.</param>
        /// <returns>Uma lista de pontos representando os movimentos de captura possíveis.</returns>
        public List<Point> VerificarMovimentosCaptura(int x, int y)
        {
            List<Point> movPossiveisCaptura = new List<Point>();
            if (JogadorAtual == 1)
            {
                if ((x - 2 >= 0) && (y + 2 < 8) &&
                   (x - 1 >= 0) && (y + 1 < 8) &&
                   ((Casas[x - 1, y + 1].Tipo == TipoPeca.Jogador2 || Casas[x - 1, y + 1].Tipo == TipoPeca.DamaJogador2) &&
                   Casas[x - 2, y + 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x - 2, y + 2));



                if ((x - 2 >= 0) && (y - 2 >= 0) &&
                     (x - 1 >= 0) && (y - 1 >= 0) &&
                     ((Casas[x - 1, y - 1].Tipo == TipoPeca.Jogador2 || Casas[x - 1, y - 1].Tipo == TipoPeca.DamaJogador2) &&
                     Casas[x - 2, y - 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x - 2, y - 2));

            }
            else
            {
                if ((x + 2 < 8) && (y + 2 < 8) &&
                    ((Casas[x + 1, y + 1].Tipo == TipoPeca.Jogador1 || Casas[x + 1, y + 1].Tipo == TipoPeca.DamaJogador1)) &&
                    Casas[x + 2, y + 2].Tipo == TipoPeca.Vazio)
                    movPossiveisCaptura.Add(new Point(x + 2, y + 2));


                if ((x + 2 < 8) && (y - 2 >= 0) &&
                    (x + 1 < 8) && (y - 1 >= 0) &&
                    ((Casas[x + 1, y - 1].Tipo == TipoPeca.Jogador1 || Casas[x + 1, y - 1].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 2, y - 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x + 2, y - 2));
            }
            return movPossiveisCaptura;
        }
        
        /// <summary>
        /// Verifica se é possível realizar uma captura dupla com a peça atual.
        /// </summary>
        /// <param name="x">A coordenada X da peça.</param>
        /// <param name="y">A coordenada Y da peça.</param>
        /// <returns>Retorna true se uma captura dupla for possível, caso contrário, retorna false.</returns>
        private bool VerificarCapturaDupla(int x, int y)
        {
            bool movPossiveisDupla = false;
            if (JogadorAtual == 1)
            {
                if ((x - 3 >= 0) && (y + 1 < 8) &&
                            (x - 4 >= 0) &&
                            ((Casas[x - 3, y + 1].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y + 1].Tipo == TipoPeca.DamaJogador2) &&
                            Casas[x - 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y + 3 < 8) &&
                    (x - 4 >= 0) && (y + 4 < 8) &&
                    ((Casas[x - 3, y + 3].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y + 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x - 4, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y - 1 >= 0) &&
                    (x - 4 >= 0) &&
                    ((Casas[x - 3, y - 1].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y - 1].Tipo == TipoPeca.DamaJogador2)) &&
                    Casas[x - 4, y].Tipo == TipoPeca.Vazio)
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y - 3 >= 0) &&
                    (x - 4 >= 0) && (y - 4 >= 0) &&
                    ((Casas[x - 3, y - 3].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y - 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x - 4, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
            }
            else
            {
                if ((x + 3 < 8) && (y + 1 < 8) && (x + 4 < 8) &&
                    ((Casas[x + 3, y + 1].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y + 1].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y + 3 < 8) && (x + 4 < 8) && (y + 4 < 8) &&
                    ((Casas[x + 3, y + 3].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y + 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y - 1 >= 0) && (x + 4 < 8) &&
                    ((Casas[x + 3, y - 1].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y - 1].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y - 3 >= 0) && (x + 4 < 8) && (y - 4 >= 0) &&
                    ((Casas[x + 3, y - 3].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y - 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
            }
            return movPossiveisDupla;
        }
        
        /// <summary>
        /// Alterna o jogador atual.
        /// </summary>
        /// <param name="jogador"></param>
        private void TrocarJogador(int jogador)
        {
            if (jogador == 1)
            {
                JogadorAtual = 2;
                return;
            }
            JogadorAtual = 1;
            return;
        }
        
        /// <summary>
        /// Verifica se a peça se torna Dama.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SerDama(int x, int y)
        {
            if (JogadorAtual == 1 && x == 0)
            {
                Casas[x, y] = new Peca(TipoPeca.DamaJogador1, x, y);
            }
            else if (JogadorAtual == 2 && x == 7)
            {
                Casas[x, y] = new Peca(TipoPeca.DamaJogador2, x, y);

            }

        }
        
        /// <summary>
        /// Executa a movimentação de uma peça no tabuleiro.
        /// Atualiza a posição da peça e lida com a remoção de peças adversárias capturadas.
        /// </summary>
        /// <param name="origemX">A coordenada X de origem da peça.</param>
        /// <param name="origemY">A coordenada Y de origem da peça.</param>
        /// <param name="destinoX">A coordenada X de destino da peça.</param>
        /// <param name="destinoY">A coordenada Y de destino da peça.</param>
        public bool MoverPeca(int origemX, int origemY, int destinoX, int destinhoY, int jogador)
        {
            Point destino = new Point(destinoX, destinhoY);
            List<Point> jogadasSimples;
            List<Point> jogadasCaptura;
            bool existeCapturaDupla;

            Debug.WriteLine("no movimentos os tipos eram estes"+ Casas[origemX, origemY].Tipo.ToString());
            Debug.WriteLine("no movimentos os tipos eram estes"+ Casas[destinoX, destinhoY].Tipo.ToString());


            if ((Casas[origemX, origemY].Tipo == TipoPeca.Jogador1) || (Casas[origemX, origemY].Tipo == TipoPeca.Jogador2))
            {
                jogadasSimples = VerificarMovimentosSimples(origemX, origemY, jogador);
                jogadasCaptura = VerificarMovimentosCaptura(origemX, origemY);
                existeCapturaDupla = VerificarCapturaDupla(origemX, origemY);
                if (jogadasCaptura.Count != 0 && jogadasCaptura.Contains(destino))
                {
                    Casas[destinoX, destinhoY] = Casas[origemX, origemY];
                    Casas[origemX, origemY] = new Peca(TipoPeca.Vazio, origemX, origemY);
                    SerDama(destinoX, destinhoY);
                    RetirarPeca(origemX, origemY, destinoX, destinhoY);
                    if (!existeCapturaDupla)
                    {
                        TrocarJogador(jogador);
                    }
                    return true;
                }
                else if (jogadasCaptura.Count == 0 && jogadasSimples.Contains(destino))
                {
                    Casas[destinoX, destinhoY] = Casas[origemX, origemY];
                    Casas[origemX, origemY] = new Peca(TipoPeca.Vazio, origemX, origemY);
                    SerDama(destinoX, destinhoY);
                    TrocarJogador(jogador);
                    return true;
                }
            }
            else if (Casas[origemX, origemY].Tipo == TipoPeca.DamaJogador1 || Casas[origemX, origemY].Tipo == TipoPeca.DamaJogador2)
            {
                {
                    jogadasSimples = VerificarMovimentosSimplesDama(origemX, origemY, jogador);
                    jogadasCaptura = VerificarMovimentosCapturaDama(origemX, origemY);
                    existeCapturaDupla = VerificarCapturaDuplaDama(origemX, origemY);
                    if (jogadasCaptura.Count != 0 && jogadasCaptura.Contains(destino))
                    {
                        Casas[destinoX, destinhoY] = Casas[origemX, origemY];
                        Casas[origemX, origemY] = new Peca(TipoPeca.Vazio, origemX, origemY);
                        SerDama(destinoX, destinhoY);
                        RetirarPeca(origemX, origemY, destinoX, destinhoY);
                        if (!existeCapturaDupla)
                        {
                            TrocarJogador(jogador);
                        }
                        return true;
                    }
                    else if (jogadasCaptura.Count == 0 && jogadasSimples.Contains(destino))
                    {
                        Casas[destinoX, destinhoY] = Casas[origemX, origemY];
                        Casas[origemX, origemY] = new Peca(TipoPeca.Vazio, origemX, origemY);
                        SerDama(destinoX, destinhoY);
                        TrocarJogador(jogador);
                        return true;
                    }
                }
            }


            return false;
        }
        
        /// <summary>
        /// Verifica os movimentos possíveis para uma peça Dama de um jogador.
        /// </summary>
        /// <param name="x">A coordenada X da peça.</param>
        /// <param name="y">A coordenada Y da peça.</param>
        /// <param name="jogador">O número do jogador (1 ou 2).</param>
        /// <returns>Uma lista de pontos representando os movimentos possíveis.</returns>
        public List<Point> VerificarMovimentosSimplesDama(int x, int y, int jogador)
        {
            List<Point> movPossiveisSimples = new List<Point>();

                if ((x + 1 < 8) && (y - 1 >= 0) && Casas[x + 1, y - 1].Tipo == TipoPeca.Vazio)
                    movPossiveisSimples.Add(new Point(x + 1, y - 1));

                if ((x + 1 < 8) && (y + 1 < 8) && Casas[x + 1, y + 1].Tipo == TipoPeca.Vazio)
                    movPossiveisSimples.Add(new Point(x + 1, y + 1));

                if ((x - 1 >= 0) && (y - 1 >= 0) && Casas[x - 1, y - 1].Tipo == TipoPeca.Vazio)
                    movPossiveisSimples.Add(new Point(x - 1, y - 1));

                if ((x - 1 >= 0) && (y + 1 < 8) && Casas[x - 1, y + 1].Tipo == TipoPeca.Vazio)
                    movPossiveisSimples.Add(new Point(x - 1, y + 1));

            return movPossiveisSimples;
        }
        
        /// <summary>
        /// Verifica os movimentos possíveis de captura para uma peça Dama.
        /// </summary>
        /// <param name="x">A coordenada X da peça.</param>
        /// <param name="y">A coordenada Y da peça.</param>
        /// <returns>Uma lista de pontos representando os movimentos de captura possíveis.</returns>
        public List<Point> VerificarMovimentosCapturaDama(int x, int y)
        {
            List<Point> movPossiveisCaptura = new List<Point>();
            if (JogadorAtual == 1)
            {
                if ((x + 2 < 8) && (y + 2 < 8) &&
                    ((Casas[x + 1, y + 1].Tipo == TipoPeca.Jogador2 || Casas[x + 1, y + 1].Tipo == TipoPeca.DamaJogador2)) &&
                    Casas[x + 2, y + 2].Tipo == TipoPeca.Vazio)
                    movPossiveisCaptura.Add(new Point(x + 2, y + 2));



                if ((x + 2 < 8) && (y - 2 >= 0) &&
                    (x + 1 < 8) && (y - 1 >= 0) &&
                    ((Casas[x + 1, y - 1].Tipo == TipoPeca.Jogador2 || Casas[x + 1, y - 1].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x + 2, y - 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x + 2, y - 2));

                if ((x - 2 >= 0) && (y + 2 < 8) &&
                    (x - 1 >= 0) && (y + 1 < 8) &&
                    ((Casas[x - 1, y + 1].Tipo == TipoPeca.Jogador2 || Casas[x - 1, y + 1].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x - 2, y + 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x - 2, y + 2));



                if ((x - 2 >= 0) && (y - 2 >= 0) &&
                     (x - 1 >= 0) && (y - 1 >= 0) &&
                     ((Casas[x - 1, y - 1].Tipo == TipoPeca.Jogador2 || Casas[x - 1, y - 1].Tipo == TipoPeca.DamaJogador2) &&
                     Casas[x - 2, y - 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x - 2, y - 2));

            }
            else
            {
                if ((x + 2 < 8) && (y + 2 < 8) &&
                    ((Casas[x + 1, y + 1].Tipo == TipoPeca.Jogador1 || Casas[x + 1, y + 1].Tipo == TipoPeca.DamaJogador1)) &&
                    Casas[x + 2, y + 2].Tipo == TipoPeca.Vazio)
                    movPossiveisCaptura.Add(new Point(x + 2, y + 2));



                if ((x + 2 < 8) && (y - 2 >= 0) &&
                    (x + 1 < 8) && (y - 1 >= 0) &&
                    ((Casas[x + 1, y - 1].Tipo == TipoPeca.Jogador1 || Casas[x + 1, y - 1].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 2, y - 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x + 2, y - 2));

                if ((x - 2 >= 0) && (y + 2 < 8) &&
                  (x - 1 >= 0) && (y + 1 < 8) &&
                  ((Casas[x - 1, y + 1].Tipo == TipoPeca.Jogador1 || Casas[x - 1, y + 1].Tipo == TipoPeca.DamaJogador1) &&
                  Casas[x - 2, y + 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x - 2, y + 2));



                if ((x - 2 >= 0) && (y - 2 >= 0) &&
                     (x - 1 >= 0) && (y - 1 >= 0) &&
                     ((Casas[x - 1, y - 1].Tipo == TipoPeca.Jogador1 || Casas[x - 1, y - 1].Tipo == TipoPeca.DamaJogador1) &&
                     Casas[x - 2, y - 2].Tipo == TipoPeca.Vazio))
                    movPossiveisCaptura.Add(new Point(x - 2, y - 2));


            }
            return movPossiveisCaptura;
        }
        
        /// <summary>
        /// Verifica se é possível realizar uma captura dupla com a peça Dama atual.
        /// </summary>
        /// <param name="x">A coordenada X da peça.</param>
        /// <param name="y">A coordenada Y da peça.</param>
        /// <returns>Retorna true se uma captura dupla for possível, caso contrário, retorna false.</returns>
        private bool VerificarCapturaDuplaDama(int x, int y)
        {
            bool movPossiveisDupla = false;
            if (JogadorAtual == 1)
            {
                if ((x + 3 < 8) && (y + 1 < 8) && (x + 4 < 8) &&
                    ((Casas[x + 3, y + 1].Tipo == TipoPeca.Jogador2 || Casas[x + 3, y + 1].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x + 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y + 3 < 8) && (x + 4 < 8) && (y + 4 < 8) &&
                    ((Casas[x + 3, y + 3].Tipo == TipoPeca.Jogador2 || Casas[x + 3, y + 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x + 4, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y - 1 >= 0) && (x + 4 < 8) &&
                    ((Casas[x + 3, y - 1].Tipo == TipoPeca.Jogador2 || Casas[x + 3, y - 1].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x + 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 1 < 8) && (y - 3 >= 0) && (x + 4 < 8) && (y - 4 >= 0) &&
                    ((Casas[x + 3, y - 3].Tipo == TipoPeca.Jogador2 || Casas[x + 3, y - 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x + 4, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x + 2 < 8) && (y + 3 < 8) && (x +1 < 8) && (y +4 <8) && 
                    ((Casas[x + 1, y + 3].Tipo == TipoPeca.Jogador2 || Casas[x + 1, y + 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x + 2 > 8) && (y - 3 > 0) && (x + 1 < 8) && (y - 4 > 0) &&
                    ((Casas[x + 1, y - 3].Tipo == TipoPeca.Jogador2 || Casas[x + 1, y - 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x - 2 >= 0) && (y + 3 < 8) && (x - 1 >= 0) && (y + 4 < 8) &&
                    ((Casas[x - 1, y + 3].Tipo == TipoPeca.Jogador2 || Casas[x - 1, y + 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x - 2 >= 0) && (y - 3 >= 0) && (x - 1 >= 0) && (y - 4 >= 0) &&
                    ((Casas[x - 1, y - 3].Tipo == TipoPeca.Jogador2 || Casas[x - 1, y - 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }



                if ((x - 3 >= 0) && (y + 1 < 8) &&
                            (x - 4 >= 0) &&
                            ((Casas[x - 3, y + 1].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y + 1].Tipo == TipoPeca.DamaJogador2) &&
                            Casas[x - 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y + 3 < 8) &&
                    (x - 4 >= 0) && (y + 4 < 8) &&
                    ((Casas[x - 3, y + 3].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y + 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x - 4, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y - 1 >= 0) &&
                    (x - 4 >= 0) &&
                    ((Casas[x - 3, y - 1].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y - 1].Tipo == TipoPeca.DamaJogador2)) &&
                    Casas[x - 4, y].Tipo == TipoPeca.Vazio)
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y - 3 >= 0) &&
                    (x - 4 >= 0) && (y - 4 >= 0) &&
                    ((Casas[x - 3, y - 3].Tipo == TipoPeca.Jogador2 || Casas[x - 3, y - 3].Tipo == TipoPeca.DamaJogador2) &&
                    Casas[x - 4, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
            }
            else
            {
                if ((x + 3 < 8) && (y + 1 < 8) && (x + 4 < 8) &&
                    ((Casas[x + 3, y + 1].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y + 1].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y + 3 < 8) && (x + 4 < 8) && (y + 4 < 8) &&
                    ((Casas[x + 3, y + 3].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y + 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y - 1 >= 0) && (x + 4 < 8) &&
                    ((Casas[x + 3, y - 1].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y - 1].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x + 3 < 8) && (y - 3 >= 0) && (x + 4 < 8) && (y - 4 >= 0) &&
                    ((Casas[x + 3, y - 3].Tipo == TipoPeca.Jogador1 || Casas[x + 3, y - 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x + 4, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }


                if ((x + 2 < 8) && (y + 3 < 8) && (x + 1 < 8) && (y + 4 < 8) &&
                    ((Casas[x + 1, y + 3].Tipo == TipoPeca.Jogador1 || Casas[x + 1, y + 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x + 2 < 8) && (y - 3 >= 0) && (x + 1 < 8) && (y - 4 >= 0) &&
                    ((Casas[x + 1, y - 3].Tipo == TipoPeca.Jogador1 || Casas[x + 1, y - 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x - 2 >= 0) && (y + 3 < 8) && (x - 1 >= 0) && (y + 4 < 8) &&
                    ((Casas[x - 1, y + 3].Tipo == TipoPeca.Jogador1 || Casas[x - 1, y + 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }

                if ((x - 2 >= 0) && (y - 3 >= 0) && (x - 1 >= 0) && (y - 4 >= 0) &&
                    ((Casas[x - 1, y - 3].Tipo == TipoPeca.Jogador1 || Casas[x - 1, y - 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }




                if ((x - 3 >= 0) && (y + 1 < 8) &&
                           (x - 4 >= 0) &&
                           ((Casas[x - 3, y + 1].Tipo == TipoPeca.Jogador1 || Casas[x - 3, y + 1].Tipo == TipoPeca.DamaJogador1) &&
                           Casas[x - 4, y].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y + 3 < 8) &&
                    (x - 4 >= 0) && (y + 4 < 8) &&
                    ((Casas[x - 3, y + 3].Tipo == TipoPeca.Jogador1 || Casas[x - 3, y + 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x - 4, y + 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y - 1 >= 0) &&
                    (x - 4 >= 0) &&
                    ((Casas[x - 3, y - 1].Tipo == TipoPeca.Jogador1 || Casas[x - 3, y - 1].Tipo == TipoPeca.DamaJogador1)) &&
                    Casas[x - 4, y].Tipo == TipoPeca.Vazio)
                {
                    movPossiveisDupla = true;
                }
                if ((x - 3 >= 0) && (y - 3 >= 0) &&
                    (x - 4 >= 0) && (y - 4 >= 0) &&
                    ((Casas[x - 3, y - 3].Tipo == TipoPeca.Jogador1 || Casas[x - 3, y - 3].Tipo == TipoPeca.DamaJogador1) &&
                    Casas[x - 4, y - 4].Tipo == TipoPeca.Vazio))
                {
                    movPossiveisDupla = true;
                }
            }
            return movPossiveisDupla;
        }
    }
}


