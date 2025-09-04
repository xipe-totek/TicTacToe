using System;
using TicTacToe.Models.Enums;

namespace TicTacToe.Models;

public class AiTurnResult
{
    /// <summary>
    /// AI will put (if will) zero here
    /// </summary>
    public int ZeroPosition { get; }
    
    /// <summary>
    /// AI will do this type of turn
    /// </summary>
    public AiTurnType Type { get; }

    public AiTurnResult
    (
        int zeroPosition,
        AiTurnType type
    )
    {
        if (zeroPosition < 0 || zeroPosition > 8)
        {
            throw new ArgumentOutOfRangeException(nameof(zeroPosition), "Invalid zero position!");
        }
        
        ZeroPosition = zeroPosition;
        Type = type;
    }
}