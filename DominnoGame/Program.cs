using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Board board = new Board();

            /*Console.Write("Enter Name Here = ");
            string addname = Console.ReadLine();*/

            Board board = new Board("dealer");
            board.AddPlayer(new Player("P1"));

            board.Play();

            //testDropDomono();
            //testCheck();      
            //testLinkedList();
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
        static void testCheck()
        {
            List<Domino> list = new List<Domino>();
            for (int i = 0; i <= 4; i++)
            {
                Domino domino = new Domino(i);
                list.Add(domino);
            }
            
            foreach (var item in list)
            {
                Console.Write(item.Side1);
                Console.Write(item.Side2);
                Console.WriteLine("");
            }
            Console.WriteLine("----------");

            int aws = list[3].Side2 + list[4].Side2;    
            Console.WriteLine(aws);

            if (list[4].Side2 == list[list.Count-1].Side2)
            {
                Console.WriteLine("win");
            }
            else
            {
                Console.WriteLine("end");
            }

            /*if(list[0].Side2 == list[list.Count].Side1)
            {
                Console.WriteLine("win");
            }
            else
            {
                Console.WriteLine("end");
            }*/
        }
        static void testLinkedList()
        {
           LinkedList<Domino> list = new LinkedList<Domino>();
            for (int i = 0; i <= 4; i++)
            {
                Domino domino = new Domino(i);
                list.AddLast(domino);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
