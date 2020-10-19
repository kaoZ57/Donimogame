using System;
using System.Collections.Generic;
using System.Text;

namespace DominnoGame
{
    class Domino
    {
        private readonly int side1, side2; 

        public Domino(int num)
        {
            if(num > 27)
            {
                ToString();
            }
            else if (num > 26)
            {
                side1 = 6;
                side2 = 6;
            }
            else if(num > 24)
            {
                side1 = 5;
                side2 = num - 20;
            }
            else if (num > 21)
            {
                side1 = 4;
                side2 = num - 18;

            }
            else if (num > 17)
            {
                side1 = 3;
                side2 = num - 15;

            }
            else if (num > 12)
            {
                side1 = 2;
                side2 = num - 11;

            }
            else if (num > 6)
            {
                side1 = 1;
                side2 = num - 6;

            }
            else
            {
                side1 = 0;
                side2 = num;
            }
        }
        public override string ToString()
        {
            string text = "__";
            string text1;
            string text2;

            text1 = side1.ToString();
            text2 = side2.ToString();

            text = "["+text1+"|"+text2+"]";

            return text;
        }
    }
}
