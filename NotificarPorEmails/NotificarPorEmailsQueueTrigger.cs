using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Fundamentos.Azure.StorageQueue.NotificarPorEmails
{
    public static class NotificarPorEmailsQueueTrigger
    {
        [Function("NotificarPorEmailsQueueTrigger")]
        public static void Run([QueueTrigger("notificaremails", Connection = "AzureWebJobsStorage")] string myQueueItem,
            FunctionContext context)
        {
            var logger = context.GetLogger("NotificarPorEmailsQueueTrigger");
            logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
