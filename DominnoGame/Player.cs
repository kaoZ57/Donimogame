using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominnoGame
{
    class Player 
    {
        private readonly List<Domino> dominoslist;
        private string Name;
        private List<int> NumHeadDrop = new List<int>();
        private LinkedList<Domino> boardcheck = new LinkedList<Domino>();
        //public Board board;
        //ConsoleKeyInfo chinput = Console.ReadKey();
        public int NumHeadCount
        {
            get
            {
                return NumHeadDrop.Count;
            }
        }
        public LinkedList<Domino> Pboard
        {
            get
            {
                return boardcheck;
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
        public void GetDomino(Domino domino)
        {
            dominoslist.Add(domino);
        }
        public void ShowDomninoCheck()
        {
            List<int> NumHeadDropNew = NumHeadDrop.Distinct().ToList();
            Console.Write("NumHeadDrop = ");
            foreach (var item in NumHeadDropNew)
            {
                int sum = item + 1;
                Console.Write("{0} ", sum);              
            }
            Console.WriteLine("");
            Console.WriteLine("-----------------------");
        }
        public void showboard()
        {
            foreach (var item in boardcheck)
            {
                Console.Write(item);
            }
        }
        public int CountDomino()
        {
            return dominoslist.Count;
        }
        public Domino SelectDomino()
        {
            List<int> NumHeadDropNew = NumHeadDrop.Distinct().ToList();
            int Selection_number;      
        UP:
            foreach (var item in NumHeadDropNew)
            {
                Console.Write(item + 1);
            }
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
            if (Selection_number > dominoslist.Count || Selection_number < 1) 
            {
                goto UP;
            }
            foreach (var item in NumHeadDropNew)
            {
                if (item + 1 == Selection_number)
                {
                    goto Down;
                }
                else
                {
                    continue;
                }
            }
        Down:
            NumHeadDrop.Clear();
            //NumHeadDrop.RemoveAll(i => i == 0);
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
 

        public void CheckDomino()
        {
            for (int i = 0; i < dominoslist.Count; i++)
            {       
                if (dominoslist[i].Side1 == boardcheck.Last.Value.Side2)
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
                if (dominoslist[i].Side2 == boardcheck.First.Value.Side1)
                {
                    NumHeadDrop.Add(i);
                }
                else if (i == dominoslist.Count)
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
