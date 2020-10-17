using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Player
    {
        public List<Domino> dominoslist;
        public string Name { get; private set; }

        public Player(string name = "P1")
        {
            this.Name = name;
            dominoslist = new List<Domino>();
        }

        public void Show()
        { 
            Console.WriteLine(Name);
            for (int i = 0; i < dominoslist.Count; i++)
            {
                Console.Write("{0}{1} ", i+1, dominoslist[i]);
            }
            Console.WriteLine("");
        }

        public void GetDomino(Domino domino)
        {
            dominoslist.Add(domino);
        }
        public int CountDomino()
        {
            return dominoslist.Count;
        }
        public int Connect_domino(int num)
        {
            Console.WriteLine(dominoslist[num-1]);
            return num;           
        }
    }
}
