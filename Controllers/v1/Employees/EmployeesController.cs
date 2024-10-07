using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_JuanJoseZapata.Repositories.Interfaces;

namespace PruebaNET_JuanJoseZapata.Controllers.v1.Employees
{
    [ApiController]
    [Route("api/v1/employees")]
    public partial class EmployeesController : ControllerBase
    {
        private readonly IEmployeeInterface _service;
        private readonly IAuth _authService;

        public EmployeesController(IEmployeeInterface service, IAuth authService)
        {
            _service  = service;
            _authService = authService;
        }
    }
}