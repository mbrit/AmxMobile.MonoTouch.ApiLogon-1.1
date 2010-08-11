using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoApiLogon
{
	public static class MessageBox
	{
		public static void Show(string message)
		{
			UIAlertView view = new UIAlertView();
			view.Title = "API Service";
			view.Message = message;
			view.AddButton("OK");
			
			// show...
			view.Show();
		}
		
		public static void Show(Exception ex)
		{
			// defer...
			Show(ex.ToString());
		}
	}
}

