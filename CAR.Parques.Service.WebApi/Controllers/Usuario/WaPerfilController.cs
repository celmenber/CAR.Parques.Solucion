namespace CAR.Parques.Service.WebApi.Controllers.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.Usuario;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
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
    [RoutePrefix("api/WaPerfil")]
    public class WaPerfilController : ApiControllerBase, IApiAccionDTControllerBase<PerfilModel>
    {
        private readonly IPerfilManager _perfilRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _perfilRepository;
            }
        }

        [ImportingConstructor]
        public WaPerfilController(IPerfilManager perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(PerfilModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var perfil = ConfiguracionApiMappers.GetInstance.
                To<PerfilModel, PerfilEO>(entidad);
                var resultado = this._perfilRepository.Actualizar(perfil);
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
                var resultado = this._perfilRepository.Consultar(id);
                var perfil = ConfiguracionApiMappers.GetInstance.
                To<PerfilEO, PerfilModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<PerfilModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = perfil
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
                var resultado = this._perfilRepository.ConsultarTodos();
                var perfil = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<PerfilEO>, IEnumerable<PerfilModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<PerfilModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = perfil
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(PerfilModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var perfil = ConfiguracionApiMappers.GetInstance.
                To<PerfilModel, PerfilEO>(entidad);
                var resultado = this._perfilRepository.Crear(perfil);
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
                var resultado = this._perfilRepository.Eliminar(id);
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
