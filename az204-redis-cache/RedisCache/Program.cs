using StackExchange.Redis;
using System.Threading.Tasks;

public class Program{

    static string connectionString = "az204redis18678.redis.cache.windows.net:6380,password=IZTZgxsaaYBt8M7h7OAyQciwW80PLJ1neAzCaAbrqYU=,ssl=True,abortConnect=False";

    public static async Task Main(string[] args){

        using(var cache = ConnectionMultiplexer.Connect(connectionString)){
            IDatabase db = cache.GetDatabase();

            var result = await db.ExecuteAsync("ping");
            Console.WriteLine($"PING =  {result.Type} : {result}");

            bool setValue = await db.StringSetAsync("test:key",100);
            Console.WriteLine($"SET =  {setValue}");


            var getValue = await db.StringGetAsync("test:key");
            Console.WriteLine($"GET =  {getValue}");

            

        }

    }

}