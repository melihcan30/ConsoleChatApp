using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

public class ChatClient
{
	private HubConnection _connection;

	public async Task StartAsync()
	{
		_connection = new HubConnectionBuilder()
			.WithUrl("https://localhost:5001")
			.Build();

		_connection.On<string>("ReceiveMessage", (message) =>
		{
			Console.WriteLine("New message: " + message);
		});

		await _connection.StartAsync();
		Console.WriteLine("Connected to the server.");

		while (true)
		{
			var input = Console.ReadLine();
			await _connection.InvokeAsync("SendMessage", input);
		}
	}

	public async Task StopAsync()
	{
		await _connection.StopAsync();
		await _connection.DisposeAsync();
	}
}

