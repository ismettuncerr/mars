using Mars.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mars.Model
{
    public class RoverDetail
    {
        public Directions RoverDirection { get; set; }
        public Position RoverPosition { get; set; }
        public string MoveDetail { get; set; }
    }
}
