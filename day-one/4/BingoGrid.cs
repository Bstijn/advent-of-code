using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class BingoGrid
    {

        //Grid[y][x]
        public BingoCell[,] Grid { get; set; } = new BingoCell[5,5];
        public int Number { get; internal set; }

        public bool CheckBingo()
        {
            //Check Row on Bingo
            for(int i = 0; i < 5; i++)
            {
                bool isRowBingo = true;
                for (int j = 0; j < 5; j++)
                {
                    if (Grid[i, j].Marked == false)
                    {
                        isRowBingo=false;
                        break;
                    }
                }
                if (isRowBingo) return true;
            }

            //Check column
            for (int i = 0; i < 5; i++)
            {
                bool isColumnBingo = true;
                for (int j = 0; j < 5; j++)
                {
                    if (Grid[j, i].Marked == false)
                    {
                        isColumnBingo=false;
                        break;
                    }
                }
                if (isColumnBingo) return true;
            }
            return false;
        }

        public override string ToString()
        {
            int result  = 0;
            foreach(var cell in Grid)
            {
                if(cell.Marked == false)
                {
                    result += cell.Number;
                }
            }
            return result.ToString();
        }

    }

    public class BingoCell
    {
        public int Number { get; set; }
        public bool Marked { get; set; }
    }
}
