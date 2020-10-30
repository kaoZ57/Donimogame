using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominnoGame
{
    class Board 
    {
        private List<Player> players; 
        private LinkedList<Domino> board = new LinkedList<Domino>();
        private readonly Player dealer;
        private Deck deck = new Deck();
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
            /*int Roundgame = 0;
        start:
            if (Roundgame > 0)
            {
                Clear();
                Roundgame = Roundgame + 1;
            }*/
            initialCard();
            battle();
            result();
            /*Console.WriteLine("Play the next round? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                goto start;
            }*/
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
            for (int x = 0; x <= 28; x++)
            {
                if (deck.Count == 0)
                {
                    break;
                }
                for (int i = 0; i < players.Count; i++)
                {     
                    Console.Clear();
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
                    //players[0].showboard();
                    players[i].Show();
                    //players[i].ShowDomninoCheck();
                    Connect_domino(players[i], i);
                    Round = Round + 1;
                    if (deck.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        public void Connect_domino(Player player,int num)
        {
        UP1:
            if (Round == 1)
            {
                Domino domino = player.SelectDomino();
                board.AddLast(player.DropDomino(domino));
                player.Pboard.AddFirst(domino);
                players[num + 1].Pboard.AddFirst(domino);
                player.CheckDomino();
                players[num + 1].CheckDomino();
                /*Domino D = dealer.AILogic();
                board.Add(dealer.DropDomino(D));*/
            }
            else if (player.NumHeadCount == 0)
            {
                player.GetDomino(deck.Deal());
                player.CheckDomino();                
                goto UP1;
            }
            else
            {
            Up:
                players[num].ShowDomninoCheck();
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
                            if (players.Count != num + 1)
                            {
                                players[num + 1].Pboard.AddFirst(domino);
                            }                       
                        }
                        else
                        {
                            board.AddLast(domino);
                            if(players.Count != num + 1)
                            {
                                players[num + 1].Pboard.AddLast(domino);
                            }      
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
        public void result()
        {
            Console.Clear();
            List<int> Score = new List<int>();
            foreach (var player in players)
            {
                for (int i = 0; i < player.Dominoslist.Count; i++)
                {
                    int score = player.Dominoslist[i].Side1 + player.Dominoslist[i].Side2;
                    player.Addscore(score);
                }
                Score.Add(player.Score);
            }
            Console.WriteLine("--------------------------");
            foreach (var player in players)
            {
                Console.WriteLine("{0} has {1} Score", player.Name, player.Score);
            }
            for (int i = 0; i <= players.Count - 1; i++)
            {
                if (players[i].Score == Score.Max())
                {
                    Win(players[i]);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("--------------------------");
        }
        public void Win(Player player)
        {
            Console.WriteLine("Player {0} is win", player.Name);
        }
        public void Lose(Player player)
        {
            Console.WriteLine("Player {0} is lose", player.Name);
        }
        public void Tie(Player player)
        {
            Console.WriteLine("Player {0} is tie", player.Name);
        }


        public void Clear()
        {
            board.Clear();
            Round = 1;
            deck.Count = 28;
            foreach (var player in players)
            {
                player.Clear();
            }
        }
    }
}
    