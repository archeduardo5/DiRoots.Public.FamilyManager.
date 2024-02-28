namespace DR.Public.FM.WindowControl
{
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;

	public static class ControlDoubleClickBehavior
	{
		#region DEPENDENCY PROPERTIES

		public static readonly DependencyProperty ExecuteCommand = DependencyProperty.RegisterAttached("ExecuteCommand",
			typeof(ICommand), typeof(ControlDoubleClickBehavior),
			new UIPropertyMetadata(null, OnExecuteCommandChanged));

		public static readonly DependencyProperty ExecuteCommandParameter = DependencyProperty.RegisterAttached("ExecuteCommandParameter",
			typeof(Window), typeof(ControlDoubleClickBehavior));

		#endregion

		#region PUBLIC METHODS

		/// <summary>
		/// Get the command to execute on double click
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static ICommand GetExecuteCommand(DependencyObject obj)
		{
			return (ICommand)obj.GetValue(ExecuteCommand);
		}

		/// <summary>
		/// Get the command to execute on double click
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <param name="command"></param>
		public static void SetExecuteCommand(DependencyObject obj, ICommand command)
		{
			obj.SetValue(ExecuteCommand, command);
		}

		/// <summary>
		/// Get the command parameters
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static Window GetExecuteCommandParameter(DependencyObject obj)
		{
			return (Window)obj.GetValue(ExecuteCommandParameter);
		}

		/// <summary>
		/// Set the command parameters
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		public static void SetExecuteCommandParameter(DependencyObject obj, ICommand command)
		{
			obj.SetValue(ExecuteCommandParameter, command);
		}

		/// <summary>
		/// Triggered when OnExecuteCommandChanged is changed
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
		private static void OnExecuteCommandChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			var control = sender as Control;

			if (control != null)
			{
				control.MouseDoubleClick += Control_MouseDoubleClick;
			}
		}

		/// <summary>
		/// Triggered when the element is double-clicked
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
		static void Control_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var control = sender as Control;

			if (control != null)
			{
				var command = control.GetValue(ExecuteCommand) as ICommand;
				var commandParameter = control.GetValue(ExecuteCommandParameter);

				if (command.CanExecute(e))
				{
					command.Execute(commandParameter);
				}
			}
		}
		#endregion
	}
}