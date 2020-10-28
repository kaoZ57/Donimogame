using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Player 
    {
        private readonly List<Domino> dominoslist;
        public string Name { get; private set; }
        public List<int> NumHeadDrop = new List<int>();
        public List<Domino> boardcheck = new List<Domino>();
        //public readonly Board board;
        //ConsoleKeyInfo chinput = Console.ReadKey();

        public List<Domino> Dominolisthand
        {
            get
            {
                return dominoslist;
            }
        }
    
        public Player(string name = "P1")
        {
            this.Name = name;
            dominoslist = new List<Domino>();
        }

        public void Show()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Player {0}", Name);
            for (int i = 0; i < dominoslist.Count; i++)
            {
                Console.Write("{0}{1} ", i + 1, dominoslist[i]);
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------");
        }

        public void ShowDomninoCheck()
        {
            foreach (var item in NumHeadDrop)
            {
                Console.Write("{0},", item);              
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
        public Domino SelectDomino()
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
            if (Selection_number > dominoslist.Count)
            {
                goto UP;
            }
            return dominoslist[Selection_number - 1];
        }

        public Domino DropDomino(Domino dropdomino)
        {
            //Domino dropdomino = domino;
            dominoslist.Remove(dropdomino);
            return dropdomino;
        }

        public Domino AILogic()
        {
            return dominoslist[0];
        }

        public void BoardCheck(Domino domino) 
        {
            boardcheck.Add(domino);
        }
        public void showboard()
        {
            foreach (var item in boardcheck)
            {
                Console.Write(item);
            }
        }

        public void CheckDomino()
        {
            for (int i = 0; i < dominoslist.Count; i++)
            {
                if (dominoslist[i].Side1 == boardcheck[boardcheck.Count].Side2)
                {
                    NumHeadDrop.Add(i);
                }            
                else if(i == dominoslist.Count)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            for (int i = 0; i < dominoslist.Count; i++)
            {
                if (dominoslist[i].Side2 == boardcheck[0].Side1)
                {
                    NumHeadDrop.Add(i);
                }
                else if(i == dominoslist.Count) 
                {
                    break;
                }
                else
                {
                    continue;
                }                
            }
        }
    }
}
