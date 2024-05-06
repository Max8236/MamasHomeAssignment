public class LinkedList
{
    private Node _head;
    
    public void append(int num)
    {
        Node tempHead = _head;
        if (tempHead != null )
        {
            while (tempHead.getNext() != null)
            {
                tempHead = tempHead.getNext();
            }
            tempHead.setNext(new Node(num));
        }
        else
        {
            this._head = new Node(num);
        }
    }
    public void prepend(int num)
    {
        Node newHead = new Node(num,this._head);
        this._head = newHead;
    }
    public int pop()
    {
        if (this._head != null )
        {
            Node tempHead = _head;
            Node lastNode = tempHead;

            while (tempHead.getNext() != null)
            {
                lastNode = tempHead;
                tempHead = tempHead.getNext();
            }
            lastNode.setNext(null);
            return tempHead.getValue();
        }
        return 0;
       
    }
    public int unqueue()
    {
        if(this._head != null )
        {
            Node tempHead = _head;
            this._head = this._head.getNext();
            return tempHead.getValue();
        }
        return 0;
       
    }
    public IEnumerable<int> toList() 
    {
        IEnumerable<int> list = new List<int>();
        Node tempHead = this._head;
        while (tempHead != null)
        {
            list.Append(tempHead.getValue());
            tempHead = tempHead.getNext();
        }
        return list;
    }
    public bool isCircular()
    {
        if (this._head != null)
        {
            Node tempHead = this._head;
            while(tempHead != null)
            {
                tempHead = tempHead.getNext();
                if (tempHead == this._head)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void sort()
    {
        // to do
    }
    public Node getMaxNode()
    {

        Node tempHead = this._head;
        Node max = tempHead;
        while (tempHead != null)
        {
            if(tempHead.getValue() > max.getValue())
            {
                max = tempHead;
            }
            tempHead = tempHead.getNext();
        }
        return max;


    }
}