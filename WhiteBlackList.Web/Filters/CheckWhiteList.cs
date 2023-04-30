using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Net;
using WhiteBlackList.Web.MiddleWares;

namespace WhiteBlackList.Web.Filters
{
    public class CheckWhiteList:ActionFilterAttribute
    {

        private readonly IPList _ipList;

        public CheckWhiteList(IOptions<IPList> ipList)
        {
            _ipList = ipList.Value;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var reqIpAdress = context.HttpContext.Connection.RemoteIpAddress;

            var isWhiteList= this._ipList.WhiteList.Where(a=>IPAddress.Parse(a).Equals(reqIpAdress)).Any();

            if (!isWhiteList)
            {
                context.Result = new StatusCodeResult(404);

                return;
            }

            base.OnActionExecuted(context);
        }

    }
}
