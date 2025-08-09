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
    
    #region Count Direction

    private bool _isIncrement;
    
    public bool IsIncrement
    {
        get => _isIncrement;

        set => this.RaiseAndSetIfChanged(ref _isIncrement, value);
    }
    
    #endregion
    
    #endregion

    #region Commands
    
    public ReactiveCommand<Unit, Unit> OnCountButtonCommandPlus { get; }
    public ReactiveCommand<Unit, Unit> OnCountButtonCommandMinus { get; }
    
    public ReactiveCommand<Unit, Unit> DoActionCommand { get; }
    
    #endregion

    public MainWindowViewModel
    (
        MainWindowModel model
    )
    {
        _mainWindowModel = model ?? throw new ArgumentNullException(nameof(model));

        var canExecuteCountCommandPlus = this.WhenAnyValue
        (
            x => x.CountValue,
            cv => cv < 10
        );

        var canExecuteCountCommandMinus = this.WhenAnyValue
        (x => x.CountValue,
            cv => cv > -10
        );
        
        OnCountButtonCommandPlus = ReactiveCommand.Create(OnCountButtonPressedPlus, canExecuteCountCommandPlus);
        OnCountButtonCommandMinus = ReactiveCommand.Create(OnCountButtonPressedMinus, canExecuteCountCommandMinus);
        DoActionCommand = ReactiveCommand.Create(OnDoActionCommand);
    }
    
    private void OnCountButtonPressedPlus()
    {
        CountValue ++;
        IsIncrement = true;
    }
    
    private void OnCountButtonPressedMinus()
    {
        CountValue --;
        IsIncrement = false;
    }

    private void OnDoActionCommand()
    {
        if (IsIncrement)
        {
            CountValue++;
        }
        else
        {
            CountValue--;
        }
    }

}