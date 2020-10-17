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
            Console.WriteLine("------------------------------");
            Console.WriteLine("Playe {0}",Name);           
            for (int i = 0; i < dominoslist.Count; i++)
            {
                Console.Write("{0}{1} ", i+1, dominoslist[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
        }

        public void GetDomino(Domino domino)
        {
            dominoslist.Add(domino);
        }
        public int CountDomino()
        {
            return dominoslist.Count;
        }
      
        public void Select()
        {
            
        }

        public Domino Move_domino(int num)
        {
            //Console.WriteLine(dominoslist[num-1]);
            /*int Selection_number;

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
            }*/
            return dominoslist[num - 1];
        }
    } 
}
