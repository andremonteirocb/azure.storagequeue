using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Fundamentos.Azure.StorageQueue.AnalisarDestinos
{
    public static class AnalisarDestinosQueueTrigger
    {
        [Function("AnalisarDestinosQueueTrigger")]
        public static async Task Run([QueueTrigger("destinos", Connection = "AzureWebJobsStorage")] string myQueueItem,
            FunctionContext context)
        {
            var logger = context.GetLogger("AnalisarDestinosQueueTrigger");
            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            var queueName = "notificaremails"; 
            var queue = new QueueClient(connectionString, queueName, new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 });
            await queue.CreateIfNotExistsAsync();
            await queue.SendMessageAsync("Receba seu e-mail!");

            queueName = "notificarapps";
            queue = new QueueClient(connectionString, queueName);
            await queue.CreateIfNotExistsAsync();
            await queue.SendMessageAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes("Receba sua notificação!")));
        }
    }
}
