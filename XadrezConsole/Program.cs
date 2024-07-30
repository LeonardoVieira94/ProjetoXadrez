using XadrezConsole.Board;
using XadrezConsole.Tabuleiro.Enums;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            
            Posicao p;

            p = new Posicao(3, 4);

            Console.WriteLine($"Posição: {p}");

            Console.ReadLine();

        }
    }
}