// See https://aka.ms/new-console-template for more information
using Microsoft.Identity.Client;
using System.Threading.Tasks;


public class Auth{
    private const string _clientId = "ba44634c-a797-4dda-9ecd-91e74ed5d3af";
    private const string _tenantId = "277d88b7-11dc-467a-82ba-813f93450925";
    
    public static async Task Main(string[] args)
    {
        var app = PublicClientApplicationBuilder
        .Create(_clientId)
        .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
        .WithRedirectUri("http://localhost")
        .Build();

        string[] scopes = { "user.read" }; 
        var result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
        Console.WriteLine($"Access Token {result.AccessToken}");

    }
}