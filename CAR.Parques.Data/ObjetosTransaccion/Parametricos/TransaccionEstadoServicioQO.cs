namespace CAR.Parques.Data.ObjetosTransaccion.Parametricos
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos;

    [Export(typeof(ITransaccionEstadoServicioQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionEstadoServicioQO : TransaccionBaseQO<EstadoServicioEO, EstadoServicioDTO>, ITransaccionEstadoServicioQO
    {
    }
}
