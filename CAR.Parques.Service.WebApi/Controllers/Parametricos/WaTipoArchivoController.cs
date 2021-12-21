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
    [RoutePrefix("api/WaTipoArchivo")]
    public class WaTipoArchivoController : ApiControllerBase, IApiAccionDTControllerBase<TipoArchivoModel>
    {
        private readonly ITipoArchivoManager _tipoArchivoRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _tipoArchivoRepository;
            }
        }

        [ImportingConstructor]
        public WaTipoArchivoController(ITipoArchivoManager tipoArchivoRepository)
        {
            _tipoArchivoRepository = tipoArchivoRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(TipoArchivoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoArchivo = ConfiguracionApiMappers.GetInstance.
                To<TipoArchivoModel, TipoArchivoEO>(entidad);
                var resultado = this._tipoArchivoRepository.Actualizar(tipoArchivo);
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
                var resultado = this._tipoArchivoRepository.Consultar(id);
                var tipoArchivo = ConfiguracionApiMappers.GetInstance.
                To<TipoArchivoEO, TipoArchivoModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<TipoArchivoModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoArchivo
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
                var resultado = this._tipoArchivoRepository.ConsultarTodos();
                var tipoArchivo = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<TipoArchivoEO>, IEnumerable<TipoArchivoModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<TipoArchivoModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoArchivo
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(TipoArchivoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoArchivo = ConfiguracionApiMappers.GetInstance.
                To<TipoArchivoModel, TipoArchivoEO>(entidad);
                var resultado = this._tipoArchivoRepository.Crear(tipoArchivo);
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
                var resultado = this._tipoArchivoRepository.Eliminar(id);
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
