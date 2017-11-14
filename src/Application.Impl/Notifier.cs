using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Application;
using Newtonsoft.Json;

namespace Application.Impl
{
    public class Notifier : INotifier
    {
        private readonly IAmazonSimpleNotificationService _sns;

        public Notifier(
            IAmazonSimpleNotificationService sns
        ) {
            _sns = sns;
        }
        public async Task NotifyAsync(string message) {
            var response = await _sns.PublishAsync(
                topicArn: "arn:aws:sns:us-east-1:123456789012:test-topic",
                message: "Herro"
            );

            await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(response));
        }
    }
}
