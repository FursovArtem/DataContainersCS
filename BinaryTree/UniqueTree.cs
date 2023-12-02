using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class UniqueTree : Tree
    {
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
            else if (data > root.Data)
            {
                if (root.Right == null) root.Right = new Element(data);
                else Insert(data, root.Right);
            }
        }
    }
}
