namespace CAR.Parques.Service.WebApi.Controllers.GestorContenido
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.GestorContenido;
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.GestorContenido;
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
    [RoutePrefix("api/WaGestorContenido")]
    public class WaGestorContenidoController : ApiControllerBase, IApiAccionDTControllerBase<GestorContenidoModel>
    {
        private readonly IGestorContenidoManager _gestorContenidoRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _gestorContenidoRepository;
            }
        }

        [ImportingConstructor]
        public WaGestorContenidoController(IGestorContenidoManager gestorContenidoManager)
        {
            _gestorContenidoRepository = gestorContenidoManager;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(GestorContenidoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var gestorContenido = ConfiguracionApiMappers.GetInstance.
                To<GestorContenidoModel, GestorContenidoEO>(entidad);
                var resultado = this._gestorContenidoRepository.Actualizar(gestorContenido);
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
                var resultado = this._gestorContenidoRepository.Consultar(id);
                var gestorContenido = ConfiguracionApiMappers.GetInstance.
                To<GestorContenidoEO, GestorContenidoModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<GestorContenidoModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = gestorContenido
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
                var resultado = this._gestorContenidoRepository.ConsultarTodos();
                var gestorContenido = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<GestorContenidoEO>, IEnumerable<GestorContenidoModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<GestorContenidoModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = gestorContenido
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(GestorContenidoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var gestorContenido = ConfiguracionApiMappers.GetInstance.
                To<GestorContenidoModel, GestorContenidoEO>(entidad);
                var resultado = this._gestorContenidoRepository.Crear(gestorContenido);
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
                var resultado = this._gestorContenidoRepository.Eliminar(id);
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
