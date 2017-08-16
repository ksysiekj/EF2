using EF2.Api.Data.Entities;
using EF2.Api.ViewModels;

namespace EF2.Api.Extensions
{
    internal static class Mapper
    {
        internal static EmployeeViewModel MapToViewModel(this Employee employee)
        {
            return new EmployeeViewModel
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
            };
        }
    }
}
