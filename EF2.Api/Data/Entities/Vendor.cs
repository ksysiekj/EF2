using System;
using EF2.Api.Data.Abstract;

namespace EF2.Api.Data.Entities
{
    public class Vendor : IEntityAuditable, IEntityActiveable
    {
        public Vendor()
        {
            PreferredVendorStatus = true;
            IsActive = true;
            ModifiedDate = DateTime.Now;
        }

        public virtual int VendorID { get; set; }
        public virtual string AccountNumber { get; set; }
        public virtual string Name { get; set; }
        public virtual byte CreditRating { get; set; }
        public virtual bool PreferredVendorStatus { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string PurchasingWebServiceURL { get; set; }
        public virtual System.DateTime ModifiedDate { get; set; }
    }
}