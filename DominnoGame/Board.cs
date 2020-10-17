using System;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Board
    {
        private readonly List<Player> players;
        Player player = new Player();
        Deck deck = new Deck();
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

            Gameplay();
        }
        public void Gameplay()
        {           
            for (int i = 0; i < 5; i++)
            {
                player.GetDomino(deck.Deal());
            }
            player.Show();
        }
    }
}
