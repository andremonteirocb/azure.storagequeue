using Microsoft.Extensions.Hosting;

namespace Fundamentos.Azure.StorageQueue.NotificarPorEmails
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .Build();

            host.Run();
        }
    }
}