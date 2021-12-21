namespace CAR.Parques.App.WebMvc.Controllers.Api.Parametricos
{
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Parametricos;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/MunicipioUiApi")]
    public class MunicipioUiApiController : BaseApiController
    {
        private readonly IMunicipioProxy iMunicipioProxyRepository;

        public override IEnumerable<IBaseProxy> Proxies
        {
            get
            {
                yield return iMunicipioProxyRepository;
            }
        }

        [ImportingConstructor]
        public MunicipioUiApiController(IMunicipioProxy municipioProxyRepository)
        {
            iMunicipioProxyRepository = municipioProxyRepository;
        }

        [HttpGet]
        [Route("ConsultarListadoMunicipiosXDepartamento/{departamentoId:int}")]
        public IHttpActionResult ConsultarListadoMunicipiosXDepartamento(int departamentoId)
        {
            var respuesta = iMunicipioProxyRepository.ConsultarListadoMunicipiosXDepto(departamentoId);
            return Ok(respuesta);
        }
    }
}
