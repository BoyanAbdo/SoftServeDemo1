using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftServeDemo1._1
{
    /// <summary>Represents a tree data structure</summary>
    /// <typeparam name="Employee">the type of the values in the tree</typeparam>
    public class Tree<Employee>
    {
        // The root of the tree
        private TreeNode<Employee> root;

        // Keeping the record of all added employees for easy access in future
        public List<Employee> listOfEmployees { get; private set; } = new List<Employee>();

        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the node</param>
        public Tree(Employee value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.root = new TreeNode<Employee>(value);

            // Keeping a record of every added employee
            listOfEmployees.Add(value);
        }


        /// <summary>Constructs the tree</summary>
        /// <param name="value">the value of the root node</param>
        /// <param name="children">the children of the root node</param>
        public Tree(Employee value, params Tree<Employee>[] children)
            : this(value)
        {
            foreach (Tree<Employee> child in children)
            {
                this.root.AddChild(child.root);

                // Adding the record of every subtree
                listOfEmployees.AddRange(child.listOfEmployees);
            }
        }

        /// <summary>Get the root node or null if the tree is empty</summary>
        public TreeNode<Employee> Root => this.root;


        /// <summary>Traverses and prints tree in Depth First Search (DFS) order</summary>
        /// <param name="root">the root of the tree to be traversed</param>
        /// <param name="spaces">the spaces used for representation of the parent-child relation</param>
        private void PrintDFS(TreeNode<Employee> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }


            Console.WriteLine(spaces + root.Value.ToString());

            TreeNode<Employee> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + "  ");
            }
        }


        /// <summary>Public method that calls the private one for traversing
        /// and printing tree in Depth First Search (DFS) order</summary>
        public void PrintDFS() => this.PrintDFS(this.root, string.Empty);



        /// <summary>
        /// The lowest common ancestor between two nodes n1 and n2 is defined as the lowest node 
        /// in T that has both n1 and n2 as descendants (where we allow a node to be a descendant of itself).
        /// </summary>
        /// <param name="employeeA">Node n1</param>
        /// <param name="employeeB">Node n2</param>
        public void PrintLCA(Employee employeeA, Employee employeeB)
        {
            // every node of the tree has an unique value
            List<Employee> pathA = this.FindPathToNodeWithLoops(this.root, employeeA);
            Console.WriteLine("Path to Number A is: \n" + string.Join(";+\n", pathA));
            Console.WriteLine();

            List<Employee> pathB = this.FindPathToNodeWithLoops(this.root, employeeB);
            Console.WriteLine("Path to Number B is: \n" + string.Join(";+\n", pathB));

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
            Console.WriteLine($"Lowest Common Ancestor of {employeeA.ToString()} and {employeeB.ToString()} is: {lca.ToString()}.");
        }

        // Naive approach (by calculating root to node path recursevely: Not yet fully implemented
        private List<Employee> FindPathToNode(TreeNode<Employee> root, Employee numA)
        {
            if (this.root == null)
            {
                return null;
            }

            List<Employee> path = new List<Employee>();

            if (root.Value.Equals(numA))
            {
                path.Add(root.Value);
                return path;
            }

            TreeNode<Employee> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                List<Employee> pathToAdd = FindPathToNode(child, numA);
                if (pathToAdd.Contains(numA))
                {
                    path.AddRange(pathToAdd);
                }
            }
            return path;
        }


        /// <summary>
        /// Finds the path from the root to the given employee
        /// </summary>
        /// <param name="root">the root of the tree or subtree</param>
        /// <param name="employee">the node value of the searched item</param>
        /// <returns>List<Employee> path with the items from the root</returns>
        private List<Employee> FindPathToNodeWithLoops(TreeNode<Employee> root, Employee employee)
        {
            if (this.root == null)
            {
                return null;
            }

            List<Employee> path = new List<Employee>();

            Employee currentEmployee = root.Value;
            path.Add(currentEmployee);

            if (root.Value.Equals(employee))
            {
                return path;
            }


            // Iteration for Depth 1
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                TreeNode<Employee> childDepth1 = root.GetChild(i);

                if (childDepth1.Value.Equals(employee))
                {
                    path.Add(childDepth1.Value);
                    return path;
                }


                // Iteration for Depth 2
                for (int j = 0; j < childDepth1.ChildrenCount; j++)
                {
                    TreeNode<Employee> childDepth2 = childDepth1.GetChild(j);

                    if (childDepth2.Value.Equals(employee))
                    {
                        path.Add(childDepth1.Value);
                        path.Add(childDepth2.Value);
                        return path;
                    }


                    // Iteration for Depth 3
                    for (int k = 0; k < childDepth2.ChildrenCount; k++)
                    {
                        TreeNode<Employee> childDepth3 = childDepth2.GetChild(k);

                        if (childDepth3.Value.Equals(employee))
                        {
                            path.Add(childDepth1.Value);
                            path.Add(childDepth2.Value);
                            path.Add(childDepth3.Value);
                            return path;
                        }


                        // Iteration for Depth 4
                        for (int l = 0; l < childDepth3.ChildrenCount; l++)
                        {
                            TreeNode<Employee> childDepth4 = childDepth3.GetChild(l);

                            if (childDepth4.Value.Equals(employee))
                            {
                                path.Add(childDepth1.Value);
                                path.Add(childDepth2.Value);
                                path.Add(childDepth3.Value);
                                path.Add(childDepth4.Value);
                                return path;
                            }


                            // Iteration for Depth 5
                            for (int m = 0; m < childDepth4.ChildrenCount; m++)
                            {
                                TreeNode<Employee> childDepth5 = childDepth4.GetChild(m);

                                if (childDepth5.Value.Equals(employee))
                                {
                                    path.Add(childDepth1.Value);
                                    path.Add(childDepth2.Value);
                                    path.Add(childDepth3.Value);
                                    path.Add(childDepth4.Value);
                                    path.Add(childDepth5.Value);
                                    return path;
                                }
                            }
                        }
                    }
                }
            }

            return path;
        }




    }
}
