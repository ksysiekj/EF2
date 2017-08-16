using EF2.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EF2.Api.Controllers.Abstract
{
    public class BaseController : Controller
    {
        protected readonly AdventureWorksDbContext _adventureWorksDbContext;

        protected static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        public BaseController(AdventureWorksDbContext adventureWorksDbContext)
        {
            _adventureWorksDbContext = adventureWorksDbContext;
        }
    }
}