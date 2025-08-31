using TicTacToe.Services.Abstract;

namespace TicTacToe.Services.Implementations;

public class StupidGameLogic : IGameLogic
{
    public int MakeTurn(int userIndex)
    {
        return (userIndex + 1) % 9;
    }
}