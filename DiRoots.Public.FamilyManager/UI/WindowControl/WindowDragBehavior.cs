namespace DR.Public.FM.WindowControl
{
	using System.Windows;

	/// <summary>
	/// Window behavior due to draging.
	/// </summary>
	class WindowDragBehavior
	{
		#region DEPENDENCY PROPERTIES

		/// <summary>
		/// The left mouse button drag behaviour.
		/// </summary>
		public static readonly DependencyProperty LeftMouseButtonDrag = DependencyProperty.RegisterAttached("LeftMouseButtonDrag",
			typeof(Window), typeof(WindowDragBehavior),
			new UIPropertyMetadata(null, OnLeftMouseButtonDragChanged));
		#endregion

		#region PUBLIC METHODS

		/// <summary>
		/// Gets the left mouse button drag.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static Window GetLeftMouseButtonDrag(DependencyObject obj)
		{
			return (Window)obj.GetValue(LeftMouseButtonDrag);
		}

		/// <summary>
		/// Sets the left mouse button drag.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="window">The ActiveWindow.</param>
		public static void SetLeftMouseButtonDrag(DependencyObject obj, Window window)
		{
			obj.SetValue(LeftMouseButtonDrag, window);
		}

		/// <summary>
		/// Triggered when OnLeftMouseButtonDragChanged is changed
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
		private static void OnLeftMouseButtonDragChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var element = sender as UIElement;

			if (element != null)
			{
				element.MouseLeftButtonDown += LeftButtonDown;
			}
		}

		/// <summary>
		/// Triggered when the left mouse button down .
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
		private static void LeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var element = sender as UIElement;
			var targetWindow = element.GetValue(LeftMouseButtonDrag) as Window;

			targetWindow?.DragMove();
		}

		#endregion
	}
}

