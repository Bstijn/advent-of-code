using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    public class Bingo
    {
        private List<BingoGrid> grids = new List<BingoGrid>();
        private List<int> numbers = new List<int>();

        public Bingo()
        {
            ReadFile();
        }

        public void Play()
        {
            foreach (int number in numbers)
            {
                PlayNextNumber(number);
            }
        }

        public bool PlayNextNumber(int number)
        {
            Console.WriteLine(number); 
            List<BingoGrid> wonGrids = new List<BingoGrid>();
            foreach (var grid in grids)
            {
                foreach (var cell in grid.Grid)
                {
                    if (cell.Number == number)
                    {
                        cell.Marked = true; ;
                    }
                }
                bool isBingo = grid.CheckBingo();
                if (isBingo)
                {
                    Console.WriteLine($"Board: {grid.Number} WON at number: {number}, value of sum of all unmarked * number = {number * Convert.ToInt32(grid.ToString())}");
                    wonGrids.Add(grid);
                }
                if (grids.Count == 1)
                {
                    Console.WriteLine("last to win is: " + grids[0].Number);
                }
            }
            foreach(var grid in wonGrids)
            {
                grids.Remove(grid);
            }
            return false;
        }

        public void ReadFile()
        {
            var lines = File.ReadAllLines("../../../Input1.txt").ToList();
            lines[0].Split(',').ToList().ForEach(number => numbers.Add(Convert.ToInt32(number)));
            lines.RemoveAt(0);
            lines.RemoveAt(0);
            int BingoGrindNumber = 1;
            int i = 0;
            BingoGrid currentGrid = new BingoGrid();
            foreach (var line in lines)
            {
                if (line =="")
                {
                    grids.Add(currentGrid);
                    currentGrid = new BingoGrid();
                    currentGrid.Number = BingoGrindNumber;
                    i =0;
                    BingoGrindNumber++;
                }
                else
                {
                    var s = line.Split(' ').ToList();
                    List<int> numbersThisLine = new List<int>();
                    s = s.Where(s => s != "").ToList();
                    foreach (string nubmer in s)
                    {
                        numbersThisLine.Add(Convert.ToInt32(nubmer));
                    }
                    currentGrid.Grid[i, 0] = new BingoCell { Number = numbersThisLine[0], Marked = false };
                    currentGrid.Grid[i, 1] = new BingoCell { Number = numbersThisLine[1], Marked = false };
                    currentGrid.Grid[i, 2] = new BingoCell { Number = numbersThisLine[2], Marked = false };
                    currentGrid.Grid[i, 3] = new BingoCell { Number = numbersThisLine[3], Marked = false };
                    currentGrid.Grid[i, 4] = new BingoCell { Number = numbersThisLine[4], Marked = false };
                    i++;
                }
            }
        }
    }
}
