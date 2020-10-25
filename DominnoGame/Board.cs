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
        Deck deck = new Deck();
        private Player dealer;
        int Round = 1;
        //ConsoleKeyInfo chinput = Console.ReadKey();

        public Board(string dealerName)
        {
            this.dealer = new Player(dealerName);
            players = new List<Player>();

        }
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
                foreach (var P in players)
                {
                    P.GetDomino(deck.Deal());
                }
                dealer.GetDomino(deck.Deal());
            }
        }

        public void battle()
        {
        UP:
            Console.Clear();

            if (deck.Count == 0)
            {
                result();
            }
            else
            {
                Console.WriteLine("***********************");
                Console.WriteLine("| Round {0}             |", Round);
                Console.WriteLine("| Number of domino {0} |", deck.Count);
                Console.WriteLine("***********************");
                Console.Write("Board|");
                foreach (var d in board)
                {
                    Console.Write(d);
                    Console.Write("|");
                }
                Console.WriteLine("");
               

                players[0].Show();

                /*foreach (var P in players)
                {
                    P.Show();
                }*/
                Connect_domino();
                Round = Round + 1;
                goto UP;
            }
        }

        public void Connect_domino()
        {
        /*foreach (var P in players)
        {
            Domino d = P.SelectDomino();
            board.Add(P.DropDomino(d));
        }*/
        if (Round == 1)
            {
                Domino d = players[0].SelectDomino();
                board.Add(players[0].DropDomino(d));

                Domino D = dealer.AILogic();
                board.Add(dealer.DropDomino(D));
            }
        else
            {
            Up:
                Console.Write("GetDonimo? (y/n): ");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        players[0].GetDomino(deck.Deal());
                        break;
                    case "n":
                        Domino d = players[0].SelectDomino();
                        board.Add(players[0].DropDomino(d));

                        Domino D = dealer.AILogic();
                        board.Add(dealer.DropDomino(D));
                        break;
                    default:
                        goto Up;
                }
            }      
        }

        public void result()
        {
            Console.WriteLine("End");
        }

        public Domino FirstCheckHand()
        {
            return board[0];
        }
        public Domino LastCheckHand()
        {
            return board[board.Count];
        }
    }
}
