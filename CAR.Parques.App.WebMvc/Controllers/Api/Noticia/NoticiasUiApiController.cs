namespace CAR.Parques.App.WebMvc.Controllers.Api.Noticias
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Models.Modelos.GestorContenido;
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
    [RoutePrefix("Api/NoticiasUiApi")]
    public class NoticiasUiApiController : BaseApiController
    {
        private readonly INoticiaProxy _iNoticiaProxy;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return _iNoticiaProxy;
            }
        }

        [ImportingConstructor]
        public NoticiasUiApiController(INoticiaProxy noticiaRepository)
        {
            _iNoticiaProxy = noticiaRepository;
        }

        [HttpGet]
        [Route("ObtenerListadoNoticias")]
        [DatosTransaccion]
        public IHttpActionResult ObtenerListadoNoticias()
        {
            var respuesta = _iNoticiaProxy.ObtenerListadoNoticias();
            if (respuesta.Codigo == 1 && respuesta.Descripcion.ToLower() == "ejecución exitosa.")
                return Ok(respuesta.Entidad);
            else
                return Ok(respuesta);
        }

        [HttpGet]
        [Route("NoticiasVigentes")]
        [DatosTransaccion]
        public IHttpActionResult ObtenerListadoNoticiasVigentes()
        {
            var respuesta = _iNoticiaProxy.ObtenerListadoNoticiasVigentes();
            if (respuesta.Codigo == 1 && respuesta.Descripcion.ToLower() == "ejecución exitosa.")
                return Ok(respuesta.Entidad);
            else
                return Ok(respuesta);
        }

        [HttpGet]
        [Route("ObtenerNoticia/{noticiaId:int}")]
        public IHttpActionResult ObtenerNoticia(int noticiaId)
        {
            var respuesta = _iNoticiaProxy.ObtenerNoticia(noticiaId);

            if (respuesta.Codigo == 1 && respuesta.Descripcion.ToLower() == "ejecución exitosa.")
                return Ok(respuesta.Entidad);
            else
                return Ok(respuesta);
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]

        public IHttpActionResult CrearNoticia()
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

            var noticia = ObtenerGestorContenidoModelDesdeContexto();
            noticia.ImagenContenido = fileData;            
            var respuesta = _iNoticiaProxy.CrearNoticia(noticia);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Editar")]
        [DatosTransaccion]
        public IHttpActionResult EditarNoticia()
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

            var noticia = ObtenerGestorContenidoModelDesdeContexto();
            noticia.ImagenContenido = fileData;

            var respuesta = _iNoticiaProxy.EditarNoticia(noticia);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{noticiaId:int}")]
        [DatosTransaccion]
        public IHttpActionResult EliminarNoticia(int noticiaId)
        {
            var respuesta = _iNoticiaProxy.EliminarNoticia(noticiaId);
            return Ok(respuesta);
        }

        private GestorContenidoModel ObtenerGestorContenidoModelDesdeContexto()
        {
            var gestorContenidoModel = new GestorContenidoModel
            {
                ContenidoId = int.Parse(HttpContext.Current.Request.Params["ContenidoId"]),
                TipoContenidoId = Convert.ToInt32(HttpContext.Current.Request.Params["TipoContenidoId"]),
                NombreContenido = HttpContext.Current.Request.Params["NombreContenido"],
                TituloContenido = HttpContext.Current.Request.Params["TituloContenido"],
                CuerpoContenido = HttpContext.Current.Request.Params["CuerpoContenido"],
                //ImagenContenido = fileData,
                URLRedireccion = HttpContext.Current.Request.Params["ParqueId"],
                FechaCreacion = DateTime.Now,
                FechaInicioVigencia = Convert.ToDateTime(HttpContext.Current.Request.Params["FechaInicioVigencia"]),
                FechaFinVigencia = Convert.ToDateTime(HttpContext.Current.Request.Params["FechaFinVigencia"]),
                Activo = Convert.ToBoolean(HttpContext.Current.Request.Params["TipoArchivoId"])
            };

            return gestorContenidoModel;
        }
    }
}