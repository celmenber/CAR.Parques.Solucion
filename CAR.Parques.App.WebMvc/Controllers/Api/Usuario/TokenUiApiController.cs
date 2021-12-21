namespace CAR.Parques.App.WebMvc.Controllers.Api
{
    using CAR.Parques.App.WebMvc.Core.Token;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using CAR.Parques.UI.Proxy.Contracts;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Configuration;
    using System.Net;
    using System.Web.Http;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("Api/Token")]
    public class TokenUiApiController : BaseApiController
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
        public TokenUiApiController(IUsuarioProxy usuarioProxyRepository)
        {
            iUsuarioProxyRepository = usuarioProxyRepository;
        }

        [HttpPost]
        [Route("Autenticar")]
        public JsonWebToken Authenticate(UsuarioModel login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var respuesta = iUsuarioProxyRepository.VerificarUsuarioAsync(login);
            if (respuesta.Entidad == null || respuesta.Entidad.Codigo == 0)
            {
                return new JsonWebToken();
            }

            var token = new JsonWebToken
            {
                access_Token = TokenGenerator.GenerateTokenJwt(respuesta.Entidad.Entidad),
                expires_in = Convert.ToInt32(ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"])
            };

            return token;
        }
    }
}
