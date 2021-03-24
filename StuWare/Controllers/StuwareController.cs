using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace StuWare.Helpers
{
    public class StuwareController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("Username")) || String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);         
        }
    }
}
