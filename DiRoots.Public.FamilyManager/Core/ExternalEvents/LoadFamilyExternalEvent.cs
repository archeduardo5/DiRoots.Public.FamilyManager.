namespace DR.Public.FM
{
  using Autodesk.Revit.DB;
  using Autodesk.Revit.UI;

  /// <summary>
  /// External event used with modeless dialog.
  /// </summary>
  /// <seealso cref="Autodesk.Revit.UI.IExternalEventHandler" />
  public class LoadFamilyExternalEvent : IExternalEventHandler
  {

    #region PUBLIC STATIC MEMBERS

    /// <summary>
    /// The handler event
    /// </summary>
    public static ExternalEvent HandlerEvent = null;

    /// <summary>
    /// The handler instance
    /// </summary>
    public static LoadFamilyExternalEvent HandlerInstance = null;

    #endregion

    #region PUBLIC PROPERTIES

    /// <summary>
    /// Gets or sets the family path.
    /// </summary>
    /// <value>
    /// The family path.
    /// </value>
    public string FamilyPath { get; set; }

    #endregion

    #region PUBLIC METHODS

    /// <summary>
    /// Executes the specified uiapp.
    /// </summary>
    /// <param name="uiapp">The uiapp.</param>
    public void Execute(UIApplication uiapp)
    {
      using (var trans = new Transaction(uiapp.ActiveUIDocument.Document, "load family"))
      {
        trans.Start();
        uiapp.ActiveUIDocument.Document.LoadFamily(FamilyPath);
        trans.Commit();
      }
    }

    /// <summary>
    /// String identification of the event handler.
    /// </summary>
    /// <returns>
    /// The event's name
    /// </returns>
    /// <since>
    /// 2013
    /// </since>
    public string GetName()
    {
      return "Load Family";
    }

    #endregion

    #region public static methods

    /// <summary>
    /// Creates the event.
    /// </summary>
    public static void CreateEvent()
    {
      if (HandlerInstance == null)
      {
        HandlerInstance = new LoadFamilyExternalEvent();
        HandlerEvent = ExternalEvent.Create(HandlerInstance);
      }
    }

    #endregion
  }
}
