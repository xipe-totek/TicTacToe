using TicTacToe.Models;
using TicTacToe.Services.Abstract;

namespace TicTacToe.Services.Implementations;

public class ModelProvider : IModelProvider
{
    public MainModel GetModel()
    {
        return MainModel.Create();
    }
}