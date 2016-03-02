using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        int[,] generation;
        int[,] lastGeneration;


        public int CountNeighbors { get; set; }
        public int GenerationCount { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Game()
        {
            this.generation = new int[20, 20];
            this.lastGeneration = new int[20, 20];
            this.GenerationCount = 1;
        }

        public void PrintGame(int[,] Board)
        {
            int Row;
            int Column;
            generation = (int[,])Board.Clone();
            lastGeneration = new int[generation.GetLength(0), generation.GetLength(1)];

            Console.Clear();
            Console.WriteLine("\t\t--+-------------------------------------------------------------------------------+-");
            Console.WriteLine("\t\t--+-------------------------------Game of Life------------------------------------+-");
            Console.WriteLine("\t\t--+-------------------------------------------------------------------------------+-");
            Console.WriteLine("\t\t  ¦ 0 ¦ 1 ¦ 2 ¦ 3 ¦ 4 ¦ 5 ¦ 6 ¦ 7 ¦ 8 ¦ 9 ¦ 10¦ 11¦ 12¦ 13¦ 14¦ 15¦ 16¦ 17¦ 18¦ 19¦");
            Console.WriteLine("\t\t--+-------------------------------------------------------------------------------+-");
            for (Row = 0; Row <= 19; Row++)
            {

                {
                    Console.Write("\t\t   ");
                }

                //Console.Write("\t\t\t " + (Row).ToString() + "¦");
                for (Column = 0; Column <= 19; Column++)
                {

                    //Console.Write(Board[Row, Column]);
                    if (Board[Row, Column] == 1)
                    {

                        Console.Write($" O  ");
                    }
                    else if (Board[Row, Column] == 0)//check if it works with only "else"
                    {
                        Console.Write("    ");
                    }



                }

                Console.WriteLine();
            }
            Console.WriteLine("\t\t--+-------------------------------------------------------------------------------+-");
            Console.WriteLine($"\t\tGeneration: {GenerationCount}");


            Console.WriteLine("\n");
        }
        public int GetNeighbours(int x, int y)
        {

            int count = 0;
            // Check for x - 1, y - 1
            if (x > 0 && y > 0) { if (generation[y - 1, x - 1] == 1) { count++; } }
            // Check for x, y - 1
            if (y > 0) { if (generation[y - 1, x] == 1) { count++; } }
            // Check for x + 1, y - 1
            if (x < generation.GetLength(1) - 1 && y > 0) { if (generation[y - 1, x + 1] == 1) { count++; } }
            // Check for x - 1, y
            if (x > 0) { if (generation[y, x - 1] == 1) { count++; } }
            // Check for x + 1, y
            if (x < generation.GetLength(1) - 1) { if (generation[y, x + 1] == 1) { count++; } }
            // Check for x - 1, y + 1
            if (x > 0 && y < generation.GetLength(0) - 1) { if (generation[y + 1, x - 1] == 1) { count++; } }
            // Check for x, y + 1
            if (y < generation.GetLength(0) - 1) { if (generation[y + 1, x] == 1) { count++; } }
            // Check for x + 1, y + 1
            if (x < generation.GetLength(1) - 1 && y < generation.GetLength(0) - 1) { if (generation[y + 1, x + 1] == 1) { count++; } }
            return count;



            


        }
        public int[,] RandomBinary()
        {
            Random r = new Random();
            int[,] grid = new int[20, 20];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {

                    grid[x, y] = r.Next(0, 2);


                }
            }
            return grid;
        }
        public void PrintNeighbours()
        {
            for (int x = 0; x < generation.GetLength(0); x++)
            {
                for (int y = 0; y < generation.GetLength(1); y++)
                {
                    Console.Write($"{GetNeighbours(x, y)}");
                }
            }
        }


        public int[,] ProcessGame(int[,] board)
        {
            int[,] nextGeneration = new int[generation.GetLength(0), generation.GetLength(1)];
            lastGeneration = (int[,])generation.Clone();
            this.GenerationCount++;

            for (int x = 0; x < generation.GetLength(0); x++)
            {
                for (int y = 0; y < generation.GetLength(1); y++)
                {
                    if (generation[x, y] == 0 && GetNeighbours(x, y) == 3)
                    {
                        nextGeneration[x, y] = 1;
                    }
                    if (generation[x, y] == 1 && (GetNeighbours(x, y) == 2 || GetNeighbours(x, y) == 3))
                    {
                        nextGeneration[x, y] = 1;
                    }
                    if (generation[y, x] == 1 && (GetNeighbours(x, y) > 3))
                    {
                        nextGeneration[x, y] = 0;
                    }
                }
            }
            return generation = (int[,])nextGeneration.Clone();

            

        }

    }


}
