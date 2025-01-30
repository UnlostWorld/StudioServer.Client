﻿namespace StudioServer.Client;

using System.Threading.Tasks;
using System.Text.Json;

public class ErrorReport
{
	public string? Message { get; set; }
	public string? LogFile { get; set; }

	public Task<string> Send()
	{
		string json = JsonSerializer.Serialize(this);
		return StudioServer.PostAsync("/error", json, "application/json");
	}
}
