using TicTacToe.Models;
using TicTacToe.Models.Enums;
using TicTacToe.Services.Abstract;

namespace TicTacToe.Services.Implementations;

public class StupidGameLogic : IGameLogic
{
    private readonly MainModel _mainModel;

    public StupidGameLogic
    (
        IModelProvider modelProvider
    )
    {
        _mainModel = modelProvider.GetModel();
    }
    
    public AiTurnResult MakeTurn(int userIndex)
    {
        var zeroCandidate = (userIndex + 1) % 9;

        if (_mainModel.GameField[zeroCandidate] != CellContent.Space)
        {
            return new AiTurnResult(0, AiTurnType.UserWon);
        }

        return new AiTurnResult(zeroCandidate, AiTurnType.Normal);
    }
}