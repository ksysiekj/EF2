using EF2.Api.Controllers.Abstract;
using EF2.Api.Data;
using EF2.Api.Data.Entities;
using EF2.Api.Extensions;
using EF2.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EF2.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : BaseController
    {
        public EmployeesController(AdventureWorksDbContext adventureWorksDbContext) : base(adventureWorksDbContext)
        {
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<EmployeeViewModel> employees = _adventureWorksDbContext.Employees.AsNoTracking().Select(
                employee =>
                new EmployeeViewModel
                {
                    BirthDate = employee.BirthDate,
                    Id = employee.EmployeeID,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate,
                    MaritalStatus = employee.MaritalStatus,
                    NationalIDNumber = employee.NationalIDNumber,
                    SalariedFlag = employee.SalariedFlag,
                    IsActive = employee.IsActive,
                    SickLeaveHours = employee.SickLeaveHours,
                    Title = employee.Title,
                    VacationHours = employee.VacationHours
                });

            return Json(employees, DefaultJsonSerializerSettings);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Employee employee = await _adventureWorksDbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                return Json(employee.MapToViewModel(), DefaultJsonSerializerSettings);
            }

            return NotFound();
        }
    }
}
