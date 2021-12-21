namespace CAR.Parques.App.WebMvc.Controllers.Api.Usuario
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/PerfilUiApi")]
    public class PerfilUiApiController : BaseApiController
    {
        private readonly IPerfilProxy iPerfilProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iPerfilProxyRepository;
            }
        }

        [ImportingConstructor]
        public PerfilUiApiController(IPerfilProxy perfilProxyRepository)
        {
            iPerfilProxyRepository = perfilProxyRepository;
        }

        [HttpGet]
        [Route("ObtenerListadoPerfiles")]
        public IHttpActionResult ObtenerListadoPerfiles()
        {
            var respuesta = iPerfilProxyRepository.ConsultarListadoPerfiles();
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ObtenerPerfilId/{perfilId:int}")]
        public IHttpActionResult ObtenerPerfilId(int perfilId)
        {
            var respuesta = iPerfilProxyRepository.ConsultarPerfilId(perfilId);
            return Ok(respuesta);
        }
    }
}
