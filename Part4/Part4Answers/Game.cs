public class Game
{
    private Board _board;
    private GameStatus _status;
    private int _points;
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
    public void Move(Direction direction)
    {
        if (this._status != GameStatus.Loss)
        {
            this._points = this._board.Move(direction);
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