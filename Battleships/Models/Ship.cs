using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Validators;

namespace Battleships.Models
{
    public class Ship
    {
        private static readonly Random rand = new Random();
        private readonly List<Point> points = new List<Point>();

        public int Size { get; }

        public Ship(int size)
        {
            Size = size;

            Point randomPoint = new Point(rand.Next(1, Constants.GridLength), rand.Next(1, Constants.GridLength));
            ShipDirection randomDirection = GetRandomDirection();
            ConstructShip(randomPoint, randomDirection);
        }

        public List<Point> GetPoints()
        {
            return points;
        }

        public bool IsSunk()
        {
            return points.All(point => point.IsShot);
        }

        public bool Shoot(Point shotPoint)
        {
            Point toBeShotPoint = points.FirstOrDefault(point => point.Equals(shotPoint));
            if (toBeShotPoint == null) return false;

            toBeShotPoint.Shoot(shotPoint.Column, shotPoint.Row);
            return true;
        }

        private void ConstructShip(Point point, ShipDirection direction)
        {
            if (GridValidator.IsShipDirectionValid(Size, point, direction))
            {
                FillPoints(point, direction);
            }
            else
            {
                int randTrial = rand.Next(1, 2) % 2;
                direction = randTrial == 0 ? GetRandomDirection() : direction;
                point = randTrial == 1 ? new Point(rand.Next(1, Constants.GridLength), rand.Next(1, Constants.GridLength)) : point;
                ConstructShip(point, direction);
            }
        }

        private void FillPoints(Point point, ShipDirection direction)
        {
            points.Add(point);
            int repetition = Size;
            int column = point.Column;
            int row = point.Row;

            switch (direction)
            {
                case ShipDirection.Up:
                    {
                        while (--repetition > 0)
                        {
                            points.Add(new Point(column, --row));
                        }
                        break;
                    }
                case ShipDirection.Down:
                    {
                        while (--repetition > 0)
                        {
                            points.Add(new Point(column, ++row));
                        }
                        break;
                    }
                case ShipDirection.Left:
                    {
                        while (--repetition > 0)
                        {
                            points.Add(new Point(--column, row));
                        }
                        break;
                    }
                case ShipDirection.Right:
                    {
                        while (--repetition > 0)
                        {
                            points.Add(new Point(++column, row));
                        }
                        break;
                    }
                default:
                    return;
            }
        }

        private ShipDirection GetRandomDirection()
        {
            int randNo = rand.Next(1, 4);

            switch (randNo)
            {
                case 1:
                    return ShipDirection.Up;
                case 2:
                    return ShipDirection.Down;
                case 3:
                    return ShipDirection.Left;
                default:
                    return ShipDirection.Right;
            }
        }
    }
}
