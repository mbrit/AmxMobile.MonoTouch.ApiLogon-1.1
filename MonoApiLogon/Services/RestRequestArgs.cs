using System;
using System.Collections.Generic;

namespace MonoApiLogon
{
	public class RestRequestArgs : Dictionary<string, string>
	{
		public RestRequestArgs (string operation)
		{
			this["operation"] = operation;
		}
	}
}

