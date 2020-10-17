using System;

namespace DominnoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            /*Player player1 = new Player("P1");
            
            board.AddPlayer(player1);*/

            board.Play();
        }
    }
}
