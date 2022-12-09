while (true)
{
    Console.WriteLine("Input a datastream");
    string stream = Console.ReadLine()!;

    //slide 4 char window down the line
    for (int i = 0; i < stream.Length - 4; i++)
    {
        HashSet<char> window = stream.Skip(i).Take(4).ToHashSet();

        if (window.Count != 4) continue;
        Console.WriteLine(i + 4);
        break;
    }
}