using Day_2_Part_1;

int totalScore = 0;

while (true)
{
    string? line = Console.ReadLine();

    if (line is null || line == "q" || line == "")
    {
        //quit
        Console.WriteLine($"Score: {totalScore}");
        break;
    } else if (line == "r")
    {
        //reset
        Console.WriteLine($"Score: {totalScore}");
        totalScore = 0;
        continue;
    }

    string[] splitLine = line.Split(" ", 2);
    string opponent = splitLine[0];
    string you = splitLine[1];

    totalScore += Day2Helpers.RoundScore(opponent, you);
}

Console.WriteLine("Goodbye. Press enter to exit");
//pause to let user read output
Console.ReadLine();

/* Potential improvements:
 *  - these quit commands feel clunky and could be improved.
 */  