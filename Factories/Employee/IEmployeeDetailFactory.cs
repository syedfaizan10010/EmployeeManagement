using ViewModels;

namespace EmployeeManagement;

public interface IEmployeeDetailFactory 
{

    Task<List<EmployeeDetailVM>> GetAllEmployees();
    Task<EmployeeDetailVM> GetEmployeeById(int id);
    Task AddNewEmp(EmployeeDetailVM employee);
    Task UpdateEmp(EmployeeDetailVM employee);
    Task DeleteEmp(int id);
    Task<string> AddNewEmpCosmos(EmployeeDetailVM employee);

}