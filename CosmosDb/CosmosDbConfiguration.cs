using CosmosLibrary;
using Microsoft.Azure.Cosmos;
public class CosmosDbConfiguration{

    public string URI { get; set; } 
    public string Key { get; set; }
    public string dbName { get; set; }
    public string ContainerName { get; set; }
    public Database DatabaseNameCosmos { get; set; }
    public Container ContainerCosmos {get; set;}
}