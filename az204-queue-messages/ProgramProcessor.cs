using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
public class ProgramProcessor{
    public static string connectionString = "Endpoint=sb://az204svcbus7797.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=OvtNBsXREFjwddJCobQ7I35kEkdbJ6Tc5I6R0XM60E8=";
    public static string queueName = "az204-queue";

    public static ServiceBusClient client;
    public static ServiceBusProcessor processor;

    private const int numOfMessages = 3;

    public static async Task Main(string[] args)
    {
        client = new ServiceBusClient(connectionString);
        processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

        try
        {
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;

            await processor.StartProcessingAsync();

            Console.WriteLine("Wait for a minute and then press a key to end processing");
            Console.ReadKey();

            Console.WriteLine("Stoping the reciver");
            
            await processor.StopProcessingAsync();
            Console.WriteLine("Stopped reciving messages");
        
        }finally{
            await processor.DisposeAsync();
            await client.DisposeAsync();
        }
        

    }

    static async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        Console.WriteLine($"Recived: {body}");
        await args.CompleteMessageAsync(args.Message);
    }

    static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }
}