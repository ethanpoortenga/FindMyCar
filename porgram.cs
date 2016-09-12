//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using RestSharp.Extensions.MonoHttp;

//namespace WheelsUp.iOS
//{
//	class Program
//	{
//		/// The client information used to get the OAuth Access Token from the server.
//		static string clientId = "JkOnJ9zIQ1vWvP3FvsJVx-3iOnSd-6a-";
//		static string clientSecret = "U_ZHCQackGJHW4-Jn4qfGce6JLV9qAKhJEGahyRHVpeYVWf_r8iSaSt4z6AZn8kC";

//		// The server base address
//		static string baseUrl = "https://api.codeproject.com/";

//		// this will hold the Access Token returned from the server.
//		static string accessToken = null;

//		static void Main(string[] args)
//		{
//			Console.WriteLine("Starting ...");
//			DoIt().Wait();
//			Console.ReadLine();
//		}

//		/// <summary>
//		/// This method does all the work to get an Access Token and read the first page of
//		/// Articles from the server.
//		/// </summary>
//		/// <returns></returns>
//		private static async Task<int> DoIt()
//		{
//			// Get the Access Token.
//			accessToken = await GetAccessToken();
//			Console.WriteLine(accessToken != null ? "Got Token" : "No Token found");

//			// Get the Articles
//			Console.WriteLine();
//			Console.WriteLine("------ New C# Articles ------");

//			dynamic response = await GetArticles(1, "c#");
//			if (response.items != null)
//			{
//				var articles = (dynamic)response.items;
//				foreach (dynamic article in articles)
//					Console.WriteLine("Title: {0}", article.title);
//			}

//			// Get the Articles
//			Console.WriteLine();
//			Console.WriteLine("------ New C# Questions ------");

//			response = await GetQuestions(1, "c#");
//			if (response.items != null)
//			{
//				var questions = (dynamic)response.items;
//				foreach (dynamic question in questions)
//					Console.WriteLine("Title: {0}", question.title);
//			}

//			return 0;
//		}

//		/// <summary>
//		/// This method uses the OAuth Client Credentials Flow to get an Access Token to provide
//		/// Authorization to the APIs.
//		/// </summary>
//		/// <returns></returns>
//		private static async Task<string> GetAccessToken()
//		{
//			using (var client = new HttpClient())
//			{
//				client.BaseAddress = new Uri(baseUrl);

//				// We want the response to be JSON.
//				client.DefaultRequestHeaders.Accept.Clear();
//				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//				// Build up the data to POST.
//				List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
//				postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
//				postData.Add(new KeyValuePair<string, string>("client_id", clientId));
//				postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));

//				FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

//				// Post to the Server and parse the response.
//				HttpResponseMessage response = await client.PostAsync("Token", content);
//				string jsonString = await response.Content.ReadAsStringAsync();
//				object responseData = JsonConvert.DeserializeObject(jsonString);

//				// return the Access Token.
//				return ((dynamic)responseData).access_token;
//			}
//		}

//		/// <summary>
//		/// Gets the page of Articles.
//		/// </summary>
//		/// <param name="page">The page to get.</param>
//		/// <param name="tags">The tags to filter the articles with.</param>
//		/// <returns>The page of articles.</returns>
//		private static async Task<dynamic> GetArticles(int page, string tags)
//		{
//			using (var client = new HttpClient())
//			{
//				client.BaseAddress = new Uri(baseUrl);
//				client.DefaultRequestHeaders.Accept.Clear();
//				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//				// Add the Authorization header with the AccessToken.
//				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

//				// create the URL string.
//				string url = string.Format("v1/Articles?page={0}&tags={1}", page, HttpUtility.UrlEncode(tags));

//				// make the request
//				HttpResponseMessage response = await client.GetAsync(url);

//				// parse the response and return the data.
//				string jsonString = await response.Content.ReadAsStringAsync();
//				object responseData = JsonConvert.DeserializeObject(jsonString);
//				return (dynamic)responseData;
//			}
//		}

//		/// <summary>
//		/// Gets the page of Questions.
//		/// </summary>
//		/// <param name="page">The page to get.</param>
//		/// <param name="tags">The tags to filter the articles with.</param>
//		/// <returns>The page of articles.</returns>
//		private static async Task<dynamic> GetQuestions(int page, string tags)
//		{
//			using (var client = new HttpClient())
//			{
//				client.BaseAddress = new Uri(baseUrl);
//				client.DefaultRequestHeaders.Accept.Clear();
//				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//				// Add the Authorization header with the AccessToken.
//				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

//				// create the URL string.
//				string url = string.Format("v1/Questions/new?page={0}&include={1}", page, HttpUtility.UrlEncode(tags));

//				// make the request
//				HttpResponseMessage response = await client.GetAsync(url);

//				// parse the response and return the data.
//				string jsonString = await response.Content.ReadAsStringAsync();
//				object responseData = JsonConvert.DeserializeObject(jsonString);
//				return (dynamic)responseData;
//			}
//		}
//	}
//}

