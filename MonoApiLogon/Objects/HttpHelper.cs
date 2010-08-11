using System;
using System.Text;
using System.Collections;

namespace MonoApiLogon
{
	public static class HttpHelper
	{
		public static string BuildUrl(string url, IDictionary values)
		{
			StringBuilder builder = new StringBuilder();
			
			// existing?
			int index = url.IndexOf("?");
			if(index == -1)
				builder.Append(url);
			else
				builder.Append(url.Substring(0, index));
			
			// add...
			bool first = true;
			foreach(string name in values.Keys)
			{
				if(first)
				{
					builder.Append("?");
					first = false;
				}
				else
					builder.Append("&");
				
				// value...
				builder.Append(name);
				builder.Append("=");
				builder.Append(values[name]);
			}
			
			// return...
			return builder.ToString();
		}
	}
}

