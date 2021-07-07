using System;
using System.Collections.Generic;

namespace SoftServeDemo1._1
{
    // Tree Nodes as Employees only

    public class TreeNode<Employee>
    {
        // Contains the value of the node
        private Employee value;

        // Shows whether the current node has a parent
        private bool hasParent;

        // Contains the children of the node
        private List<TreeNode<Employee>> children;


        /// <summary>Constructs a tree node</summary>
        /// <param name="value">the value of the node</param>
        public TreeNode(Employee value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.value = value;
            this.children = new List<TreeNode<Employee>>();
        }


        /// <summary>The value of the node</summary>
        public Employee Value
        {
            get => this.value;
            set => this.value = value;
        }

        /// <summary>The count of node's children</summary>
        public int ChildrenCount => this.children.Count;


        /// <summary>Adds child to the node</summary>
        /// <param name="child">the child to be added</param>
        public void AddChild(TreeNode<Employee> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }


        /// <summary>Gets the child of the node at given index</summary>
        /// <param name="index">the index of the desired child</param>
        /// <returns>the child on the given position</returns>
        public TreeNode<Employee> GetChild(int index)
        {
            return this.children[index];
        }
    }
}
