namespace CAR.Parques.Service.WebApi.Core.ContratoBase
{
    using System.Net.Http;
    using System.Web.Http;

    public interface IApiAccionDTControllerBase<T>
    {
        HttpResponseMessage Actualizar(T entidad);

        HttpResponseMessage Consultar(int id);

        
        HttpResponseMessage ConsultarTodos();

        HttpResponseMessage Crear(T entidad);

        HttpResponseMessage Eliminar(int id);
    }
}
