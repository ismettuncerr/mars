using Mars.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars.Model
{
    public class PlateauArea //: IPlateauArea
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public PlateauArea(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
