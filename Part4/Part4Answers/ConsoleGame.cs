public class ConsoleGame
{
    private Game _game;
    public ConsoleGame()
    {
        this._game = new Game();
    }
    public void PrintBoard()
    {
        Console.Clear();
        int[][] boardData = this._game.getBoard().getData();
        for(int row = 0; row < Board.ROW_SIZE; row++)
        {
            for(int col = 0; col < Board.COL_SIZE; col++)
            {
                Console.Write(boardData[row][col].ToString() + " "); 
            }
            Console.WriteLine("");
        }
    }
    //thread?
    public Direction InputNextMove()
    {
        Console.WriteLine("Press Arrow Key:");
        var key = Console.ReadKey().Key;
        Console.WriteLine(key);
        while(key != ConsoleKey.UpArrow && key != ConsoleKey.DownArrow && key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow)
        {
            key = Console.ReadKey().Key;
        }
        switch(key)
        {
            case ConsoleKey.UpArrow:
                return Direction.Up;
            case ConsoleKey.DownArrow:
                return Direction.Down;
            case ConsoleKey.LeftArrow:
                return Direction.Left;
        }
        return Direction.Right;
    }
    public void Run()
    {
        while(this._game.GetStatus() != GameStatus.Loss)
        {
            this.PrintBoard();
            this._game.Move(this.InputNextMove());
        }
        Console.Write("Player Lost!");
    }
}