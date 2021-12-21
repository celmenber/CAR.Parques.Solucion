namespace CAR.Parques.Service.WebApi.Controllers.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Business.Contract.ManagerContracts.Reserva;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Base;
    using CAR.Parques.Common.Models.Modelos.Reserva;
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
    [RoutePrefix("api/WaDescuentoTipoUsuario")]
    public class WaDescuentoTipoUsuarioController : ApiControllerBase, IApiAccionDTControllerBase<DescuentoTipoUsuarioModel>
    {
        private readonly IDescuentoTipoUsuarioManager _descuentoTipoUsuarioRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _descuentoTipoUsuarioRepository;
            }
        }

        [ImportingConstructor]
        public WaDescuentoTipoUsuarioController(IDescuentoTipoUsuarioManager descuentoTipoUsuarioRepository)
        {
            _descuentoTipoUsuarioRepository = descuentoTipoUsuarioRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(DescuentoTipoUsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var descuentoTipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<DescuentoTipoUsuarioModel, DescuentoTipoUsuarioEO>(entidad);
                var resultado = this._descuentoTipoUsuarioRepository.Actualizar(descuentoTipoUsuario);
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
                var resultado = this._descuentoTipoUsuarioRepository.Consultar(id);
                var descuentoTipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<DescuentoTipoUsuarioEO, DescuentoTipoUsuarioModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<DescuentoTipoUsuarioModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = descuentoTipoUsuario
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
                var resultado = this._descuentoTipoUsuarioRepository.ConsultarTodos();
                var descuentoTipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<DescuentoTipoUsuarioEO>, IEnumerable<DescuentoTipoUsuarioModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<DescuentoTipoUsuarioModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = descuentoTipoUsuario
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(DescuentoTipoUsuarioModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var descuentoTipoUsuario = ConfiguracionApiMappers.GetInstance.
                To<DescuentoTipoUsuarioModel, DescuentoTipoUsuarioEO>(entidad);
                var resultado = this._descuentoTipoUsuarioRepository.Crear(descuentoTipoUsuario);
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
                var resultado = this._descuentoTipoUsuarioRepository.Eliminar(id);
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
