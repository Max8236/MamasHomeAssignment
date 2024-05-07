public class LinkedList
{
    private Node _head;
    /// <summary>
    /// The function receives a number and adds a new node containing the number received to the end of the list
    /// </summary>
    /// <param name="num">the number to add</param>
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
    /// <summary>
    /// The function receives a number and adds a new node containing the number received to the beginning of the list
    /// </summary>
    /// <param name="num">the number to add</param>
    public void Prepend(int num)
    {
        Node newHead = new Node(num,this._head);
        this._head = newHead;
    }
    /// <summary>
    /// The function removes the last node from the list and returns its number
    /// </summary>
    /// <returns>The value that was stored in the last node</returns>
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
    /// <summary>
    /// The function removes a node from the beginning of the list and returns the number that was stored in it
    /// </summary>
    /// <returns>the number that was stored in the node that was removed</returns>
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
    /// <summary>
    /// The function returns A IEnumerable<int> object containing the values inside the list
    /// </summary>
    /// <returns> the list object containing the list items</returns>
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
    /// <summary>
    /// the function check if the list is circular and returns a Boolean value accordingly
    /// </summary>
    /// <returns>a Boolean value indicating if the list is circular</returns>
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
    /// <summary>
    /// The function sorts the list by going through each node in the list and checking if there is a smaller node
    /// if such node is found the function swaps the values stored inside the nodes - the function run through the entire
    /// list each time, meaning it will assign the smallest possible number at the current position
    /// binary sort could have been used to make
    /// the algorithm more efficient and quicker, but using it would have made the code consume more memory
    /// </summary>
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
    /// <summary>
    /// The function searches for the node with the biggest value stored in it and returns that node
    /// </summary>
    /// <returns>the node holding the max value in the list</returns>
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
    /// <summary>
    /// The function searches for the node with the smallest value stored in it and returns that node
    /// </summary>
    /// <returns>the node holding the min value in the list</returns>
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
    }
}