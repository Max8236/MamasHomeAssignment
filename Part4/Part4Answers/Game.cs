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