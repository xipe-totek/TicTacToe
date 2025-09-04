using TicTacToe.Models;

namespace TicTacToe.Services.Abstract;

/// <summary>
/// Game logic
/// </summary>
public interface IGameLogic
{
    /// <summary>
    /// Call this when user made a turn
    /// </summary>
    /// <param name="userIndex">User put X here</param>
    /// <returns>AI put O here</returns>
    AiTurnResult MakeTurn(int userIndex);
}