namespace CAR.Parques.Data.ObjetosTransaccion.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(ITransaccionMenuPerfilQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionMenuPerfilQO : TransaccionBaseQO<MenuPerfilEO, MenuPerfilDTO>, ITransaccionMenuPerfilQO
    {
    }
}
