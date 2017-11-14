using System;
using System.Threading.Tasks;

namespace Application.Fake
{
    public class FakeNotifier : INotifier
    {
        public async Task NotifyAsync(string message) {
            await Console.Out.WriteLineAsync($"Notifying: {message}");
            await Task.CompletedTask;
        }
    }
}
