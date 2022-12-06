using Day_3_Part_1;

int badgePriorities = 0;

string[] groupRucksacks = new string[3];
int groupCount = 0;

while (true)
{
    string? rucksack = Console.ReadLine();
    if (rucksack == null || rucksack == "")
    {
        Console.WriteLine($"Total Priorities: {badgePriorities}");
        continue;
    }

    //add rucksack to group
    groupRucksacks[groupCount] = rucksack;
    groupCount++;
    
    //check if we have a full group
    if(groupCount == 3)
    {
        badgePriorities += Day3Helpers.GetTypePriority(Day3Helpers.FindSharedItemInGroup(groupRucksacks));

        //reset for next group
        Array.Clear(groupRucksacks);
        groupCount = 0;
    }

}
