using EmployeeEntityModel;

public interface IEmployeeService
{
    Task<List<EmployeeDetails>> GetEmployeesAsync();
    Task<EmployeeDetails> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(EmployeeDetails employee);
    Task UpdateEmployeeAsync(EmployeeDetails employee);
    Task DeleteEmployeeAsync(int id);
}
