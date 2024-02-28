namespace DR.Public.FM.Helpers
{
	using System;
	using System.IO;
  using Autodesk.Revit.DB;
  using Autodesk.Revit.UI;

  /// <summary>
  /// Constant members.
  /// </summary>
  public static class ConstantMembers
  {

    #region PUBLIC PROPERTIES

    /// <summary>
    /// Gets the Revit document.
    /// </summary>
    /// <value>
    /// The document.
    /// </value>
    public static Document Document { get; private set; }

    /// <summary>
    /// Gets the Revit UIDocument.
    /// </summary>
    /// <value>
    /// The UI document.
    /// </value>
    public static UIDocument UiDocument { get; private set; }

    /// <summary>
    /// Gets or sets the Revit UIApplication.
    /// </summary>
    /// <value>
    /// The uiapp.
    /// </value>
    public static UIApplication UiApplication { get; set; }

    /// <summary>
    /// Gets or sets the Revit UIApplication.
    /// </summary>
    /// <value>
    /// The uiapp.
    /// </value>
    public static string ProfilePath { get; set; }

    #endregion

    #region CONSTRUCTORS

    /// <summary>
    /// Defualt constructor.
    /// Initializes a new instance of the <see cref="ConstantMembers"/> class.
    /// </summary>
    /// <param name="doc">The document.</param>
    public static void Initialize(UIDocument uidoc)
    {
      UiDocument = uidoc;
      Document = uidoc.Document;
      string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      string profileDirectory = Path.Combine(documentPath, "DiRootsPublic\\Profile\\");
      if (!Directory.Exists(profileDirectory))
      {
	      Directory.CreateDirectory(profileDirectory);
      }
      ProfilePath = Path.Combine(profileDirectory, "Repositories.xml");
    }

    #endregion

  }
}
