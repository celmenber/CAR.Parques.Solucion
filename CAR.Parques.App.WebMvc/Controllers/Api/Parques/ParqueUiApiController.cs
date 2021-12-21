namespace CAR.Parques.App.WebMvc.Controllers.Api
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/ParqueUiApi")]
    public class ParqueUiApiController : BaseApiController
    {
        private readonly IParqueProxy iParqueProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iParqueProxyRepository;
            }
        }

        [ImportingConstructor]
        public ParqueUiApiController(IParqueProxy parqueProxyRepository)
        {
            iParqueProxyRepository = parqueProxyRepository;
        }

        [HttpGet]
        [Route("ObtenerListadoParques")]
        [DatosTransaccion]
        public IHttpActionResult ObtenerListadoParques()
        {
            var respuesta = iParqueProxyRepository.ConsultarListadoTodosParques();
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ObtenerListadoInformacionParques")]
        [DatosTransaccion]
        public IHttpActionResult ObtenerListadoInformacionParques()
        {
            var respuesta = iParqueProxyRepository.ConsultarListadoTodosParquesInformacion();
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ObtenerListadoParquesDetalle")]
        [DatosTransaccion]
        public IHttpActionResult ObtenerListadoParquesDetalle()
        {
            var respuesta = iParqueProxyRepository.ConsultarListadoTodosParques();
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarDetalleXId/{parqueId:int}")]
        public IHttpActionResult ConsultarDetalleXId(int parqueId)
        {
            var respuesta = iParqueProxyRepository.ConsultarDetalleParqueXId(parqueId);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]
        public IHttpActionResult CrearParque(ParqueModel parque)
        {
            var respuesta = iParqueProxyRepository.CrearParque(parque);
            return Ok(respuesta);
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccion]
        public IHttpActionResult ActualizarParque(ParqueModel parque)
        {
            var respuesta = iParqueProxyRepository.ActualizarParque(parque);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{parqueId:int}")]
        [DatosTransaccion]
        public IHttpActionResult EliminarParque(int parqueId)
        {
            var respuesta = iParqueProxyRepository.EliminarParque(parqueId);
            return Ok(respuesta);
        }
    }
}
