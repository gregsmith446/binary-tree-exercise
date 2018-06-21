// create a binary tree in C#

// STEP1 - create a base Node class
// contains a Node class and a NodeList class
public class Node<T>
    // Private member-variables
        private T data; 
        // neighbors, aka children, initially set = null 
        private NodeList<T> neighbors = null;

        // Node instance = the node's chidren
        public Node() {}
        public Node(T data) : this(data, null) {}
        public Node(T data, NodeList<T> neighbors)
        {
            this.data = data;
            this.neighbors = neighbors;
        }

        // member variable of data type <T>
        public T Value
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        // member variable for the Node's children
        protected NodeList<T> Neighbors
        {
            get
            {
                return neighbors;
            }
            set
            {
                neighbors = value;
            }
        }
    }
}

// STEP 1.5 - ADD CONSTRUCTORS AND PUBLIC PROPERTIES
// the NodeList class IS derived from the Collection<T> class
// The Collection<T> class is DERVIED from the System.Collections.Generics namespace. 
// Collection<T> class provides the base functionality for methods:
// Add(T), Remove(T), and Clear(), & properties: Count and default indexer.
public class NodeList<T> : Collection<Node<T>>
{
    public NodeList() : base() { }

    public NodeList(int initialSize)
    {
        // Add the specified number of items
        for (int i = 0; i < initialSize; i++)
            base.Items.Add(default(Node<T>));
    }

    // the collections class also contains:
    // A constructor that creates a specified number of nodes 
    // in the collection + a method that searches the collection for an 
    // element of a particular value.
    public Node<T> FindByValue(T value)
    {
        // search the list for the value
        foreach (Node<T> node in Items)
            if (node.Value.Equals(value))
                return node;

        // if we reached here, we didn't find a matching node
        return null;
    }
}

// STEP 2 - Extend the Base Node Class
public class BinaryTreeNode<T> : Node<T>
{
    public BinaryTreeNode() : base() {}
    public BinaryTreeNode(T data) : base(data, null) {}
    public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
    {
        base.Value = data;
        NodeList<T> children = new NodeList<T>(2);
        children[0] = left;
        children[1] = right;

        base.Neighbors = children;
    }

    public BinaryTreeNode<T> Left
    {
        get
        {
            if (base.Neighbors == null)
                return null;
            else
                return (BinaryTreeNode<T>) base.Neighbors[0];
        }
        set
        {
            if (base.Neighbors == null)
                base.Neighbors = new NodeList<T>(2);

            base.Neighbors[0] = value;
        }
    }

    public BinaryTreeNode<T> Right
    {
        get
        {
            if (base.Neighbors == null)
                return null;
            else
                return (BinaryTreeNode<T>) base.Neighbors[1];
        }
        set
        {
            if (base.Neighbors == null)
                base.Neighbors = new NodeList<T>(2);

            base.Neighbors[1] = value;
        }
    }
}

// STEP 3 - Creating the BinaryTree Class
// only contains the var root and a Clear() method
// root is a private member var, of type BTN and = the root of the BT

public class BinaryTree<T>
{
   private BinaryTreeNode<T> root;

   public BinaryTree()
   {
      root = null;
   }

   public virtual void Clear()
   {
      root = null;
   }

   public BinaryTreeNode<T> Root
   {
      get
      {
         return root;
      }
      set
      {
         root = value;
      }
   }
}

// STEP 4 - create the contents of the binary tree, 
// using this format:
// the image binaryTree.gif is a visual of the BT created by this exact code!

// 1.) Create binary tree instance
BinaryTree<int> btree = new BinaryTree<int>();

// 2.) Create root of BT
btree.Root = new BinaryTreeNode<int>(1);
// 3.) Add 2 BTN instances for the L and R children
btree.Root.Left = new BinaryTreeNode<int>(2);
btree.Root.Right = new BinaryTreeNode<int>(3);

// 4.) To add more node instances, use btree.Root.Left or Right
// Then use btree.Root.Left.Left or Right.Right, to give each node instance a L, R, or LR 
btree.Root.Left.Left = new BinaryTreeNode<int>(4);
btree.Root.Right.Right = new BinaryTreeNode<int>(5);

btree.Root.Left.Left.Right = new BinaryTreeNode<int>(6);
btree.Root.Right.Right.Right = new BinaryTreeNode<int>(7);

btree.Root.Right.Right.Right.Right = new BinaryTreeNode<int>(8);
