namespace CAR.Parques.UI.Proxy.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IDescuentoTipoUsuarioProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DescuentoTipoUsuarioProxy : BaseProxy, IDescuentoTipoUsuarioProxy
    {
        private string nombreApi;

        public DescuentoTipoUsuarioProxy()
        {
            nombreApi = "WaDescuentoTipoUsuario/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarDescuentoTipoUsuario(DescuentoTipoUsuarioModel descuentoTipoUsuario)
        {
            this.AsociarServicio($"{nombreApi}Actualizar", string.Empty);
            return Put<ResultadoEjecucion<bool>>(descuentoTipoUsuario);
        }

        public ResultadoEjecucion<ResultadoEjecucion<DescuentoTipoUsuarioModel>> ConsultarDescuentoTipoUsuario(int descuentoId)
        {
            this.AsociarServicio($"{nombreApi}Consultar/{descuentoId}", string.Empty);
            return Get<ResultadoEjecucion<DescuentoTipoUsuarioModel>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearDescuentoTipoUsuario(DescuentoTipoUsuarioModel descuentoTipoUsuario)
        {
            this.AsociarServicio($"{nombreApi}Crear", string.Empty);
            return Post<ResultadoEjecucion<int>>(descuentoTipoUsuario);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarDescuentoTipoUsuario(int descuentoId)
        {
            this.AsociarServicio($"{nombreApi}Eliminar", string.Empty);
            return Delete<ResultadoEjecucion<bool>>(descuentoId);
        }
    }
}
