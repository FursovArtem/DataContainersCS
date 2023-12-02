using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BinaryTree.Tree;

namespace BinaryTree
{
    internal class Tree
    {
        public class Element
        {
            public int Data { get; set; }
            public Element Left { get; set; }
            public Element Right { get; set; }
            public Element(int data, Element left = null, Element right = null)
            {
                Data = data;
                Left = left;
                Right = right;
                Console.WriteLine($"EConstructor:\t{GetHashCode()}");
            }
            ~Element() { Console.WriteLine($"EDestructor:\t{GetHashCode()}"); }
        }
        protected Element Root { get; set; }
        public Tree()
        {
            Root = null;
            Console.WriteLine($"TConstructor:\t{GetHashCode()}");
        }
        public Tree(params int[] values) : this()
        {
            foreach (int i in values) Insert(i);
        }
        ~Tree() { Console.WriteLine($"TDestructor:\t{GetHashCode()}"); }
        public void Insert(int data)
        {
            Insert(data, Root);
        }
        void Insert(int data, Element root)
        {
            if (Root == null) Root = new Element(data);
            if (root == null) return;
            if (data < root.Data)
            {
                if (root.Left == null) root.Left = new Element(data);
                else Insert(data, root.Left);
            }
            else
            {
                if (root.Right == null) root.Right = new Element(data);
                else Insert(data, root.Right);
            }
        }
        public void Print()
        {
            Print(Root);
            Console.WriteLine();
        }
        void Print(Element root)
        {
            if (root == null) return;
            Print(root.Left);
            Console.Write(root.Data + "\t");
            Print(root.Right);
        }
        public int Min() => Min(Root);
        int Min(Element root)
        {
            if (root == null) throw new Exception("Tree is empty");
            return root.Left == null ? root.Data : Min(root.Left);
        }
        public int Max() => Max(Root);
        int Max(Element root)
        {
            if (root == null) throw new Exception("Tree is empty");
            return root.Right == null ? root.Data : Max(root.Right);
        }
        public int Sum() => Sum(Root);
        int Sum(Element root)
        {
            return root != null ? root.Data + Sum(root.Left) + Sum(root.Right) : 0;
        }
        public int Count() => Count(Root);
        int Count(Element root)
        {
            return root != null ? 1 + Count(root.Left) + Count(root.Right) : 0;
        }
        public double Average() => Average(Root);
        double Average(Element root)
        {
            return (double)Sum() / Count();
        }
        public int Depth() => Depth(Root);
        int Depth(Element root)
        {
            if (root == null) return 0;
            int l_depth = Depth(root.Left) + 1;
            int r_depth = Depth(root.Right) + 1;
            return l_depth > r_depth ? l_depth : r_depth;
        }
        public void Erase(int data) => Erase(data, Root, null);
        void Erase(int data, Element root, Element parent)
        {
            if (root == null) return;
            Erase(data, root.Left, root);
            Erase(data, root.Right, root);
            if (data == root.Data)
            {
                if (root.Left == root.Right)
                {
                    if (root.Equals(parent.Left)) parent.Left = null;
                    if (root.Equals(parent.Right)) parent.Right = null;
                }
                else
                {
                    if (Count(root.Left) > Count(root.Right))
                    {
                        root.Data = Max(root.Left);
                        Erase(Max(root.Left), root.Left, root);
                    }
                    else
                    {
                        root.Data = Min(root.Right);
                        Erase(Min(root.Right), root.Right, root);
                    }
                }
            }
        }
        public void Clear()
        {
            Root = null;
            GC.Collect(1);
        }
    }
}
