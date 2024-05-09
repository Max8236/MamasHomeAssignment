public class Board
{
    internal const int ROW_SIZE = 4;
    internal const int COL_SIZE = 4;
    internal const int POINTS_TO_WIN = 2048; //cell that you need to achieve in order to win is 2048
    private const int EMPTY_CELL = 0;
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
        this._data = new int[ROW_SIZE][];
        for(int row = 0; row < ROW_SIZE; row++)
        {
            this._data[row] = new int[COL_SIZE];
        }
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
    private List<KeyValuePair<int, int>> GetEmptyCells()
    {
        List<KeyValuePair<int, int>> cells = new List<KeyValuePair<int, int>>();
        for (int i = 0;i < ROW_SIZE; i++)
        {
            for (int j = 0;j < COL_SIZE;j++)
            {
                // cell is empty
                if (this._data[i][j] == EMPTY_CELL)
                {
                    cells.Add(new KeyValuePair<int, int>(i,j));
                }
            }
        }
        return cells;
    }
    public bool AddRandomCell()
    {
        List<KeyValuePair<int, int>> emptyCells = this.GetEmptyCells();
        // checking that dict isn't empty
        if (emptyCells.Count>0)
        {
            // adding cell with random value
            this._data[emptyCells.ElementAt(0).Key][emptyCells.ElementAt(0).Value] = Board.CELLS[rng.Next(CELLS.Length)];
            return true;
        }
        return false;
    }
    internal KeyValuePair<int, int> getIndexesForMove(Direction direction, int row, int col)
    {
        switch (direction)
        {
            case Direction.Up:
                return new KeyValuePair<int, int>(row - 1, col);
            case Direction.Down:
                return new KeyValuePair<int, int>(row + 1, col);
            case Direction.Left:
                return new KeyValuePair<int, int>(row, col - 1);
            case Direction.Right:
                return new KeyValuePair<int, int>(row, col + 1);
        }
        return new KeyValuePair<int, int>(0, 0);
    }
    private int swapCells(Direction direction, int row, int col)
    {
        int sum = 0;
        KeyValuePair<int, int> indexes = this.getIndexesForMove(direction, row, col);
        try
        {
            if (this._data[indexes.Key][indexes.Value] == this._data[row][col])
            {
                this._data[indexes.Key][indexes.Value] = this._data[row][col] * 2; // doubling the cell;
                this._data[row][col] = EMPTY_CELL;
                sum += this._data[indexes.Key][indexes.Value];
            }
            //swapping the empty cell with the cell to move everything in the dircetion
            else if(this._data[indexes.Key][indexes.Value] == EMPTY_CELL)
            {
                int temp = this._data[indexes.Key][indexes.Value];
                this._data[indexes.Key][indexes.Value] = this._data[row][col];
                this._data[row][col] = temp;
            }
        }
        catch (System.IndexOutOfRangeException)
        {
        }
        return sum;
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

        //trying to move all cells of the board in the direction requested
        for (int row = direction != Direction.Up ? 0 : ROW_SIZE - 1; direction != Direction.Up ? (row < ROW_SIZE) : (row >= 0); row += direction != Direction.Up ? 1 : -1)
        {
            for (int col = direction != Direction.Left ? 0 : COL_SIZE - 1; direction != Direction.Left ? (col < COL_SIZE) : (col >= 0); col += direction != Direction.Left ? 1 : -1)
            {
                try
                {
                    sum += swapCells(direction, row, col);
                }
                catch (System.IndexOutOfRangeException)
                {
                }
            }
        }
        return sum;
    }
    
    internal bool checkIfPlayerLost()
    {
        //checking if player can make a move on any cell to any direction - functions is used when board is full
        //no need to check for empty cells
        for (int row = 0; row < ROW_SIZE; row++)
        {
            for(int col = 0; col < COL_SIZE;col++)
            {
                for (Direction direction = 0; direction <= Direction.Right; direction++)
                    try
                    {
                        KeyValuePair<int, int> indexes = getIndexesForMove(direction,row, col);
                        if (this._data[row][col] == this._data[indexes.Key][indexes.Value])
                        {
                            return true;
                        }

                    }
                    catch (System.IndexOutOfRangeException)
                    {
                    }
            }
        }
            
        return false;
    }
    internal bool CheckIfWon()
    {
        for(int row = 0;row < ROW_SIZE; row++)
        {
            for(int col=0;col < COL_SIZE; col++)
            {
                if (this._data[row][col] == POINTS_TO_WIN)
                {
                    return true;
                }
            }
        }
        return false;
    }

}

