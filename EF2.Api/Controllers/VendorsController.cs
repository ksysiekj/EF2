using EF2.Api.Controllers.Abstract;
using EF2.Api.Data;
using EF2.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF2.Api.Controllers
{
    [Route("api/[controller]")]
    public class VendorsController : BaseController
    {
        public VendorsController(AdventureWorksDbContext adventureWorksDbContext) : base(adventureWorksDbContext)
        {
        }

        [HttpGet]
        public IActionResult Get(DateTime sinceModifiedDate)
        {
            IQueryable<VendorViewModel> vendors = _adventureWorksDbContext.Vendors.AsNoTracking()
                .Where(q => q.ModifiedDate >= sinceModifiedDate)
                .Select(
                vendor =>
                    new VendorViewModel
                    {
                        Id = vendor.VendorID,
                        IsActive = vendor.IsActive,
                        AccountNumber = vendor.AccountNumber,
                        Name = vendor.Name,
                        PreferredVendorStatus = vendor.PreferredVendorStatus
                    });

            return Json(vendors, DefaultJsonSerializerSettings);
        }
    }
}