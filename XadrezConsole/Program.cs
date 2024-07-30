using XadrezConsole.Board;
using XadrezConsole.Board.Enums;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            
            Posicao p;

            Screen.PrintBoard(tab);

        }
    }
}