namespace CAR.Parques.Service.WebApi.Filters
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.ReturnValue)]
    public class ControlExcepcionesAttribute : ExceptionFilterAttribute
    {
        private readonly ILogManager _logRepository;

        public ControlExcepcionesAttribute(ILogManager logRepository)
        {
            _logRepository = logRepository;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = 
                    context.Request.CreateErrorResponse(HttpStatusCode.NotImplemented, context.Exception);
            }

            try
            {
                //var headers = context.Request.Headers;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}