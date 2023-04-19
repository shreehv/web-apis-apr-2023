using HrApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HrApi.Controllers
{
    public class HiringRequestsController : ControllerBase
    {
        [HttpPost("/hiring-requests")]
        public async Task<ActionResult> AddAHiringRequest([FromBody] HiringRequestCreateModel request)
        {
            return Ok();
        }
    }
}
