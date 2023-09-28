using System.Text.Json;

await GenerateCountryDataFilesAsync();

static async Task GenerateCountryDataFilesAsync()
{
    var countriesApiClient = new CountriesApiClient();

    var countries = await countriesApiClient.GetAllCountries();

    var directoryPath = await FileHelper.CreateDirectoryInCurrentAssembly("Countries");

    foreach (var country in countries)
    {
        var countryName = country.Name?.Official?.Replace(' ', '_');
        var filePath = Path.Combine(directoryPath, $"{countryName}.txt");
        await File.WriteAllTextAsync(filePath, country.ToString());
    }
}

public static class FileHelper
{
    public static Task<string> CreateDirectoryInCurrentAssembly(string directoryName)
    {
        var currentAssemblyPath = AppDomain.CurrentDomain.BaseDirectory;
        var directoryPath = Path.Combine(currentAssemblyPath, directoryName);
        Directory.CreateDirectory(directoryPath);

        return Task.FromResult(directoryPath);
    }
}

public class CountriesApiClient
{
    private readonly RestApiClient _restApiClient;

    public CountriesApiClient()
    {
        _restApiClient = new RestApiClient();
    }

    public async Task<List<Country>> GetAllCountries()
    {
        var apiUrl = "https://restcountries.com/v3.1/all";

        return await _restApiClient.CallRestGetApiAsync<List<Country>>(apiUrl);
    }
}

public class RestApiClient
{
    private readonly HttpClient _httpClient;

    public RestApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TResponse> CallRestGetApiAsync<TResponse>(string apiUrl)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Read and return the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                var responseData = JsonSerializer.Deserialize<TResponse>(
                    responseBody,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return responseData;
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }

        return default;
    }
}

public class Country
{
    public CountryName Name { get; set; }
    public string Region { get; set; }
    public string Subregion { get; set; }
    public float Area { get; set; }
    public int Population { get; set; }
    public float[] LatLng { get; set; }

    public override string ToString()
    {
        var result = $"Region: {Region}{Environment.NewLine}" +
            $"Subregion: {Subregion}{Environment.NewLine}" +
            $"Area: {Area}{Environment.NewLine}" +
            $"Population: {Population}{Environment.NewLine}" +
            $"LatLang: [{LatLng[0]}, {LatLng[1]}]";

        return result;
    }
}

public record CountryName(string Official);