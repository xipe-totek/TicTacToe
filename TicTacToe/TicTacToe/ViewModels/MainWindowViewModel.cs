using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using TicTacToe.Models;

namespace TicTacToe.ViewModels;

// 1) Invent a new type, which can hold only 3 values, corresponding to space, X and 0 (hint: read about enums)
// 2) Switch model to this new data type (hint: change ObservableCollection data type)
// 3) Modify proxy (i.e. GameField in MainWindowViewModel) next way:
// 3.1) Convert invented at 1) data type to string (hint: put code into get)
// 3.2) Convert incoming string values to invented at 1) data type (hint: put code into set) 

public partial class MainWindowViewModel : ViewModelBase
{
    private MainWindowModel _mainWindowModel;

    #region Binbale variables
    
    #region Game field
    
    public ObservableCollection<string> GameField
    {
        get
        {
            return _mainWindowModel.GameField;
        }

        set
        {
            _mainWindowModel.GameField = value;
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
        GameField[index] = "!";
        
        GameButtonPressedCommand.NotifyCanExecuteChanged();
    }
    
    public bool CanExecuteGameButtonPressed(int index)
    {
        return GameField[index] != "!";
    }
}