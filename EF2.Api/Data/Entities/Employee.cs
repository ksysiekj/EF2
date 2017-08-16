using EF2.Api.Data.Abstract;
using System;
using System.Collections.Generic;

namespace EF2.Api.Data.Entities
{
    public class Employee : IEntityAuditable, IEntityActiveable
    {
        public Employee()
        {
            SalariedFlag = true;
            VacationHours = 0;
            SickLeaveHours = 0;
            IsActive = true;
            ModifiedDate = DateTime.Now;
            JobCandidates = new List<JobCandidate>();
        }

        public virtual int EmployeeID { get; set; }
        public virtual string NationalIDNumber { get; set; }
        public virtual string Title { get; set; }
        public virtual System.DateTime BirthDate { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual string Gender { get; set; }
        public virtual System.DateTime HireDate { get; set; }
        public virtual bool SalariedFlag { get; set; }
        public virtual short VacationHours { get; set; }
        public virtual short SickLeaveHours { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual System.Guid Rowguid { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual ICollection<JobCandidate> JobCandidates { get; set; }
    }
}
