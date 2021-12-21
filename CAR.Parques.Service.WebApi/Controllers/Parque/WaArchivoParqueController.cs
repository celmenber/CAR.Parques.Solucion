namespace CAR.Parques.Service.WebApi.Controllers.Parque
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.ParqueContract;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
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
    [RoutePrefix("api/WaArchivoParque")]
    public class WaArchivoParqueController : ApiControllerBase, IApiAccionDTControllerBase<ArchivoParqueModel>
    {
        private readonly IArchivoParqueManager _archivoParqueRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _archivoParqueRepository;
            }
        }

        [ImportingConstructor]
        public WaArchivoParqueController(IArchivoParqueManager archivoParqueRepository)
        {
            _archivoParqueRepository = archivoParqueRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(ArchivoParqueModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<ArchivoParqueModel, ArchivoParqueEO>(entidad);
                var resultado = this._archivoParqueRepository.Actualizar(archivoParque);
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
                var resultado = this._archivoParqueRepository.Consultar(id);
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<ArchivoParqueEO, ArchivoParqueModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<ArchivoParqueModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = archivoParque
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
                var resultado = this._archivoParqueRepository.ConsultarTodos();
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ArchivoParqueEO>, IEnumerable<ArchivoParqueModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ArchivoParqueModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = archivoParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarArchivoParque/{tipoArchivoId:int}/{parqueId:int}")]
        public HttpResponseMessage ConsultarArchivoParque(int tipoArchivoId, int parqueId)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._archivoParqueRepository.ConsultarListadoArchivosParque(tipoArchivoId, parqueId);
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ArchivoParqueEO>, IEnumerable<ArchivoParqueModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ArchivoParqueModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = archivoParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpGet]
        [Route("ConsultarArchivosParque/{parqueId:int}")]
        public HttpResponseMessage ConsultarArchivosParque(int parqueId)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._archivoParqueRepository.ConsultarListadoArchivosParque(0, parqueId);
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<ArchivoParqueEO>, IEnumerable<ArchivoParqueModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<ArchivoParqueModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = archivoParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(ArchivoParqueModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<ArchivoParqueModel, ArchivoParqueEO>(entidad);
                var resultado = this._archivoParqueRepository.Crear(archivoParque);
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
                var resultado = this._archivoParqueRepository.Eliminar(id);
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
        [Route("ConsultarTiposArchivo")]
        public HttpResponseMessage ConsultarTiposArchivo()
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._archivoParqueRepository.ConsultarTiposArchivo();
                var archivoParque = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<TipoArchivoEO>, IEnumerable<TipoArchivoModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<TipoArchivoModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = archivoParque
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }
    }
}
