using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IConfiguration Configuration { get; private set; }
        IConfiguration _iconfiguration;
        public ValuesController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string conString = Microsoft
               .Extensions
               .Configuration
               .ConfigurationExtensions
               .GetConnectionString(this.Configuration, "DefaultConnection");
            try
            {
                string value1 = _iconfiguration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           // string value1 = _iconfiguration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return new string[] { "value1", "value2" };
        }
    }
}
