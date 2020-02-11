using LabTestVerThree.Infrastructure;
using LabTestVerThree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTestVerThree.Filters
{
    public class LogConnectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            EventsDetails visitor = new EventsDetails()
            {
                EventMessage = (request.IsAuthenticated) ? "connect:" + filterContext.HttpContext.User.Identity.Name : "null",
                StackTrace = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress
            };

            using (AppIdentityDbContext db = new AppIdentityDbContext())
            {
                db.EventDetails.Add(visitor);
                db.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}