using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Models;
using TicTacToe.Models.Enums;
using TicTacToe.Services.Abstract;

namespace TicTacToe.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    #region DI
    
    private readonly IGameLogic _gameLogic = Program.Di.GetService<IGameLogic>();
    private readonly MainModel _mainModel = Program.Di.GetService<IModelProvider>().GetModel();

    #endregion

    #region Binbale variables
    
    #region Game field
    
    public List<string> GameField
    {
        get
        {
            return _mainModel
                .GameField
                .Select(cc => cc switch
                {
                    CellContent.Space => " ",
                    CellContent.X => "X",
                    CellContent.O => "0",
                    _ => throw new ArgumentOutOfRangeException()
                })
                .ToList();
        }
    }
    
    #endregion

    #endregion
    
    [RelayCommand(CanExecute = nameof(CanExecuteGameButtonPressed))]
    public void GameButtonPressed(int index)
    {
        var aiTurnResult = _gameLogic.MakeTurn(index);
        
        OnPropertyChanged(nameof(GameField));
        GameButtonPressedCommand.NotifyCanExecuteChanged();
        
        if (aiTurnResult == AiTurnType.UserWon)
        {
            // TODO: Add nice message
            throw new Exception("You won!");
        }
        else if (aiTurnResult == AiTurnType.AiWon)
        {
            // TODO: Add nice message too
            throw new Exception("You lose!");
        }
    }
    
    public bool CanExecuteGameButtonPressed(int index)
    {
        return _mainModel.GameField[index] == CellContent.Space;
    }
}