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
    [RoutePrefix("api/WaBitacoraReserva")]
    public class WaBitacoraReservaController : ApiControllerBase, IApiAccionDTControllerBase<BitacoraReservaModel>
    {
        private readonly IBitacoraReservaManager _bitacoraReservaRepository;

        public override IEnumerable<IBaseServicioManager> Services
        {
            get
            {
                yield return _bitacoraReservaRepository;
            }
        }

        [ImportingConstructor]
        public WaBitacoraReservaController(IBitacoraReservaManager bitacoraReservaRepository)
        {
            _bitacoraReservaRepository = bitacoraReservaRepository;
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Actualizar(BitacoraReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var bitacoraReserva = ConfiguracionApiMappers.GetInstance.
                To<BitacoraReservaModel, BitacoraReservaEO>(entidad);
                var resultado = this._bitacoraReservaRepository.Actualizar(bitacoraReserva);
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
        [DatosTransaccionInfo]
        public HttpResponseMessage Consultar(int id)
        {
            return GetHttpResponse(() =>
            {
                var resultado = this._bitacoraReservaRepository.Consultar(id);
                var bitacoraReserva = ConfiguracionApiMappers.GetInstance.
                To<BitacoraReservaEO, BitacoraReservaModel>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<BitacoraReservaModel>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = bitacoraReserva
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
                var resultado = this._bitacoraReservaRepository.ConsultarTodos();
                var bitacoraReserva = ConfiguracionApiMappers.GetInstance.
                To<IEnumerable<BitacoraReservaEO>, IEnumerable<BitacoraReservaModel>>(resultado.Entidad);
                var resultadoEjecucion = new ResultadoEjecucionModel<IEnumerable<BitacoraReservaModel>>
                {
                    Codigo = resultado.Codigo,
                    Descripcion = resultado.Descripcion,
                    Entidad = bitacoraReserva
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultadoEjecucion);
            });
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccionInfo]
        public HttpResponseMessage Crear(BitacoraReservaModel entidad)
        {
            return GetHttpResponse(() =>
            {
                var bitacoraReserva = ConfiguracionApiMappers.GetInstance.
                To<BitacoraReservaModel, BitacoraReservaEO>(entidad);
                var resultado = this._bitacoraReservaRepository.Crear(bitacoraReserva);
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
                var resultado = this._bitacoraReservaRepository.Eliminar(id);
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
