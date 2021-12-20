namespace CAR.Parques.UI.Proxy.Contracts.Parques
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.GestorContenido;
    using System.Collections.Generic;

    public interface INoticiaProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<GestorContenidoModel>>> ObtenerListadoNoticias();
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<GestorContenidoModel>>> ObtenerListadoNoticiasVigentes();

        ResultadoEjecucion<ResultadoEjecucion<int>> CrearNoticia(GestorContenidoModel archivoParque);

        ResultadoEjecucion<ResultadoEjecucion<bool>> EditarNoticia(GestorContenidoModel archivoParque);

        ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarNoticia(int noticiaId);

        ResultadoEjecucion<ResultadoEjecucion<GestorContenidoModel>> ObtenerNoticia(int noticiaId);
    }
}
