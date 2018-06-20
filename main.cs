// STEP1 - create a base Node class
// repersents the nodes of the BT
//contains a Node class and a NodeList class
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

        // member varialbe of data of type T
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
// The class also provides a constructor that creates a specified number of 
// nodes in the collection + a method that searches the collection for an 
// element of a particular value.
public class NodeList<T> : Collection<Node<T>>
{
    public NodeList() : base() { }

    public NodeList(int initialSize)
    {
        // Add the specified number of items
        for (int i = 0; i < initialSize; i++)
            base.Items.Add(default(Node<T>));
    }

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