using System.Net.Http;
using System.Threading.Tasks;

public class ExternalApiService
{
    private readonly HttpClient _httpClient;       

    public ExternalApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;   
    }

    public async Task<string> GetExternalData()
    {
        var externalApiUrl = "https://localhost:7000/api";

        var response = await _httpClient.GetAsync(externalApiUrl);

        if (response.IsSuccessStatusCode) 
        { 
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        return null;
    }

}
