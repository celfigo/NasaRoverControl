using Nasa.Mars.RoverControl.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nasa.Mars.RoverControl.Services
{
    /// <summary>
    /// Yönler için yardımcı sınıf
    /// </summary>
    public static class DirectionHelper
    {
        /// <summary>
        /// Yönler
        /// </summary>
        public static Direction[] directions = new Direction[]
            {
                new Direction() { CardinalCompassPoint='N',Left='W',Right='E'},
                new Direction() { CardinalCompassPoint='E',Left='N',Right='S'},
                new Direction() { CardinalCompassPoint='S',Left='E',Right='W'},
                new Direction() { CardinalCompassPoint='W',Left='S',Right='N'}
            };

        /// <summary>
        /// Yön kısaltmasına göre uygun yönü döner
        /// </summary>
        /// <param name="cardinalCompassPoint">'N','S','E','W' değerli ile ilgili yön istenir</param>
        /// <returns>Yön değeri dönülür.</returns>
        public static Direction GetDirection(char cardinalCompassPoint)
        {
            var direction = directions.Where(x => x.CardinalCompassPoint == cardinalCompassPoint)?.FirstOrDefault();

            if (direction == null)
            {
                throw new Exception("Yön bulunamadı");
            }

            return direction;
        }
    }
}
