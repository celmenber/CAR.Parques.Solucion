namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/EstadoReservaUiApi")]
    public class EstadoReservaUiApiController : BaseApiController
    {
        private readonly IEstadoReservaProxy iEstadoReservaProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iEstadoReservaProxyRepository;
            }
        }

        [ImportingConstructor]
        public EstadoReservaUiApiController(IEstadoReservaProxy estadoReservaProxyRepository)
        {
            iEstadoReservaProxyRepository = estadoReservaProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoEstadoReserva")]
        public IHttpActionResult ConsultarListadoEstadoReserva()
        {
            var respuesta = iEstadoReservaProxyRepository.ConsultarListadoEstadoReservas();
            return Ok(respuesta);
        }
    }
}
