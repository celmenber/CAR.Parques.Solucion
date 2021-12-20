namespace CAR.Parques.UI.Proxy.Contracts.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Parametricos;
    using System.Collections.Generic;

    public interface ITipoServicioProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<IEnumerable<TipoServicioModel>>> ConsultarListadoTipoServicio();
    }
}
