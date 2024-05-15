public class Game
{
    private Board _board;
    private GameStatus _status;
    private int _points;
    public Game()
    {
        this._board = new Board();
        this._status = GameStatus.Idle;
        this._points = 0;
    }
    public int GetPoints()
    {
        return this._points;
    }
    protected void SetPoints(int points)
    {
        this._points = points;
    }
    public Board GetBoard() 
    {
        return this._board;
    }
    public GameStatus GetStatus()
    {
        return this._status;
    }
    /// <summary>
    /// the function receives the direction of the move and moves the player accordingly,
    /// updates _gamestatus according to if player won or lost
    /// </summary>
    /// <param name="direction">direciton of move - of type Direction</param>
    public void Move(Direction direction)
    {
        if (this._status != GameStatus.Loss)
        {
            int pointsGained = this._board.Move(direction);
            this._points += pointsGained;
            //checking if the player won
            if (this._status != GameStatus.Win && pointsGained >= Board.POINTS_TO_WIN && this._board.CheckIfWon())
            {
                this._status = GameStatus.Win;
            }
            //checking if the board is full, in case the board is full checking if the player lost
            else if (!this._board.AddRandomCell() && this._board.CheckIfPlayerLost())
            {
                this._status = GameStatus.Loss;
            }
        }

    }
}