using EmployeeManagement;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

public class EmployeeController : Controller
{
    private readonly IEmployeeDetailFactory _employeeDetailFactory;

    public EmployeeController(IEmployeeDetailFactory employeeDetailFactory)
    {
        _employeeDetailFactory = employeeDetailFactory;
    }    

    public async Task<IActionResult> GetAllEmployeeDetails()
    {
        List<ViewModels.EmployeeDetailVM> data = await _employeeDetailFactory.GetAllEmployees();
        return View("~/Views/Employee/EmployeeDetails.cshtml",data);
    }

    public async Task<IActionResult> SaveEmployee(ViewModels.EmployeeDetailVM model){
        await _employeeDetailFactory.AddNewEmp(model);
        return await GetAllEmployeeDetails();
    }

    public async Task<IActionResult> AddEmployee(){
    return View("~/Views/Employee/AddEmployee.cshtml"); 
    }

    public async Task<IActionResult> UpdateEmployee(EmployeeDetailVM model){
        await _employeeDetailFactory.UpdateEmp(model);
        return await GetAllEmployeeDetails();
    }

    public async Task DeleteEmployee(int id)
    {
        await _employeeDetailFactory.DeleteEmp(id);
    }
}
