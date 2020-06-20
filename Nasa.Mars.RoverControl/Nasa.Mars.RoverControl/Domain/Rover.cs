using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Mars.RoverControl.Domain
{
    /// <summary>
    /// Mars üzerinde keşif yapacak araç
    /// </summary>
    public class Rover
    {
        public string Commands { get; set; }
        public Position CurruntPosition { get; set; }
    }
}
