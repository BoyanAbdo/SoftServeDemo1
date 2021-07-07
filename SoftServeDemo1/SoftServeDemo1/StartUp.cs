using System;

namespace SoftServeDemo1
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Creating a tree with int values
            Tree<int> tree =
                new Tree<int>(18,
                    new Tree<int>(41,
                        new Tree<int>(10),
                        new Tree<int>(2),
                        new Tree<int>(31)),
                    new Tree<int>(12,
                        new Tree<int>(22,
                            new Tree<int>(8),
                            new Tree<int>(5))),
                    new Tree<int>(16,
                        new Tree<int>(37),
                        new Tree<int>(9))
                );


            // Traversing and printing the tree using Depth-First Search
            tree.PrintDFS();
            Console.WriteLine();

            // Reading two numbers to find their Lowest Common Ancestor (LCA)
            Console.WriteLine("Enter two numbers to find their Lowest Common Ancestor (LCA):");
            Console.Write("Number A: ");
            int numA = int.Parse(Console.ReadLine());
            Console.Write("Number B: ");
            int numB = int.Parse(Console.ReadLine());
            Console.WriteLine();


            if (tree.listOfItems.Contains(numA) && tree.listOfItems.Contains(numB))
            {
                // Printing the paths and LCA of the two given nums
                tree.PrintLCA(numA, numB);
            }
            else
            {
                Console.WriteLine("Numbers not found!");
                Console.WriteLine("Please enter valid numbers from the tree structure above.");
            }

        }
    }
}
