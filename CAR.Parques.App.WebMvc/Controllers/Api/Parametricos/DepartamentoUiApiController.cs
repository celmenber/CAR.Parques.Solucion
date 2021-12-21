namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/DepartamentoUiApi")]
    public class DepartamentoUiApiController : BaseApiController
    {
        private readonly IDepartamentoProxy iDepartamentoProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iDepartamentoProxyRepository;
            }
        }

        [ImportingConstructor]
        public DepartamentoUiApiController(IDepartamentoProxy departamentoProxyRepository)
        {
            iDepartamentoProxyRepository = departamentoProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoDepartamentos")]
        public IHttpActionResult ConsultarListadoDepartamentos()
        {
            var respuesta = iDepartamentoProxyRepository.ConsultarListadoDepartamentos();
            return Ok(respuesta);
        }
    }
}
