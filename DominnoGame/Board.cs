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
                foreach (var P in players)
                {
                    P.GetDomino(deck.Deal());
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
                players[0].Show();
                Console.Write("NumHeadDrop = ");
                players[0].ShowDomninoCheck();
                Console.WriteLine("");
                Console.WriteLine("-----------------------");
                Connect_domino();
                Round =+ 1;
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
                Domino domino = players[0].SelectDomino();
                board.AddLast(players[0].DropDomino(domino));
                players[0].BoardCheck(domino);
                players[0].CheckDomino();
                /*Domino D = dealer.AILogic();
                board.Add(dealer.DropDomino(D));*/
            }
            else
            {
            Up:
                Console.WriteLine(players[0].NumHeadDrop.Count);
                if (players[0].NumHeadDrop.Count == 0)
                {
                    players[0].GetDomino(deck.Deal());
                    players[0].CheckDomino();
                    goto Up;
                }
                else
                {
                    Domino domino = players[0].SelectDomino();
                    players[0].DropDomino(domino);
                    if (domino.Side2 == board.First.Value.Side1)
                    {
                        board.AddFirst(domino);
                    }
                    else
                    {
                        board.AddLast(players[0].DropDomino(domino));
                    }
                    players[0].BoardCheck(domino);
                    players[0].CheckDomino();          
                }
                /*
            Up:
                Console.Write("GetDonimo? (y/n): ");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "y":
                        players[0].GetDomino(deck.Deal());
                        players[0].CheckDomino();
                        break;
                    case "n":
                        Domino domino = players[0].SelectDomino();
                        if (domino.Side2 == board.First.Value.Side1)
                        {
                            board.AddFirst(domino);
                        }
                        else
                        {
                            board.AddLast(players[0].DropDomino(domino));
                        }
                        players[0].BoardCheck(domino);
                        players[0].CheckDomino();
                        /*Domino D = dealer.AILogic();
                        board.Add(dealer.DropDomino(D));*
                        break;
                    default:
                        goto Up;
                } */
            }
        }

        public void result()
        {
            Console.WriteLine("End");
        }
    }
}
    