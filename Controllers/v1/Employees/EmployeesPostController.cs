using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Models.DTOs;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Employees
{
    public partial class EmployeesController
    {
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _service.Create(dto);

            if (created == false)
            {
                return StatusCode(500, "An error occurred while creating the object.");
            }

            return Created();
        }
    }
}