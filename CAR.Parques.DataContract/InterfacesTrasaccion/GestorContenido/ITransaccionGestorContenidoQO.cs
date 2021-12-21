namespace CAR.Parques.DataContract.InterfacesTrasaccion.GestorContenido
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using CAR.Parques.Data.DataTransferObjects.DTO.GestorContenido;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System.Collections.Generic;

    public interface ITransaccionGestorContenidoQO : ITransaccionBaseQO<GestorContenidoEO, GestorContenidoDTO>
    {
        ResultadoEjecucion<IEnumerable<GestorContenidoEO>> ConsultarTodosVigentes();
    }
}
