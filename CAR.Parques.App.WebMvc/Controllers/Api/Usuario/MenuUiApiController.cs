namespace CAR.Parques.App.WebMvc.Controllers.Api.Usuario
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/MenuUiApi")]
    public class MenuUiApiController : BaseApiController
    {
        private readonly IMenuPerfilProxy iMenuPerfilProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iMenuPerfilProxyRepository;
            }
        }

        [ImportingConstructor]
        public MenuUiApiController(IMenuPerfilProxy menuPerfilProxyRepository)
        {
            iMenuPerfilProxyRepository = menuPerfilProxyRepository;
        }

        [HttpGet]
        [Route("ObtenerMenuPerfil/{idPerfil:int}")]
        public IHttpActionResult ObtenerListadoPerfiles(int idPerfil)
        {
            var respuesta = iMenuPerfilProxyRepository.ConsultaMenuPorPerfil(idPerfil);
            return Ok(respuesta);
        }
    }
}
