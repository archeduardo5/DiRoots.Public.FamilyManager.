namespace DR.Public.FM.ViewModels
{
  using System.Windows;
  using System.ComponentModel;
  using System.Runtime.CompilerServices;
  
  using Models;

  /// <summary>
  /// Provides the base functionality of a view model.
  /// Implements the <see cref="System.ComponentModel.INotifyPropertyChanged" />
  /// </summary>
  /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
  public abstract class ViewModelBase : INotifyPropertyChanged
  {

    #region INotifyPropertyChanged INTERFACE

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Notify that property has changed.
    /// </summary>
    /// <param name="property">The property.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    #endregion

    /// <summary>
    /// The model ActiveWindow
    /// </summary>
    protected Window ModelWindow;

    /// <summary>
    /// Gets the ok command.
    /// </summary>
    /// <value>
    /// The ok command.
    /// </value>
    public CommandBase OkCommand => new CommandBase(Execute, CanProceed);

    #region ABSTRACT METHODS

    /// <summary>
    /// Executes this instance.
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Determines whether this instance can proceed the specified object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>
    ///   <c>true</c> if this instance can proceed the specified object; otherwise, <c>false</c>.
    /// </returns>
    public abstract bool CanProceed(object obj);

    #endregion
  }
}
