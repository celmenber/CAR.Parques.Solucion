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
    [RoutePrefix("api/WaMunicipio")]
    public class WaMunicipioController : ApiControllerBase, IApiAccionDTControllerBase<MunicipioModel>
    {
        private readonly IMunicipioManager _municipioManager;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _municipioManager;
            }
        }

        [ImportingConstructor]
        public WaMunicipioController(IMunicipioManager municipioManager)
        {
            _municipioManager = municipioManager;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(MunicipioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var municipio = ConfiguracionApiMappers.GetInstance.
                To<MunicipioModel, MunicipioEO>(entidad);
                var resultado = this._municipioManager.Actualizar(municipio);
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
                var resultado = this._municipioManager.Consultar(id);
                var municipio = ConfiguracionApiMappers.GetInstance.
                To<MunicipioEO, MunicipioModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<MunicipioModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = municipio
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
                var resultado = this._municipioManager.ConsultarTodos();
                var municipio = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<MunicipioEO>, IEnumerable<MunicipioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<MunicipioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = municipio
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarTodosPorDepartamento/{departamentoId:int}")]
        public HttpResponseMessage ConsultarTodosPorDepartamento(int departamentoId)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._municipioManager.ConsultarMunicipiosXDepartamento(departamentoId);
                var municipio = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<MunicipioEO>, IEnumerable<MunicipioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<MunicipioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = municipio
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(MunicipioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var municipio = ConfiguracionApiMappers.GetInstance.
                To<MunicipioModel, MunicipioEO>(entidad);
                var resultado = this._municipioManager.Crear(municipio);
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
                var resultado = this._municipioManager.Eliminar(id);
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
