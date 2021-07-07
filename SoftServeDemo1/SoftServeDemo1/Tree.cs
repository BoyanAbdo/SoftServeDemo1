using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftServeDemo1
{
    /// <summary>Represents a tree data structure</summary>
    /// <typeparam name="T">the type of the values in the tree</typeparam>
    public class Tree<T>
    {
        // The root of the tree
        private TreeNode<T> root;

        // Keeping the record of all added employees for easy access in future
        public List<T> listOfItems { get; private set; } = new List<T>();


        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the node</param>
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = new TreeNode<T>(value);

            // Keeping a record of every item added
            listOfItems.Add(value);
        }


        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the root node</param>
        /// <param name="children">the children of the root node</param>
        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);

                // Adding the record of every subtree
                listOfItems.AddRange(child.listOfItems);
            }
        }

        /// <summary>Get the root node or null if the tree is empty</summary>
        public TreeNode<T> Root => this.root;


        /// <summary>Traverses and prints tree in Depth First Search (DFS) order</summary>
        /// <param name="root">the root of the tree to be traversed</param>
        /// <param name="spaces">the spaces used for representation of the parent-child relation</param>
        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + "  ");
            }
        }


        /// <summary>Public method that calls the private one for traversing
        /// and printing tree in Depth-First Search (DFS) order</summary>
        public void PrintDFS() => this.PrintDFS(this.root, string.Empty);



        /// <summary>
        /// The lowest common ancestor between two nodes n1 and n2 is defined as the lowest node 
        /// in T that has both n1 and n2 as descendants (where we allow a node to be a descendant of itself)
        /// </summary>
        /// <param name="numA">Node n1</param>
        /// <param name="numB">Node n2</param>
        public void PrintLCA(T numA, T numB)
        {
            // let's assume every node has a unique value
            List<T> pathA = this.FindPathToNodeWithLoops(this.root, numA);
            Console.WriteLine("Path to Number A is: " + string.Join(", ", pathA));

            List<T> pathB = this.FindPathToNodeWithLoops(this.root, numB);
            Console.WriteLine("Path to Number B is: " + string.Join(", ", pathB));

            int length1 = pathA.Count();
            int length2 = pathB.Count();

            object lca = null;
            for (int i = 0; i < Math.Min(length1, length2); i++)
            {
                if (pathA.ElementAt(i).Equals(pathB.ElementAt(i)))
                {
                    lca = pathA.ElementAt(i);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Lowest Common Ancestor of {numA} and {numB} is: {lca}.");
        }

        // Naive approach (by calculating root to node path recursevely: Not yet fully implemented
        private List<T> FindPathToNode(TreeNode<T> root, T numA)
        {
            if (this.root == null)
            {
                return null;
            }

            List<T> path = new List<T>();

            if (root.Value.Equals(numA))
            {
                path.Add(root.Value);
                return path;
            }

            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                List<T> pathToAdd = FindPathToNode(child, numA);
                if (pathToAdd.Contains(numA))
                {
                    path.AddRange(pathToAdd);
                }
            }
            return path;
        }

        /// <summary>
        /// Finds the path from the root to the given node
        /// </summary>
        /// <param name="root">the root of the tree or subtree</param>
        /// <param name="numA">the node value of the searched item</param>
        /// <returns>List<T> path with the items from the root</returns>
        private List<T> FindPathToNodeWithLoops(TreeNode<T> root, T numA)
        {
            if (this.root == null)
            {
                return null;
            }

            List<T> path = new List<T>();
            path.Add(root.Value);

            if (root.Value.Equals(numA))
            {
                return path;
            }


            // Iteration for Depth 1
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                TreeNode<T> childDepth1 = root.GetChild(i);

                if (childDepth1.Value.Equals(numA))
                {
                    path.Add(childDepth1.Value);
                    return path;
                }


                // Iteration for Depth 2
                for (int j = 0; j < childDepth1.ChildrenCount; j++)
                {
                    TreeNode<T> childDepth2 = childDepth1.GetChild(j);

                    if (childDepth2.Value.Equals(numA))
                    {
                        path.Add(childDepth1.Value);
                        path.Add(childDepth2.Value);
                        return path;
                    }


                    // Iteration for Depth 3
                    for (int k = 0; k < childDepth2.ChildrenCount; k++)
                    {
                        TreeNode<T> childDepth3 = childDepth2.GetChild(k);

                        if (childDepth3.Value.Equals(numA))
                        {
                            path.Add(childDepth1.Value);
                            path.Add(childDepth2.Value);
                            path.Add(childDepth3.Value);
                            return path;
                        }
                    }
                }
            }

            return path;
        }

    }
}
