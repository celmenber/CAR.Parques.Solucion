namespace CAR.Parques.Data.ObjetosTransaccion.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionMenuQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionMenuQO : TransaccionBaseQO<MenuEO, MenuDTO>, ITransaccionMenuQO
    {
        public ResultadoEjecucion<IEnumerable<MenuEO>> ConsultaMenuPorPerfil(int idPerfil)
        {
            ResultadoEjecucion<IEnumerable<MenuEO>> resultado = new ResultadoEjecucion<IEnumerable<MenuEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var menu = (from m in context.MenuSet
                                join mp in context.MenuPerfilSet on m.MenuId equals mp.MenuId
                                where mp.PerfilId == idPerfil
                                select m).ToList();

                    if(menu != null)
                    {
                        resultado.Entidad = ConfiguracionDataMapper.GetInstance.To<IEnumerable<MenuDTO>, IEnumerable<MenuEO>>(menu);
                    }                    
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"ERROR ConsultaMenuPorPerfil: {ex.Message}";
            }

            return resultado;
        }
    }
}
