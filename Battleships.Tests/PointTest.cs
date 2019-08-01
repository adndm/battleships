using Battleships.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleships.Tests
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestNewPoint()
        {
            Point point = new Point(1, 2);

            Assert.AreEqual(point.Column, 1);
            Assert.AreEqual(point.Row, 2);
            Assert.IsFalse(point.IsShot);
        }

        [TestMethod]
        public void TestShootPoint_ValidColumnAndRow()
        {
            Point point = new Point(1, 2);

            point.Shoot(1, 2);

            Assert.AreEqual(point.IsShot, true);
        }

        [TestMethod]
        public void TestShootPoint_InvalidColumnAndRow()
        {
            Point point = new Point(1, 2);

            point.Shoot(10, 22);

            Assert.AreEqual(point.IsShot, false);
        }

        [TestMethod]
        public void TestEquals_EqualPoint()
        {
            Point originalPoint = new Point(1, 2);
            Point copyPoint = new Point(1, 2);

            bool areEqual = originalPoint.Equals(copyPoint);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestEquals_NotEqualPoint()
        {
            Point originalPoint = new Point(1, 2);
            Point copyPoint = new Point(12, 2);

            bool areEqual = originalPoint.Equals(copyPoint);

            Assert.IsFalse(areEqual);
        }
    }
}
