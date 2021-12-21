namespace CAR.Parques.DataContract.InterfacesTrasaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System;

    public interface ITransaccionDetalleReservaQO : ITransaccionBaseQO<DetalleReservaEO, DetalleReservaDTO>
    {
        ResultadoEjecucion<int> ValidarPreReserva(DetalleReservaEO detalleReserva);
    }
}
