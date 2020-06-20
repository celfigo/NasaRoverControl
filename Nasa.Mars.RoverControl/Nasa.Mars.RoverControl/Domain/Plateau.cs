using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Mars.RoverControl.Domain
{
    /// <summary>
    /// Mars üzerindeki platolar
    /// Platonun sınır uzunlukları kooordinat sistemine göre değerler tutulur
    /// </summary>
    public class Plateau
    {
        public int xLenght { get; set; }
        public int yLenght { get; set; }
    }
}
