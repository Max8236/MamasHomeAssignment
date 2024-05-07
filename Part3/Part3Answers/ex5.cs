public class Node
{
    private int _value;
    private Node _next;
    /// <summary>
    /// Constructor for node class
    /// receives a int value and creates a new node pointing to null with that value received
    /// </summary>
    /// <param name="value">the value of the node</param>
    public Node(int value)
    {
        this._value = value;
        this._next = null;
    }
    /// <summary>
    /// Constructor for node class
    /// receives a int value and a node to point to, and creates a new node pointing to the node received with that value received
    /// </summary>
    /// <param name="value">the value of the node</param>
    /// <param name="next">the next node to point to</param>
    public Node(int value, Node next)
    {
        this._value = value; 
        this._next = next;
    }
    public void SetValue(int value)
    {
        this._value = value;
    }
    public int GetValue()
    {
        return this._value;
    }
    public void SetNext(Node next)
    {
            this._next = next;
    }
    public Node GetNext()
    {
        return this._next;
    }

}