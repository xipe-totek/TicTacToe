namespace TicTacToe.Models;

public class MainWindowModel
{
    /// <summary>
    /// Game field width
    /// </summary>
    public const int Width = 3;
    
    /// <summary>
    /// Game field height
    /// </summary>
    public const int Height = 3;
    
    /// <summary>
    /// Game field
    /// </summary>
    public string[,] GameField = new string[Height, Width];
    
    /// <summary>
    /// How many times user pressed the button
    /// </summary>
    public int CountValue;
}