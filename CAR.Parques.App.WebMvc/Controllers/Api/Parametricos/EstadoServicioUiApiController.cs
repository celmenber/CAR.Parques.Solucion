namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/EstadoServicioUiApi")]
    public class EstadoServicioUiApiController : BaseApiController
    {
        private readonly IEstadoServicioProxy iEstadoServicioProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iEstadoServicioProxyRepository;
            }
        }

        [ImportingConstructor]
        public EstadoServicioUiApiController(IEstadoServicioProxy estadoServicioProxyRepository)
        {
            iEstadoServicioProxyRepository = estadoServicioProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoEstadoServicio")]
        public IHttpActionResult ConsultarListadoTipoDocumento()
        {
            var respuesta = iEstadoServicioProxyRepository.ConsultarListadoEstadoServicio();
            return Ok(respuesta);
        }
    }
}
