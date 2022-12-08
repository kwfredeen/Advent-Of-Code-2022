using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_Part_1
{
    public class Day5Helpers
    {
        /// <summary>
        /// Adds a layer to a sequence of stacks, mutating it.
        /// </summary>
        /// <param name="stacks">list of crates to add, where [0] is the first stack [1] is second, etc</param>
        /// <param name="layerString">layer to add, as a seuence of either four spaces or [X] with a space after.</param>
        public static void AddCrateLayer(List<Queue<char>> stacks, string layerString)
        {
            List<char> layerList = ParseLayerStringToList(layerString);

            for(int i = 0; i < layerList.Count; i++)
            {
                char crate = layerList[i];

                if (stacks.Count <= i)
                {
                    //we don't have enough stacks
                    stacks.Add(new());
                }

                //include spaces
                stacks[i].Enqueue(crate);
            }
        }

        /// <summary>
        /// parses a layer string into a list where the index is the stack the crate is in.
        /// </summary>
        /// <param name="layer">string representing the layer</param>
        /// <returns>List representing the layer. Contains the contents of the crate or ' ' if there was no crate</returns>
        public static List<char> ParseLayerStringToList(string layer)
        {
            List<char> levelList = new();

            for (int i = 0; i < layer.Length; i += 4)
            {
                //take next 4 characters, this should contain the next crate, if any
                string stack = layer.Substring(i, Math.Min(4, layer.Length - i));

                char crate;
                if (String.IsNullOrEmpty(stack.Trim()))
                {
                    //no crate, insert a space
                    crate = ' ';
                } else
                {
                    //filter to just the crate contents
                    crate = stack.Where(c => Char.IsUpper(c)).First();
                }
                levelList.Insert(i / 4, crate);
            }

            return levelList;
        }
    }
}
