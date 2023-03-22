using Plant.NET.Infrastructure;

public class PlantNetClientOptions
{
    public string ApiKey { get; set; } = string.Empty;

    public int NumRequestRetries { get; set; } = PlantNetClientDefaults.NumRequestRetries;
}
