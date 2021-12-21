namespace CAR.Parques.App.WebMvc.Core.Token
{
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Security.Cryptography;

    public static class TokenGenerator
    {
        public static string GenerateTokenJwt(UsuarioDetalleModel model)
        {
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            // create token to the user
            var tokenHandler = new JwtSecurityTokenHandler();

            var parameters = new CspParameters() { KeyContainerName = secretKey };
            var provider = new RSACryptoServiceProvider(2048, parameters);
            var securityKey = new RsaSecurityKey(provider); 
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256Signature);

            // create a claimsIdentity
            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name, $"{model.Nombre1} {model.Nombre2} {model.Apellido1} {model.Apellido2}"),
                new Claim(ClaimTypes.Role, model.PerfilId.ToString()),
                new Claim(ClaimTypes.PrimarySid, model.UsuarioId.ToString()),
                new Claim(ClaimTypes.Email, model.Email.ToString()),
                new Claim(ClaimTypes.NameIdentifier, $"{model.Nombre1} {model.Apellido1}"),
                new Claim(ClaimTypes.SerialNumber, model.Documento),
                new Claim("role_name", model.NombrePerfil),
                new Claim("menu", JsonConvert.SerializeObject(model.Menu))
            }, "Custom");

            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                //notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}