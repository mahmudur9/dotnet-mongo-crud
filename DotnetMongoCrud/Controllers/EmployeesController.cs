using DotnetMongoCrud.Models;
using DotnetMongoCrud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetMongoCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> EmployeeList()
        {
            return Ok(await employeeRepository.EmployeeList());
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Employee employee)
        {
            await employeeRepository.AddEmployee(employee);
            return Ok("Employee added successfully!");
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetEmployee(string id)
        {
            var employee = await employeeRepository.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await employeeRepository.UpdateEmployee(employee);
            return Ok("Employee updated successfully!");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await employeeRepository.DeleteEmployee(id);
            return Ok("Employee deleted successfully!");
        }
    }
}
