using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day_three
{
    public class Class1
    {
        public void readFile()
        {
            var lines = File.ReadAllLines("../../../Files/Input.txt");
            var bitsPerLine = lines[0].Count();
            int[] amountOfone = new int[bitsPerLine];
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1')
                    {
                        amountOfone[i]++;
                    }
                }

            }
            var gamma = new int[bitsPerLine];
            var epsilon = new int[bitsPerLine];
            for (int i = 0; i < amountOfone.Length; i++)
            {
                if (amountOfone[i] > 500)
                {
                    gamma[i] = 1;
                    epsilon[i]=0;
                }
                else
                {
                    gamma[i] = 0;
                    epsilon[i]=1;
                }
            }
            var gammaValue = bitArrayToInt(gamma);
            var epsiloneValue = bitArrayToInt(epsilon);
            var powerConsumption = gammaValue * epsiloneValue;
            Console.WriteLine("PowerConsumption:" + powerConsumption);
        }

        private int bitArrayToInt(int[] bits)
        {
            int value = 0;
            var bitstring = "";
            foreach(int bit in bits)
            {
                bitstring+=bit.ToString();
            }
            return Convert.ToInt32(bitstring, 2);
        }
    }
}
