using Mars.Enum;
using Mars.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars.Abstract
{
    public interface IMarsRover
    {
        PlateauArea RoverPlateauArea { get; set; }
        Position RoverPosition { get; set; }
        Directions RoverDirection { get; set; }
        bool Process(string commands);
    }
}
