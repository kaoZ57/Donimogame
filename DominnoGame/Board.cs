using System;
using System.Collections;
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
            initialCard();
            //battle();
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
            Connect_domino();
            foreach (var d in board)
            {
                Console.Write("Board| ");
                Console.Write(d);
                Console.Write(" |");
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
            board.Add(player.Move_domino(Selection_number));
        }

        public void ChaeckDeck()
        {
            //Console.WriteLine(deck.CountDominoDeck());      
            if (deck.CountDominoDeck() == 0)
            {
                result();
            }          
        }
        public void result()
        {

        }
    }
}
