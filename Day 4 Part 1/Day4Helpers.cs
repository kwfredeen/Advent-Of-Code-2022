using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4_Part_1
{
    public class Day4Helpers
    {
        /// <summary>
        /// Parses a section range string into a section range array.
        /// </summary>
        /// <param name="section">section range string to parse</param>
        /// <returns>section range array, where [0] is the start and [1] is the end of the section range</returns>
        /// <exception cref="ArgumentException">when section string has more than one hyphen</exception>
        public static int[] ParseSection(string section)
        {
            int[] startEnd = section.Split('-').Select(s => int.Parse(s)).ToArray();

            if (startEnd.Length != 2) throw new ArgumentException("section must have exactly two numbers separated by one hyphen!");

            return startEnd;
        }

        /// <summary>
        /// Checks if two section range arrays are fully overlapped
        /// </summary>
        /// <param name="range1">first section range array</param>
        /// <param name="range2">second section range array</param>
        /// <returns>true if either section range is completely covered by the other</returns>
        public static bool CheckFullSectionOverlap(int[] range1, int[] range2)
        {
            bool oneInsideTwo = range1[0] >= range2[0] && range1[1] <= range2[1];

            //check the other direction
            bool twoInsideOne = range1[0] <= range2[0] && range1[1] >= range2[1];

            return oneInsideTwo || twoInsideOne;
        }

        /// <summary>
        /// Checks if swo section range arrays overlap in any way
        /// </summary>
        /// <param name="range1">first section range array</param>
        /// <param name="range2">second section range array</param>
        /// <returns>true if either range overlaps the other. false if there is no overlap</returns>
        public static bool CheckAnySectionOverlap(int[] range1, int[] range2)
        {
            return (range1[0] >= range2[0] && range1[0] <= range2[1]) || (range2[0] >= range1[0] && range2[0] <= range1[1]);
        }
    }
}
