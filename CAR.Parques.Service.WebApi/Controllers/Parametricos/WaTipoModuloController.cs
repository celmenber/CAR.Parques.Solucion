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
    [RoutePrefix("api/WaTipoModulo")]
    public class WaTipoModuloController : ApiControllerBase, IApiAccionDTControllerBase<TipoModuloModel>
    {
        private readonly ITipoModuloManager _tipoModuloRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _tipoModuloRepository;
            }
        }

        [ImportingConstructor]
        public WaTipoModuloController(ITipoModuloManager tipoModuloRepository)
        {
            _tipoModuloRepository = tipoModuloRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(TipoModuloModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoModulo = ConfiguracionApiMappers.GetInstance.
                To<TipoModuloModel, TipoModuloEO>(entidad);
                var resultado = this._tipoModuloRepository.Actualizar(tipoModulo);
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
                var resultado = this._tipoModuloRepository.Consultar(id);
                var tipoModulo = ConfiguracionApiMappers.GetInstance.
                To<TipoModuloEO, TipoModuloModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<TipoModuloModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoModulo
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
                var resultado = this._tipoModuloRepository.ConsultarTodos();
                var tipoModulo = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<TipoModuloEO>, IEnumerable<TipoModuloModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<TipoModuloModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoModulo
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(TipoModuloModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoModulo = ConfiguracionApiMappers.GetInstance.
                To<TipoModuloModel, TipoModuloEO>(entidad);
                var resultado = this._tipoModuloRepository.Crear(tipoModulo);
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
                var resultado = this._tipoModuloRepository.Eliminar(id);
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
