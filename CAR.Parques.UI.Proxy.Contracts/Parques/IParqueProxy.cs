namespace CAR.Parques.UI.Proxy.Contracts.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using System.Collections.Generic;

    public interface IParqueProxy : IBaseProxy
    {
        ResultadoEjecucion<IEnumerable<ParqueModel>> ConsultarListadoTodosParques();
        ResultadoEjecucion<IEnumerable<ParqueInformacionModel>> ConsultarListadoTodosParquesInformacion();
        ResultadoEjecucion<IEnumerable<ParqueDetalleModel>> ConsultarListadoTodosParquesDet();
        ResultadoEjecucion<ResultadoEjecucion<int>> CrearParque(ParqueModel parque);
        ResultadoEjecucion<ParqueInformacionModel> ConsultarDetalleParqueXId(int parqueId);
        ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarParque(ParqueModel parque);
        ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarParque(int parqueId);
    }
}
