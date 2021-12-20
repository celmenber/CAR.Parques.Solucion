namespace CAR.Parques.UI.Proxy.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IParqueProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ParqueProxy : BaseProxy, IParqueProxy
    {
        private string nombreApi;
        public ParqueProxy()
        {
            nombreApi = "WaParque/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarParque(ParqueModel parque)
        {
            this.AsociarServicio($"{nombreApi}Actualizar", string.Empty);
            return Put<ResultadoEjecucion<bool>>(parque);
        }

        public ResultadoEjecucion<ParqueInformacionModel> ConsultarDetalleParqueXId(int parqueId)
        {
            this.AsociarServicio($"{nombreApi}ConsultarDetalleXId/{parqueId}", string.Empty);
            ResultadoEjecucion<ParqueInformacionModel> resultado = Get<ResultadoEjecucion<ParqueInformacionModel>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ParqueModel>> ConsultarListadoTodosParques()
        {
            this.AsociarServicio($"{nombreApi}ConsultarListadoParques", string.Empty);
            ResultadoEjecucion<IEnumerable<ParqueModel>> resultado = Get<ResultadoEjecucion<IEnumerable<ParqueModel>>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ParqueDetalleModel>> ConsultarListadoTodosParquesDet()
        {
            this.AsociarServicio($"{nombreApi}ConsultarListadoParquesDetalle", string.Empty);
            ResultadoEjecucion<IEnumerable<ParqueDetalleModel>> resultado = 
                Get<ResultadoEjecucion<IEnumerable<ParqueDetalleModel>>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ParqueInformacionModel>> ConsultarListadoTodosParquesInformacion()
        {
            this.AsociarServicio($"{nombreApi}ConsultarListadoInformacionParques", string.Empty);
            ResultadoEjecucion<IEnumerable<ParqueInformacionModel>> resultado =
                Get<ResultadoEjecucion<IEnumerable<ParqueInformacionModel>>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearParque(ParqueModel parque)
        {
            this.AsociarServicio($"{nombreApi}Crear", string.Empty);
            return Post<ResultadoEjecucion<int>>(parque);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarParque(int parqueId)
        {
            this.AsociarServicio($"{nombreApi}Eliminar", string.Empty);
            return Delete<ResultadoEjecucion<bool>>(parqueId);
        }
    }
}
