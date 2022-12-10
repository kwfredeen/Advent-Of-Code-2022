using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7_Part_1
{
    public enum FileType
    {
        Directory,
        File
    }

    /// <summary>
    /// Represents a file on the elves' device
    /// </summary>
    public class ElvenFile
    {
        /// <summary>
        /// size of the file
        /// </summary>
        public int size;
        /// <summary>
        /// name of the file
        /// </summary>
        public string name;

        public List<ElvenFile> children = new();

        public ElvenFile Parent;

        public FileType Type;

        /// <summary>
        /// Creates a new file with itself as the parent, use for root.
        /// </summary>
        /// <param name="size">size of the file</param>
        /// <param name="name">name of the file</param>
        public ElvenFile(int size, string name)
        {
            Type = FileType.Directory;
            this.size = size;
            this.name = name;
            this.Parent = this;
        }

        /// <summary>
        /// Creates a new file in the specified folder
        /// </summary>
        /// <param name="size">size of the file</param>
        /// <param name="name">name of the file</param>
        /// <param name="parent">file this file is inside</param>
        public ElvenFile(int size, string name, FileType type, ElvenFile parent)
        {
            this.Type = type;
            this.size=size;
            this.name=name;
            Parent = parent;
        }



        /// <summary>
        /// Add a file to the children of this file. If a file with the name exists already, replaces it.
        /// </summary>
        /// <param name="file">file to add</param>
        public void AddFile(ElvenFile file)
        {
            children.RemoveAll(x => x.name == file.name);
            children.Add(file);
        }

        /// <summary>
        /// Get child file that has matching name. Only one child must have a matching name
        /// </summary>
        /// <param name="name">name of file to find</param>
        /// <returns>file with given name</returns>
        /// <exception cref="Exception">If number of matching files is not 1 exactly</exception>
        public ElvenFile GoToChildFile(string name)
        {
            List<ElvenFile> matches = this.children.Where(file => file.name == name).ToList();

            if (matches.Count == 0) throw new Exception("No files of that name found!");
            else if (matches.Count > 1) throw new Exception("More than one file matches given name!");

            return matches[0];
        }

        /// <summary>
        /// Gets Total Size of file and all children files.
        /// </summary>
        /// <returns>Total size of file and children files</returns>
        public int getTotalSize()
        {
            int totalSize = size;

            //sum all children's files too
            foreach (ElvenFile file in children)
            {
                totalSize += file.getTotalSize();
            }

            return totalSize;
        }

        public List<ElvenFile> GetChildDirsWithMaxSize(int maxSize)
        {
            List<ElvenFile> metThreshold = new();

            //get all children that are directories
            List<ElvenFile> childDirs = children.Where(dir => dir.Type == FileType.Directory).ToList();

            foreach (ElvenFile childDir in childDirs)
            {
                metThreshold.AddRange(childDir.GetChildDirsWithMaxSize(maxSize));
            }

            int thisSize = this.getTotalSize();
            if (thisSize <= maxSize) metThreshold.Add(this);

            return metThreshold;
        }

        public List<ElvenFile> GetChildDirsWithMinSize(int minSize)
        {
            List<ElvenFile> metThreshold = new();

            //get all children that are directories
            List<ElvenFile> childDirs = children.Where(dir => dir.Type == FileType.Directory).ToList();

            foreach (ElvenFile childDir in childDirs)
            {
                metThreshold.AddRange(childDir.GetChildDirsWithMinSize(minSize));
            }

            int thisSize = this.getTotalSize();
            if (thisSize >= minSize) metThreshold.Add(this);

            return metThreshold;
        }
    }
}
