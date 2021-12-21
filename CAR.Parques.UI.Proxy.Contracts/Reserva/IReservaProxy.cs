namespace CAR.Parques.UI.Proxy.Contracts.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using System;
    using System.Collections.Generic;

    public interface IReservaProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<int>> CrearReserva(RevDetalleModel reserva);
        ResultadoEjecucion<ResultadoEjecucion<int>> CrearDetalleReserva(DetalleReservaModel reserva);
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ReservaDetalleServicioModel>>> ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin);
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ReservaDetalleServicioModel>>> ConsultarReservasUsuario(FiltroReserva filtros);
        ResultadoEjecucion<ResultadoEjecucion<int>> CrearArchivoReserva(ArchivoReservaModel archivoReserva);
        ResultadoEjecucion<ResultadoEjecucion<int>> ValidarPreReserva(DetalleReservaModel detalleReserva);
        ResultadoEjecucion<ResultadoEjecucion<ArchivoReservaModel>> ObtenerArchivoComprobanteReserva(int reservaId);
        ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarEstadoReserva(ReservaModel reserva);
    }
}
