namespace CAR.Parques.Business.Contract.ManagerContracts.Base
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using System.Collections.Generic;

    public interface IBaseAccionManager<T> : IBaseServicioManager 
        where T : class
    {
        ResultadoEjecucion<bool> Actualizar(T entidad);
        ResultadoEjecucion<T> Consultar(int id);
        ResultadoEjecucion<IEnumerable<T>> ConsultarTodos();
        ResultadoEjecucion<int> Crear(T entidad);
        ResultadoEjecucion<bool> Eliminar(int id);
    }
}
