namespace DR.Public.FM
{
  using System;
  using System.Linq;
  using System.Collections.Generic;
  
  using Autodesk.Revit.UI;

  /// <summary>
  /// Helper class.
  /// Contains static public methods.
  /// </summary>
  public static class RevitHelper
  {
    #region PUBLIC METHODS

    /// <summary>
    /// Adds the ribbon tab.
    /// </summary>
    /// <param name="application">The application.</param>
    /// <param name="tabName">Name of the tab.</param>
    /// <returns></returns>
    public static bool AddRibbonTab(UIControlledApplication application, string tabName)
    {
      try
      {
        application.CreateRibbonTab(tabName);
      }
      catch
      {
        return false;
      }
      return true;
    }

    /// <summary>
    /// Adds the ribbon panel.
    /// </summary>
    /// <param name="application">The application.</param>
    /// <param name="tabName">Name of the tab.</param>
    /// <param name="panelName">Name of the panel.</param>
    /// <param name="addSeperator">if set to <c>true</c> [add seperator].</param>
    /// <returns></returns>
    public static RibbonPanel AddRibbonPanel(UIControlledApplication application, string tabName, string panelName, bool addSeperator)
    {
      List<RibbonPanel> panels = application.GetRibbonPanels(tabName);
      RibbonPanel panel = panels.FirstOrDefault(x => x.Name == tabName);

      if (panel == null)
      {
        panel = application.CreateRibbonPanel(tabName, panelName);
      }
      else if (addSeperator)
      {
        panel.AddSeparator();
      }

      return panel;
    }


    /// <summary>
    /// Adds the push button.
    /// </summary>
    /// <param name="panel">The panel.</param>
    /// <param name="name">The name.</param>
    /// <param name="title">The title.</param>
    /// <param name="targetClass">The target class.</param>
    /// <param name="path">The path.</param>
    /// <returns></returns>
    public static PushButton AddPushButton(RibbonPanel panel, string name, string title, Type targetClass, string path)
    {
      var button = panel.AddItem(new PushButtonData(name, title, path, targetClass.FullName)) as PushButton;
      return button;
    }

    #endregion
  }
}