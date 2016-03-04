using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int[,] arr = new int[20, 20];



            //Add some random values to the array 
            //Random R = new Random();
            //for (int i = 0; i < 50; i++)
            //{
            //    int x = R.Next(20);
            //    int y = R.Next(20);
            //    arr[x, y] = 1;


            //}
            arr = game.RandomBinary();
            var now = DateTime.Now;
            while (true)

                while (now < DateTime.Now)
                {
                    now = DateTime.Now.AddMilliseconds(400);
                    Console.Clear();
                    game.PrintGame(arr);
                    arr = game.ProcessGame(arr);
                }
        }
    }
}
