namespace TicTacToe.Models.Enums;

/// <summary>
/// AI turn result
/// </summary>
public enum AiTurnType
{
    /// <summary>
    /// Normal turn
    /// </summary>
    Normal,
    
    /// <summary>
    /// User won, I wouldn't put zero
    /// </summary>
    UserWon,
    
    /// <summary>
    /// I put zero and therefore won
    /// </summary>
    AiWon
}