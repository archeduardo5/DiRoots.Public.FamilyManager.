namespace DR.Public.FM
{
  using System.Windows;

  using Autodesk.Revit.Attributes;
  using Autodesk.Revit.DB;
  using Autodesk.Revit.UI;

  using Helpers;
  using ViewModels;

  /// <summary>
  /// <summary>
  /// Command Class executes by push button.
  /// </summary>
  /// <seealso cref="Autodesk.Revit.UI.IExternalCommand" />
  [Transaction(TransactionMode.Manual)]
  public class Command : IExternalCommand
  {

    #region PUBLIC STATIC PROPERTIES

    /// <summary>
    /// The ActiveWindow
    /// </summary>
    public static Window ActiveWindow;

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// Overload this method to implement and external command within Revit.
    /// </summary>
    /// <param name="commandData">An ExternalCommandData object which contains reference to Application and View
    /// needed by external command.</param>
    /// <param name="message">Error message can be returned by external command. This will be displayed only if the command status
    /// was "Failed".  There is a limit of 1023 characters for this message; strings longer than this will be truncated.</param>
    /// <param name="elements">Element set indicating problem elements to display in the failure dialog.  This will be used
    /// only if the command status was "Failed".</param>
    /// <returns>
    /// The result indicates if the execution fails, succeeds, or was canceled by user. If it does not
    /// succeed, Revit will undo any changes made by the external command.
    /// </returns>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      LoadFamilyExternalEvent.CreateEvent();
      ConstantMembers.Initialize(commandData.Application.ActiveUIDocument);
      if (ActiveWindow == null)
      {
        var windowViewModel = new MainWindowViewModel();
        ActiveWindow = windowViewModel.MainWindow;
        WindowHandler.SetWindowOwner(commandData.Application, ActiveWindow);
      }

      return Result.Succeeded;
    }

    #endregion

  }
}
