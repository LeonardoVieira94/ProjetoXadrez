using XadrezConsole.Board;
using XadrezConsole.Board.Enums;
using XadrezConsole.ChessGame;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);

            tab.ColocarPeca(new Tower(Cor.Black, tab), new Posicao(0, 0));
            tab.ColocarPeca(new Tower(Cor.Black, tab), new Posicao(1, 3));
            tab.ColocarPeca(new King(Cor.Black, tab), new Posicao(2, 4));

            Screen.PrintBoard(tab);

        }
    }
}