using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Validators;

namespace Battleships
{
    public class Game
    {
        private readonly Grid grid;
        private List<Point> points;
        private List<Point> missPoints = new List<Point>();

        public Game(List<int> gridConfiguration)
        {
            grid = new Grid(gridConfiguration);
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Battleships!");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Do you want to see the actual grid (cheat-mode)? - Y/N");
            
            HandleInput(DetermineSeeGrid());

            Console.WriteLine("THE END!");
        }

        private void HandleInput(bool seeGrid)
        {
            while(!grid.AreAllShipsSank())
            {
                Console.WriteLine("Shoot the ships!");

                DrawGrid(seeGrid);

                Console.WriteLine("Enter point in format {RowColumn}, where Row is [A-J] and Column is [1-10]:");
                Point inputPoint = DetermineInputPoint();

                bool isShot = grid.Shoot(inputPoint);

                if (!isShot) missPoints.Add(inputPoint);
            }

            Console.WriteLine("Every ship sank. Congratulations!!");
        }

        private Point DetermineInputPoint()
        {
            string inputPoint = string.Empty;
            bool isValid = false;

            while (!isValid)
            {
                inputPoint = Console.ReadLine();
                if (InputValidator.IsInputPointValid(inputPoint))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input point! Re-enter, please:");
                }

            }
            return new Point(Constants.LetterDigitMap[inputPoint[0]], (int)char.GetNumericValue(inputPoint[1]));
        }

        private void DrawGrid(bool showActualGrid)
        {
            points = grid.GetPoints();

            Console.WriteLine(Constants.GridHeader);
            Console.WriteLine(Constants.GridDelimitation);

            for (int column = 1; column <= Constants.GridLength; column++)
            {
                string line = Constants.DigitLetterMap[column] + Constants.GridEndRow;
                for (int row = 1; row <= Constants.GridLength; row++)
                {
                    line += string.Format(Constants.GridValueTemplate, GetGridValue(showActualGrid, column, row));
                }
                line += Constants.GridEndRow;
                Console.WriteLine(line);
            }
            Console.WriteLine(Constants.GridDelimitation);
        }

        private string GetGridValue(bool showActualGrid, int column, int row)
        {
            Point inputPoint = new Point(column, row);

            Point missPoint = missPoints.FirstOrDefault(point => point.Equals(inputPoint));
            if (missPoint != null)
                return Constants.Miss;

            Point hitPoint = points.FirstOrDefault(point => point.Equals(inputPoint));

            if (hitPoint != null)
            {
                return  hitPoint.IsShot ? Constants.Hit : showActualGrid ? Constants.ShipPart : Constants.Dash;
            }

            return Constants.Dash;
        }
        
        private static bool DetermineSeeGrid()
        {
            bool isValid = false;
            string seeGrid = string.Empty;

            while (!isValid)
            {
                seeGrid = Console.ReadLine();
                if (InputValidator.IsSeeGridValid(seeGrid))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid option. Choose Y/N:");
                }
            }

            return seeGrid.Equals(Constants.Yes, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
