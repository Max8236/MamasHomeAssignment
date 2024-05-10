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
    public int getPoints()
    {
        return this._points;
    }
    protected void setPoints(int points)
    {
        this._points = points;
    }
    public Board getBoard() 
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
            this._points = this._board.Move(direction);
            if(this._status != GameStatus.Win && this._points >= Board.POINTS_TO_WIN && this._board.CheckIfWon())
            {
                this._status = GameStatus.Win;
            }
            if (!this._board.AddRandomCell())
            {
                if(this._board.checkIfPlayerLost())
                {
                    this._status = GameStatus.Loss;
                }
            }
        }

    }
}