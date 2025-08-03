using System;
using System.Reactive;
using ReactiveUI;
using TicTacToe.Models;

namespace TicTacToe.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private MainWindowModel _mainWindowModel;
    
    #region Binbale variables
    
    #region CountValue
    
    public int CountValue
    {
        get => _mainWindowModel.CountValue;

        set => this.RaiseAndSetIfChanged(ref _mainWindowModel.CountValue, value);
    }

    #endregion
    
    #endregion

    #region Commands
    
    public ReactiveCommand<Unit, Unit> OnButtonCommand { get; }
    
    public ReactiveCommand<Unit, Unit> OnCountButtonCommand { get; }
    
    #endregion

    public MainWindowViewModel
    (
        MainWindowModel model
    )
    {
        _mainWindowModel = model ?? throw new ArgumentNullException(nameof(model));

        var canExecuteCountCommand = this.WhenAnyValue
        (
            x => x.CountValue,
            cv => cv < 10
        );
        
        OnCountButtonCommand = ReactiveCommand.Create(OnCountButtonPressed, canExecuteCountCommand);
    }
    
    private void OnCountButtonPressed()
    {
        CountValue ++;
    }

}