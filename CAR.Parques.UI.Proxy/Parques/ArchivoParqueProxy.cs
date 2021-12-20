namespace CAR.Parques.UI.Proxy.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Common.Models.Modelos.Parques;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IArchivoParqueProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ArchivoParqueProxy : BaseProxy, IArchivoParqueProxy
    {
        private string nombreApi;
        public ArchivoParqueProxy()
        {
            nombreApi = "WaArchivoParque/";
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarArchivoParque(ArchivoParqueModel archivoParque)
        {
            this.AsociarServicio($"{nombreApi}Actualizar", string.Empty);
            return Post<ResultadoEjecucion<bool>>(archivoParque);
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<ArchivoParqueEO>>> ConsultarListadoArchivosParque(int tipoArchivoId, int parqueId)
        {
            this.AsociarServicio($"{nombreApi}ConsultarArchivoParque/{tipoArchivoId}/{parqueId}", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<ArchivoParqueEO>>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearArchivoParque(ArchivoParqueModel archivoParque)
        {
            this.AsociarServicio($"{nombreApi}Crear", string.Empty);
            return Post<ResultadoEjecucion<int>>(archivoParque);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarArchivo(int archivoParqueId)
        {
            this.AsociarServicio($"{nombreApi}Eliminar", string.Empty);
            return Delete<ResultadoEjecucion<bool>>(archivoParqueId);
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<TipoArchivoEO>>> ConsultarTiposArchivo()
        {
            this.AsociarServicio($"{nombreApi}ConsultarTiposArchivo", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<TipoArchivoEO>>>();
        }
    }
}
