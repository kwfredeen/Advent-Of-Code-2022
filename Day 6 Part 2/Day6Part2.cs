while (true)
{
    Console.WriteLine("Input a datastream");
    string stream = Console.ReadLine()!;

    //slide 4 char window down the line
    for (int i = 0; i < stream.Length - 14; i++)
    {
        HashSet<char> window = stream.Skip(i).Take(14).ToHashSet();

        if (window.Count != 14) continue;
        Console.WriteLine(i + 14);
        break;
    }
}

/* Potential Improvements
 *  - Move sliding window code to own function, with generalized input for a window of any size
 */
