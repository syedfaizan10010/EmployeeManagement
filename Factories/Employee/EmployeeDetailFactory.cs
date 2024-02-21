using CosmosLibrary;
using EmployeeEntityModel;
using ViewModels;

namespace EmployeeManagement;
public class EmployeeDetailFactory :IEmployeeDetailFactory
{
    private readonly  IEmployeeService _employeeService; 
    private readonly IEmployeeServiceCosmos _empServiceCosmos;
    public EmployeeDetailFactory(IEmployeeService employeeService, IEmployeeServiceCosmos empServiceCosmos)
    {
       _employeeService = employeeService;   
       _empServiceCosmos = empServiceCosmos;
    }

    public async Task AddNewEmp(EmployeeDetailVM employee)
    {
        var postModel = new EmployeeDetails{
            Id = employee.Id,
            Salary = employee.Salary,
            Designation = employee.Designation,
            Name = employee.Name,
            Experience = employee.Experience
        };
        await _employeeService.AddEmployeeAsync(postModel);
    }

    public async Task<string> AddNewEmpCosmos(EmployeeDetailVM employee)
    {
        var postModel = new Model{
            id = Guid.NewGuid().ToString(),
            Id = employee.Id,
            Salary = employee.Salary,
            Designation = employee.Designation,
            Name = employee.Name,
            Experience = employee.Experience
        };
       var result = await _empServiceCosmos.AddEmployeeAsync(postModel);
       return result;
    }

    public async Task DeleteEmp(int id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
    }

    public async Task<List<EmployeeDetailVM>> GetAllEmployees()
    {
        var data = await _employeeService.GetEmployeesAsync();
        var model = data.Select(x => new EmployeeDetailVM {
            Id = x.Id,
            Name = x.Name,
            Salary = x.Salary,
            Designation = x.Designation,
            Experience = x.Experience
        });
        return model.ToList();
    }

    public async Task<EmployeeDetailVM> GetEmployeeById(int id)
    {
       var data = await _employeeService.GetEmployeeByIdAsync(id);
       var model = new EmployeeDetailVM{
            Id = data.Id,
            Name = data.Name,
            Salary = data.Salary,
            Designation = data.Designation,
            Experience = data.Experience
       };
       return model;
    }

    public async Task UpdateEmp(EmployeeDetailVM employee)
    {
        var updateModel = new EmployeeDetails{
            Id = employee.Id,
            Salary = employee.Salary,
            Designation = employee.Designation,
            Name = employee.Name,
            Experience = employee.Experience
        };
        await _employeeService.UpdateEmployeeAsync(updateModel);    }
}
