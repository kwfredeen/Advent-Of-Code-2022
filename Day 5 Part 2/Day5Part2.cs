using Day_5_Part_1;

//build initial crate stacks
Console.WriteLine("Input Starting Crate Positions:");

List<Queue<char>> stacks = new();
while (true)
{
    string? line = Console.ReadLine();

    if (string.IsNullOrEmpty(line)) break;
    else if (!line.Contains('[')) continue;

    Day5Helpers.AddCrateLayer(stacks, line);
}

//remove extra spaces
Day5Helpers.StripEmptySpace(stacks);

//convert to stacks so we can move crates correctly
List<Stack<char>> stackedStacks = Day5Helpers.StacksFromQueues(stacks);

//execute all moves
while (true)
{
    string? line = Console.ReadLine();

    if (string.IsNullOrEmpty(line)) break;

    Day5Helpers.ExecuteMultiMove(stackedStacks, line);
}

//print top crate in each stack
foreach (Stack<char> stack in stackedStacks)
{
    Console.WriteLine(stack.Peek());
}

Console.WriteLine("done");

/* Potential Improvements:
 *  - cannot handle end states where stacks are empty. Should be a simple change if it were needed.
 */
