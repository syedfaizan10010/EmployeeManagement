using EmployeeEntityModel;
using EmployeeData;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService;

public class EmployeeDataService : IEmployeeService
{
    private readonly EmplyeeDbContext _employeeDataSource;

    public EmployeeDataService(EmplyeeDbContext emplyeeDbSource)
    {
        _employeeDataSource = emplyeeDbSource;
    }
    public async Task<List<EmployeeDetails>> GetEmployeesAsync()
    {
        var result = await _employeeDataSource.EmployeeDetails.ToListAsync();;
        return result ?? null;
    }

    public async Task<EmployeeDetails> GetEmployeeByIdAsync(int id)
    {
        var result = await _employeeDataSource.EmployeeDetails.FindAsync(id);
        return result ?? null;
    }

    public async Task AddEmployeeAsync(EmployeeDetails employee)
    {
        _employeeDataSource.EmployeeDetails.Add(employee);
        await _employeeDataSource.SaveChangesAsync();    }

    public async Task UpdateEmployeeAsync(EmployeeDetails employee)
    {
        _employeeDataSource.Entry(employee).State = EntityState.Modified;
        await _employeeDataSource.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _employeeDataSource.EmployeeDetails.FindAsync(id);
        if (employee != null)
        {
            _employeeDataSource.EmployeeDetails.Remove(employee);
            await _employeeDataSource.SaveChangesAsync();
        }    
    }

}
