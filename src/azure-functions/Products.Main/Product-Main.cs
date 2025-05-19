using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;

namespace Company.Function;

public class Product_Main
{
    private readonly ILogger<Product_Main> _logger;

    public Product_Main(ILogger<Product_Main> logger)
    {
        _logger = logger;
    }

    [Function(nameof(Product_Main))]
    public async Task Run([BlobTrigger("product-samples/{name}", Connection = "AZURE_STORAGE")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();

        _logger.LogInformation("C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}", name, content);

        //read the service bus connection string from environment variable SERVICE_BUS
        var serviceBusConnectionString = Environment.GetEnvironmentVariable("SERVICE_BUS");    
        if (string.IsNullOrEmpty(serviceBusConnectionString))
        {
            _logger.LogError("Service Bus connection string is not set.");
            return;
        }

        var serviceBusClient = new ServiceBusClient("Endpoint=sb://host.docker.internal;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;");
        var sender = serviceBusClient.CreateSender("product-samples");
        var message = new ServiceBusMessage(content);
        await sender.SendMessageAsync(message);
        await sender.DisposeAsync();
        await serviceBusClient.DisposeAsync();
    }
}