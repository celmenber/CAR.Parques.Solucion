namespace CAR.Parques.DataContract.InterfacesTrasaccion.Base
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using System.Collections.Generic;

    public interface ITransaccionBaseQO <T,K>  where T : class where K : class
    {
        ResultadoEjecucion<bool> Actualizar(T entidad);
        ResultadoEjecucion<T> Consultar(int id);
        ResultadoEjecucion<IEnumerable<T>> ConsultarTodos();
        ResultadoEjecucion<int> Crear(T entidad);
        ResultadoEjecucion<bool> Eliminar(int id);
    }
}
