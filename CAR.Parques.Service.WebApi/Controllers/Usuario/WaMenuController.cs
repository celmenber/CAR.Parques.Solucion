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
    [RoutePrefix("api/WaMenu")]
    public class WaMenuController : ApiControllerBase, IApiAccionDTControllerBase<MenuModel>
    {
        private readonly IMenuManager _menuRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _menuRepository;
            }
        }

        [ImportingConstructor]
        public WaMenuController(IMenuManager menuRepository)
        {
            _menuRepository = menuRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(MenuModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var menu = ConfiguracionApiMappers.GetInstance.
                To<MenuModel, MenuEO>(entidad);
                var resultado = this._menuRepository.Actualizar(menu);
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
                var resultado = this._menuRepository.Consultar(id);
                var menu = ConfiguracionApiMappers.GetInstance.
                To<MenuEO, MenuModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<MenuModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = menu
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
                var resultado = this._menuRepository.ConsultarTodos();
                var menu = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<MenuEO>, IEnumerable<MenuModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<MenuModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = menu
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(MenuModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var menu = ConfiguracionApiMappers.GetInstance.
                To<MenuModel, MenuEO>(entidad);
                var resultado = this._menuRepository.Crear(menu);
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
                var resultado = this._menuRepository.Eliminar(id);
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
