using System;
using System.Collections.Generic;

namespace MonoApiLogon
{
	public class HttpDownloadSettings
	{
		public Dictionary<string, string>  ExtraHeaders { get; private set; }
		
		public HttpDownloadSettings ()
		{
			this.ExtraHeaders = new Dictionary<string, string>();
		}
	}
}

