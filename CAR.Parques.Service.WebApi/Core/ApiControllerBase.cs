namespace CAR.Parques.Service.WebApi.Core
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;

    public abstract class ApiControllerBase : ApiController
    {
        public abstract IEnumerable<IBaseServicioManager> Services { get; }

        protected HttpResponseMessage GetHttpResponse(
            HttpRequestMessage request, 
            Func<HttpResponseMessage> codigoEjecutar)
        {
            HttpResponseMessage response = null;
            try
            {
                response = codigoEjecutar.Invoke();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }

        protected HttpResponseMessage GetHttpResponse(Func<HttpResponseMessage> codigoEjecutar)
        {
            HttpResponseMessage response = null;
            try
            {
                response = codigoEjecutar.Invoke();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return response;
        }
    }
}