using AutoMapper;
using AutoMapper.QueryableExtensions;
using HrApi.Domain;
using HrApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HrApi.Controllers;
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly HrDataContext _context;
    private readonly IMapper _mapper;
    private readonly Mapper _config;

    public DepartmentsController(HrDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // GET /departments
    [HttpGet("/departments")]
    public async Task<ActionResult<DepartmentsResponse>> GetDepartments()
    {
        var response = new DepartmentsResponse
        {
            Data = await _context.Departments
                .ProjectTo<DepartmentSummaryItem>(_config)
                .ToListAsync()
        };
        return Ok(response);
    }

    [HttpPost("/departments")]
    public async Task<ActionResult<DepartmentsResponse>> AddDepartment([FromBody] DepartmentCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        //var departmentToAdd = new DepartmentEntity { Name= request.Name };
        var departmentToAdd = _mapper.Map<DepartmentEntity>(request);
        _context.Departments.Add(departmentToAdd);
        await _context.SaveChangesAsync();
       
        var reponse = _mapper.Map<DepartmentSummaryItem>(departmentToAdd);
        return Ok(request);

    }
}
