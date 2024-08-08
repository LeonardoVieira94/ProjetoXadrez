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
    internal class Bishop : Peca
    {
        public Bishop(Cor color, Tabuleiro tab) : base(color, tab)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Tab.Rows, Tab.Columns];

            Posicao pos = new Posicao(0, 0);

            // NO
            pos.SetValues(Posicao.Row - 1, Posicao.Column - 1);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row - 1, pos.Column - 1);
            }

            // NE
            pos.SetValues(Posicao.Row - 1, Posicao.Column + 1);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row - 1, pos.Column + 1);
            }

            // SE
            pos.SetValues(Posicao.Row + 1, Posicao.Column + 1);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row + 1, pos.Column + 1);
            }

            // SO
            pos.SetValues(Posicao.Row + 1, Posicao.Column - 1);
            while (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Color != Color)
                {
                    break;
                }
                pos.SetValues(pos.Row + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
