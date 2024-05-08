public class Board
{
    private const int ROW_SIZE = 4;
    private const int COL_SIZE = 4;
    private static int[] CELLS = { 2, 4 }; //const?
    private Random rng = new Random();
    private int[][] _data;
    public int[][] getData()
    {
        return this._data;
    }
    protected void setData(int[][] data)
    {
        this._data = data;
    }
    public Board()
    {
        this.InitializeBoard();
    }
    /// <summary>
    /// The function initializes the board with 2 random cells with the values of 2/4 at a random position
    /// </summary>
    public void InitializeBoard()
    {
        //first random cell
        int first_row = rng.Next(ROW_SIZE);
        int first_col = rng.Next(COL_SIZE);
        // second random cell
        int second_row = rng.Next(ROW_SIZE);
        int second_col = rng.Next(COL_SIZE);
        while (second_row == first_row)
        {
            second_row = rng.Next(ROW_SIZE); // making sure the second cell is at a different position from the first cell
        }
        this._data[first_row][first_col] = Board.CELLS[rng.Next(CELLS.Length)];
        this._data[second_row][second_col] = Board.CELLS[rng.Next(CELLS.Length)];

    }
    private IDictionary<int, int> GetEmptyCells()
    {
        IDictionary<int, int> cells = new Dictionary<int, int>();
        for (int i = 0;i < ROW_SIZE; i++)
        {
            for (int j = 0;j < COL_SIZE;j++)
            {
                // cell is empty
                if (this._data[i][j] == 0)
                {
                    cells.Add(i,j);
                }
            }
        }
        return cells;
    }
    private bool AddRandomCell()
    {
        IDictionary<int, int> emptyCells = this.GetEmptyCells();
        // checking that dict isn't empty
        if (emptyCells.Count>0)
        {
            // adding cell with random value
            this._data[emptyCells.ElementAt(0).Key][emptyCells.ElementAt(0).Value] = Board.CELLS[rng.Next(CELLS.Length)];
            return true;
        }
        return false;
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
        int sum = 0; // sum of points gained

        switch (direction)
        {
            case Direction.Up:
                break;
            case Direction.Down:
                break;
            case Direction.Left:
                break;
            case Direction.Right:
                break;
        }
        return sum;
    }
}
