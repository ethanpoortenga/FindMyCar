using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ModernHttpClient;
using OAuth2.Client;
using OAuth2;
using Xamarin.Auth;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FindMyCar.iOS

{
	public class MojioAPIManager
	{
		public double lattitude { get; set; }
		public double longitude { get; set; }

		public MojioAPIManager()
		{
			//setting default lat/long values
			lattitude = 0.0;
			longitude = 0.0;
		}


		string clientId = "062305af-78a8-4e1e-927f-01dc9f0ddf70";
		string clientSecret = "83910bc8-9342-4efd-8694-598b898a9215";

		string baseUrl = "https://accounts.moj.io/oauth2/token";

		string accessToken = null;

		public async Task MakeGetCall()
		{
			////get call

			//accessToken = await GetAccessToken();

			//setting the request url
			Uri requestUri = new Uri("https://staging-api.moj.io/v2/vehicles?fields=Location");

			//For right now I set all of this
			//TODO: get this information after user logs in
			var AuthorizationType = "Bearer";
			var AuthorizationToken = "0b97256d-3f7b-4ae0-a118-e2c2527dab43";

			//initializes a http client to make call to API
			HttpClient client = new HttpClient(new NativeMessageHandler());
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationType, AuthorizationToken);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			client.BaseAddress = requestUri;

			//initializes the get request
			var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

			//initializing the variables to recieve response url and subsequent parsed reponse
			string responseUrl = "";
			string response = "";

			//try to read read the vehicle locaiton from the API
			try
			{
				var sendResult = client.SendAsync(request).Result;

				Console.WriteLine();
				responseUrl = sendResult.RequestMessage.RequestUri.ToString();
				var statuscode = sendResult.StatusCode;

				if (sendResult.IsSuccessStatusCode)
				{
					response = await sendResult.Content.ReadAsStringAsync();
					Console.WriteLine("Message Recieved From API");
					Console.WriteLine(response);
				}
				else
				{
					Console.WriteLine("Error");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			//try to parse the JSON response
			//TODO: determine which vehicle's location to track
			try
			{
				lattitude = Double.Parse(response.Substring((response.IndexOf("Lat") + 5),
							((response.IndexOf("Lng") - 2) - (response.IndexOf("Lat") + 5))));
				longitude = Double.Parse(response.Substring((response.IndexOf("Lng") + 5),
							((response.IndexOf("Timestamp") - 2) - (response.IndexOf("Lng") + 5))));

				Console.WriteLine(lattitude);
				Console.WriteLine(longitude);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

		}

		///uncomment next two lines
		//public async Task<string> GetAccessToken()
		//{
			//using (var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri(baseUrl);

			//	//we want the response to be JSON
			//	client.DefaultRequestHeaders.Accept.Clear();
			//	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			//	//build up the data to post
			//	List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
			//	postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
			//	postData.Add(new KeyValuePair<string, string>("client_id", clientId));
			//	postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

			//	FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

			//	// Post to the Server and parse the response.
			//	HttpResponseMessage response = await client.PostAsync("Token", content);
			//	string jsonString = response.Content.ReadAsStringAsync().Result;
			//	object responseData = JsonConvert.DeserializeObject(jsonString);

			//	Console.WriteLine(responseData);

			//	// return the Access Token.
			//	return "done";
			//}

			///USUALLY NOT COMMENTED vvv

			//string username = "ethanp@moj.io";
			//string password = "Poortenga.13";
			//string redirectUri = "https://www.google.com";
			//string clientId = "062305af-78a8-4e1e-927f-01dc9f0ddf70";
			//string clientSecret = "83910bc8-9342-4efd-8694-598b898a9215";
			//string scope = "full";

			//var payload = string.Format("grant_type=password&username={0}&password={1}&redirect_uri={2}&client_id={3}&client_secret={4}&scope={5}", System.Net.WebUtility.UrlEncode(username), System.Net.WebUtility.UrlEncode(password), System.Net.WebUtility.UrlEncode(redirectUri), System.Net.WebUtility.UrlEncode(clientId), System.Net.WebUtility.UrlEncode(clientSecret), System.Net.WebUtility.UrlEncode(scope));

			//var _method = HttpMethod.Get;


			//var loginResult = await _clientBuilder.Request<IAuthorization>(ApiEndpoint.Accounts, "oauth2/token", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, payload, null, "application/x-www-form-urlencoded");

		//}
	}
}