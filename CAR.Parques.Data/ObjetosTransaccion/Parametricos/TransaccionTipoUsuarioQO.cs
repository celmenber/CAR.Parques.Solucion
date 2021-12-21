namespace CAR.Parques.Data.ObjetosTransaccion.Parametricos
{
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parametricos;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionTipoUsuarioQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionTipoUsuarioQO : TransaccionBaseQO<TipoUsuarioEO, TipoUsuarioDTO>, ITransaccionTipoUsuarioQO
    {
        public int ConsultarIdTipoUsuarioPorNombre(string nombre)
        {
            int tipoUsuario = 0;
            using (context = new AppParquesContext())
            {
                tipoUsuario = (from tu in context.TipoUsuarioSet
                               where tu.NombreTipoUsuario == nombre
                               select tu.TipoUsuarioId).FirstOrDefault();
                return tipoUsuario;
            }
        }
    }
}
