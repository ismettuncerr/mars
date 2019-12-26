using Mars.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars.Model
{
    public class Position //: IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
