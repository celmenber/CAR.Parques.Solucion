﻿namespace CAR.Parques.DataContract.InterfacesTrasaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;

    public interface ITransaccionArchivoReservaQO : ITransaccionBaseQO<ArchivoReservaEO, ArchivoReservaDTO>
    {
        ResultadoEjecucion<ArchivoReservaEO> ConsultarArchivoReserva(int reservaId);        
    }
}