using System.Collections.Generic;
using System.Collections.ObjectModel;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models;

public class MainWindowModel
{
    /// <summary>
    /// Game field
    /// </summary>
    public List<CellContent> GameField =
    [
        CellContent.Space, CellContent.Space, CellContent.Space,
        CellContent.Space, CellContent.Space, CellContent.Space,
        CellContent.Space, CellContent.Space, CellContent.Space
    ];
}