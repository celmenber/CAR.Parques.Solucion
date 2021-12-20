namespace CAR.Parques.UI.Proxy.Parques
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.UI.Proxy.Contracts.Parques;

    [Export(typeof(IServicioParqueProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServicioParqueProxy : BaseProxy, IServicioParqueProxy
    {
        private string nombreApi;

        public ServicioParqueProxy()
        {
            nombreApi = "WaServicioParque/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarServiciosParque(ServicioParqueDetalleModel servicioParque)
        {
            var servicioModel = new ServicioParqueModel
            {
                CreadoPorUsuarioId = servicioParque.CreadoPorUsuarioId,
                DescripcionServicioParque = servicioParque.DescripcionServicioParque,
                EstadoServicioId = servicioParque.EstadoServicioId,
                FechaCreacion = servicioParque.FechaCreacion,
                ImpuestoServicio = servicioParque.ImpuestoServicio,
                NombreServicioParque = servicioParque.NombreServicioParque,
                ParqueId = servicioParque.ParqueId,
                PrecioServicio = servicioParque.PrecioServicio,
                ServicioParqueId = servicioParque.ServicioParqueId,
                TipoServicioId = servicioParque.TipoServicioId
            };

            this.AsociarServicio($"{nombreApi}Actualizar", string.Empty);
            return Put<ResultadoEjecucion<bool>>(servicioParque);
        }

        public ResultadoEjecucion<ResultadoEjecucion<ServicioParqueDetalleModel>> ConsultarDetalleServicioParqueXId(int servicioParqueId)
        {
            this.AsociarServicio($"{nombreApi}ConsultarDetalleXId/{servicioParqueId}", string.Empty);
            return Get<ResultadoEjecucion<ServicioParqueDetalleModel>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ServicioParqueDetalleModel>>> ConsultarServiciosParque(int parqueId)
        {
            this.AsociarServicio($"{nombreApi}ConsultarServiciosParque/{parqueId}", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<ServicioParqueDetalleModel>>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearServicioParque(ServicioParqueModel servicioParque)
        {
            this.AsociarServicio($"{nombreApi}Crear", string.Empty);
            return Post<ResultadoEjecucion<int>>(servicioParque);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarServicioParque(int servicioParqueId)
        {
            this.AsociarServicio($"{nombreApi}Eliminar", string.Empty);
            return Delete<ResultadoEjecucion<bool>>(servicioParqueId);
        }
    }
}
