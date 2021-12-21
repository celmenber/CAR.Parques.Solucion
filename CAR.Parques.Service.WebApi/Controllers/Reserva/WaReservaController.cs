namespace CAR.Parques.Service.WebApi.Controllers.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.Reserva;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using CAR.Parques.Service.WebApi.Adaptadores;
    using CAR.Parques.Service.WebApi.Core;
    using CAR.Parques.Service.WebApi.Core.ContratoBase;
    using CAR.Parques.Service.WebApi.Filters;    
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/WaReserva")]
    public class WaReservaController : ApiControllerBase, IApiAccionDTControllerBase<ReservaModel>
    {
        private readonly IReservaManager _reservaRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _reservaRepository;
            }
        }



        [ImportingConstructor]
        public WaReservaController(IReservaManager reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(ReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var reserva = ConfiguracionApiMappers.GetInstance.
                To<ReservaModel, ReservaEO>(entidad);
                var resultado = this._reservaRepository.Actualizar(reserva);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("Consultar/{id:int}")]
        public HttpResponseMessage Consultar(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._reservaRepository.Consultar(id);
                var reserva = ConfiguracionApiMappers.GetInstance.
                To<ReservaEO, ReservaModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<ReservaModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = reserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        //[Route("ConsultarReservasDetalle/{estadoId:int}/{parqueId:int}/{fechaIncio:string}/{fechaFin:string}")]
        [Route("ConsultarReservasDetalle/{estadoId:int}/{parqueId:int}/{fechaIncio}/{fechaFin}")]
        public HttpResponseMessage ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._reservaRepository.ConsultarReservasDetalleServicio(estadoId, parqueId, fechaIncio, fechaFin);
                var reserva = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ReservaDetalleServicioEO>, IEnumerable<ReservaDetalleServicioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ReservaDetalleServicioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = reserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public HttpResponseMessage ConsultarTodos()
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._reservaRepository.ConsultarTodos();
                var reserva = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ReservaEO>, IEnumerable<ReservaModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ReservaModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = reserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ReservasUsuario/{usuarioId:int}/{estadoId:int}")]
        public HttpResponseMessage ConsultarReservasUsuarioPorEstado(int usuarioId, int estadoId)
        {
            return GetHttpResponse(() =>
            {
                ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> resultado;
                if (estadoId != 0) {
                    resultado = this._reservaRepository.ConsultarReservasUsuario(usuarioId, estadoId);
                }
                else { 
                    resultado = this._reservaRepository.ConsultarReservasUsuario(usuarioId);
                }
                
                var reserva = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ReservaDetalleServicioEO>, IEnumerable<ReservaDetalleServicioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ReservaDetalleServicioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = reserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPut]
        [DatosTransaccionInfo]
        [Route("EstadoReserva")]
        public IHttpActionResult ActualizarEstadoReserva(ReservaModel reserva)
        {
            var respuesta = _reservaRepository.ActualizarEstadoReserva(reserva);
            return Ok(respuesta);
        }

        [HttpGet]
        [DatosTransaccionInfo]
        [Route("ArchivoReserva/{reservaId:int}")]
        public HttpResponseMessage ObtenerArchivoComprobanteReserva(int reservaId)
        {
            return GetHttpResponse(() =>
            {
                var respuesta = _reservaRepository.ObtenerArchivoComprobanteReserva(reservaId);

                var resultadoEjecucion = new ResultadoEjecucionModel<ArchivoReservaEO>
                {
                    Codigo = respuesta.Codigo,
                    Descripcion = respuesta.Descripcion,
                    Entidad = respuesta.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("ArchivoReserva")]
        [DatosTransaccionInfo]        
        public HttpResponseMessage CrearArchivoReserva(ArchivoReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var archivoReserva = ConfiguracionApiMappers.GetInstance.
                To<ArchivoReservaModel, ArchivoReservaEO>(entidad);

                var resultado = this._reservaRepository.CargarArchivoReserva(archivoReserva);

                var resultadoEjecucion = new ResultadoEjecucionModel<int>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };

                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }
         
        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(ReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var reserva = ConfiguracionApiMappers.GetInstance.
                To<ReservaModel, ReservaEO>(entidad);
                var resultado = this._reservaRepository.Crear(reserva);
                var resultadoEjecucion = new ResultadoEjecucionModel<int>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("CrearReservaDetalle")]
        [DatosTransaccionInfo]
        public HttpResponseMessage CrearReservaDetalle(RevDetalleModel entidad)
        {            
            return GetHttpResponse(() =>
            {
                var resultadoEjecucion = new ResultadoEjecucionModel<int>();
                try
                {
                    var reserva = ConfiguracionApiMappers.GetInstance.
                                    To<ReservaModel, ReservaEO>(entidad.Reserva);
                    
                    var detalle = ConfiguracionApiMappers.GetInstance.
                    To<IEnumerable<DetalleReservaModelFecha>, IEnumerable<DetalleReservaEO>>(entidad.Detalle);

                    var resultado = this._reservaRepository.CrearDetalle(reserva, detalle);

                    resultadoEjecucion.Codigo = resultado.Codigo;
                    resultadoEjecucion.Descripcion = resultado.Descripcion;
                    resultadoEjecucion.Entidad = resultado.Entidad;
                    
                }
                catch (System.Exception ex)
                {
                    resultadoEjecucion.Codigo = 0;
                    resultadoEjecucion.Descripcion = ex.Message;
                    resultadoEjecucion.Entidad = 0;
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Eliminar(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._reservaRepository.Eliminar(id);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("ValidarPreReserva")]
        [DatosTransaccionInfo]
        public HttpResponseMessage ValidarPreReserva(DetalleReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var detalleReserva = ConfiguracionApiMappers.GetInstance.
                To<DetalleReservaModel, DetalleReservaEO>(entidad);

                var resultado = this._reservaRepository.ValidarPreReserva(detalleReserva);
                var resultadoEjecucion = new ResultadoEjecucionModel<int>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }
    }
}
