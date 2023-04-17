using Microsoft.AspNetCore.Mvc;



namespace HrApi.Controllers;



public class DepartmentsController : ControllerBase
{
    // GET /departments
    [HttpGet("/departments")]
    public async Task<ActionResult> GetDepartments()
    {
        return Ok();
    }
}