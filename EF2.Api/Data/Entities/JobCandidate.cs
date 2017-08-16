using EF2.Api.Data.Abstract;
using System;

namespace EF2.Api.Data.Entities
{
    public class JobCandidate : IEntityAuditable
    {
        public JobCandidate()
        {
            ModifiedDate = DateTime.Now;
        }
        public virtual int JobCandidateID { get; set; }
        public virtual int? EmployeeID { get; set; }
        public virtual string Resume { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}