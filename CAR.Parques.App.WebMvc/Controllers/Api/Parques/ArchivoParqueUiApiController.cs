namespace CAR.Parques.App.WebMvc.Controllers.Api.Parques
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Web;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/ArchivoParqueUiApi")]
    public class ArchivoParqueUiApiController : BaseApiController
    {
        private readonly IArchivoParqueProxy iArchivoParqueProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iArchivoParqueProxyRepository;
            }
        }

        [ImportingConstructor]
        public ArchivoParqueUiApiController(IArchivoParqueProxy archivoParqueRepository)
        {
            iArchivoParqueProxyRepository = archivoParqueRepository;
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]
        public IHttpActionResult CrearArchivoParque()
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

            var archivoParque = new ArchivoParqueModel
            {
                ArchivoParqueId = 0,
                ObservacionArchivoParque = HttpContext.Current.Request.Params["ObservacionArchivoParque"],
                TituloArchivParque = HttpContext.Current.Request.Params["TituloArchivParque"],
                Orden = Convert.ToInt32(HttpContext.Current.Request.Params["Orden"]),
                ParqueId = Convert.ToInt32(HttpContext.Current.Request.Params["ParqueId"]),
                RutaArchivoParque = HttpContext.Current.Request.Params["RutaArchivoParque"],
                TipoArchivoId = Convert.ToInt32(HttpContext.Current.Request.Params["TipoArchivoId"]),
                ByteArchivo = fileData
            };

            var respuesta = iArchivoParqueProxyRepository.CrearArchivoParque(archivoParque);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Editar")]
        [DatosTransaccion]
        public IHttpActionResult EditarArchivoParque()
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

            ArchivoParqueModel archivoParque = new ArchivoParqueModel
            {
                ArchivoParqueId = Convert.ToInt32(HttpContext.Current.Request.Params["ArchivoParqueId"]),
                ObservacionArchivoParque = HttpContext.Current.Request.Params["ObservacionArchivoParque"],
                TituloArchivParque = HttpContext.Current.Request.Params["TituloArchivParque"],
                Orden = Convert.ToInt32(HttpContext.Current.Request.Params["Orden"]),
                ParqueId = Convert.ToInt32(HttpContext.Current.Request.Params["ParqueId"]),
                RutaArchivoParque = HttpContext.Current.Request.Params["RutaArchivoParque"],
                TipoArchivoId = Convert.ToInt32(HttpContext.Current.Request.Params["TipoArchivoId"]),
                ByteArchivo = fileData
            };

            var respuesta = iArchivoParqueProxyRepository.ActualizarArchivoParque(archivoParque);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarArchivoParque/{tipoArchivoId:int}/{parqueId:int}")]
        public IHttpActionResult ObtenerListadoParques(int tipoArchivoId, int parqueId)
        {
            var respuesta = iArchivoParqueProxyRepository.ConsultarListadoArchivosParque(tipoArchivoId, parqueId);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarArchivosParque/{parqueId:int}")]
        public IHttpActionResult ObtenerArchivosParque(int parqueId)
        {            
            var respuesta = iArchivoParqueProxyRepository.ConsultarListadoArchivosParque(0, parqueId);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("EliminarArchivo/{archivoParqueId:int}")]
        [DatosTransaccion]
        public IHttpActionResult EliminarParque(int archivoParqueId)
        {
            var respuesta = iArchivoParqueProxyRepository.EliminarArchivo(archivoParqueId);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarTiposArchivo")]
        public IHttpActionResult ObtenerTiposArchivo()
        {
            var respuesta = iArchivoParqueProxyRepository.ConsultarTiposArchivo();
            return Ok(respuesta);            
        }
    }
}
