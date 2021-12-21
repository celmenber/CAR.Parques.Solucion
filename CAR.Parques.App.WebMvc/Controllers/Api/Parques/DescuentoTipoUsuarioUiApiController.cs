namespace CAR.Parques.App.WebMvc.Controllers.Api.Parques
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/DescuentoTipoUsuarioUiApi")]
    public class DescuentoTipoUsuarioUiApiController : BaseApiController
    {
        private readonly IDescuentoTipoUsuarioProxy iDescuentoTipoUsuarioProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iDescuentoTipoUsuarioProxyRepository;
            }
        }

        [ImportingConstructor]
        public DescuentoTipoUsuarioUiApiController(IDescuentoTipoUsuarioProxy descuentoTipoUsuarioProxyRepository)
        {
            iDescuentoTipoUsuarioProxyRepository = descuentoTipoUsuarioProxyRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccion]
        public IHttpActionResult ActualizarServicioParque(DescuentoTipoUsuarioModel descuentoTipoUsuario)
        {
            var respuesta = iDescuentoTipoUsuarioProxyRepository.ActualizarDescuentoTipoUsuario(descuentoTipoUsuario);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{descuentoId:int}")]
        [DatosTransaccion]
        public IHttpActionResult EliminarParque(int descuentoId)
        {
            var respuesta = iDescuentoTipoUsuarioProxyRepository.EliminarDescuentoTipoUsuario(descuentoId);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]
        public IHttpActionResult CrearServicioParque(DescuentoTipoUsuarioModel descuentoTipoUsuario)
        {            
            var respuesta = iDescuentoTipoUsuarioProxyRepository.CrearDescuentoTipoUsuario(descuentoTipoUsuario);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarDetalleXId/{descuentoId:int}")]
        public IHttpActionResult ConsultarDetalleXId(int descuentoId)
        {
            var respuesta = iDescuentoTipoUsuarioProxyRepository.ConsultarDescuentoTipoUsuario(descuentoId);
            return Ok(respuesta);
        }
    }
}
