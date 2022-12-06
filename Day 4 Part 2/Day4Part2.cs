using Day_4_Part_1;

int completeoverlappedCount = 0;

while (true)
{
    string? line = Console.ReadLine();

    if (string.IsNullOrEmpty(line))
    {
        Console.WriteLine($"Count: {completeoverlappedCount}");
        continue;
    }

    //split the two ranges
    string[] sectionRanges = line.Split(',');

    string rangeString1 = sectionRanges[0];
    string rangeString2 = sectionRanges[1];

    //parse section range strings into section range arrays
    int[] rangeArray1 = Day4Helpers.ParseSection(rangeString1);
    int[] rangeArray2 = Day4Helpers.ParseSection(rangeString2);

    if (Day4Helpers.CheckAnySectionOverlap(rangeArray1, rangeArray2))
    {
        completeoverlappedCount++;
    }
}

