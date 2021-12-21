namespace CAR.Parques.Service.WebApi.Controllers.Parametricos
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.Parametricos;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
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
    [RoutePrefix("api/WaEstadoReserva")]
    public class WaEstadoReservaController : ApiControllerBase, IApiAccionDTControllerBase<EstadoReservaModel>
    {
        private readonly IEstadoReservaManager _estadoReservaRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _estadoReservaRepository;
            }
        }

        [ImportingConstructor]
        public WaEstadoReservaController(IEstadoReservaManager estadoReservaRepository)
        {
            _estadoReservaRepository = estadoReservaRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(EstadoReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var estadoReserva = ConfiguracionApiMappers.GetInstance.
                To<EstadoReservaModel, EstadoReservaEO>(entidad);
                var resultado = this._estadoReservaRepository.Actualizar(estadoReserva);
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
                var resultado = this._estadoReservaRepository.Consultar(id);
                var estadorReserva = ConfiguracionApiMappers.GetInstance.
                To<EstadoReservaEO, EstadoReservaModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<EstadoReservaModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = estadorReserva
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
                var resultado = this._estadoReservaRepository.ConsultarTodos();
                var estadoReserva = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<EstadoReservaEO>, IEnumerable<EstadoReservaModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<EstadoReservaModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = estadoReserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(EstadoReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var estadoReserva = ConfiguracionApiMappers.GetInstance.
                To<EstadoReservaModel, EstadoReservaEO>(entidad);
                var resultado = this._estadoReservaRepository.Crear(estadoReserva);
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
                var resultado = this._estadoReservaRepository.Eliminar(id);
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
