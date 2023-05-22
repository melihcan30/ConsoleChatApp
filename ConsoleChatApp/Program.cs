using System;
using System.Threading.Tasks;

namespace ConsoleChatApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var chatClient = new ChatClient();
			await chatClient.StartAsync();

			Console.WriteLine("Press Enter to exit.");
			Console.ReadLine();

			await chatClient.StopAsync();
		}
	}
}

