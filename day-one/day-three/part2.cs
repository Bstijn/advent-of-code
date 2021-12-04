using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_three
{
    internal class part2
    {
        public int LifeSupportRating()
        {
            var lines = File.ReadAllLines("../../../Files/Input.txt");
            var oxygen = OxygenGeneratingValue(lines);
            var scrubber = ScrubberGeneratingvalue(lines);
            var lifeSupport = oxygen * scrubber;
            return lifeSupport;
        }

        public int OxygenGeneratingValue(string[] lines)
        {
            for (int i = 0; i<lines[0].Length; i++)
            {
                int amountOfTimesOne = 0;
                int amountOfTimesZero = 0;
                foreach (string line in lines)
                {
                    if (line[i] == '1')
                    {
                        amountOfTimesOne++;
                    }
                    else
                    {
                        amountOfTimesZero++;
                    }
                }
                if (lines.Count() == 1)
                {
                    break;
                }
                if (amountOfTimesOne >= amountOfTimesZero)
                {
                    lines = lines.Where(line => line[i] == '1').ToArray();
                }
                else
                {
                    lines = lines.Where(line => line[i] == '0').ToArray();
                }
            }
            return Convert.ToInt32(lines[0], 2);
        }

        public int ScrubberGeneratingvalue(string[] lines)
        {
            for (int i = 0; i<lines[0].Length; i++)
            {
                int amountOfTimesOne = 0;
                int amountOfTimesZero = 0;
                foreach (string line in lines)
                {
                    if (line[i] == '1')
                    {
                        amountOfTimesOne++;
                    }
                    else
                    {
                        amountOfTimesZero++;
                    }
                }
                if(lines.Count() == 1)
                {
                    break;
                }
                if (amountOfTimesZero <= amountOfTimesOne )
                {
                    lines = lines.Where(line => line[i] == '0').ToArray();
                }
                else
                {
                    lines = lines.Where(line => line[i] == '1').ToArray();
                }
            }
            return Convert.ToInt32(lines[0], 2);
        }
    }
}
