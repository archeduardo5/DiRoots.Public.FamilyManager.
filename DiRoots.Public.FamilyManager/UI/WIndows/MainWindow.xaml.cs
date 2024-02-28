namespace DR.Public.FM
{
  using System.Windows;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  /// <seealso cref="System.Windows.Window" />
  /// <seealso cref="System.Windows.Markup.IComponentConnector" />
  public partial class MainWindow : Window
  {
    #region CONSTRUCTORS

    /// <summary>
    /// Default constructor.
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
    }

    #endregion

    #region EVENTS

    /// <summary>
    /// Main ActiveWindow close event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void MainWindowClose(object sender, System.EventArgs e)
    {
      Command.ActiveWindow = null;
    }

    #endregion
  }
}
