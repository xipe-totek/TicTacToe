using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Models;
using TicTacToe.Models.Enums;
using TicTacToe.Services.Abstract;

namespace TicTacToe.Services.Implementations;

public class RandomGameLogic : IGameLogic
{
    private readonly MainModel _mainModel;

    /// <summary>
    /// Player-agnostic win conditions
    /// </summary>
    private readonly IReadOnlyCollection<WinCondition> _winConditions = new List<WinCondition>()
    {
        new(0, 1, 2),
        new(3, 4, 5),
        new(6, 7, 8),
        new(0, 3, 6),
        new(1, 4, 7),
        new(2, 5, 8),
        new(0, 4, 8),
        new(6, 4, 2)
    };

    public RandomGameLogic
    (
        IModelProvider modelProvider
    )
    {
        _mainModel = modelProvider.GetModel();

        // Win conditions count
        if (_winConditions.Count != 8)
        {
            throw new InvalidOperationException("There are exactly 8 win conditions!");
        }

        // Win conditions uniqueness
        if
        (
            _winConditions
                .DistinctBy(wc => (wc.A, wc.B, wc.C))
                .Count()
            != _winConditions.Count
        )
        {
            throw new InvalidOperationException("Some duplicates are detected!");
        }
    }
    
    public AiTurnType MakeTurn(int userIndex)
    {
        _mainModel.GameField[userIndex] = CellContent.X;

        // Is user won?
        if (IsWon(_mainModel.GameField, true))
        {
            return AiTurnType.UserWon;
        }
        
        // AI decided that User didn't won
        
        // TODO: Check if it possible to put 0 at all?
        
        // AI will put zero to zeroCandidate position
        var random = new Random();
        var zeroCandidate = random.Next(0, 8);
        
        while (_mainModel.GameField[zeroCandidate] != CellContent.Space)
        {
            zeroCandidate = random.Next(0, 8);
        }
        
        _mainModel.GameField[zeroCandidate] = CellContent.O;
        
        if (IsWon(_mainModel.GameField, false))
        {
            return AiTurnType.AiWon;
        }

        return AiTurnType.Normal;
    }

    /// <summary>
    /// Check if someone won?
    /// </summary>
    /// <param name="gameField">Game field (abstract, we don't know from where did it came)</param>
    /// <param name="isUser">If true then search for X'es, otherwise of 0's</param>
    /// <returns>True if won</returns>
    private bool IsWon(List<CellContent> gameField, bool isUser)
    {
        var toCheck = isUser ? CellContent.X : CellContent.O;

        return _winConditions
            .Any
            (
                wc
                =>
                gameField[wc.A] == toCheck
                &&
                gameField[wc.B] == toCheck
                &&
                gameField[wc.C] == toCheck
            );
    }
}