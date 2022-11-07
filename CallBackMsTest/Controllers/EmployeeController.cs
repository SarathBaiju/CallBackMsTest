using CallBackMsTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallBackMsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeService.GetEmployeeById(id));
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post(EmployeeDto employee)
        {
            return Ok(await _employeeService.InsertEmployee(employee));
        }
    }
}
