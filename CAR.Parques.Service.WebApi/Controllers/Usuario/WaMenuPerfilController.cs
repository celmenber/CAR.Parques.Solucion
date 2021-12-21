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
    [RoutePrefix("api/WaMenuPerfil")]
    public class WaMenuPerfilController : ApiControllerBase, IApiAccionDTControllerBase<MenuPerfilModel>
    {
        private readonly IMenuPerfilManager _menuPerfilRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _menuPerfilRepository;
            }
        }

        [ImportingConstructor]
        public WaMenuPerfilController(IMenuPerfilManager menuPerfilRepository)
        {
            _menuPerfilRepository = menuPerfilRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(MenuPerfilModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var menuPerfil = ConfiguracionApiMappers.GetInstance.
                To<MenuPerfilModel, MenuPerfilEO>(entidad);
                var resultado = this._menuPerfilRepository.Actualizar(menuPerfil);
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
                var resultado = this._menuPerfilRepository.Consultar(id);
                var menuPerfil = ConfiguracionApiMappers.GetInstance.
                To<MenuPerfilEO, MenuPerfilModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<MenuPerfilModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = menuPerfil
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
                var resultado = this._menuPerfilRepository.ConsultarTodos();
                var menuPerfil = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<MenuPerfilEO>, IEnumerable<MenuPerfilModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<MenuPerfilModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = menuPerfil
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(MenuPerfilModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var menuPerfil = ConfiguracionApiMappers.GetInstance.
                To<MenuPerfilModel, MenuPerfilEO>(entidad);
                var resultado = this._menuPerfilRepository.Crear(menuPerfil);
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
                var resultado = this._menuPerfilRepository.Eliminar(id);
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
        [Route("ConsultarMenuPerfilPorId/{idPerfil:int}")]
        public HttpResponseMessage ConsultarTodos(int idPerfil)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._menuPerfilRepository.ConsultaMenuPorPerfil(idPerfil);
                var menuPerfil = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<MenuEO>, IEnumerable<MenuModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<MenuModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = menuPerfil
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }
    }
}
