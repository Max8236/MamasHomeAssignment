public class Board
{
    private const int ROW_SIZE = 4;
    private const int COL_SIZE = 4;
    private int[][] _data;
    public int[][] getData()
    {
        return this._data;
    }
    protected void setData(int[][] data)
    {
        this._data = data;
    }
    /// <summary>
    /// The function initializes the board with 2 random cells with the values of 2/4 at a random position
    /// </summary>
    public void InitializeBoard()
    {
        //todo
    }
    /// <summary>
    /// The function receives a direction to move the board to, tries to move the cells accordingly
    /// the function add a random cell with the value of 2/4 at a random position
    /// nd returns the points gained from the current move
    /// </summary>
    /// <param name="direction">the direction to move at</param>
    /// <returns>the amount of points gained from the move</returns>
    public int Move(Direction direction)
    {
        //todo
        return 0;
    }
}
