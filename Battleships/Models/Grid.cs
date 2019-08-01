using System.Collections.Generic;
using System.Linq;
using Battleships.Validators;

namespace Battleships.Models
{
    public class Grid
    {
        private readonly List<Ship> ships = new List<Ship>();

        public Grid(List<int> shipSizes)
        {
            foreach (int shipSize in shipSizes)
            {
                ships.Add(GenerateShip(new Ship(shipSize)));
            }
        }

        public List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();
            foreach(var ship in ships)
            {
                points.AddRange(ship.GetPoints());
            }
            return points;
        }

        public bool Shoot(Point point)
        {
            bool isHit = false;
            foreach (var ship in ships)
            {
                isHit |= ship.Shoot(point);
            }

            return isHit;
        }

        public bool AreAllShipsSank()
        {
            return ships.All(ship => ship.IsSunk());
        }

        private Ship GenerateShip(Ship ship)
        {
            return GridValidator.IsShipValid(ships, ship) ? ship : GenerateShip(new Ship(ship.Size));
        }
    }
}
