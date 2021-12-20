namespace CAR.Parques.UI.Proxy.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.GestorContenido;
    using CAR.Parques.UI.Proxy.Contracts.Parques;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(INoticiaProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class NoticiaProxy : BaseProxy, INoticiaProxy
    {
        private string nombreApi;
        public NoticiaProxy()
        {
            nombreApi = "WaNoticia/";
        }
        
        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<GestorContenidoModel>>> ObtenerListadoNoticias()
        {
            this.AsociarServicio($"{nombreApi}ConsultarNoticias", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<GestorContenidoModel>>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<IEnumerable<GestorContenidoModel>>> ObtenerListadoNoticiasVigentes()
        {
            this.AsociarServicio($"{nombreApi}NoticiasVigentes", string.Empty);
            return Get<ResultadoEjecucion<IEnumerable<GestorContenidoModel>>>();
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearNoticia(GestorContenidoModel noticia)
        {
            this.AsociarServicio($"{nombreApi}Crear", string.Empty);
            return Post<ResultadoEjecucion<int>>(noticia);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EditarNoticia(GestorContenidoModel noticia)
        {
            this.AsociarServicio($"{nombreApi}Actualizar", string.Empty);
            return Post<ResultadoEjecucion<bool>>(noticia);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarNoticia(int noticiaId)
        {
            this.AsociarServicio($"{nombreApi}Eliminar", string.Empty);
            return Delete<ResultadoEjecucion<bool>>(noticiaId);
        }

        public ResultadoEjecucion<ResultadoEjecucion<GestorContenidoModel>> ObtenerNoticia(int noticiaId)
        {
            this.AsociarServicio($"{nombreApi}ConsultarNoticia/{noticiaId}", string.Empty);
            return Get<ResultadoEjecucion<GestorContenidoModel>>();
        }
    }
}
