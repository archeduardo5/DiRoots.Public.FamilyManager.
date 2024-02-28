
namespace DR.Public.FM
{

	using System;
	using System.Reflection;
	using System.Windows;
	using System.Windows.Interop;
	using System.Windows.Media.Imaging;

	using Autodesk.Revit.DB;
	using Autodesk.Revit.UI;

	/// <summary>
	/// External Apllication Manager.
	/// Intialize the push button on opening revit.
	/// </summary>
	/// <seealso cref="Autodesk.Revit.UI.IExternalApplication" />
	public class Main : IExternalApplication
	{

		/// <summary>
		/// Implement this method to execute some tasks when Autodesk Revit starts.
		/// </summary>
		/// <param name="application">A handle to the application being started.</param>
		/// <returns>
		/// Indicates if the external application completes its work successfully.
		/// </returns>
		public Result OnStartup(UIControlledApplication application)
		{
			var tabName = "DiRoots Public";
			var panelName = "Utility";

			RevitHelper.AddRibbonTab(application, tabName);
			RibbonPanel panel = RevitHelper.AddRibbonPanel(application, tabName, panelName, false);

			string path = Assembly.GetExecutingAssembly().Location;
			var btnCommand = RevitHelper.AddPushButton(panel, "Family Manager", "Family Manager", typeof(Command), path);
			btnCommand.AvailabilityClassName = typeof(AvailableIfOpenDoc).FullName;
			btnCommand.Image = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.icon_16x16.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			btnCommand.LargeImage = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.icon_32x32.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			btnCommand.ToolTip = "Demo application for showing accessibility Modeless plugins.";

			return Result.Succeeded;
		}

		/// <summary>
		/// Called when [shutdown].
		/// </summary>
		/// <param name="a">a.</param>
		/// <returns></returns>
		public Result OnShutdown(UIControlledApplication a)
		{
			return Result.Succeeded;
		}

		#region PRIVATE CLASSES

		/// <summary>
		/// The class providing the entry point to decide availability of this push button
		/// </summary>
		/// <seealso cref="Autodesk.Revit.UI.IExternalCommandAvailability" />
		private class AvailableIfOpenDoc : IExternalCommandAvailability
		{

			#region PUBLIC METHODS

			/// <summary>
			/// Implement this method to provide control over whether your external command is enabled or disabled.
			/// </summary>
			/// <param name="applicationData">An ApplicationServices.Application object which contains reference to Application
			/// needed by external command.</param>
			/// <param name="selectedCategories">An list of categories of the elements which have been selected in Revit in the active document,
			/// or an empty set if no elements are selected or there is no active document.</param>
			/// <returns>
			/// Indicates whether Revit should enable or disable the corresponding external command.
			/// </returns>
			/// <remarks>
			/// This callback will be called by Revit's user interface any time there is a contextual change. Therefore, the callback
			/// must be fast and is not permitted to modify the active document and be blocking in any way.
			/// </remarks>
			public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
			{
				if (applicationData.ActiveUIDocument != null && applicationData.ActiveUIDocument.Document != null)
				{
					return true;
				}

				return false;
			}

			#endregion

		}

		#endregion

	}
}