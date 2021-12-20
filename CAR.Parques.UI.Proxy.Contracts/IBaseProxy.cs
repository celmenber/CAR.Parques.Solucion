namespace CAR.Parques.UI.Proxy.Contracts
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IBaseProxy
    {
        Dictionary<string, string> Headers { get; }
        void AsociarServicio(string nombreServicio, string token);
        HttpResponseMessage Get();
        Task<ResultadoEjecucion<T>> GetAsync<T>();
        ResultadoEjecucion<T> Get<T>();
        ResultadoEjecucion<T> Get<T>(int id);
        HttpResponseMessage Get(string id);
        HttpResponseMessage Get(object entidad);
        HttpResponseMessage Post();
        HttpResponseMessage Post(string id);
        HttpResponseMessage Post(object entidad);
        ResultadoEjecucion<T> Post<T>(object entidad);
        Task<ResultadoEjecucion<T>> PostAsync<T>(object entidad);
        ResultadoEjecucion<T> Send<T, K>(K objectRequest, string method = "POST");
        ResultadoEjecucion<T> Delete<T>(int id);
        ResultadoEjecucion<T> Put<T>(object entidad);
    }
}
