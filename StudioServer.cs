namespace StudioServer.Client;

using System.Net;
using System.Text;

public static class StudioServer
{
	public static string Url = "http://unlostworld.duckdns.org:5202/api/";

	private static readonly HttpClient client;

	static StudioServer()
	{
		HttpClientHandler handler = new HttpClientHandler
		{
			AutomaticDecompression = DecompressionMethods.All
		};

		client = new();
	}

	public static async Task<string> GetAsync(string uri)
	{
		using HttpResponseMessage response = await client.GetAsync(Url + uri);

		return await response.Content.ReadAsStringAsync();
	}

	public static async Task<string> PostAsync(string uri, string data, string contentType)
	{
		using HttpContent content = new StringContent(data, Encoding.UTF8, contentType);

		HttpRequestMessage requestMessage = new HttpRequestMessage()
		{
			Content = content,
			Method = HttpMethod.Post,
			RequestUri = new Uri(Url + uri)
		};

		using HttpResponseMessage response = await client.SendAsync(requestMessage);

		return await response.Content.ReadAsStringAsync();
	}
}
