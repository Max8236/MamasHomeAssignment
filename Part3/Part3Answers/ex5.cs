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
    public void setValue(int value)
    {
        this._value = value;
    }
    public int getValue()
    {
        return this._value;
    }
    public void setNext(Node next)
    {
            this._next = next;
    }
    public Node getNext()
    {
        return this._next;
    }

}