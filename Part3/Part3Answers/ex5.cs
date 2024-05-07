public class Node
{
    private int _value;
    private Node _next;
    public Node(int value)
    {
        this._value = value;
        this._next = null;
    }
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