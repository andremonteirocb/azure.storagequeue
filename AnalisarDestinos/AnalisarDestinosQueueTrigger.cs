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

            var connectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

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
