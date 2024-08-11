using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.ChessGame
{
    internal class Rook : Peca
    {
        public Rook(Cor color, Tabuleiro tab) : base(color, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Tab.Rows, Tab.Columns];
            Posicao pos = new Posicao(0, 0);

            //Upper
            pos.SetValues(Posicao.Row - 1, Posicao.Column);

            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row - 1;
            }

            //lower

            pos.SetValues(Posicao.Row + 1, Posicao.Column);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.Row = pos.Row + 1;
            }

            //Right

            pos.SetValues(Posicao.Row, Posicao.Column + 1);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //left 

            pos.SetValues(Posicao.Row, Posicao.Column - 1);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;

        }
    }
}
