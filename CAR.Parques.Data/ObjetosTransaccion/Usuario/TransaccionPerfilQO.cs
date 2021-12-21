namespace CAR.Parques.Data.ObjetosTransaccion.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionPerfilQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionPerfilQO : TransaccionBaseQO<PerfilEO, PerfilDTO>, ITransaccionPerfilQO
    {
        public int ConsultarIdPerfilNombre(string nombre)
        {
            using (context = new AppParquesContext())
            {
                return (from p in context.PerfilSet
                        where p.NombrePerfil == nombre
                        select p.PerfilId).FirstOrDefault();
            }
        }
    }
}
