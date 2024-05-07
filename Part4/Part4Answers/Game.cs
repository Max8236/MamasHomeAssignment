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
    public void Move(Direction direction)
    {
        //todo
    }
}