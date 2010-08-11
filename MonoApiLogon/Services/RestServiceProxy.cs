using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;

namespace MonoApiLogon
{
	public abstract class RestServiceProxy : ServiceProxy
	{
		public RestServiceProxy (string serviceName)
			: base(serviceName)
		{
		}
					
		protected XmlElement SendRequest(RestRequestArgs args)
		{
			// build a url...
			string url = HttpHelper.BuildUrl(this.ResolvedServiceUrl, args);
			
			// make a request...
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			
			// headers...
			HttpDownloadSettings settings = this.GetDownloadSettings();
			foreach(string header in settings.ExtraHeaders.Keys)
				request.Headers.Add(header, settings.ExtraHeaders[header]);
				
			// get a response...
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if(response == null)
				throw new InvalidOperationException("'response' is null.");
			using(response)
			{
				// load the response into xml...
				XmlDocument doc = new XmlDocument();
				using(Stream stream = response.GetResponseStream())
					doc.Load(stream);
				
				// did we get an AmxResponse?
				XmlElement amxElement = (XmlElement)doc.SelectSingleNode("AmxResponse");
				if(amxElement == null)
					throw new InvalidOperationException("The response did not include an AmxResponse element.");
				
				// find the error element...
				XmlElement hasExceptionElement = (XmlElement)amxElement.SelectSingleNode("HasException");
				if(hasExceptionElement == null)
					throw new InvalidOperationException("The response did not include a HasException element.");
				
				// did we?
				if(hasExceptionElement.Value == "1" || string.Compare(hasExceptionElement.Value, "true", true) == 0)
				{
					// error...
					XmlElement errorElement = (XmlElement)amxElement.SelectSingleNode("Error");
					if(errorElement == null)
						throw new InvalidOperationException("The error has not found.");
					else
						throw new InvalidOperationException(string.Format("The server returned an exception: {0}", errorElement.Value));
				}
				else
					return amxElement;

			}
		}
	}

}

