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
    [RoutePrefix("api/WaTipoUsuario")]
    public class WaTipoUsuarioController : ApiControllerBase, IApiAccionDTControllerBase<TipoUsuarioModel>
    {
        private readonly ITipoUsuarioManager _tipoUsuarioRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _tipoUsuarioRepository;
            }
        }

        [ImportingConstructor]
        public WaTipoUsuarioController(ITipoUsuarioManager tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(TipoUsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<TipoUsuarioModel, TipoUsuarioEO>(entidad);
                var resultado = this._tipoUsuarioRepository.Actualizar(tipoUsuario);
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
                var resultado = this._tipoUsuarioRepository.Consultar(id);
                var tipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<TipoUsuarioEO, TipoUsuarioModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<TipoUsuarioModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoUsuario
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
                var resultado = this._tipoUsuarioRepository.ConsultarTodos();
                var tipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<TipoUsuarioEO>, IEnumerable<TipoUsuarioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<TipoUsuarioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = tipoUsuario
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(TipoUsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var tipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<TipoUsuarioModel, TipoUsuarioEO>(entidad);
                var resultado = this._tipoUsuarioRepository.Crear(tipoUsuario);
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
                var resultado = this._tipoUsuarioRepository.Eliminar(id);
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
