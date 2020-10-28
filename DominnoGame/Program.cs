using System;

namespace DominnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Board board = new Board("dealer");
            //Board board = new Board();

            /*Console.Write("Enter Name Here = ");
            string addname = Console.ReadLine();

            board.AddPlayer(new Player("P1"));*/

            board.Play();

            //testDropDomono();
            Console.ReadKey();
        }

        static void testDropDomono()
        {
            Player p = new Player("A");
            Deck deck = new Deck();
            p.GetDomino(deck.Deal());
            p.GetDomino(deck.Deal());
            p.GetDomino(deck.Deal());

            p.Show();

            Domino d = p.SelectDomino();

            Console.WriteLine(d.ToString());

            p.DropDomino(d);
            p.Show();
        }
    }
}
