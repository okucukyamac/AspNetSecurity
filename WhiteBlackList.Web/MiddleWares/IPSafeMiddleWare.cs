using Microsoft.Extensions.Options;
using System.Net;

namespace WhiteBlackList.Web.MiddleWares
{
    public class IPSafeMiddleWare
    {

        private readonly RequestDelegate _next;

        private readonly IPList _ipList;

        public IPSafeMiddleWare(RequestDelegate next, IOptions<IPList> ipList)
        {
            this._next = next;
            this._ipList = ipList.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var reqIpAdress = context.Connection.RemoteIpAddress;

            var isWhiteList = _ipList.WhiteList.Where(a => IPAddress.Parse(a).Equals(reqIpAdress)).Any();

            if (isWhiteList)
            {
                context.Response.StatusCode=(int)HttpStatusCode.Forbidden;

                return;
            }

            await _next(context).ConfigureAwait(false);
        }

    }
}
