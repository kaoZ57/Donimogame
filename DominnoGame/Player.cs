using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Player
    {
        public List<Domino> dominoslist;
        public string Name = "P1";  

        public Player()
        {
            //this.Name = name;
            dominoslist = new List<Domino>();
        }

        public void Show()
        { 
            Console.WriteLine(Name);
            foreach (var item in dominoslist)
            {
                Console.WriteLine(item);
            }
        }

        public void GetDomino(Domino domino)
        {
            dominoslist.Add(domino);
        }
        public int CountDomino()
        {
            return dominoslist.Count;
        }
    }
}
