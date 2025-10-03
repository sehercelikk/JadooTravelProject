using System.Text;
using System.Text.Json;
namespace JadooTravel.Services.TranslatorService;
public class TranslatorService
{
    private readonly string _key;
    private readonly string _endpoint;
    private readonly string _region;
    private readonly HttpClient _httpClient;

    public TranslatorService(IConfiguration config)
    {
        _key = config["TranslatorService:Key"];
        _endpoint = config["TranslatorService:Endpoint"];
        _region = config["TranslatorService:Region"];
        _httpClient = new HttpClient();
    }

    public async Task<string> TranslateAsync(string text, string toLanguage)
    {
        string route = $"/translate?api-version=3.0&to={toLanguage}";

        var requestBody = JsonSerializer.Serialize(new object[] { new { Text = text } });

        using var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(_endpoint + route),
            Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
        };

        request.Headers.Add("Ocp-Apim-Subscription-Key", _key);
        request.Headers.Add("Ocp-Apim-Subscription-Region", _region);

        var response = await _httpClient.SendAsync(request);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(jsonResponse);
        var translated = doc.RootElement[0].GetProperty("translations")[0].GetProperty("text").GetString();

        return translated ?? text;
    }
}
