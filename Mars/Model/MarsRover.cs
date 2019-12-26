using Mars.Abstract;
using Mars.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mars.Model
{
    public class MarsRover : IMarsRover
    {
        /// <summary>
        /// Robotun indiği Alanın Boyutları
        /// </summary>
        public PlateauArea RoverPlateauArea { get; set; }
        /// <summary>
        /// Robotun Hangi konumda olduğunu tutacağımız değer
        /// </summary>
        /// 
        public Position RoverPosition { get; set; }

        /// <summary>
        /// Robotun Anlık Yönünü Tutacağımız değer
        /// </summary>
        public Directions RoverDirection { get; set; }
        public Directions robotDirections { get; set; }

        public MarsRover(PlateauArea roverPlateauArea, Position roverPosition, Directions roverDirection)
        {

            RoverPlateauArea = roverPlateauArea;
            RoverPosition = roverPosition;
            RoverDirection = roverDirection;
            /*Direction = new Dictionary<int, string>();
            Direction.Add(1, "North");
            Direction.Add(2, "East");
            Direction.Add(3, "South");
            Direction.Add(4, "West");*/

        }

        public bool Process(string commands)
        {
            //Girilen Komuta göre Robotun hareket ettirecek olan kod bloğu
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
                //Belirtilen Alan dışına çıkıp çıkmadığını kontrol ettiğimiz kısım
                if (RoverPosition.X > RoverPlateauArea.Width || RoverPosition.Y > RoverPlateauArea.Height)
                {
                    //throw new ArgumentException("Robot has moved out of the area.");
                    Console.WriteLine("Robot has moved out of the area.");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Robotun Sola Dönmesi için gereken kod bloğu
        /// </summary>
        private void TurnLeft()
        {
            //Burada Kuzey yönünün değeri 1 olduğundan dolayı robot tekrar döndüğünde 0 a eşit olacak aslında 0 değeri olduğunda robot Batıya dönmüş olacak

            if (((int)RoverDirection - 1) == 0)
            {
                RoverDirection = Directions.W;
            }
            else
            {
                RoverDirection = RoverDirection - 1;
            }
        }
        /// <summary>
        /// Robotun Sağa Dönmesi için gereken kod bloğu
        /// </summary>
        private void TurnRight()
        {
            //Burada Batı yönünün değeri 4 olduğundan dolayı robot tekrar sağa döndüğünde 5 e eşit olacak aslında 5 değeri olduğunda robot Kuzeye dönmüş olacak

            if (((int)RoverDirection + 1) == 5)
            {
                RoverDirection = Directions.N;
            }
            else
            {
                RoverDirection = RoverDirection + 1;
            }
        }

        /// <summary>
        /// Robotu hareket ettirmek içinkullanılan kod bloğu
        /// Robotun Yönüne göre hangi eksende gideceğini belirliyoruz.
        /// </summary>
        private void Move()
        {
            switch (RoverDirection)
            {
                case Directions.N:
                    RoverPosition.Y++;
                    break;
                case Directions.S:
                    RoverPosition.Y--;
                    break;
                case Directions.E:
                    RoverPosition.X++;
                    break;
                case Directions.W:
                    RoverPosition.X--;
                    break;
                default: break;
            }
        }

    }
}
