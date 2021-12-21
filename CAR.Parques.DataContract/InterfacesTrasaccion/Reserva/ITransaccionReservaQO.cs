namespace CAR.Parques.DataContract.InterfacesTrasaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System.Collections.Generic;

    public interface ITransaccionReservaQO : ITransaccionBaseQO<ReservaEO, ReservaDTO>
    {
        ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin);

        ResultadoEjecucion<IEnumerable<DetalleReservaEO>> CrearDetalleReservas(int DetalleReservaId, int ReservaId, int ServicioId, string fechaIncio, string fechaFin, decimal PrecioTotalServicio, decimal PrecioTotalDescuento, bool AdquirioServicio, int cantidad);

        ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId);
        ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId, int estadoId);
        ResultadoEjecucion<ReservaDetalleServicioEO> ConsultarReservaUsuario(int reservaId);
    }
}
