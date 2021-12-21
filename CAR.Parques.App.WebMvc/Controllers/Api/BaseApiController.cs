namespace CAR.Parques.App.WebMvc.Controllers.Api
{
    using CAR.Parques.UI.Proxy.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/BaseApi")]
    public class BaseApiController : ApiController
    {
        public virtual IEnumerable<IBaseProxy> Proxies
        {
            get;
        }

        protected T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}