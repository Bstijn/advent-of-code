using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    public class Fish
    {
        public int TypeFish;
        public Int64 Amount = 0;
        public Fish(int type)
        {
            TypeFish = type;
        }
    }
    public class Grow
    {
        List<Fish> fishes = new List<Fish>()
        {
            new Fish(0),
            new Fish(1),
            new Fish(2),
            new Fish(3),
            new Fish(4),
            new Fish(5),
            new Fish(6),
            new Fish(7),
            new Fish(8),
        };
        public Grow()
        {
            ReadFile();
            for (int i = 0; i < 256; i++)
            {
                FISHMUSTGROW();
            }
            Int64 total = 0;
            foreach (Fish f in fishes)
            {
                Console.WriteLine(f.TypeFish + "*" + f.Amount);
                total+=f.Amount;
            }
            Console.WriteLine(total);
        }

        public void FISHMUSTGROW()
        {
            List<Fish> newfishses = new List<Fish>()
            {
                new Fish(0),
                new Fish(1),
                new Fish(2),
                new Fish(3),
                new Fish(4),
                new Fish(5),
                new Fish(6),
                new Fish(7),
                new Fish(8),
            };
            foreach (Fish oldFish in fishes)
            {
                switch (oldFish.TypeFish)
                {
                    case 0:
                        newfishses[6].Amount += oldFish.Amount;
                        newfishses[8].Amount += oldFish.Amount;
                        break;
                    default:
                        newfishses[oldFish.TypeFish-1].Amount += oldFish.Amount;
                        break;

                }
            }

            fishes = newfishses;
        }

        private void ReadFile()
        {
            var numbers = File.ReadAllLines("../../../Input.txt")[0].Split(',');
            foreach (var number in numbers)
            {
                int n = Convert.ToInt32(number);
                fishes[n].Amount++;
            }
        }
    }
}
