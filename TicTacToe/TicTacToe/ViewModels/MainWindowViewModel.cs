using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Models;
using TicTacToe.Models.Enums;
using TicTacToe.Services.Abstract;

namespace TicTacToe.ViewModels;

// 1) Invent a new type, which can hold only 3 values, corresponding to space, X and 0 (hint: read about enums)
// 2) Switch model to this new data type (hint: change ObservableCollection data type)
// 3) Modify proxy (i.e. GameField in MainWindowViewModel) next way:
// 3.1) Convert invented at 1) data type to string (hint: put code into get)
// 3.2) Convert incoming string values to invented at 1) data type (hint: put code into set) 

public partial class MainWindowViewModel : ViewModelBase
{
    #region DI
    
    private readonly IGameLogic _gameLogic = Program.Di.GetService<IGameLogic>();

    #endregion
    
    private MainWindowModel _mainWindowModel;

    #region Binbale variables
    
    #region Game field
    
    public List<string> GameField
    {
        get
        {
            return _mainWindowModel
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

    public MainWindowViewModel
    (
        MainWindowModel model
    )
    {
        _mainWindowModel = model ?? throw new ArgumentNullException(nameof(model));
    }
    
    [RelayCommand(CanExecute = nameof(CanExecuteGameButtonPressed))]
    public void GameButtonPressed(int index)
    {
        SetGameFiledCell(index, CellContent.X); // User turn
        SetGameFiledCell(_gameLogic.MakeTurn(index), CellContent.O); // PC turn
    }
    
    public bool CanExecuteGameButtonPressed(int index)
    {
        return _mainWindowModel.GameField[index] == CellContent.Space;
    }

    private void SetGameFiledCell(int index, CellContent cellContent)
    {
        _mainWindowModel.GameField[index] = cellContent;
        
        OnPropertyChanged(nameof(GameField));
        GameButtonPressedCommand.NotifyCanExecuteChanged();
    }
}