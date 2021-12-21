namespace CAR.Parques.Service.WebApi.Controllers
{
    using Business.Contract.ManagerContracts.Base;
    using Business.Contract.ManagerContracts.ParqueContract;
    using CAR.Parques.Service.WebApi.Core.ContratoBase;
    using CAR.Parques.Service.WebApi.Filters;
    using Common.Entities.Entidades.Parques;
    using Common.Models.Modelos.Base;
    using Common.Models.Modelos.Parques;
    using Service.WebApi.Adaptadores;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using WebApi.Core;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/WaParque")]
    public class WaParquesController : ApiControllerBase, IApiAccionDTControllerBase<ParqueModel>
    {
        private readonly IParqueManager _parqueRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _parqueRepository;
            }
        }

        [ImportingConstructor]
        public WaParquesController(IParqueManager parqueRepository)
        {
            _parqueRepository = parqueRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoParques")]
        [DatosTransaccionInfo]
        public HttpResponseMessage ConsultarListadoParques()
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._parqueRepository.ConsultarTodosParques();
                var parques = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ParqueEO>, IEnumerable<ParqueModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ParqueModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = parques
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarListadoParquesDetalle")]
        [DatosTransaccionInfo]
        public HttpResponseMessage ConsultarListadoParquesDetalle()
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._parqueRepository.ConsultarTodosParquesInformacionDetalle();
                var parques = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ParqueInformacionEO>, IEnumerable<ParqueInformacionModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ParqueInformacionModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = parques
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarListadoInformacionParques")]
        [DatosTransaccionInfo]
        [CacheControl]
        public HttpResponseMessage ConsultarListadoInformacionParques()
        {
            return GetHttpResponse(() =>
            {
                
                var resultado = this._parqueRepository.ConsultarTodosParquesInformacionDetalle();
                var parques = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ParqueInformacionEO>, IEnumerable<ParqueInformacionModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ParqueInformacionModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = parques
                };
                var response = Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
                return response;
            });
        }

        [HttpGet]
        [Route("ConsultarDetalleXId/{id:int}")]
        public HttpResponseMessage ConsultarDetalleXId(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._parqueRepository.ConsultarParquesDetalleXId(id);
                var parques = ConfiguracionApiMappers.GetInstance.
                To<ParqueDetalleEO, ParqueInformacionModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<ParqueInformacionModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = parques
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(ParqueModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var parque = ConfiguracionApiMappers.GetInstance.
                To<ParqueModel, ParqueEO>(entidad);
                var resultado = this._parqueRepository.Actualizar(parque);
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
                var resultado = this._parqueRepository.Consultar(id);
                var parques = ConfiguracionApiMappers.GetInstance.
                To<ParqueEO, ParqueModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<ParqueModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = parques
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
                var resultado = this._parqueRepository.ConsultarTodos();
                var parques = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ParqueEO>, IEnumerable<ParqueModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ParqueModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = parques
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(ParqueModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var parque = ConfiguracionApiMappers.GetInstance.
                To<ParqueModel, ParqueEO>(entidad);
                var resultado = this._parqueRepository.Crear(parque);
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
                var resultado = this._parqueRepository.Eliminar(id);
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
