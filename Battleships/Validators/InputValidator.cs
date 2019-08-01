using Battleships.Models;
using System;

namespace Battleships.Validators
{
    public static class InputValidator
    {
        public static bool IsSeeGridValid(string seeGrid)
        {
            if (seeGrid == null) return false;

            return seeGrid.Equals(Constants.Yes, StringComparison.InvariantCultureIgnoreCase) || seeGrid.Equals(Constants.No, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsInputPointValid(string inputPoint)
        {
            if (inputPoint == null) return false;
                        
            if (!Constants.Letters.Contains(inputPoint[0])) return false;
            
            var column = int.Parse(inputPoint.Substring(1));
            return column > 0 && column <= Constants.GridLength;
        }
    }
}