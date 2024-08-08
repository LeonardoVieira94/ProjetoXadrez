using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole.ChessGame
{
    internal class Horse : Peca
    {
        public Horse(Cor color, Tabuleiro Tab) : base(color, Tab)
        {
        }

        public override string ToString()
        {
            return "H";
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

            pos.SetValues(Posicao.Row - 1, Posicao.Column - 2);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row - 2, Posicao.Column - 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row - 2, Posicao.Column + 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row - 1, Posicao.Column + 2);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row + 1, Posicao.Column + 2);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row + 2, Posicao.Column + 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row + 2, Posicao.Column - 1);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }
            pos.SetValues(Posicao.Row + 1, Posicao.Column - 2);
            if (Tab.PosicaoValida(pos) && CanMove(pos))
            {
                mat[pos.Row, pos.Column] = true;
            }

            return mat;
        }
    }
}
