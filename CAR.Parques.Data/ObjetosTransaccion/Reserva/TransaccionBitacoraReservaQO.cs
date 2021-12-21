namespace CAR.Parques.Data.ObjetosTransaccion.Reserva
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Data.DataTransferObjects.DTO.Reserva;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(ITransaccionBitacoraReservaQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionBitacoraReservaQO : TransaccionBaseQO<BitacoraReservaEO, BitacoraReservaDTO>, ITransaccionBitacoraReservaQO
    {
    }
}
