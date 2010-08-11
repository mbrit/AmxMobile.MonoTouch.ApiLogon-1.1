
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoApiLogon
{

	// The name AppDelegateIPhone is referenced in the MainWindowIPhone.xib file.
	public partial class AppDelegateIPhone : UIApplicationDelegate
	{
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);

			buttonGo.TouchUpInside += HandleButtonGoTouchUpInside;
			
			window.MakeKeyAndVisible ();
			
			return true;
		}

		void HandleButtonGoTouchUpInside (object sender, EventArgs e)
		{
			// create the API service and make the call...
			try
			{
				ApiService service = new ApiService();
				string token = service.Logon(ServiceProxy.ApiPassword);

				// did we get one?
				if(!(string.IsNullOrEmpty(token)))
					MessageBox.Show("The token: " + token);
				else
					throw new InvalidOperationException("A token was not returned.");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex);
			}
		}
	}
}

