namespace DR.Public.FM.Models
{
	using System.Xml.Serialization;
	using System.Runtime.Serialization;
	using System.Windows.Media;

	/// <summary>
	/// Model for each family file information.
	/// </summary>
	public class CustomFileInfo
	{
		#region PRIVATE MEMBERS

		private BrushConverter _colorConverter = new BrushConverter();
		private string _colorString;
		private Brush _brushColor;

		#endregion

		#region PUBLIC PROPERTIES

		/// <summary>
		/// Gets or sets the name of the file.
		/// </summary>
		/// <value>
		/// The name of the file.
		/// </value>
		public string FileName { get; set; }

		/// <summary>
		/// Gets or sets the file path.
		/// </summary>
		/// <value>
		/// The file path.
		/// </value>
		public string FilePath { get; set; }

		/// <summary>
		/// Gets or sets the folder path.
		/// </summary>
		/// <value>
		/// The folder path.
		/// </value>
		public string FolderPath { get; set; }

		/// <summary>
		/// Gets or sets the name of the folder.
		/// </summary>
		/// <value>
		/// The name of the folder.
		/// </value>
		public string FolderName { get; set; }

		public string ColorString
		{
			get { return _colorString; }
			set
			{
				_colorString = value;
				BrushColor = (Brush)_colorConverter.ConvertFrom(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the brush.
		/// </summary>
		/// <value>
		/// The color of the brush.
		/// </value>
		// Color
		[XmlIgnore]
		public Brush BrushColor
		{
			get { return _brushColor; }
			set
			{
				_brushColor = value;
				_colorString = _colorConverter.ConvertToString(value);
			}
		}
		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Default constructor.
		/// Initializes a new instance of the <see cref="CustomFileInfo"/> class.
		/// </summary>
		public CustomFileInfo()
		{

		}

		#endregion

		#region PRIVATE METHODS 

		/// <summary>
		///		This method is called after the object is completely deserialized to assign brush color.
		/// </summary>
		/// <param name="context"></param>
		[OnDeserialized]
		private void SetValuesOnDeserialized(StreamingContext context)
		{
			_colorConverter = new BrushConverter();
			_brushColor = (Brush)_colorConverter.ConvertFrom(ColorString);
		}

		#endregion
	}
}
