namespace CAR.Parques.UI.Proxy
{
    using Common.Core.Utilidades;
    using Common.Entities.Entidades.Base;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using UI.Proxy.Contracts;

    [Export(typeof(IBaseProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BaseProxy : IBaseProxy
    {
        private const string MediaTypeJSOn = "application/json";
        public Dictionary<string, string> Headers { get; }
        private string NombreServicio { get; set; }
        private string AccessToken { get; set; }
        private static HttpClient contexto = ObtenerCliente();

        public BaseProxy()
        {
            this.Headers = new Dictionary<string, string>();
        }

        private static HttpClient ObtenerCliente()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(ConfiguracionSitio.ObtenerValorConfiguracion("WebApiCAR"));
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJSOn));
            cliente.DefaultRequestHeaders.Add("Accept-Type", MediaTypeJSOn);
            cliente.Timeout = ObtenerTiempoTimeOut();
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(
                    string.Format(
                        "{0}:{1}",
                        ConfiguracionSitio.ObtenerValorConfiguracion("UsuarioRequestWebApi"),
                        ConfiguracionSitio.ObtenerValorConfiguracion("TokenRequestWebApi"))))
                );
            return cliente;
        }

        private static TimeSpan ObtenerTiempoTimeOut()
        {
            double timeOutSegundos;
            if (double.TryParse(
                ConfiguracionSitio.ObtenerValorConfiguracion("TimeoutHttpClientSegundos"), out timeOutSegundos))
            {
                return TimeSpan.FromSeconds(timeOutSegundos);
            }
            return TimeSpan.FromSeconds(60);
        }

        public void AsociarServicio(string nombreServicio, string token)
        {
            this.NombreServicio = nombreServicio;
            this.AccessToken = token;
        }

        public HttpResponseMessage Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, this.NombreServicio);
            this.AgregarHeaders(request);
            return contexto.SendAsync(request).Result;
        }

        public ResultadoEjecucion<T> Get<T>()
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var request = new HttpRequestMessage(HttpMethod.Get, this.NombreServicio);
            this.AgregarHeaders(request);
            HttpResponseMessage response = contexto.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                resultado.Codigo = 1;
                resultado.Entidad = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                resultado.Codigo = Convert.ToInt32(response.StatusCode);
                resultado.Descripcion = response.ReasonPhrase.ToUpper() + ": " + response.RequestMessage;
            }
            return resultado;
        }

        public ResultadoEjecucion<T> Get<T>(int id)
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}/{1}", this.NombreServicio, id));
            this.AgregarHeaders(request);
            HttpResponseMessage response = contexto.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                resultado.Codigo = 1;
                resultado.Entidad = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                resultado.Codigo = Convert.ToInt32(response.StatusCode);
                resultado.Descripcion = response.ReasonPhrase.ToUpper() + ": " + response.RequestMessage;
            }
            return resultado;
        }

        public HttpResponseMessage Get(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format("{0}/{1}", this.NombreServicio, id));
            this.AgregarHeaders(request);
            return contexto.SendAsync(request).Result;
        }

        public HttpResponseMessage Get(object entidad)
        {
            var contenidoRequest = 
                new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, MediaTypeJSOn);
            var request = new HttpRequestMessage(HttpMethod.Get, this.NombreServicio)
            {
                Content = contenidoRequest
            };
            this.AgregarHeaders(request);
            return contexto.SendAsync(request).Result;
        }

        public async Task<ResultadoEjecucion<T>> GetAsync<T>()
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var request = new HttpRequestMessage(HttpMethod.Get, this.NombreServicio);
            this.AgregarHeaders(request);
            HttpResponseMessage response = await contexto.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                resultado.Codigo = 1;
                resultado.Entidad = await response.Content.ReadAsAsync<T>();
            }
            return resultado;
        }

        public HttpResponseMessage Post()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, this.NombreServicio);
            this.AgregarHeaders(request);
            return contexto.SendAsync(request).Result;
        }

        public HttpResponseMessage Post(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, string.Format("{0}/{1}", this.NombreServicio, id));
            this.AgregarHeaders(request);
            return contexto.SendAsync(request).Result;
        }

        public HttpResponseMessage Post(object entidad)
        {
            var contenidoRequest =
                new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, MediaTypeJSOn);
            var request = new HttpRequestMessage(HttpMethod.Post, this.NombreServicio)
            {
                Content = contenidoRequest
            };
            this.AgregarHeaders(request);
            return contexto.SendAsync(request).Result;
        }

        public ResultadoEjecucion<T> Post<T>(object entidad)
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var contenidoRequest =
                new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, MediaTypeJSOn);
            var request = new HttpRequestMessage(HttpMethod.Post, this.NombreServicio)
            {
                Content = contenidoRequest
            };
            this.AgregarHeaders(request);
            return AsociarCodigosEstado<T>(contexto.SendAsync(request).Result, resultado);
        }

        public async Task<ResultadoEjecucion<T>> PostAsync<T>(object entidad)
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var contenidoRequest =
                new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, MediaTypeJSOn);
            var request = new HttpRequestMessage(HttpMethod.Post, this.NombreServicio)
            {
                Content = contenidoRequest
            };
            this.AgregarHeaders(request);

            var response = await contexto.PostAsync(this.NombreServicio, contenidoRequest);
            return AsociarCodigosEstado<T>(await response.Content.ReadAsHttpResponseMessageAsync(), resultado);
        }

        public static ResultadoEjecucion<T> AsociarCodigosEstado<T>(
            HttpResponseMessage respuestaApi, ResultadoEjecucion<T> objetoSerializado)
        {
            objetoSerializado.Codigo = (int)respuestaApi.StatusCode;
            objetoSerializado.Descripcion = respuestaApi.ReasonPhrase;
            if (respuestaApi.StatusCode != HttpStatusCode.OK)
            {
                return objetoSerializado;
            }
            objetoSerializado = SerializarObjetosRespuesta<T>(respuestaApi, objetoSerializado);
            return objetoSerializado;
        }

        private static ResultadoEjecucion<T> SerializarObjetosRespuesta<T>(
            HttpResponseMessage respuestaApi, ResultadoEjecucion<T> objetoSerializado)
        {
            objetoSerializado.Entidad = (T)respuestaApi.Content.ReadAsAsync<T>().Result;
            return objetoSerializado;
        }

        private void AgregarHeaders(HttpRequestMessage request)
        {
            if (this.Headers != null)
            {
                foreach (var header in this.Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
        }

        public ResultadoEjecucion<T> Send<T,K>(K objectRequest, string method = "POST")
        {
            string result = "";
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(new Uri(ConfiguracionSitio.ObtenerValorConfiguracion("WebApiCAR")) + this.NombreServicio);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                //request.Timeout = 10000; //Si despues de 10 segundos no contesta generar excepción. 

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                var des = JsonConvert.DeserializeObject(result);
                resultado.Entidad = JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception e)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "Error " + e.Message;
            }

            return resultado;
        }

        public ResultadoEjecucion<T> Delete<T>(int id)
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var request = new HttpRequestMessage(HttpMethod.Delete, string.Format("{0}/{1}", this.NombreServicio, id));
            this.AgregarHeaders(request);
            HttpResponseMessage response = contexto.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                resultado.Codigo = 1;
                resultado.Entidad = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                resultado.Codigo = Convert.ToInt32(response.StatusCode);
                resultado.Descripcion = response.ReasonPhrase.ToUpper() + ": " + response.RequestMessage;
            }
            return resultado;
        }

        public ResultadoEjecucion<T> Put<T>(object entidad)
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            var contenidoRequest =
                new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, MediaTypeJSOn);
            var request = new HttpRequestMessage(HttpMethod.Put, this.NombreServicio)
            {
                Content = contenidoRequest
            };
            this.AgregarHeaders(request);
            return AsociarCodigosEstado<T>(contexto.SendAsync(request).Result, resultado);
        }
    }
}
