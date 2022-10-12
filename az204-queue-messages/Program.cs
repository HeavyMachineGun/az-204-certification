using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
public class Program{
    public static string connectionString = "Endpoint=sb://az204svcbus7797.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=OvtNBsXREFjwddJCobQ7I35kEkdbJ6Tc5I6R0XM60E8=";
    public static string queueName = "az204-queue";

    public static ServiceBusClient client;
    public static ServiceBusSender sender;

    private const int numOfMessages = 3;

    public static async Task Main(string[] args)
    {
        client = new ServiceBusClient(connectionString);
        sender = client.CreateSender(queueName);

        using var messageBatch = await sender.CreateMessageBatchAsync();
        for(int i=1; i< numOfMessages; i++)
        {
            if(!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}"))){

                throw new Exception($"Exception {i} has occurred");
            }
        }
        try
        {
            await sender.SendMessagesAsync(messageBatch);
            Console.WriteLine("Messages has been sent");
        }catch(Exception e)
        {
            await sender.DisposeAsync();
            await client.DisposeAsync();
        }

    }

}