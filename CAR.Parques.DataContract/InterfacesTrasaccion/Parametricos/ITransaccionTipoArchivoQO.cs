namespace CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System.Collections.Generic;

    public interface ITransaccionTipoArchivoQO : ITransaccionBaseQO<TipoArchivoEO, TipoArchivoDTO>
    {
    }
}
