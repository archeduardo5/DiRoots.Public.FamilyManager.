namespace DR.Public.FM.Models
{
  using System;
  using System.Windows.Input;

  /// <summary>
  /// Non Generic Implementation of a CommandBase
  /// </summary>
  public class CommandBase : ICommand
  {
    #region PRIVATE MEMBERS

    /// <summary>
    /// The action to be executed.
    /// </summary>
    private readonly Action _execute;

    /// <summary>
    /// Can action be executed.
    /// </summary>
    private readonly Predicate<object> _canExecute;

    #endregion

    #region CONSTRUCTOR

    /// <summary>
    /// Default constructor.
    /// Initializes a new instance of the <see cref="CommandBase"/> class.
    /// </summary>
    /// <param name="execute">The execute.</param>
    /// <param name="canExecute">The can execute.</param>
    /// <exception cref="NullReferenceException">execute</exception>
    public CommandBase(Action execute, Predicate<object> canExecute = null)
    {
      _execute = execute ?? throw new NullReferenceException(nameof(execute));
      _canExecute = canExecute ?? (_ => true);
    }

    #endregion

    #region EVENTS

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
    /// <returns><see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.</returns>
    public bool CanExecute(object parameter = null) => _canExecute(parameter);

    /// <summary>
    /// Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
    public void Execute(object parameter) => _execute();

    #endregion

  }
}
