namespace CAR.Parques.Data.ObjetosTransaccion.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(ITransaccionTipoServicioQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionTipoServicioQO : TransaccionBaseQO<TipoServicioEO, TipoServicioDTO>, ITransaccionTipoServicioQO
    {
    }
}
