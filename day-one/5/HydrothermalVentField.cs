using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    public class HydrothermalVentField
    {
        public List<HydrothermalVent> vents = new List<HydrothermalVent>();
        int[,] pos = new int[1000, 1000];
        int AmountOfVentsTwo = 0;
        public HydrothermalVentField()
        {
            ReadFile();
            calcPos();
            foreach (var cell in pos)
            {
                if (cell >= 2)
                {
                    AmountOfVentsTwo++;
                }
            }
            Console.WriteLine(AmountOfVentsTwo);
            //printGrid();
        }

        private void printGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(pos[i, j]);
                }
            }
        }

        public void calcPos()
        {
            foreach (var vent in vents)
            {
                if (vent.IsHorizontal())
                {
                    fillInPosHorizontal(vent);
                }
                if (vent.IsVertical())
                {
                    fillInPosVertical(vent);
                }
                if (vent.isDiagonal())
                {
                    fillInposDiagonal(vent);
                }
            }

        }

        private void fillInposDiagonal(HydrothermalVent vent)
        {
            int lenght = vent.StartX - vent.EndX;
            if (lenght < 0)
            {
                lenght*=-1;
            }

            int xMod = vent.StartX > vent.EndX ? -1 : 1;
            int yMod = vent.StartY > vent.EndY ? -1 : 1;

            for (int i = 0;i <= lenght; i++)
            {
                int y = vent.StartY+(i*yMod);
                int x = vent.StartX+(i*xMod);
                pos[y, x]++;
            }
        }

        private void fillInPosVertical(HydrothermalVent vent)
        {
            int x = vent.StartX;
            int start;
            int end;
            if (vent.StartY > vent.EndY)
            {
                start = vent.EndY;
                end = vent.StartY;
            }
            else
            {
                end = vent.EndY;
                start = vent.StartY;
            }

            for (int y = start; y<= end; y++)
            {
                pos[y, x]++;
            }
        }

        private void fillInPosHorizontal(HydrothermalVent vent)
        {
            int y = vent.StartY;
            int start;
            int end;
            if (vent.StartX > vent.EndX)
            {
                start = vent.EndX;
                end = vent.StartX;
            }
            else
            {
                end = vent.EndX;
                start = vent.StartX;
            }
            for (int x = start; x<= end; x++)
            {
                pos[y, x]++;
            }
        }

        private void ReadFile()
        {
            var lines = File.ReadAllLines("../../../TextFile1.txt").ToList();
            foreach (var line in lines)
            {
                string[] coordinates = line.Split(" -> ");
                var vent = new HydrothermalVent();
                string[] pos1 = coordinates[0].Split(',');
                vent.StartX = int.Parse(pos1[0]);
                vent.StartY = int.Parse(pos1[1]);
                string[] pos2 = coordinates[1].Split(',');
                vent.EndX = int.Parse(pos2[0]);
                vent.EndY = int.Parse(pos2[1]);
                vents.Add(vent);
            }
        }
    }
}
