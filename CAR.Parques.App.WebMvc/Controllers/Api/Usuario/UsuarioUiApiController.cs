namespace CAR.Parques.App.WebMvc.Controllers.Api
{
    using CAR.Parques.App.WebMvc.Filters;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/UsuarioUiApi")]
    public class UsuarioUiApiController : BaseApiController
    {
        private readonly IUsuarioProxy iUsuarioProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iUsuarioProxyRepository;
            }
        }

        [ImportingConstructor]
        public UsuarioUiApiController(IUsuarioProxy usuarioProxyRepository)
        {
            iUsuarioProxyRepository = usuarioProxyRepository;
        }

        [HttpPost]
        [Route("VerificarUsuario")]
        public IHttpActionResult VerificarUsuario(UsuarioModel usuario)
        {
            var respuesta = iUsuarioProxyRepository.VerificarUsuarioAsync(usuario);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Crear")]
        [DatosTransaccion]
        public IHttpActionResult CrearUsuario(UsuarioModel usuario)
        {
            var respuesta = iUsuarioProxyRepository.CrearUsuario(usuario);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarTodosUsuarios")]
        public IHttpActionResult ConsultarTodosUsuarios()
        {
            var respuesta = iUsuarioProxyRepository.ConsultarTodosUsuarios();
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarTodosUsuariosDetalles")]
        public IHttpActionResult ConsultarTodosUsuariosDetalles()
        {
            var respuesta = iUsuarioProxyRepository.ConsultarTodosUsuariosDetalles();
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("OlvidoContrasenia")]
        public IHttpActionResult OlvidoContrasenia(UsuarioModel usuario)
        {
            var respuesta = iUsuarioProxyRepository.OlvidoContrasenia(usuario);
            return Ok(respuesta);
        }

        [HttpPost]
        [Route("Restablecer")]
        public IHttpActionResult Restablecer(RestablecerModel restablecer)
        {
            var respuesta = iUsuarioProxyRepository.Restablecer(restablecer);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ConsultarUsuario/{usuarioId:int}")]
        public IHttpActionResult ConsultarUsuarioXId(int usuarioId)
        {
            var respuesta = iUsuarioProxyRepository.ConsultarUsuario(usuarioId);
            return Ok(respuesta);
        }

        [HttpPut]
        [Route("Actualizar")]
        [DatosTransaccion]
        public IHttpActionResult ActualizarUsuario(UsuarioModel usuario)
        {
            var respuesta = iUsuarioProxyRepository.ActualizarUsuario(usuario);
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("Eliminar/{usuarioId:int}")]
        [DatosTransaccion]
        public IHttpActionResult EliminarParque(int usuarioId)
        {
            var respuesta = iUsuarioProxyRepository.EliminarUsuario(usuarioId);
            return Ok(respuesta);
        }
    }
}
