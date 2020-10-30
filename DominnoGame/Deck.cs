using System;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
	class Deck
	{
		private Domino[] dominos;
		private int nextDomino;
		private Random random;

		public int Count
		{
			get
			{
				return nextDomino;
			}
			set 
			{								
			}
		}

		public Deck()
		{
			random = new Random();
			dominos = new Domino[28];
			Initialize();

			/*foreach (var item in Dominos)
            {
                Console.WriteLine(item);
            }*/
		}

		public void Initialize()
		{
			for (int i = 0; i < dominos.Length; i++)
			{
				dominos[i] = new Domino(i);
			}
			nextDomino = dominos.Length;
			Shuffle();
		}

		void Shuffle(int times = 60)
		{
			int j, k;
			Domino holder;
			for (int i = 0; i < times; i++)
			{
				j = random.Next(dominos.Length);
				holder = dominos[j];
				k = random.Next(dominos.Length);
				dominos[j] = dominos[k];
				dominos[k] = holder;
			}
		}
		public int CountDominoDeck()
		{
			return dominos.Length;
		}

		public Domino Deal()
		{
			nextDomino--; // nextCard = nextCard - 1;
			return dominos[nextDomino];
		}
	}
}
