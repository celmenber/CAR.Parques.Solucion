namespace CAR.Parques.App.WebMvc.Controllers.Api.Parques
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/ServicioParqueUiApi")]
    public class ServicioParqueUiApiController : BaseApiController
    {
        private readonly IServicioParqueProxy iServicioParqueProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iServicioParqueProxyRepository;
            }
        }

        [ImportingConstructor]
        public ServicioParqueUiApiController(IServicioParqueProxy servicioParqueProxyRepository)
        {
            iServicioParqueProxyRepository = servicioParqueProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarServiciosParque/{parqueId:int}")]
        public IHttpActionResult ConsultarServiciosParque(int parqueId)
        {
            var respuesta = iServicioParqueProxyRepository.ConsultarServiciosParque(parqueId);
            return Ok(respuesta);
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccion]
        public IHttpActionResult ActualizarServicioParque(ServicioParqueDetalleModel servicioParque)
        {
            var respuesta = iServicioParqueProxyRepository.ActualizarServiciosParque(servicioParque);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{servicioParqueId:int}")]
        [DatosTransaccion]
        public IHttpActionResult EliminarParque(int servicioParqueId)
        {
            var respuesta = iServicioParqueProxyRepository.EliminarServicioParque(servicioParqueId);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]
        public IHttpActionResult CrearServicioParque(ServicioParqueModel parque)
        {
            parque.FechaCreacion = DateTime.Now.ToString();
            var respuesta = iServicioParqueProxyRepository.CrearServicioParque(parque);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarDetalleXId/{servicioParqueId:int}")]
        public IHttpActionResult ConsultarDetalleXId(int servicioParqueId)
        {
            var respuesta = iServicioParqueProxyRepository.ConsultarDetalleServicioParqueXId(servicioParqueId);
            return Ok(respuesta);
        }
    }
}
