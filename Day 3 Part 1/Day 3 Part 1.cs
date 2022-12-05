using Day_3_Part_1;

string testString = "vJrwpWtwJgWrhcsFMMfFFhFp";
Console.WriteLine(Day3Helpers.GetCompartments(testString));
Console.WriteLine(Day3Helpers.FindSharedType(testString));
Console.WriteLine(Day3Helpers.GetTypePriority('a'));
Console.WriteLine(Day3Helpers.GetTypePriority('z'));
Console.WriteLine(Day3Helpers.GetTypePriority('A'));
Console.WriteLine(Day3Helpers.GetTypePriority('Z'));

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