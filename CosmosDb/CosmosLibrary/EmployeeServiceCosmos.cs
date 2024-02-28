
using Microsoft.Azure.Cosmos;

namespace CosmosLibrary;
public class EmployeeServiceCosmos : IEmployeeServiceCosmos
{
    private readonly IConfiguration _configuration;
    public EmployeeServiceCosmos(IConfiguration configuration)
    {
     _configuration = configuration;   
    }

    public async Task<string> AddEmployeeAsync(Model employee){
        var configuration = GetConfiguration();
        CosmosClient  client;
        client = new CosmosClient(configuration.URI,configuration.Key);
        Database db = client.GetDatabase(configuration.dbName);
        Container container = db.GetContainer(configuration.ContainerName);
        ItemResponse<Model> response=await container.CreateItemAsync<Model>(employee, new PartitionKey(employee.Id));
        return response.RequestCharge.ToString();
    }
    public CosmosDbConfiguration GetConfiguration(){
        var builder = WebApplication.CreateBuilder();
        builder.Configuration.AddEnvironmentVariables();
        // CosmosDbConfiguration configuration = new CosmosDbConfiguration{
        //     URI = _configuration.GetValue<string>("CosmosDbConfiguration:cosmosDbUri"),
        //     Key = _configuration.GetValue<string>("CosmosDbConfiguration:cosmosDbKey"),
        //     dbName = _configuration.GetValue<string>("CosmosDbConfiguration:dbName"),
        //     ContainerName = _configuration.GetValue<string>("CosmosDbConfiguration:containerName")
        // };
           CosmosDbConfiguration configuration = new CosmosDbConfiguration{
            URI = _configuration["CosmosDbConfiguration:cosmosDbUri"],
            Key = _configuration["CosmosDbConfiguration:cosmosDbKey"],
            dbName = _configuration["CosmosDbConfiguration:dbName"],
            ContainerName = _configuration["CosmosDbConfiguration:containerName"]
        };

        return configuration;
    }
    

}