public class LinkedList
{
    private Node _head;
    
    public void Append(int num)
    {
        Node tempHead = _head;
        if (tempHead != null )
        {
            while (tempHead.GetNext() != null)
            {
                tempHead = tempHead.GetNext();
            }
            tempHead.SetNext(new Node(num));
        }
        else
        {
            this._head = new Node(num);
        }
    }
    public void Prepend(int num)
    {
        Node newHead = new Node(num,this._head);
        this._head = newHead;
    }
    public int Pop()
    {
        if (this._head != null )
        {
            Node tempHead = _head;
            Node lastNode = tempHead;

            while (tempHead.GetNext() != null)
            {
                lastNode = tempHead;
                tempHead = tempHead.GetNext();
            }
            lastNode.SetNext(null);
            return tempHead.GetValue();
        }
        return 0;
       
    }
    public int Unqueue()
    {
        if(this._head != null )
        {
            Node tempHead = _head;
            this._head = this._head.GetNext();
            return tempHead.GetValue();
        }
        return 0;
       
    }
    public IEnumerable<int> ToList() 
    {
        IEnumerable<int> list = new List<int>();
        Node tempHead = this._head;
        while (tempHead != null)
        {
            list.Append(tempHead.GetValue());
            tempHead = tempHead.GetNext();
        }
        return list;
    }
    public bool IsCircular()
    {
        if (this._head != null)
        {
            Node tempHead = this._head;
            while(tempHead != null)
            {
                tempHead = tempHead.GetNext();
                if (tempHead == this._head)
                {
                    return true;
                }
            }
        }
        return false;
    } 
    public void Sort()
    {
        Node itterationNode = this._head;
        while (itterationNode != null)
        {
            Node currNode = itterationNode.GetNext();
            while (currNode != null)
            {
                if (currNode.GetValue() < itterationNode.GetValue())
                {
                    //swapping nodes values
                    int temp = itterationNode.GetValue();
                    itterationNode.SetValue(currNode.GetValue());
                    currNode.SetValue(temp);
                }
                currNode = currNode.GetNext();
            }
            itterationNode = itterationNode.GetNext();
        }
    }
    public Node GetMaxNode()
    {

        Node tempHead = this._head;
        Node max = tempHead;
        while (tempHead != null)
        {
            if(tempHead.GetValue() > max.GetValue())
            {
                max = tempHead;
            }
            tempHead = tempHead.GetNext();
        }
        return max;
    }

    public Node GetMinNode()
    {

        Node tempHead = this._head;
        Node min = tempHead;
        while (tempHead != null)
        {
            if (tempHead.GetValue() < min.GetValue())
            {
                min = tempHead;
            }
            tempHead = tempHead.GetNext();
        }
        return min;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NumericalExpression test = new NumericalExpression(213213);
        Console.WriteLine(test.ToString());
        Console.WriteLine(NumericalExpression.SumLetters(11111111).ToString());
    }
}