namespace CAR.Parques.Service.WebApi.Filters
{
    using System;
    using System.Configuration;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class ControlAutorizacionAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var headers = actionContext.Request.Headers;
            if (headers.Authorization != null && headers.Authorization.Scheme == "Basic")
            {
                try
                {
                    string usuario = ConfigurationManager.AppSettings["UsuarioRequestWebApi"].ToString();
                    string tokenApi = ConfigurationManager.AppSettings["TokenRequestWebApi"].ToString();
                    var userPwd = Encoding.UTF8.GetString(Convert.FromBase64String(headers.Authorization.Parameter));
                    var user = userPwd.Substring(0, userPwd.IndexOf(':'));
                    var password = userPwd.Substring(userPwd.IndexOf(':') + 1);
                    if (!(user == usuario && password == tokenApi))
                    {
                        throw new ArgumentException("Credenciales invalidas");
                    }
                }
                catch (Exception)
                {
                    PutUnauthorizedResult(actionContext, "Invalid Authorization header");
                }
            }
            else
            {
                PutUnauthorizedResult(actionContext, "Authorization needed");
            }
        }

        private void PutUnauthorizedResult(HttpActionContext httpActionContext, string msg)
        {
            httpActionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(msg)
            };
        }
    }
}