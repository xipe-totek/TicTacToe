using TicTacToe.Models;

namespace TicTacToe.Services.Abstract;

/// <summary>
/// Use it to get models
/// </summary>
public interface IModelProvider
{
    /// <summary>
    /// Returns a model
    /// </summary>
    MainModel GetModel();
}