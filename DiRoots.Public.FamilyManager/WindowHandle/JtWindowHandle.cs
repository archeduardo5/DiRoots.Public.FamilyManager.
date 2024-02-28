namespace DR.Public.FM
{
	using System;
	using System.Diagnostics;
	using System.Windows.Interop;

	/// <summary>
	/// Handle ActiveWindow helper.
	/// </summary>
	/// <seealso cref="System.Windows.Interop.IWin32Window" />
	public class JtWindowHandle : IWin32Window
	{
		#region PRIVATE MEMBERS
		/// <summary>
		/// The HWND
		/// </summary>
		private readonly IntPtr _hwnd;

		#endregion

		#region PUBLIC PROPERTIES

		/// <summary>
		/// Gets the ActiveWindow handle.
		/// </summary>
		public IntPtr Handle { get { return _hwnd; } }

		#endregion

		#region Public Methods

		/// <summary>
		/// Initializes a new instance of the <see cref="JtWindowHandle"/> class.
		/// </summary>
		/// <param name="h">The h.</param>
		public JtWindowHandle(IntPtr h)
		{
			Debug.Assert(IntPtr.Zero != h,
				"expected non-null ActiveWindow handle");

			_hwnd = h;
		}

		#endregion
	}
}
