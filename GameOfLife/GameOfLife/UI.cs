using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class UI
    {
        
            public string text = string.Format("\t\t  +-------------------------------------------------------------------------------+");
            public string text2 = string.Format("\t\t  |                               Game of Life                                    |");
            
            public string text3 = string.Format("\t\t  ¦ 0 ¦ 1 ¦ 2 ¦ 3 ¦ 4 ¦ 5 ¦ 6 ¦ 7 ¦ 8 ¦ 9 ¦ 10¦ 11¦ 12¦ 13¦ 14¦ 15¦ 16¦ 17¦ 18¦ 19¦");
            
        
        public void PaintTable(string value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
        }
    }
}
