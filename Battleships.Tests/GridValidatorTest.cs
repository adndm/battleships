using System;
using Battleships.Models;
using Battleships.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests
{
    [TestClass]
    public class GridValidatorTest
    {
        [TestMethod]
        public void IsShipDirectionValid_ValidPointSizeDirection()
        {
            Point point = new Point(4, 6);
            int shipSize = 5;
            ShipDirection shipDirection = ShipDirection.Right;

            Assert.IsTrue(GridValidator.IsShipDirectionValid(shipSize, point, shipDirection));
        }

        [TestMethod]
        public void IsShipDirectionValid_ValidPointInvalidSizeDirection()
        {
            Point point = new Point(4, 6);
            int shipSize = 11;
            ShipDirection shipDirection = ShipDirection.Right;

            Assert.IsFalse(GridValidator.IsShipDirectionValid(shipSize, point, shipDirection));
        }

        [TestMethod]
        public void IsShipDirectionValid_ValidPointValidSizeRightDirection()
        {
            Point point = new Point(9, 6);
            int shipSize = 4;
            ShipDirection shipDirection = ShipDirection.Right;

            Assert.IsFalse(GridValidator.IsShipDirectionValid(shipSize, point, shipDirection));
        }

        [TestMethod]
        public void IsShipDirectionValid_ValidPointValidSizeDownDirection()
        {
            Point point = new Point(9, 6);
            int shipSize = 4;
            ShipDirection shipDirection = ShipDirection.Down;

            Assert.IsTrue(GridValidator.IsShipDirectionValid(shipSize, point, shipDirection));
        }

        [TestMethod]
        public void IsShipDirectionValid_ValidPointValidSizeLeftDirection()
        {
            Point point = new Point(9, 1);
            int shipSize = 5;
            ShipDirection shipDirection = ShipDirection.Left;

            Assert.IsTrue(GridValidator.IsShipDirectionValid(shipSize, point, shipDirection));
        }
    }
}
