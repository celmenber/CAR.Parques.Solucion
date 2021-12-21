namespace CAR.Parques.App.WebMvc.Controllers.Api.Reserva
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Reserva;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Web;
    using System.Web.Http;    

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/ReservaUiApi")]
    public class ReservaUiApiController : BaseApiController
    {
        private readonly IReservaProxy iReservaProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iReservaProxyRepository;
            }
        }

        [ImportingConstructor]
        public ReservaUiApiController(IReservaProxy reservaProxyRepository)
        {
            iReservaProxyRepository = reservaProxyRepository;
        }

        [HttpGet]
        //[Route("ConsultarReservasDetalle/{estadoId:int}")]
        [Route("ConsultarReservasDetalle/{estadoId:int}/{parqueId:int}/{fechaIncio}/{fechaFin}")]
        public IHttpActionResult ConsultarServiciosParque(int estadoId, int parqueId, string fechaIncio, string fechaFin)
        //public IHttpActionResult ConsultarServiciosParque(int estadoId)
        {
            var respuesta = iReservaProxyRepository.ConsultarReservasDetalleServicio(estadoId, parqueId, fechaIncio, fechaFin);
            //var respuesta = iReservaProxyRepository.ConsultarReservasDetalleServicio(estadoId, 0, "NA", "NA");
            return Ok(respuesta);
        }

        [HttpGet]
        [DatosTransaccion]
        [Route("ReservasUsuario")]
        public IHttpActionResult ConsultarReservasUsuario([FromUri] FiltroReserva filtros)
        {
            var dato = Request.Headers.GetValues("UsuarioId").ToList();
            var resultado = iReservaProxyRepository.ConsultarReservasUsuario(filtros);
            return Ok(resultado);
        }

        [HttpGet]
        [DatosTransaccion]
        [Route("ArchivoReserva/{reservaId:int}")]
        public IHttpActionResult ObtenerArchivoComprobanteReserva(int reservaId)
        {
            var respuesta = iReservaProxyRepository.ObtenerArchivoComprobanteReserva(reservaId);
            return Ok(respuesta);
        }


        [HttpPut]
        [DatosTransaccion]
        [Route("EstadoReserva")]
        public IHttpActionResult ActualizarEstadoReserva(ReservaModel reserva)
        {
            var respuesta = iReservaProxyRepository.ActualizarEstadoReserva(reserva);
            return Ok(respuesta);
        }

        [HttpPost]
        [DatosTransaccion]
        [Route("ArchivoReserva")]
        public IHttpActionResult CrearArchivoReserva()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            byte[] fileData = null;
            if (file != null)
            {
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }
            }

            var archivoReserva = new ArchivoReservaModel
            {
                ReservaId = Convert.ToInt32(HttpContext.Current.Request.Params["ReservaId"]),
                TituloArchivoReserva = HttpContext.Current.Request.Params["TituloArchivoReserva"],
                ByteArchivo = fileData
            };

            var respuesta = iReservaProxyRepository.CrearArchivoReserva(archivoReserva);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]
        public IHttpActionResult CrearReserva(RevDetalleModel reserva)
        {
            var Parametros = HttpContext.Current.Request.Params;
            var respuesta = iReservaProxyRepository.CrearReserva(reserva);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("CrearDetalleReserva")]
        [DatosTransaccion]
        public IHttpActionResult CrearDetalleReserva(DetalleReservaModel detalleReserva)
        {
            var Parametros = HttpContext.Current.Request.Params;
            var respuesta = iReservaProxyRepository.CrearDetalleReserva(detalleReserva);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("ValidarPreReserva")]
        [DatosTransaccion]
        public IHttpActionResult ValidarPreReserva(DetalleReservaModel detalleReserva)
        {
            var respuesta = iReservaProxyRepository.ValidarPreReserva(detalleReserva);
            return Ok(respuesta);
        }

    }
}
