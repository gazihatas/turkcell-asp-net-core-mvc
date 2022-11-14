using System.Net;

namespace MiddlewareExample.Web.Middlewares
{
    public class WhiteIpAddressControlMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private const string WhiteIpAddres = "::1";

        public WhiteIpAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //IPV4 => 127.0.0.1 => localhost
            //IPV6 => ::1 => localhost

            var requestIpAddress = context.Connection.RemoteIpAddress;

            bool AnyWhiteIpAdress = IPAddress.Parse(WhiteIpAddres).Equals(requestIpAddress);

            if(AnyWhiteIpAdress==true)
            {
                await _requestDelegate(context);
            }
            else
            {
                context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
                await context.Response.WriteAsync("Forbidden");
            }
        }
    }
}
