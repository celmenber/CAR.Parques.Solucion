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
    using System.Text;
    using System.Threading.Tasks;

    [Export(typeof(ITransaccionTokenRestablecimientoQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionTokenRestablecimientoQO : TransaccionBaseQO<TokenRestablecimientoEO, TokenRestablecimientoDTO>, ITransaccionTokenRestablecimientoQO
    {
        public ResultadoEjecucion<TokenRestablecimientoEO> ConsultarTokenRestablecimiento(string token)
        {
            ResultadoEjecucion<TokenRestablecimientoEO> resultadoEjecucion = new ResultadoEjecucion<TokenRestablecimientoEO>();
            using (context = new AppParquesContext())
            {
                var tokenObject = (from t in context.TokenRestablecimientoSet
                                   where t.Token == token
                                   select t).FirstOrDefault();
                resultadoEjecucion.Entidad = ConfiguracionDataMapper.GetInstance.
                To<TokenRestablecimientoDTO, TokenRestablecimientoEO>(tokenObject); ;
            }
            return resultadoEjecucion;
        }
    }
}
