namespace CAR.Parques.Ext.Service.BaseProxy
{
    using Common.Entities.Entidades.Base;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    public class BaseProxyWebApi
    {
        private HttpClient cliente = null;

        private const string MediaTypeJson = "application/json";

        public string NombreServicio { get; set; }

        public BaseProxyWebApi()
        {
            this.cliente = new HttpClient();
            this.cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
            this.cliente.DefaultRequestHeaders.Add("Accept-Type", MediaTypeJson);
        }

        public HttpResponseMessage Get()
        {
            return this.cliente.GetAsync(this.NombreServicio).Result;
        }

        public ResultadoEjecucion<T> Get<T>()
        {
            return AsociarCodigosEstado<T>(this.cliente.GetAsync(this.NombreServicio).Result);
        }

        public ResultadoEjecucion<T> Post<T>(object entidad)
        {
            var contenidoRequest = 
                new StringContent(JsonConvert.SerializeObject(entidad), Encoding.UTF8, MediaTypeJson);
            var resultado = this.cliente.PostAsync(this.NombreServicio, contenidoRequest).Result;
            return this.AsociarCodigosEstado<T>(resultado);
        }

        private ResultadoEjecucion<T> AsociarCodigosEstado<T>(HttpResponseMessage respuestaApi)
        {
            ResultadoEjecucion<T> objetoSerializado = new ResultadoEjecucion<T>();
            objetoSerializado = new ResultadoEjecucion<T>
            {
                Codigo = (int)respuestaApi.StatusCode,
                Descripcion = respuestaApi.ReasonPhrase
            };

            if(respuestaApi.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(string.Format("Error Servicio: {0}.", respuestaApi.ReasonPhrase));
            }

            objetoSerializado = SerializarObjetoRespuesta<T>(respuestaApi, objetoSerializado);
            return objetoSerializado;
        }

        private static ResultadoEjecucion<T> SerializarObjetoRespuesta<T>(
            HttpResponseMessage respuestaApi, 
            ResultadoEjecucion<T> objetoSerializado)
        {
            var resultado = respuestaApi.Content.ReadAsStringAsync().Result;
            objetoSerializado.Entidad = JsonConvert.DeserializeObject<T>(resultado);
            return objetoSerializado;
        }
    }
}
