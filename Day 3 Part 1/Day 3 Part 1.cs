using Day_3_Part_1;

int duplicatePriorities = 0;

while (true)
{
    string? rucksack = Console.ReadLine();
    if (rucksack == null || rucksack == "")
    {
        Console.WriteLine($"Total Priorities: {duplicatePriorities}");
        continue;
    }

    duplicatePriorities += Day3Helpers.GetTypePriority(Day3Helpers.FindSharedType((string)rucksack));

}