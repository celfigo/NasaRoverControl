using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Mars.RoverControl.Domain
{
    /// <summary>
    /// Mars üzerideki konumu belirtir,
    /// Aracın X,Y kooordinatlarını ve yönünü gösterir
    /// </summary>
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public override string ToString()
        { 
            return X +" "+Y+" "+Direction.CardinalCompassPoint;
        }
        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y &&
                   EqualityComparer<Direction>.Default.Equals(Direction, position.Direction);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Direction);
        }
    }
}
