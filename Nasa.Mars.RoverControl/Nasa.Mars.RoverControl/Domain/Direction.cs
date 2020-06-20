using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Mars.RoverControl.Domain
{

    /// <summary>
    /// Yönler
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// Yönün tek karakterlik kısatlması örğ: N,S,W,E
        /// </summary>
        public char CardinalCompassPoint { get; set; }
        /// <summary>
        /// Sol taraftaki yön
        /// </summary>
        public char Left { get; set; }
        /// <summary>
        /// Sağ taraftaki yön
        /// </summary>
        public char Right { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Direction direction &&
                   CardinalCompassPoint == direction.CardinalCompassPoint &&
                   Left == direction.Left &&
                   Right == direction.Right;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CardinalCompassPoint, Left, Right);
        }


    }
}
