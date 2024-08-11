using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.ChessGame
{
    internal class King : Peca
    {
        ChessMatch Match;
        public King(Cor color, Tabuleiro tab, ChessMatch match) : base(color, tab)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Color != Color;
        }

        private bool CastlingTest(Posicao pos) 
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Rook && p.Color == Color && p.NumMovements == 0;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Tab.Rows, Tab.Columns];
            Posicao pos = new Posicao(0, 0);

            //Upper
            pos.SetValues(Posicao.Row - 1, Posicao.Column);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //NE
            pos.SetValues(Posicao.Row - 1, Posicao.Column + 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //right
            pos.SetValues(Posicao.Row, Posicao.Column + 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //SE
            pos.SetValues(Posicao.Row + 1, Posicao.Column + 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //lower
            pos.SetValues(Posicao.Row + 1, Posicao.Column);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            // So
            pos.SetValues(Posicao.Row + 1, Posicao.Column - 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //left 
            pos.SetValues(Posicao.Row, Posicao.Column - 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //NO
            pos.SetValues(Posicao.Row - 1, Posicao.Column - 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            //Special Movement

            if (NumMovements == 0 && !Match.Check)
            {
                //Small Castling
                Posicao posRook1 = new Posicao(Posicao.Row, Posicao.Column + 3);
                if (CastlingTest(posRook1))
                {
                    Posicao p1 = new Posicao(Posicao.Row, Posicao.Column + 1);
                    Posicao p2 = new Posicao(Posicao.Row, Posicao.Column + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null)
                    {
                        mat[Posicao.Row, Posicao.Column + 2] = true;
                    }
                }

                //Bigger Castling
                Posicao posRook2 = new Posicao(Posicao.Row, Posicao.Column - 4);
                if (CastlingTest(posRook2))
                {
                    Posicao p1 = new Posicao(Posicao.Row, Posicao.Column - 1);
                    Posicao p2 = new Posicao(Posicao.Row, Posicao.Column - 2);
                    Posicao p3 = new Posicao(Posicao.Row, Posicao.Column - 3);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Posicao.Row, Posicao.Column - 2] = true;
                    }
                }
                
            }
            return mat;
        }
    }
}
