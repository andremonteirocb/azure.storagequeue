using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Fundamentos.Azure.StorageQueue.NotificarApp
{
    public static class NotificarAppQueueTrigger
    {
        [Function("NotificarAppQueueTrigger")]
        public static void Run([QueueTrigger("notificarapps", Connection = "AzureWebJobsStorage")] string myQueueItem,
            FunctionContext context)
        {
            var logger = context.GetLogger("NotificarAppQueueTrigger");
            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
