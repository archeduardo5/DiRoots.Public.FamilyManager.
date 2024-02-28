namespace DR.Public.FM.ViewModels
{
  using System.Linq;
  
  using Helpers;
  using Models;

  /// <summary>
  /// Folder Control user control view model
  /// </summary>
  /// <seealso cref="DR.Public.FM.ViewModels.ViewModelBase" />
  public class FolderControlViewModel : ViewModelBase
  {

    #region PRIVATE MEMBERS

    /// <summary>
    /// The file
    /// </summary>
    private CustomFileInfo _file;

    /// <summary>
    /// The parent main ActiveWindow
    /// </summary>
    private MainWindowViewModel _parentMainWindow;

    #endregion

    #region PUBLIC PROPERTIES

    /// <summary>
    /// Gets or sets the folder control.
    /// </summary>
    /// <value>
    /// The folder control.
    /// </value>
    public FolderControl FolderControl { get; set; }
    /// <summary>
    /// Gets or sets the file.
    /// </summary>
    /// <value>
    /// The file.
    /// </value>
    public CustomFileInfo File
    {
      get => _file;
      set
      {
        _file = value;
        OnPropertyChanged();
      }
    }

    /// <summary>
    /// Gets the remove command.
    /// </summary>
    /// <value>
    /// The remove command.
    /// </value>
    public CommandBase RemoveCommand => new CommandBase(RemoveFamily);

    /// <summary>
    /// Gets the load command.
    /// </summary>
    /// <value>
    /// The load command.
    /// </value>
    public CommandBase LoadCommand => new CommandBase(LoadFamily);

    /// <summary>
    /// Gets the open command.
    /// </summary>
    /// <value>
    /// The open command.
    /// </value>
    public CommandBase OpenCommand => new CommandBase(OpenFamily);

    /// <summary>
    /// Gets the expand command.
    /// </summary>
    /// <value>
    /// The expand command.
    /// </value>
    public CommandBase ExpandCommand => new CommandBase(ExpandInfo);

    /// <summary>
    /// Gets the open folder command.
    /// </summary>
    /// <value>
    /// The open folder command.
    /// </value>
    public CommandBase OpenFolderCommand => new CommandBase(OpenFolder);

    #endregion

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="FolderControlViewModel"/> class.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="parentMainWindow">The parent main ActiveWindow.</param>
    public FolderControlViewModel(CustomFileInfo file, MainWindowViewModel parentMainWindow)
    {
      FolderControl = new FolderControl();
      File = file;
      FolderControl.DataContext = this;
      _parentMainWindow = parentMainWindow;
    }

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// Executes this instance.
    /// </summary>
    public override void Execute()
    {

    }

    /// <summary>
    /// Determines whether this instance can proceed the specified object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>
    ///   <c>true</c> if this instance can proceed the specified object; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanProceed(object obj)
    {
      return true;
    }

    #endregion

    #region PRIVATE METHODS 

    /// <summary>
    /// Removes the family.
    /// </summary>
    private void RemoveFamily()
    {
      var toBeRemoved = _parentMainWindow.FolderControlViewModels.Where(p => p.File.FolderPath == File.FolderPath).ToList();
      foreach (var folderControl in toBeRemoved)
      {
        _parentMainWindow.MainWindow.filterPanel.Children.Remove(folderControl.FolderControl);
        _parentMainWindow.FolderControlViewModels.Remove(folderControl);
      }

      XmlUtility.SerialiseInfo(_parentMainWindow.FolderControlViewModels.Select(fv => fv.File).ToList(), ConstantMembers.ProfilePath);
    }

    /// <summary>
    /// Loads the family.
    /// </summary>
    private void LoadFamily()
    {
      LoadFamilyExternalEvent.HandlerInstance.FamilyPath = File.FilePath;
      LoadFamilyExternalEvent.HandlerEvent.Raise();
    }

    /// <summary>
    /// Opens the family.
    /// </summary>
    private void OpenFamily()
    {
      ConstantMembers.UiDocument.Application.OpenAndActivateDocument(File.FilePath);
    }

    /// <summary>
    /// Expands the information.
    /// </summary>
    private void ExpandInfo()
    {
      if (FolderControl.stPanel.Visibility == System.Windows.Visibility.Collapsed)
      {
        FolderControl.stPanel.Visibility = System.Windows.Visibility.Visible;
      }
      else
      {
        FolderControl.stPanel.Visibility = System.Windows.Visibility.Collapsed;
      }
    }

    /// <summary>
    /// Opens the folder.
    /// </summary>
    private void OpenFolder()
    {
      System.Diagnostics.Process.Start(File.FolderPath);
    }

    #endregion
  }
}
