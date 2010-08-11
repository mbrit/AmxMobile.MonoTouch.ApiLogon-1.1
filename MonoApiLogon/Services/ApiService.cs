using System;
using System.Xml;

namespace MonoApiLogon
{
	public class ApiService : RestServiceProxy
	{
		public ApiService ()
			: base("apirest.aspx")
		{
		}

		public string Logon(string apiPassword)
		{
			// package a request...
			RestRequestArgs args = new RestRequestArgs("logon");
			args["password"] = apiPassword;
			
			// send it...
			XmlElement element = SendRequest(args);
			if(element == null)
				throw new InvalidOperationException("'element' was null.");
			
			// find it...  in a real implementation we'd need to look
			// for logon result, but for now we'll just get the element
			// out.  see the other implementations for how this is done
			// properly...
			XmlElement tokenElement = (XmlElement)element.SelectSingleNode("Token");
			if(tokenElement == null)
				throw new InvalidOperationException("A token element was not found.");
			
			// return...
			return tokenElement.InnerText;
		}
	}

}

