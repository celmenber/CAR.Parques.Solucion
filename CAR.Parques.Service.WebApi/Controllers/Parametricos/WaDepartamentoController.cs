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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/WaDepartamento")]
    public class WaDepartamentoController : ApiControllerBase, IApiAccionDTControllerBase<DepartamentoModel>
    {
        private readonly IDepartamentoManager _departamentoRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _departamentoRepository;
            }
        }

        [ImportingConstructor]
        public WaDepartamentoController(IDepartamentoManager departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(DepartamentoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var parque = ConfiguracionApiMappers.GetInstance.
                To<DepartamentoModel, DepartamentoEO>(entidad);
                var resultado = this._departamentoRepository.Actualizar(parque);
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
                var resultado = this._departamentoRepository.Consultar(id);
                var parques = ConfiguracionApiMappers.GetInstance.
                To<DepartamentoEO, DepartamentoModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<DepartamentoModel>
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
                var resultado = this._departamentoRepository.ConsultarTodos();
                var parques = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<DepartamentoEO>, IEnumerable<DepartamentoModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<DepartamentoModel>>
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
        public HttpResponseMessage Crear(DepartamentoModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var parque = ConfiguracionApiMappers.GetInstance.
                To<DepartamentoModel, DepartamentoEO>(entidad);
                var resultado = this._departamentoRepository.Crear(parque);
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
                var resultado = this._departamentoRepository.Eliminar(id);
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
