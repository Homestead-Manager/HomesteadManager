using HomesteadManagerApi.Interfaces;
using HomesteadManagerApi.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HomesteadManagerApi.Services;

public class OpenAIService : IOpenAIService
{
	private readonly HttpClient _httpClient;
	private readonly IOptions<OpenAIConfig> _config;

	public OpenAIService(IOptions<OpenAIConfig> config, HttpClient httpClient)
	{
		_config = config;
		_httpClient = httpClient;
		InitializeClient();
	}

	private void InitializeClient()
	{
		_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.Value.ApiKey);
		_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	}

	public async Task<string> CallEndpointAsync(string prompt, string model)
	{
		var requestBody = new
		{
			prompt = prompt,
			model = model,
			// Add additional parameters here if needed (e.g., temperature, max_tokens, etc.)
		};

		var jsonContent = JsonConvert.SerializeObject(requestBody);
		var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

		try
		{
			var response = await _httpClient.PostAsync(_config.Value.EndpointUrl, httpContent);

			if (!response.IsSuccessStatusCode)
			{
				var errorContent = await response.Content.ReadAsStringAsync();
				throw new HttpRequestException($"Error calling the Azure OpenAI endpoint: {response.StatusCode} - {errorContent}");
			}

			var resultContent = await response.Content.ReadAsStringAsync();
			return resultContent;
		}
		catch (Exception e)
		{
			throw new Exception("An error occurred while calling the Azure OpenAI endpoint", e);
		}
	}
}