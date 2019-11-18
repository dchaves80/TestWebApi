using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Route("api/Default/{action}")]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [ActionName("GetHola")]
        public string GetHola()
        {
            return "hola";
        }
    }
}
