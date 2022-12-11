using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8_Part_1
{
    public class TreeGrid
    {
        public List<List<int>> Grid;
        public List<List<bool>> IsVisible;

        /// <summary>
        /// Creates an empty tree grid
        /// </summary>
        public TreeGrid()
        {
            Grid = new List<List<int>>();
            IsVisible = new List<List<bool>>();
        }

        /// <summary>
        /// Converts a row string into a row list
        /// </summary>
        /// <param name="rowString">string to parse</param>
        /// <returns>list of trees, in same order as in string</returns>
        private List<int> ParseRowString(string rowString)
        {
            List<int> row = new();

            foreach (char tree in rowString)
            {
                row.Add(int.Parse(tree.ToString()));
            }

            return row;
        }

        /// <summary>
        /// Adds a row of trees to the grid
        /// </summary>
        /// <param name="rowString">row to add</param>
        public void AddRow(string rowString)
        {
            List<int> newRow = ParseRowString(rowString);

            Grid.Add(newRow);

            IsVisible.Add(newRow.Select(t => false).ToList());
        }

        /// <summary>
        /// Looks across rows and colums in both directions and determines what trees are and are not visible
        /// </summary>
        public void Look()
        {
            //look along rows
            for(int y = 0; y < Grid.Count; y++)
            {
                var row = Grid[y];
                int largest = 0;
                //look right
                for(int x = 0; x < row.Count; x++)
                {
                    int tree = row[x];

                    //first tree is automatically added
                    if (tree > largest || x == 0)
                    {
                        IsVisible[y][x] = true;
                        largest = tree;
                    }
                }

                //look left
                //this could definitely be done inside the right loop, but I broke it out for clarity's sake
                largest = 0;
                for (int x = row.Count - 1; x >= 0; x--)
                {
                    int tree = row[x];
                    //first tree is automatically added
                    if (tree > largest || x == row.Count - 1)
                    {
                        IsVisible[y][x] = true;
                        largest = tree;
                    } 
                }
            }

            //look around colums
            for(int x = 0; x < Grid.Select(row => row.Count).Min(); x++)
            {
                int largest = 0;
                //look down
                for(int y = 0; y < Grid.Count; y++)
                {
                    int tree = Grid[y][x];
                    //first tree is automatically added
                    if (tree > largest || y == 0)
                    {
                        IsVisible[y][x] = true;
                        largest = tree;
                    }
                }

                //look up
                largest = 0;
                
                for (int y = Grid.Count - 1; y >= 0; y--)
                {
                    int tree = Grid[y][x];
                    //first tree is automatically added
                    if (tree > largest || y == Grid.Count - 1)
                    {
                        IsVisible[y][x] = true;
                        largest = tree;
                    } 
                }
            }
        }

        public int CountVisible()
        {
            int visibleTrees = 0;

            foreach(var row in IsVisible)
            {
                foreach (bool tree in row)
                {
                    visibleTrees += tree ? 1 : 0;
                }
            }

            return visibleTrees;
        }
    }
}

/* Potential improvements
 *  - Can set largest to -1 to before every look direction in Look() to avoid the index check in each if
 */
