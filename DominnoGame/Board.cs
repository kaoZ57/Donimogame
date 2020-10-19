using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Board
    {
        private readonly List<Player> players;
        private List<Domino> board = new List<Domino>();
        Player player = new Player();
        Deck deck = new Deck();
        int _CountDominoDeck = 28;
        int Round = 1;
        //ConsoleKeyInfo chinput = Console.ReadKey();
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void Play()
        {
            initialCard();
            battle();
        }
        private void initialCard()
        {
            for (int i = 0; i < 5; i++)
            {
                player.GetDomino(deck.Deal());
                _CountDominoDeck -= 1;
            }
        }    

        public void battle()
        {
        UP:
            Console.Clear();
            
            if (_CountDominoDeck == 0)
            {
                result();
            }
            else
            {
                Console.WriteLine("***********************");
                Console.WriteLine("| Number of domino {0} |", _CountDominoDeck);
                Console.WriteLine("***********************");
                Console.Write("Board|");
                foreach (var d in board)
                {
                    Console.Write(d);
                    Console.Write("|");
                }
                Console.WriteLine("");
                player.Show();
                Connect_domino();               
                goto UP;
            }           
        }

        public void Connect_domino()
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
            if(Selection_number > player.dominoslist.Count)
            {
                goto UP;
            }

            if(Round == 1)
            {
                board.Add(player.Move_domino(Selection_number));
            }
            else
            {
                //player.dominoslist[Selection_number - 1];
                board.Add(player.Move_domino(Selection_number));
            }
        }
      
        public void result()
        {
            Console.WriteLine("End");
        }
    }
}
