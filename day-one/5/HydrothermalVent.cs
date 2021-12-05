using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    public class HydrothermalVent
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public bool IsHorizontal()
        {
            return StartY == EndY;
        }

        public bool IsVertical()
        {
            return EndX == StartX;
        }

        internal bool isDiagonal()
        {
            return EndX != StartX && EndY != StartY;
        }
    }
}
