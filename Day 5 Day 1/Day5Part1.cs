using Day_5_Part_1;

Console.WriteLine("Input Starting Crate Positions:");

List<Queue<char>> stacks = new();
while (true)
{
    string? line = Console.ReadLine();

    if (string.IsNullOrEmpty(line)) break;
    else if (!line.Contains('[')) continue;

    Day5Helpers.AddCrateLayer(stacks, line);
}
