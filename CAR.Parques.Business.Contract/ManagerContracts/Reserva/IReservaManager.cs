namespace CAR.Parques.Business.Contract.ManagerContracts.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using System.Collections.Generic;

    public interface IReservaManager : IBaseAccionManager<ReservaEO>
    {
        ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin);
        ResultadoEjecucion<int> CrearDetalle(ReservaEO entidad, IEnumerable<DetalleReservaEO> detalles);
        ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId, int estadoId);
        ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId);
        ResultadoEjecucion<int> CargarArchivoReserva(ArchivoReservaEO entidad);
        ResultadoEjecucion<int> ValidarPreReserva(DetalleReservaEO detalleReserva);
        ResultadoEjecucion<ArchivoReservaEO> ObtenerArchivoComprobanteReserva(int reservaId);
        ResultadoEjecucion<bool> ActualizarEstadoReserva(ReservaModel reserva);
    }
}
