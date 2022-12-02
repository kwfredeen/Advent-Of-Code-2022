//https://adventofcode.com/2022/day/1#part2
//similar to part 1, but take total of top 3 instead of top 1 

int[] top3Elves = {0, 0, 0};

//the current elf's calories
int elfSum = 0;
//read console input
while (true)
{
    string? line = Console.ReadLine();

    //check if this elf has no more snacks (or the next elf has started recording)
    if (line is null || line == "")
    {
        //check if this elf has more calories than smallest top elf
        int smallestTopElf = top3Elves.Min();
        if(elfSum > smallestTopElf)
        {
            //replace smallest with this elf
            int smallestIndex = Array.IndexOf(top3Elves, smallestTopElf);
            top3Elves[smallestIndex] = elfSum;
        }

        //report the top 3 elves' individual calories
        Console.WriteLine($"Top 3: {String.Join(",", top3Elves)}");
        //report the sum of the top 3 elves' calories
        Console.WriteLine($"Top 3 Total Calories: {top3Elves.Sum()}");

        //reset elf sum and move onto the next elf with food
        elfSum = 0;
        continue;
    }

    //elf still has snacks, add calories of next snack
    elfSum += int.Parse(line);
}

/* Potential improvements:
 *  - repeating from part 1:
 *     - Last line needs user to press enter twice manually. This could be fixed.
 *     - Add built in commands to reset, quit
 *  - DRY day one code into 1 function counting any number of top elves, where part 1 calls the function
 *    for 1 top elf and part 2 calls the function for 3 top elves
 *     - This will require much more testing given any number of top elves can be asked for.
 */
