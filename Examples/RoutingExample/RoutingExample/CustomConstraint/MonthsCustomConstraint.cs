
using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraint
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext,
            IRouter? route, string routeKey,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey))
            {
                return false;
            }

            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string? monthvalue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthvalue))
            {
                return true;
            }
            return false;
        }
    }
}
