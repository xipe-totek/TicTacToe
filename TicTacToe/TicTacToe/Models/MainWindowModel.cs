using System.Collections.ObjectModel;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models;

public class MainWindowModel
{
    /// <summary>
    /// Game field
    /// </summary>
    public ObservableCollection<CellContent> GameField = new ObservableCollection<CellContent>()
    {
        CellContent.Space, CellContent.Space, CellContent.Space, 
        CellContent.Space, CellContent.Space, CellContent.Space, 
        CellContent.Space, CellContent.Space, CellContent.Space
    };
}