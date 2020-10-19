using System;

namespace DominnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Board board = new Board();

            /*Console.Write("Enter Name Here = ");
            string addname = Console.ReadLine();
        
            Player player1 = new Player(addname);       
            board.AddPlayer(player1);*/

            board.Play();

            Console.ReadKey();
        }
    }
}
