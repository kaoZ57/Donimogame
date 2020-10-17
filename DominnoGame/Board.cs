using System;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Board
    {
        private readonly List<Player> players;
        private readonly List<Domino> board;
        Player player = new Player();
        Deck deck = new Deck();
        //ConsoleKeyInfo chinput = Console.ReadKey();
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void Play()
        {

            /*for (int i = 0; i < 28; i++)
            {
                Console.Write(i+1);
                Console.WriteLine(deck.Deal());
            }*/


            /*for (int i = 0; i < 28; i++)
            {
                Domino domino = new Domino(i);
                Console.Write(i+1);
                Console.WriteLine(domino);
            }*/

            /*Player player = new Player();

            player.GetDomino(deck.Deal());
            player.GetDomino(deck.Deal());          
            player.Show();*/

            initialCard();
            battle();
        }
        private void initialCard()
        {
            for (int i = 0; i < 5; i++)
            {
                player.GetDomino(deck.Deal());               
            }
            player.Show();
        }    

        public void battle()
        {
            int Selection_number;          

        UP:
            Console.Write("SelectionDomino = ");
            string InputNum = Console.ReadLine();
            try
            {
                Selection_number = Int32.Parse(InputNum);
            }
            catch (Exception)
            {
                goto UP;
            }
            player.Connect_domino(Selection_number);
        }      
    }
}
