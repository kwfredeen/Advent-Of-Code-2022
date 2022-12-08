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

        /// <summary>
        /// Removes empty crates (spaces) from stacks
        /// </summary>
        /// <param name="stacks">stacks to remove spaces from</param>
        public static void StripEmptySpace(List<Queue<char>> stacks)
        {
            foreach(Queue<char> stack in stacks)
            {
                while(stack.Peek() == ' ')
                {
                    //remove the space
                    _ = stack.Dequeue();
                }
            }
        }

        /// <summary>
        /// Executes a move command on stacks of crates.
        /// </summary>
        /// <param name="stacks">stacks to move</param>
        /// <param name="move">move command</param>
        public static void ExecuteMove(List<Stack<char>> stacks, string move)
        {
            var command = ParseMoveCommand(move);

            for(int i = 0; i < command.cratesToMove; i++)
            {
                Stack<char> destinationStack = stacks[command.to - 1];
                Stack<char> sourceStack = stacks[command.from - 1];
                destinationStack.Push(sourceStack.Pop());
            }
        }

        /// <summary>
        /// Parses a move command into number of crates to move, and source and destination stacks
        /// </summary>
        /// <param name="command">crane move command to parse</param>
        /// <returns>Value tuple with number of crates to move, and to and from stack numbers</returns>
        private static (int cratesToMove, int from, int to) ParseMoveCommand(string command)
        {
            List<int> commandNumbers = AllNumbersinString(command);
            
            return (commandNumbers[0], commandNumbers[1], commandNumbers[2]);
        }

        /// <summary>
        /// Converts Queue representation of stacks (for construction) to Stacks representation (for moving)
        /// </summary>
        /// <param name="stackQueues">stacks as a list of queues</param>
        /// <returns>stacks as a list of stacks</returns>
        public static List<Stack<char>> StacksFromQueues(List<Queue<char>> stackQueues)
        {
            List<Stack<char>> stackStacks = new();

            foreach(Queue<char> stack in stackQueues)
            {
                stackStacks.Add(new Stack<char>(stack.Reverse()));
            }

            return stackStacks;
        }

        /// <summary>
        /// Parses every number present in a string
        /// </summary>
        /// <param name="str">string to extract numbers from, where all numbers are positive integers</param>
        /// <returns>List of positive ints found in the string</returns>
        private static List<int> AllNumbersinString(string str)
        {
            List<int> allnumbers = new();

            bool inNumber = false;
            string currentNumber = "";
            foreach(char c in str)
            {
                if (Char.IsDigit(c))
                {
                    inNumber = true;
                    currentNumber += c;
                } else if (inNumber)
                {
                    allnumbers.Add(int.Parse(currentNumber));
                    inNumber = false;
                    currentNumber = "";
                }
            }

            //in case last char was part of a number
            if (inNumber)
            {
                allnumbers.Add(int.Parse(currentNumber));
            }

            return allnumbers;
        }
    }
}
