using Nasa.Mars.RoverControl.Domain;
using Nasa.Mars.RoverControl.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Nasa.Mars.Tests
{
    [TestFixture()]
    public class RoverMotionTests
    {
        private RoverMotion _roverMotion;
        [SetUp]
        public void Setup()
        {
            Plateau plateau = new Plateau() { xLenght = 5, yLenght = 5 };

            _roverMotion = new RoverMotion(plateau);
        }


        [Test()]
        public void TurnLeftTest()
        {
            var nextposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' } };
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };

            var testPosition = _roverMotion.TurnLeft(currentposition);

            Assert.AreEqual(testPosition, nextposition);

        }

        [Test()]
        public void TurnRightTest()
        {
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' } };
            var nextposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };

            var testPosition = _roverMotion.TurnRight(currentposition);

            Assert.AreEqual(testPosition, nextposition);
        }

        [Test()]
        public void MoveForwardNorthTest()
        {
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' } };
            var nextposition = new Position() { X = 1, Y = 2, Direction = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' } };

            var testPosition = _roverMotion.MoveForward(currentposition);

            Assert.AreEqual(testPosition, nextposition);


        }
        [Test()]
        public void MoveForwardSouthTest()
        {
            var currentposition = new Position() { X = 1, Y = 2, Direction = new Direction() { CardinalCompassPoint = 'S', Left = 'E', Right = 'W' } };
            var nextposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'S', Left = 'E', Right = 'W' } };

            var testPosition = _roverMotion.MoveForward(currentposition);

            Assert.AreEqual(testPosition, nextposition);


        }
        [Test()]
        public void MoveForwardWestTest()
        {
            var currentposition = new Position() { X = 2, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'W', Left = 'S', Right = 'N' } };
            var nextposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'W', Left = 'S', Right = 'N' } };

            var testPosition = _roverMotion.MoveForward(currentposition);

            Assert.AreEqual(testPosition, nextposition);


        }
        [Test()]
        public void MoveForwardEastTest()
        {
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };
            var nextposition = new Position() { X = 2, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };

            var testPosition = _roverMotion.MoveForward(currentposition);

            Assert.AreEqual(testPosition, nextposition);


        }

        [Test()]
        public void GetNextPositionLeftTest()
        {
            var nextposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' } };
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };
            var testPosition = _roverMotion.GetNextPosition(currentposition, 'L');

            Assert.AreEqual(testPosition, nextposition);
        }
        [Test()]
        public void GetNextPositionRightTest()
        {
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'N', Left = 'W', Right = 'E' } };
            var nextposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };
            var testPosition = _roverMotion.GetNextPosition(currentposition, 'R');

            Assert.AreEqual(testPosition, nextposition);
        }
        [Test()]
        public void GetNextPositionMoveForwardTest()
        {
            var currentposition = new Position() { X = 1, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };
            var nextposition = new Position() { X = 2, Y = 1, Direction = new Direction() { CardinalCompassPoint = 'E', Left = 'N', Right = 'S' } };
            var testPosition = _roverMotion.GetNextPosition(currentposition, 'M');

            Assert.AreEqual(testPosition, nextposition);
        }
    }
}