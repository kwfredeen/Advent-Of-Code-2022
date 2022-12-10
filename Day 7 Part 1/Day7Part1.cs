using Day_7_Part_1;

ElvenFile rootFile = new(0, "/");
ElvenFile currentFile = rootFile;

while (true)
{
    string line = Console.ReadLine();

    if (String.IsNullOrEmpty(line))
    {
        continue;
    } else if (line == "compute")
    {
        List<ElvenFile> smallDirs = rootFile.GetChildDirsWithMaxSize(100000);
        Console.WriteLine(smallDirs.Select(dir => dir.getTotalSize()).Sum());
        continue;
    }

    //parts of the line
    string[] parts = line.Split(' ');

    if (parts[0] == "$")
    {
        string command = parts[1];
        if (command == "cd")
        {
            //change directories
            string target = parts[2];

            currentFile = target switch
            {
                "/" => rootFile,
                ".." => currentFile.Parent,
                _ => currentFile.GoToChildFile(target)
            };
            
        } else if (command == "ls")
        {
            //do nothing for ls
        }
    } else
    {
        //add files, size based on type
        if(parts[0] == "dir")
        {
            ElvenFile newFolderFile = new(0, parts[1], FileType.Directory, currentFile);
            currentFile.AddFile(newFolderFile);
        } else
        {
            int size = int.Parse(parts[0]);
            ElvenFile newFile = new(size, parts[1], FileType.File, currentFile);
            currentFile.AddFile(newFile);
        }
    }
}