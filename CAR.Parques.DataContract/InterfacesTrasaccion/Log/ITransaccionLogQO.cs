namespace CAR.Parques.DataContract.InterfacesTrasaccion.Log
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Bitacora;
    using CAR.Parques.Data.DataTransferObjects.DTO.Log;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;

    public interface ITransaccionLogQO : ITransaccionBaseQO<LogTransaccion, LogSistemaDTO>
    {
        ResultadoEjecucion<bool> Insertar(LogTransaccion log);
    }
}
