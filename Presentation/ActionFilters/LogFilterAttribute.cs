using Entities.LogDetails;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ActionFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;

        public LogFilterAttribute(ILoggerService logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInfo(Log("OnActionExecuting", context.RouteData));
        }
        private string Log(string a, RouteData routeData)
        {
            var lg = new LogDetails
            {
                ModelName = a,
                Action = routeData.Values["action"],
                Controller = routeData.Values["controller"],

            };
            if (routeData.Values.Count >= 3)
            {
                lg.Id = routeData.Values["id"];
            }
            return lg.ToString();
        }
    }
}
