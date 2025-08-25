using System.Collections.ObjectModel;

namespace TicTacToe.Models;

public class MainWindowModel
{
    /// <summary>
    /// Game field
    /// </summary>
    public ObservableCollection<string> GameField = new ObservableCollection<string>()
    {
        "X0", "X1", "X2", "X3", "X4", "X5", "X6", "X7", "X8"
    };
}