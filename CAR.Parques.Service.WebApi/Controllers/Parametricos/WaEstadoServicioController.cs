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
    [RoutePrefix("api/WaEstadoServicio")]
    public class WaEstadoServicioController : ApiControllerBase, IApiAccionDTControllerBase<EstadoServicioModel>
    {
        private readonly IEstadoServicioManager _estadoServicioRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _estadoServicioRepository;
            }
        }

        [ImportingConstructor]
        public WaEstadoServicioController(IEstadoServicioManager estadoServicioRepository)
        {
            _estadoServicioRepository = estadoServicioRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(EstadoServicioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var estadoServicio = ConfiguracionApiMappers.GetInstance.
                To<EstadoServicioModel, EstadoServicioEO>(entidad);
                var resultado = this._estadoServicioRepository.Actualizar(estadoServicio);
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
                var resultado = this._estadoServicioRepository.Consultar(id);
                var estadoServicio = ConfiguracionApiMappers.GetInstance.
                To<EstadoServicioEO, EstadoServicioModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<EstadoServicioModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = estadoServicio
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
                var resultado = this._estadoServicioRepository.ConsultarTodos();
                var estadoServicio = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<EstadoServicioEO>, IEnumerable<EstadoServicioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<EstadoServicioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = estadoServicio
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(EstadoServicioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var estadoServicio = ConfiguracionApiMappers.GetInstance.
                To<EstadoServicioModel, EstadoServicioEO>(entidad);
                var resultado = this._estadoServicioRepository.Crear(estadoServicio);
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
                var resultado = this._estadoServicioRepository.Eliminar(id);
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
