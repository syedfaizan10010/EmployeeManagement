using EmployeeManagement;
using Microsoft.AspNetCore.Mvc;

public class EmployeeController : Controller
{
    private readonly IEmployeeDetailFactory _employeeDetailFactory;

    public EmployeeController(IEmployeeDetailFactory employeeDetailFactory)
    {
        _employeeDetailFactory = employeeDetailFactory;
    }    

    public async Task<IActionResult> GetAllEmployeeDetails()
    {
        //var data = _employeeDetailFactory.GetAllEmployees();
        List<ViewModels.EmployeeDetailVM> data = await _employeeDetailFactory.GetAllEmployees();
        return View("~/Views/Employee/EmployeeDetails.cshtml",data);
    }
}
