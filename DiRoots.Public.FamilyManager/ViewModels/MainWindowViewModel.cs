namespace DR.Public.FM.ViewModels
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Windows.Media;
	using System.Collections.Generic;

	using Microsoft.WindowsAPICodePack.Dialogs;

	using Models;
	using Helpers;


	/// <summary>
	/// Main ActiveWindow view model
	/// </summary>
	/// <seealso cref="DR.Public.FM.ViewModels.ViewModelBase" />
	public class MainWindowViewModel : ViewModelBase
	{
		#region PRIVATE MEMBERS

		/// <summary>
		/// The selected folder path
		/// </summary>
		private string _selectedFolderPath;

		#endregion

		#region PUBLIC PROPERTIES

		/// <summary>
		/// Gets or sets the main ActiveWindow.
		/// </summary>
		/// <value>
		/// The main ActiveWindow.
		/// </value>
		public MainWindow MainWindow { get; set; }

		/// <summary>
		/// Gets the select folder command.
		/// </summary>
		/// <value>
		/// The select folder command.
		/// </value>
		public CommandBase SelectFolderCommand => new CommandBase(SelectFolder);


		/// <summary>
		/// Gets or sets the folder control view models.
		/// </summary>
		/// <value>
		/// The folder control view models.
		/// </value>
		public List<FolderControlViewModel> FolderControlViewModels
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the selected folder path.
		/// </summary>
		/// <value>
		/// The selected folder path.
		/// </value>
		public string SelectedFolderPath
		{
			get => _selectedFolderPath;
			set
			{
				_selectedFolderPath = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
		/// </summary>
		public MainWindowViewModel()
		{
			//Files = new ObservableCollection<CustomFileInfo>();
			FolderControlViewModels = new List<FolderControlViewModel>();
			MainWindow = new MainWindow();
			MainWindow.DataContext = this;
			Init();
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		private void Init()
		{
			try
			{
				List<CustomFileInfo> files = XmlUtility.DeserialiseInfo<List<CustomFileInfo>>(ConstantMembers.ProfilePath);

				if (files != null)
				{
					foreach (var customFile in files)
					{
						var folderControlViewModel = new FolderControlViewModel(customFile, this);
						FolderControlViewModels.Add(folderControlViewModel);
						MainWindow.filterPanel.Children.Add(folderControlViewModel.FolderControl);
					}
				}
			}
			catch (Exception)
			{
			}

			MainWindow.Show();
		}

		/// <summary>
		/// Selects the folder.
		/// </summary>
		private void SelectFolder()
		{
			using (var dialog = new CommonOpenFileDialog())
			{
				dialog.IsFolderPicker = true;
				if (dialog.ShowDialog(this.MainWindow) == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName) && !FolderControlViewModels.Any(p => p.File.FolderPath == dialog.FileName + "\\"))
				{
					SelectedFolderPath = dialog.FileName + "\\";
					ReloadFiles(SelectedFolderPath);
				}
			}
		}

		/// <summary>
		/// Reloads the files.
		/// </summary>
		/// <param name="folderPath">The folder path.</param>
		private void ReloadFiles(string folderPath)
		{
			string[] fileList = Directory.GetFiles(folderPath);
			fileList = fileList.Where(p => p.Contains(".rfa")).ToArray();
			var brushColor = GetRandomBrush();

			foreach (var file in fileList)
			{
				FileInfo fileInfo = new FileInfo(file);
				CustomFileInfo customFile = new CustomFileInfo();
				customFile.FolderPath = folderPath;
				customFile.FileName = fileInfo.Name;
				customFile.FilePath = file;
				customFile.BrushColor = brushColor;
				customFile.FolderName = fileInfo.Directory.Name;
				var folderControlViewModel = new FolderControlViewModel(customFile, this);

				FolderControlViewModels.Add(folderControlViewModel);
				MainWindow.filterPanel.Children.Add(folderControlViewModel.FolderControl);
			}

			XmlUtility.SerialiseInfo(FolderControlViewModels.Select(fv => fv.File).ToList(), ConstantMembers.ProfilePath);

		}


		/// <summary>
		/// Gets the random brush.
		/// </summary>
		/// <returns></returns>
		private Brush GetRandomBrush()
		{
			Random rnd = new Random();
			Type brushesType = typeof(Brushes);
			PropertyInfo[] properties = brushesType.GetProperties();
			int random = rnd.Next(properties.Length);
			return (Brush)properties[random].GetValue(null, null);
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
	}
}
