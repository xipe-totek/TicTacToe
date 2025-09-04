using System.Collections.Generic;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models;

public class MainModel
{
    /// <summary>
    /// We store MainModel object here
    /// </summary>
    private static MainModel? _model = null;
    
    /// <summary>
    /// Game field
    /// </summary>
    public List<CellContent> GameField =
    [
        CellContent.Space, CellContent.Space, CellContent.Space,
        CellContent.Space, CellContent.Space, CellContent.Space,
        CellContent.Space, CellContent.Space, CellContent.Space
    ];

    private MainModel()
    {
    }

    /// <summary>
    /// Call me to get model object
    /// If you call me again, I'll return you already created object
    /// </summary>
    public static MainModel Create()
    {
        return _model ??= new MainModel(); // Short form of: return _model ?? (_model = new MainModel())
    }
}