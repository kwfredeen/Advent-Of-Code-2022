namespace Day_3_Part_1
{
    public class Day3Helpers
    {
        /// <summary>
        /// Splits a rucksack string into compartment strings
        /// </summary>
        /// <param name="rucksack">rucksack string</param>
        /// <returns>value tuple containing both compartment strings</returns>
        public static (string firstCompartment, string secondCompartment) GetCompartments(string rucksack)
        {
            return (String.Join("", rucksack.Take(rucksack.Length / 2)), String.Join("", rucksack.TakeLast(rucksack.Length/2)));
        }

        /// <summary>
        /// Finds one shared item type between the two compartments of a rucksack
        /// </summary>
        /// <param name="rucksack">rucksack to search</param>
        /// <returns>a shared item type</returns>
        /// <exception cref="ArgumentException">when there are no shared items between the two compartments</exception>
        public static char FindSharedType(string rucksack)
        {
            (string firstCompartment, string secondCompartment) = GetCompartments(rucksack);
            //build set of items in first compartment
            HashSet<char> firstCompartmentItems = new();
            foreach (char item in firstCompartment)
            {
                firstCompartmentItems.Add(item);
            }

            //check second compartment for duplicate items
            foreach (char item in secondCompartment)
            {
                if (firstCompartmentItems.Contains(item))
                {
                    //duplicate item
                    return item;
                }
            }
            throw new ArgumentException("rucksack compartments should contain at least one shared item type between them");
        }

        /// <summary>
        /// gets the priority of a given item type
        /// </summary>
        /// <param name="item">item to check priority of</param>
        /// <returns>priority of item to check</returns>
        public static int GetTypePriority(char item)
        {
            //this isn't a very keystroke-efficient way to approach this, but the other solution I thought of being getting an index from a string would be much slower at runtime
            //maps lowercase types to their priorities
            Dictionary<char, int> lowPriorityMap = new()
            {
                { 'a', 1 },
                { 'b', 2 },
                { 'c', 3 },
                { 'd', 4 },
                { 'e', 5 },
                { 'f', 6 },
                { 'g', 7 },
                { 'h', 8 },
                { 'i', 9 },
                { 'j', 10 },
                { 'k', 11 },
                { 'l', 12 },
                { 'm', 13 },
                { 'n', 14 },
                { 'o', 15 },
                { 'p', 16 },
                { 'q', 17 },
                { 'r', 18 },
                { 's', 19 },
                { 't', 20 },
                { 'u', 21 },
                { 'v', 22 },
                { 'w', 23 },
                { 'x', 24 },
                { 'y', 25 },
                { 'z', 26 }
            };

            if (Char.IsUpper(item))
            {
                //uppercase types have priority of lowercase version plus 26
                return lowPriorityMap[Char.ToLower(item)] + 26;
            }

            return lowPriorityMap[item];
        }

        /// <summary>
        /// Finds one shared item type within a group of rucksacks.
        /// </summary>
        /// <param name="rucksacks">array of rucksack strings, where exactly one item type is shared between them</param>
        /// <returns>the item type shared between the rucksacks in the group</returns>
        /// <exception cref="ArgumentException">when the number of shared item types is not exactly 1</exception>
        public static char FindSharedItemInGroup(string[] rucksacks)
        {
            //track items common across all rucksacks
            HashSet<char> typesInAll = new();

            foreach (string rucksack in rucksacks)
            {
                HashSet<char> typesInThis = new(rucksack);

                if (!typesInAll.Any())
                {
                    //populate with contents of first rucksack
                    typesInAll = typesInThis;
                } else
                {
                    //take only items that are common
                    typesInAll.IntersectWith(typesInThis);
                }
            }

            if(typesInAll.Count != 1)
            {
                throw new ArgumentException("rucksacks must share exactly one type across all rucksacks");
            }

            return typesInAll.ToArray()[0];
        }
    }
}

/* Potential Improvements:
 *  - Rewrite Day 3 Part 1 code to use FindSharedItemsInGroup
 */
