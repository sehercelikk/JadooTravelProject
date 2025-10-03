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
        _endpoint = config["TranslatorService:Endpoint"];
        _key = config["TranslatorService:Key"];
        _region = config["TranslatorService:Region"];

        _httpClient = new HttpClient();
    }

    public async Task<string> TranslateAsync(string text, string toLanguage)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;

        string route = $"/translate?api-version=3.0&to={toLanguage}";
        var requestUri = new Uri(_endpoint.TrimEnd('/') + route);

        var requestBody = JsonSerializer.Serialize(new object[] { new { Text = text } });

        using var request = new HttpRequestMessage(HttpMethod.Post, requestUri)
        {
            Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
        };

        request.Headers.Add("Ocp-Apim-Subscription-Key", _key);
        request.Headers.Add("Ocp-Apim-Subscription-Region", _region);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode(); // Hata varsa burada fırlatır

        var jsonResponse = await response.Content.ReadAsStringAsync();

        // JSON parse
        using var doc = JsonDocument.Parse(jsonResponse);
        if (doc.RootElement.ValueKind == JsonValueKind.Array)
        {
            return doc.RootElement[0].GetProperty("translations")[0].GetProperty("text").GetString() ?? text;
        }
        else if (doc.RootElement.ValueKind == JsonValueKind.Object)
        {
            // Bazen object dönüyorsa fallback
            if (doc.RootElement.TryGetProperty("translations", out var translations))
            {
                return translations[0].GetProperty("text").GetString() ?? text;
            }
        }

        return text;
    }

}
