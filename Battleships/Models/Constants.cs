using System.Collections.Generic;

namespace Battleships.Models
{
    public static class Constants
    {
        /// <summary>
        /// Constant indicating the grid length
        /// </summary>
        public static readonly int GridLength = 10;

        /// <summary>
        /// Constant indicating the hidden grid value
        /// </summary>
        public static readonly string Dash = "-";

        /// <summary>
        /// Constant indicating the ship part grid value
        /// </summary>
        public static readonly string ShipPart = "X";

        /// <summary>
        /// Constant indicating the Yes option
        /// </summary>
        public static readonly string Yes = "Y";

        /// <summary>
        /// Constant indicating the No option
        /// </summary>
        public static readonly string No = "N";

        /// <summary>
        /// Constant indicating the grid header
        /// </summary>
        public static readonly string GridHeader = "  | 1  2  3  4  5  6  7  8  9  10 |";

        /// <summary>
        /// Constant indicating the grid delimitation
        /// </summary>
        public static readonly string GridDelimitation = "--|-------------------------------|";

        /// <summary>
        /// Constant indicating the grid value template
        /// </summary>
        public static readonly string GridValueTemplate = " {0} ";

        /// <summary>
        /// Constant indicating the grid end row
        /// </summary>
        public static readonly string GridEndRow = " |";

        /// <summary>
        /// Constant indicating the grid hit value
        /// </summary>
        public static readonly string Hit = "H";

        /// <summary>
        /// Constant indicating the grid miss value
        /// </summary>
        public static readonly string Miss = "M";

        /// <summary>
        /// Constant indicating the list of grid row characters
        /// </summary>
        public static readonly List<char> Letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        /// <summary>
        /// Constant indicating a mapping between grid row characters and input values
        /// </summary>
        public static readonly Dictionary<int, char> DigitLetterMap = new Dictionary<int, char> { { 1, 'A'}, { 2, 'B'},
                                                                                                { 3, 'C'}, { 4, 'D'},
                                                                                                { 5, 'E'}, { 6, 'F'},
                                                                                                { 7, 'G'}, { 8, 'H'},
                                                                                                { 9, 'I'}, { 10, 'J'}};

        /// <summary>
        /// Constant indicating a mapping between input values and grid row characters
        /// </summary>
        public static readonly Dictionary<char, int> LetterDigitMap = new Dictionary<char, int> { { 'A', 1}, { 'B', 2},
                                                                                                { 'C', 3}, { 'D', 4},
                                                                                                { 'E', 5}, { 'F', 6},
                                                                                                { 'G', 7}, { 'H', 8},
                                                                                                { 'I', 9}, { 'J', 10}};
    }
}
