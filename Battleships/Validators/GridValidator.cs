using Battleships.Models;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Validators
{
    public static class GridValidator
    {
        public static bool IsShipDirectionValid(int shipSize, Point startPoint, ShipDirection direction)
        {
            switch (direction)
            {
                case ShipDirection.Up:
                    return startPoint.Row - shipSize >= 1;
                case ShipDirection.Down:
                    return startPoint.Row + shipSize <= Constants.GridLength;
                case ShipDirection.Left:
                    return startPoint.Column - shipSize >= 1;
                case ShipDirection.Right:
                    return startPoint.Column + shipSize <= Constants.GridLength;
                default:
                    return false;
            }
        }
        public static bool IsShipValid(List<Ship> existingShips, Ship shipToBeValidated)
        {
            var toBeValidatedPoints = shipToBeValidated.GetPoints();
            foreach (var ship in existingShips)
            {
                if (ship.GetPoints().Any(existingPoint => toBeValidatedPoints.Any(existingPoint.Equals)))
                    return false;
            }
            return true;
        }
    }
}
