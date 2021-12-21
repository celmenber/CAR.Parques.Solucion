namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/TipoServicioUiApi")]
    public class TipoServicioUiApiController : BaseApiController
    {
        private readonly ITipoServicioProxy iTipoServicioProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iTipoServicioProxyRepository;
            }
        }

        [ImportingConstructor]
        public TipoServicioUiApiController(ITipoServicioProxy tipoServicioProxyRepository)
        {
            iTipoServicioProxyRepository = tipoServicioProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoTipoServicio")]
        public IHttpActionResult ConsultarListadoTipoServicio()
        {
            var respuesta = iTipoServicioProxyRepository.ConsultarListadoTipoServicio();
            return Ok(respuesta);
        }
    }
}
