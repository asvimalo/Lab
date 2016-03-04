using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoLaVida
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new bool[25,50];
            var g = new Game();
            var lf = new LifeColors();
            var now = DateTime.Now;
            grid = g.GenerateRandomMatrix();

            while (true)
            {
                while (now < DateTime.Now)
                {
                    //Control speed frequency
                    now = DateTime.Now.AddMilliseconds(400);
                    Console.Clear();
                    //print matrix
                    g.Print();
                    lf.PrintColored(grid);
                    //generate next generation
                    grid = g.GoNextState();
                    g.Print();
                    Console.ReadKey();
                }
            }
        }


    }
}

