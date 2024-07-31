using XadrezConsole.Board;
using XadrezConsole.Board.Enums;
using XadrezConsole.Board.Exceptions;
using XadrezConsole.ChessGame;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.ColocarPeca(new Tower(Cor.Black, tab), new Posicao(0, 0));
                tab.ColocarPeca(new Tower(Cor.Black, tab), new Posicao(1, 3));
                tab.ColocarPeca(new King(Cor.Black, tab), new Posicao(2, 4));
                tab.ColocarPeca(new King(Cor.White, tab), new Posicao(3, 5));

                Screen.PrintBoard(tab);

                ChessPosition piece = new ChessPosition('c', 7);

                Console.WriteLine(piece);

                Console.WriteLine(piece.ToPosition());
            }

            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}