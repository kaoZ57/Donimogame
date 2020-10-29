using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Board 
    { 
        public List<Player> players;
        private LinkedList<Domino> board = new LinkedList<Domino>();
        private readonly Player dealer;
        Deck deck = new Deck();
        private int Round = 1;
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
                foreach (var player in players)
                {
                    player.GetDomino(deck.Deal());
                }
                //dealer.GetDomino(deck.Deal());
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
                players[0].showboard();
                players[0].Show();
                players[0].ShowDomninoCheck();
                Connect_domino();
                Round = Round + 1;
                goto UP;
            }
        }

        public void Connect_domino()
        {
            foreach (var player in players)
            {
                if (Round == 1)
                {
                    Domino domino = player.SelectDomino();
                    board.AddLast(player.DropDomino(domino));
                    player.Pboard.AddFirst(domino);
                    player.CheckDomino();
                    /*Domino D = dealer.AILogic();
                    board.Add(dealer.DropDomino(D));*/
                }
                else if (player.NumHeadCount == 0)
                {
                    player.GetDomino(deck.Deal());
                    player.CheckDomino();
                }
                else
                {
                Up:
                    Console.Write("GetDonimo? (y/n): ");
                    string input = Console.ReadLine().ToLower();
                    switch (input)
                    {
                        case "y":
                            player.GetDomino(deck.Deal());
                            player.CheckDomino();
                            break;
                        case "n":
                            Domino domino = player.SelectDomino();
                            player.DropDomino(domino);
                            if (domino.Side2 == board.First.Value.Side1)
                            {
                                board.AddFirst(domino);
                                player.Pboard.AddFirst(domino);
                            }
                            else
                            {
                                board.AddLast(domino);
                                player.Pboard.AddLast(domino);
                            }
                            player.CheckDomino();
                            /*Domino D = dealer.AILogic();
                            board.Add(dealer.DropDomino(D));*/
                            break;
                        default:
                            goto Up;
                    }
                }
            } 
        }

        public void result()
        {
            Console.WriteLine("End");
        }
    }
}
    