//https://adventofcode.com/2022/day/1

//most calories held by any elf
int mostCalories = 0;

//the current elf's calories
int elfSum = 0;
//read console input
while (true)
{
    string? line = Console.ReadLine();

    //check if this elf has no more snacks (or the next elf has started recording)
    if(line is null || line == "")
    {
        //check if this elf has the most calories
        if (elfSum > mostCalories) mostCalories = elfSum;

        //report which elf has the most calories
        Console.WriteLine($"Most Calories: {mostCalories}");

        //reset elf sum and move onto the next elf with food
        elfSum = 0;
        continue;
    }

    //elf still has snacks, add calories of next snack
    elfSum += int.Parse(line);
}

/* Potential improvements:
 *  - Last line needs user to press enter twice manually. This could be fixed.
 *  - Add built in commands to reset, quit
 */