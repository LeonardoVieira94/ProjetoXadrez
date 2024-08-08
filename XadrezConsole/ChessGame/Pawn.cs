using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.ChessGame
{
    internal class Pawn : Peca
    {
        private ChessMatch Match;
        public Pawn(Cor color, Tabuleiro Tab, ChessMatch match) : base(color, Tab)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool CanMove(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Color != this.Color;
        }

        private bool RivalPiece(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Color != Color;
        }

        private bool livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Tab.Rows, Tab.Columns];

            Posicao pos = new Posicao(0, 0);

            if (Color == Cor.White)
            {
                pos.SetValues(Posicao.Row - 1, Posicao.Column);
                if (Tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Posicao.Row - 2, Posicao.Column);
                Posicao p2 = new Posicao(Posicao.Row - 1, Posicao.Column);
                if (Tab.PosicaoValida(p2) && livre(p2) && Tab.PosicaoValida(pos) && livre(pos) && NumMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Posicao.Row - 1, Posicao.Column - 1);
                if (Tab.PosicaoValida(pos) && RivalPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Posicao.Row - 1, Posicao.Column + 1);
                if (Tab.PosicaoValida(pos) && RivalPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // #jogadaespecial en passant
                /* if (Posicao.Row == 3)
                 {
                     Posicao esquerda = new Posicao(Posicao.Row, Posicao.Column - 1);
                     if (Tab.PosicaoValida(esquerda) && RivalPiece(esquerda) && Tab.Peca(esquerda) == Match.vulneravelEnPassant)
                     {
                         mat[esquerda.Row - 1, esquerda.Column] = true;
                     }
                     Posicao direita = new Posicao(Posicao.Row, Posicao.Column + 1);
                     if (Tab.PosicaoValida(direita) && RivalPiece(direita) && Tab.Peca(direita) == Match.vulneravelEnPassant)
                     {
                         mat[direita.Row - 1, direita.Column] = true;
                     }
                 }
             }*/
            }
            else
            {

                pos.SetValues(Posicao.Row + 1, Posicao.Column);
                if (Tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Posicao.Row + 2, Posicao.Column);
                Posicao p2 = new Posicao(Posicao.Row + 1, Posicao.Column);
                if (Tab.PosicaoValida(p2) && livre(p2) && Tab.PosicaoValida(pos) && livre(pos) && NumMovements == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Posicao.Row + 1, Posicao.Column - 1);
                if (Tab.PosicaoValida(pos) && RivalPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Posicao.Row + 1, Posicao.Column + 1);
                if (Tab.PosicaoValida(pos) && RivalPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // #jogadaespecial en passant
                /* if (Posicao.Row == 4)
                 {
                     Posicao esquerda = new Posicao(Posicao.Row, Posicao.Column - 1);
                     if (Tab.PosicaoValida(esquerda) && RivalPiece(esquerda) && Tab.Peca(esquerda) == Match.vulneravelEnPassant)
                     {
                         mat[esquerda.Row + 1, esquerda.Column] = true;
                     }
                     Posicao direita = new Posicao(Posicao.Row, Posicao.Column + 1);
                     if (Tab.PosicaoValida(direita) && RivalPiece(direita) && Tab.Peca(direita) == Match.vulneravelEnPassant)
                     {
                         mat[direita.Row + 1, direita.Column] = true;
                     }
                 }*/
            }

            return mat;
        }                    

    }
}
