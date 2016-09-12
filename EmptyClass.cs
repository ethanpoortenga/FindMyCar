using System;

using Xamarin.Auth;

using Mojio.Client;

using System.Net.Http;
using System.Net;
using System.Net.WebSockets;

using System.Text.RegularExpressions;
using Mojio;
using System.Threading.Tasks;
using System.Json;
using System.IO;

namespace WheelsUp.iOS
{
	public class EmptyClass
	{
		public async Task FetchWeatherAsync(string url)
		{
			//Task<JsonValue>
			//// Create an HTTP web request using the URL:
			//HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
			//request.ContentType = "application/json";
			//request.Method = "GET";

			//// Send the request to the server and wait for the response:
			//using (WebResponse response = await request.GetResponseAsync())
			//{
			//	// Get a stream representation of the HTTP web response:
			//	using (Stream stream = response.GetResponseStream())
			//	{
			//		// Use this stream to build a JSON document object:
			//		JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
			//		Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

			//		// Return the JSON document:
			//		return jsonDoc;
			//	}
			//}
			HttpClient client = new HttpClient();

			var response = client.GetAsync("http://google.com").Result;

			if (response.IsSuccessStatusCode)
			{
				// by calling .Result you are performing a synchronous call
				var responseContent = response.Content;

				// by calling .Result you are synchronously reading the result
				string responseString = responseContent.ReadAsStringAsync().Result;

				Console.WriteLine(responseString);
			}
		}
	}
}

