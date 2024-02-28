namespace DR.Public.FM.WindowControl
{
  using System;
  using System.Windows;
  using System.Windows.Input;

  /// <summary>
  /// Window close command.
  /// </summary>
  /// <seealso cref="System.Windows.Input.ICommand" />
  public class WindowCloseCommand : ICommand
  {

    #region EVENT HANDLERS

    /// <summary>
    /// Occurs when changes occur that affect whether or not the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
    /// <returns>
    ///   <see langword="true" /> if this command can be executed; otherwise, <see langword="false" />.
    /// </returns>
    public bool CanExecute(object parameter)
    {
      return true;
    }

    /// <summary>
    /// Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
    public void Execute(object parameter)
    {
      if (parameter is Window window)
      {
        window.Close();
      }
    }

    #endregion

  }
}