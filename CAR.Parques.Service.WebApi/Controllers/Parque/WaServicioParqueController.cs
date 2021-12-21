namespace CAR.Parques.Service.WebApi.Controllers.Parque
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.ParqueContract;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
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
    [RoutePrefix("api/WaServicioParque")]
    public class WaServicioParqueController : ApiControllerBase, IApiAccionDTControllerBase<ServicioParqueModel>
    {
        private readonly IServicioParqueManager _servicioParqueRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _servicioParqueRepository;
            }
        }

        [ImportingConstructor]
        public WaServicioParqueController(IServicioParqueManager servicioParqueRepository)
        {
            _servicioParqueRepository = servicioParqueRepository;
        }


        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(ServicioParqueModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var servicioParque = ConfiguracionApiMappers.GetInstance.
                To<ServicioParqueModel, ServicioParqueEO>(entidad);
                var resultado = this._servicioParqueRepository.Actualizar(servicioParque);
                var resultadoEjecucion = new ResultadoEjecucionModel<bool>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = resultado.Entidad
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        public HttpResponseMessage Consultar(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._servicioParqueRepository.Consultar(id);
                var servicioParque = ConfiguracionApiMappers.GetInstance.
                To<ServicioParqueEO, ServicioParqueModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<ServicioParqueModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = servicioParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarDetalleXId/{id:int}")]
        public HttpResponseMessage ConsultarDetalleXId(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._servicioParqueRepository.ConsultarServiciosParqueDetalleXId(id);
                var serviciosParques = ConfiguracionApiMappers.GetInstance.
                To<ServicioParqueDetalleEO, ServicioParqueDetalleModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<ServicioParqueDetalleModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = serviciosParques
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
                var resultado = this._servicioParqueRepository.ConsultarTodos();
                var servicioParque = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ServicioParqueEO>, IEnumerable<ServicioParqueModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ServicioParqueModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = servicioParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarServiciosParque/{parqueId:int}")]
        public HttpResponseMessage ConsultarServiciosParque(int parqueId)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._servicioParqueRepository.ConsultarServiciosParque(parqueId);
                var servicioParque = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ServicioParqueDetalleEO>, IEnumerable<ServicioParqueDetalleModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ServicioParqueDetalleModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = servicioParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(ServicioParqueModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var servicioParque = ConfiguracionApiMappers.GetInstance.
                To<ServicioParqueModel, ServicioParqueEO>(entidad);
                var resultado = this._servicioParqueRepository.Crear(servicioParque);
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
                var resultado = this._servicioParqueRepository.Eliminar(id);
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
