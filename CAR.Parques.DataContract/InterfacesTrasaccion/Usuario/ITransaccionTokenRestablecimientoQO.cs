namespace CAR.Parques.DataContract.InterfacesTrasaccion.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;

    public interface ITransaccionTokenRestablecimientoQO : ITransaccionBaseQO<TokenRestablecimientoEO, TokenRestablecimientoDTO>
    {
        ResultadoEjecucion<TokenRestablecimientoEO> ConsultarTokenRestablecimiento(string token);
    }
}
