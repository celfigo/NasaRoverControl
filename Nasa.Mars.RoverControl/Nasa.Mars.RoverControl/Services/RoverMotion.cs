using Nasa.Mars.RoverControl.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nasa.Mars.RoverControl.Services
{
    
    /// <summary>
    /// Araç haeketleri sağlayan sınıf
    /// </summary>
    public class RoverMotion
    {
        
        private readonly Plateau _plateau;

        public RoverMotion( Plateau plateau)
        {
            _plateau = plateau;
        }
        /// <summary>
        /// 'L' komutu sonrası aracı sola döndürür 
        /// </summary>
        /// <param name="position">Aracı bulunduğu pozisyon</param>
        /// <returns>güncel pozisyonu döner</returns>
        public Position TurnLeft(Position position)
        {
            if (position == null)
                throw new Exception("Pozisyon değeri boş olamaz!");

            if (position.Direction == null)
                throw new Exception("Yön değeri boş olamaz!");

            position.Direction = DirectionHelper.GetDirection(position.Direction.Left);

            return position;
        }
        /// <summary>
        /// 'R' komutu sonrası aracı sağa döndürür 
        /// </summary>
        /// <param name="position">Aracı bulunduğu pozisyon</param>
        /// <returns>güncel pozisyonu döner</returns>
        public Position TurnRight(Position position)
        {
            if (position == null)
                throw new Exception("Pozisyon değeri boş olamaz!");

            if (position.Direction == null)
                throw new Exception("Yön değeri boş olamaz!");

            position.Direction = DirectionHelper.GetDirection(position.Direction.Right);
            return position;
        }
        /// <summary>
        /// Gelen komuta göre aracın pozisyonunu günceller
        /// </summary>
        /// <param name="currentPosition">Aracın bulunduğu pozisyon</param>
        /// <param name="movementCommand">'L','R','M' komutlarını alır</param>
        /// <returns>Güncel pozisyonu döner</returns>
        public Position GetNextPosition(Position currentPosition, char movementCommand)
        {
            if (currentPosition == null)
                throw new Exception("Pozisyon değeri boş olamaz!");

            if (currentPosition.Direction == null)
                throw new Exception("Yön değeri boş olamaz!");

            switch (movementCommand)
            {
                case 'L':
                    currentPosition = TurnLeft(currentPosition);
                    break;
                case 'R':
                    currentPosition = TurnRight(currentPosition);
                    break;
                case 'M':
                    currentPosition = MoveForward(currentPosition);
                    break;

                default:
                    break;
            }

            return currentPosition;
        }
        /// <summary>
        /// Aracı bulundugu yönde bir adım ileri konumladırır
        /// </summary>
        /// <param name="currentPosition">Aracın pozisyonu</param>
        /// <returns>Güncel pozisyon</returns>
        public Position MoveForward(Position currentPosition)
        {
            if (currentPosition == null)
                throw new Exception("Pozisyon değeri boş olamaz!");

            if (currentPosition.Direction == null)
                throw new Exception("Yön değeri boş olamaz!");

            switch (currentPosition.Direction.CardinalCompassPoint)
            {
                case 'N':
                    if (currentPosition.Y < _plateau.yLenght)
                        currentPosition.Y += 1;
                    break;

                case 'E':
                    if (currentPosition.X < _plateau.xLenght)
                        currentPosition.X += 1;
                    break;
                case 'W':
                    if (currentPosition.X > 0)
                        currentPosition.X -= 1;
                    break;
                case 'S':
                    if (currentPosition.Y > 0)
                        currentPosition.Y -= 1;
                    break;
                default:
                    break;
            }
            return currentPosition;
        }
    }
}
