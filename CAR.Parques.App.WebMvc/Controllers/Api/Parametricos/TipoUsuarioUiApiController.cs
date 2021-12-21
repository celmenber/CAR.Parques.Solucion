namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/TipoUsuarioUiApi")]
    public class TipoUsuarioUiApiController : BaseApiController
    {
        private readonly ITipoUsuarioProxy iTipoUsuarioProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iTipoUsuarioProxyRepository;
            }
        }

        [ImportingConstructor]
        public TipoUsuarioUiApiController(ITipoUsuarioProxy tipoUsuarioProxyRepository)
        {
            iTipoUsuarioProxyRepository = tipoUsuarioProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoTipoUsuario")]
        public IHttpActionResult ConsultarListadoTipoUsuario()
        {
            var respuesta = iTipoUsuarioProxyRepository.ConsultarListadoTipoUsuario();
            return Ok(respuesta);
        }
    }
}
