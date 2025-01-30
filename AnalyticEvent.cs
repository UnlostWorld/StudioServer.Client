namespace StudioServer.Client;

using System.Text.Json;

public class AnalyticEvent
{
	public string? EventName { get; set; }
	public string? EventData { get; set; }

	public Task Send()
	{
		string json = JsonSerializer.Serialize(this);
		return StudioServer.PostAsync("/analytics", json, "application/json");
	}
}
