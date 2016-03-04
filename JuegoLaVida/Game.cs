using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoLaVida
{
    class Game
    {
        //Field
        private const int sizeX = 25;
        private const int sizeY = 50;



        // Fields
        //First empty matrix
        private bool[,] matrix = new bool[sizeX, sizeY];



        // Constructor
        //Generates a true or false through empty matrix(20% ==> Can modify at the method we are calling)
        public Game()
        {
            
        }



        // Methods

        public bool[,] GoNextState()
        {
            bool[,] newMatrix = new bool[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    newMatrix[x, y] = this.GetNext(x, y);

            return this.matrix = newMatrix;
        }
        /// <summary>
        /// Print new matrix
        /// </summary>
        public void Print()
        {
            Console.Clear();
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                    Console.Write(" {0}", this.matrix[x, y] ? "@" : " ");
                Console.WriteLine(" ");
            }
        }



        //Private methods

        /// <summary>
        /// Generate a random treu false at ex: 20% (0.20)
        /// </summary>
        public bool[,] GenerateRandomMatrix()
        {
            var random = new Random();
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    this.matrix[x, y] = random.NextDouble() < 0.10;
            return this.matrix;
        }

        /// <summary>
        /// Counts the number of living neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetLivingNeighbours(int x, int y)
        {
            return
                this.GetLivingValue(x - 1, y - 1) +
                this.GetLivingValue(x + 0, y - 1) +
                this.GetLivingValue(x + 1, y - 1) +
                this.GetLivingValue(x - 1, y) +
                this.GetLivingValue(x + 1, y) +
                this.GetLivingValue(x - 1, y + 1) +
                this.GetLivingValue(x + 0, y + 1) +
                this.GetLivingValue(x + 1, y + 1);
        }
        /// <summary>
        /// Which cells are alive
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int GetLivingValue(int x, int y)
        {
            if (x < 0 || x > sizeX - 1)
                return 0;
            if (y < 0 || y > sizeY - 1)
                return 0;

            return this.matrix[x, y] ? 1 : 0;
        }
        /// <summary>
        /// Returns true for neighbours = 3 (dead or alive) and 2 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool GetNext(int x, int y)
        {
            var alive = this.matrix[x, y];
            var livingNeighbours = this.GetLivingNeighbours(x, y);

            // Any dead cell with exactly three live neighbours becomes a live cell
            if (!alive)
                return (livingNeighbours == 3);

            // Any live cell with less than two live neighbours dies
            // Any live cell with two or three live neighbours lives on to the next generation
            // Any live cell with more than three live neighbours dies
            return (livingNeighbours == 2 || livingNeighbours == 3);
        }
    }
}

