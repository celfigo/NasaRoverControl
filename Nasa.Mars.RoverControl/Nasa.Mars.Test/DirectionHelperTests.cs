using Nasa.Mars.RoverControl.Domain;
using Nasa.Mars.RoverControl.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nasa.Mars.Tests
{
    [TestFixture()]
    public class DirectionHelperTests
    {
        public static Direction[] directions = new Direction[]
           {
                new Direction() { CardinalCompassPoint='N',Left='W',Right='E'},
                new Direction() { CardinalCompassPoint='E',Left='N',Right='S'},
                new Direction() { CardinalCompassPoint='S',Left='E',Right='W'},
                new Direction() { CardinalCompassPoint='W',Left='S',Right='N'}
           };

        [Test()]
        public void GetDirectionNorthTest()
        {
            var North = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' };
            var NorthTest = DirectionHelper.GetDirection('N');

            Assert.AreEqual(North, NorthTest);


        }
    }
}