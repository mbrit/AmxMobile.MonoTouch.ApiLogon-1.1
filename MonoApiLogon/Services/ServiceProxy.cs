using System;

namespace MonoApiLogon
{
	public abstract class ServiceProxy
	{
		// YOU MUST CHANGE THESE IN ORDER TO USE THIS SAMPLE...
		public const string ApiUsername = "amxmobile";
		public const string ApiPassword = "password";
		
		private string ServiceName { get; set; }
		
		protected ServiceProxy (string serviceName)
		{
			// set...
			this.ServiceName = serviceName;
		}
		
		public string ResolvedServiceUrl
		{
			get
			{
				return "http://services.multimobiledevelopment.com/" + this.ServiceName;
			}
		}
		
		internal HttpDownloadSettings GetDownloadSettings()
		{
			HttpDownloadSettings settings = new HttpDownloadSettings();
			settings.ExtraHeaders["x-amx-apiusername"] = ServiceProxy.ApiUsername;
			
			// return...
			return settings;
		}
	}
}

