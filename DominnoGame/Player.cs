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
        ConsoleKeyInfo chinput = Console.ReadKey();

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

        public int CheckDomino()
        {
            foreach (var d in dominoslist)
            {
                Console.WriteLine(d);
                //FirstCheckHand();             
            }
            return 1;
        }
    }
}
