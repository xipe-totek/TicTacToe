using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Models;
using TicTacToe.Models.Enums;
using TicTacToe.Services.Abstract;

namespace TicTacToe.ViewModels;

// 1) Create new class RealGameLogic, implementing IGameLogic (do not forget to inject IModelProvider into constructor and so on,
// see StupidGameLogic for example)
// 2) Register RealGameLogic as active implementation of IGameLogic (see Program.cs ConfigureServices())
// 3) Implement real game logic MakeTurn() method of RealGameLogic (you can create additional private methods in RealGameLogic if needed,
// but _do_not_ add anything to IGameLogic interface)

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
        SetGameFiledCell(index, CellContent.X); // User turn

        var aiTurnResult = _gameLogic.MakeTurn(index);
        
        if (aiTurnResult.Type == AiTurnType.UserWon)
        {
            // TODO: Add nice message
            throw new Exception("You won!");
        }
        else if (aiTurnResult.Type == AiTurnType.AiWon)
        {
            // TODO: Add nice message too
            throw new Exception("You lose!");
        }
        else
        {
            SetGameFiledCell(aiTurnResult.ZeroPosition, CellContent.O); // PC turn
        }
    }
    
    public bool CanExecuteGameButtonPressed(int index)
    {
        return _mainModel.GameField[index] == CellContent.Space;
    }

    private void SetGameFiledCell(int index, CellContent cellContent)
    {
        _mainModel.GameField[index] = cellContent;
        
        OnPropertyChanged(nameof(GameField));
        GameButtonPressedCommand.NotifyCanExecuteChanged();
    }
}