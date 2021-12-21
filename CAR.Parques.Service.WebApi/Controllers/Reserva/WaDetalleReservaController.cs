namespace CAR.Parques.Service.WebApi.Controllers.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.Reserva;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Base;
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
    [RoutePrefix("api/WaDetalleReserva")]
    public class WaDetalleReservaController : ApiControllerBase, IApiAccionDTControllerBase<DetalleReservaModel>
    {
        private readonly IDetalleReservaManager _detalleReservaRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _detalleReservaRepository;
            }
        }

        [ImportingConstructor]
        public WaDetalleReservaController(IDetalleReservaManager detalleReservaRepository)
        {
            _detalleReservaRepository = detalleReservaRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(DetalleReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var detalleReserva = ConfiguracionApiMappers.GetInstance.
                To<DetalleReservaModel, DetalleReservaEO>(entidad);
                var resultado = this._detalleReservaRepository.Actualizar(detalleReserva);
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
                var resultado = this._detalleReservaRepository.Consultar(id);
                var detalleReserva = ConfiguracionApiMappers.GetInstance.
                To<DetalleReservaEO, DetalleReservaModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<DetalleReservaModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = detalleReserva
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
                var resultado = this._detalleReservaRepository.ConsultarTodos();
                var detalleReserva = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<DetalleReservaEO>, IEnumerable<DetalleReservaModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<DetalleReservaModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = detalleReserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(DetalleReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var detalleReserva = ConfiguracionApiMappers.GetInstance.
                To<DetalleReservaModel, DetalleReservaEO>(entidad);
                var resultado = this._detalleReservaRepository.Crear(detalleReserva);
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
        [Route("ValidarPreReserva")]
        [DatosTransaccionInfo]
        public HttpResponseMessage ValidarPreReserva(DetalleReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var detalleReserva = ConfiguracionApiMappers.GetInstance.
                To<DetalleReservaModel, DetalleReservaEO>(entidad);

                var resultado = this._detalleReservaRepository.ValidarPreReserva(detalleReserva);
                var resultadoEjecucion = new ResultadoEjecucionModel<int>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
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
                var resultado = this._detalleReservaRepository.Eliminar(id);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
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
