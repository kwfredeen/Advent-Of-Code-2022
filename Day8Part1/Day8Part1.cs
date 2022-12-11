using Day_8_Part_1;

TreeGrid trees = new();

while (true)
{
    string line = Console.ReadLine();

    if (String.IsNullOrEmpty(line))
    {
        trees.Look();
        Console.WriteLine(trees.CountVisible());
    }

    trees.AddRow(line);
}