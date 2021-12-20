namespace CAR.Parques.UI.Proxy.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using CAR.Parques.UI.Proxy.Contracts.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IReservaProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReservaProxy : BaseProxy, IReservaProxy
    {
        private string nombreApi;

        public ReservaProxy()
        {
            nombreApi = "WaReserva/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearReserva(RevDetalleModel reserva)
        {
            this.AsociarServicio($"{nombreApi}CrearReservaDetalle", string.Empty);
            return Post<ResultadoEjecucion<int>>(reserva);
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearDetalleReserva(DetalleReservaModel reserva)
        {
            this.AsociarServicio($"{nombreApi}CrearDetalleReserva", string.Empty);
            return Post<ResultadoEjecucion<int>>(reserva);
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ReservaDetalleServicioModel>>> ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin)
        {
            this.AsociarServicio($"{nombreApi}ConsultarReservasDetalle/{estadoId}/{parqueId}/{fechaIncio}/{fechaFin}", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<ReservaDetalleServicioModel>>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ReservaDetalleServicioModel>>> ConsultarReservasUsuario(FiltroReserva filtros)
        {
            this.AsociarServicio($"{nombreApi}ReservasUsuario/{filtros.UsuarioId}/{filtros.EstadoId}", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<ReservaDetalleServicioModel>>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearArchivoReserva(ArchivoReservaModel archivoReserva)
        {
            this.AsociarServicio($"{nombreApi}ArchivoReserva", string.Empty);
            return Post<ResultadoEjecucion<int>>(archivoReserva);
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> ValidarPreReserva(DetalleReservaModel detalleReserva)
        {
            this.AsociarServicio($"{nombreApi}ValidarPreReserva", string.Empty);
            return Post<ResultadoEjecucion<int>>(detalleReserva);
        }

    }
}
