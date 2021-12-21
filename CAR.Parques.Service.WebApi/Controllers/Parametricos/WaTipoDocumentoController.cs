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
    [RoutePrefix("api/WaTipoDocumento")]
    public class WaTipoDocumentoController : ApiControllerBase, IApiAccionDTControllerBase<TipoDocumentoModel>
    {
        private readonly ITipoDocumentoManager _tipoDocumentoRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _tipoDocumentoRepository;
            }
        }

        [ImportingConstructor]
        public WaTipoDocumentoController(ITipoDocumentoManager tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(TipoDocumentoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoDocumento = ConfiguracionApiMappers.GetInstance.
                To<TipoDocumentoModel, TipoDocumentoEO>(entidad);
                var resultado = this._tipoDocumentoRepository.Actualizar(tipoDocumento);
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
                var resultado = this._tipoDocumentoRepository.Consultar(id);
                var tipoDocumento = ConfiguracionApiMappers.GetInstance.
                To<TipoDocumentoEO, TipoDocumentoModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<TipoDocumentoModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoDocumento
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
                var resultado = this._tipoDocumentoRepository.ConsultarTodos();
                var tipoDocumento = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<TipoDocumentoEO>, IEnumerable<TipoDocumentoModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<TipoDocumentoModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoDocumento
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(TipoDocumentoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoDocumento = ConfiguracionApiMappers.GetInstance.
                To<TipoDocumentoModel, TipoDocumentoEO>(entidad);
                var resultado = this._tipoDocumentoRepository.Crear(tipoDocumento);
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
                var resultado = this._tipoDocumentoRepository.Eliminar(id);
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
