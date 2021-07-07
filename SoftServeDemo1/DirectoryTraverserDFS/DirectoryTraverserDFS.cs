using System;
using System.IO;

namespace DirectoryTraverserDFS
{

    /// <summary>Sample class, which traverses recursively given directory, 
    /// based on the Depth-First Search(DFS) algorithm</summary>
    public static class DirectoryTraverserDFS
    {
        /// <summary>Traverses and prints given directory recursively</summary>
        /// <param name="dir">the directory to be traversed</param>
        /// /// <param name="spaces">the spaces used for representation
        /// of the parent-child relation</param>
        private static void TraverseDirectory(DirectoryInfo dir, string spaces)
        {
            // Visit the current directory
            Console.WriteLine(spaces + dir.FullName);
            DirectoryInfo[] children = dir.GetDirectories();

            // For each child go and visit its subtree
            foreach (DirectoryInfo child in children)
            {
                TraverseDirectory(child, spaces + " ");
            }
        }


        /// <summary>Traverses and prints given directory recursively</summary>
        /// <param name="directoryPath">the path to the directory being traversed</param>
        public static void TraverseDir(string directoryPath) =>
            TraverseDirectory(new DirectoryInfo(directoryPath), string.Empty);
    }

}
