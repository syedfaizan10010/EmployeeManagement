namespace CosmosLibrary;

public interface IEmployeeServiceCosmos
{
    Task<string> AddEmployeeAsync(Model employee);
}