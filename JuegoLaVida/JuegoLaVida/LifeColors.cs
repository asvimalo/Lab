using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoLaVida
{
    class LifeColors
    {
        //Field
        private ConsoleColor color1;
        private ConsoleColor color2;
        private int posX;
        private int posY;

        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        //Grid for 2 colors
        private ConsoleColor[,] grid = new ConsoleColor[25, 50];



        //Color cells
        public ConsoleColor Color1
        {
            get { return color1; }
            set { color1 = value; }
        }
        //Color dead cells
        public ConsoleColor Color2
        {
            get { return color2; }
            set { color2 = value; }
        }
        //Constructor
        public LifeColors()
        {
            this.color1 = ConsoleColor.Blue;
            this.color2 = ConsoleColor.Red;
            
            
        }
        public void PrintColored(bool[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if(matrix[x,y])
                    {

                        grid[x, y] = color2;
                        Console.Write(grid[x,y]);
                    }
                    else
                    {
                        grid[x, y] = color1;
                        Console.Write(grid[x, y]);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    } 
}
