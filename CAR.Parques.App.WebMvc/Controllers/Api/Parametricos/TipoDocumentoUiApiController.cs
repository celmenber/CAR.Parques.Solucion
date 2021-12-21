namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/TipoDocumentoUiApi")]
    public class TipoDocumentoUiApiController : BaseApiController
    {
        private readonly ITipoDocumentoProxy iTipoDocumentoProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iTipoDocumentoProxyRepository;
            }
        }

        [ImportingConstructor]
        public TipoDocumentoUiApiController(ITipoDocumentoProxy tipoDocumentoProxyRepositoty)
        {
            iTipoDocumentoProxyRepository = tipoDocumentoProxyRepositoty;
        }

        [HttpGet]
        [Route("ConsultarListadoTipoDocumento")]
        public IHttpActionResult ConsultarListadoTipoDocumento()
        {
            var respuesta = iTipoDocumentoProxyRepository.ConsultarListadoTipoDocumento();
            return Ok(respuesta);
        }
    }
}
