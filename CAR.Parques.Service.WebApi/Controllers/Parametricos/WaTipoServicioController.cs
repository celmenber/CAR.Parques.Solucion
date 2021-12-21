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
    [RoutePrefix("api/WaTipoServicio")]
    public class WaTipoServicioController : ApiControllerBase, IApiAccionDTControllerBase<TipoServicioModel>
    {
        private readonly ITipoServicioManager _tipoServicioRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _tipoServicioRepository;
            }
        }

        [ImportingConstructor]
        public WaTipoServicioController(ITipoServicioManager tipoServicioRepository)
        {
            _tipoServicioRepository = tipoServicioRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(TipoServicioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoServicio = ConfiguracionApiMappers.GetInstance.
                To<TipoServicioModel, TipoServicioEO>(entidad);
                var resultado = this._tipoServicioRepository.Actualizar(tipoServicio);
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
                var resultado = this._tipoServicioRepository.Consultar(id);
                var tipoServicio = ConfiguracionApiMappers.GetInstance.
                To<TipoServicioEO, TipoServicioModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<TipoServicioModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoServicio
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
                var resultado = this._tipoServicioRepository.ConsultarTodos();
                var tipoServicio = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<TipoServicioEO>, IEnumerable<TipoServicioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<TipoServicioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoServicio
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(TipoServicioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoServicio = ConfiguracionApiMappers.GetInstance.
                To<TipoServicioModel, TipoServicioEO>(entidad);
                var resultado = this._tipoServicioRepository.Crear(tipoServicio);
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
                var resultado = this._tipoServicioRepository.Eliminar(id);
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
