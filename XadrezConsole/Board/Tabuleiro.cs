using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Board.Exceptions;

namespace XadrezConsole.Board
{
    internal class Tabuleiro
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        
        private Peca[,] Pecas;

        public Tabuleiro()
        {
        }

        public Tabuleiro(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pecas = new Peca[Lines, Columns];
        }

        public Peca Peca(int line, int column)
        { 
            return Pecas[line, column];
        }

        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Line, pos.Column];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new BoardException("There's a piece on this position!");
            }
            Pecas[pos.Line, pos.Column] = p;
            p.Posicao = pos;
        }

        public bool PosicaoValida (Posicao pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }


}
