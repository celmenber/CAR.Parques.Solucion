namespace CAR.Parques.DataContract.InterfacesTrasaccion.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;
    using System.Collections.Generic;

    public interface ITransaccionUsuarioQO : ITransaccionBaseQO<UsuarioEO, UsuarioDTO>
    {
        ResultadoEjecucion<UsuarioDetalleEO> VerificarUsuario(string email, string password);

        ResultadoEjecucion<string> verificarTipoUsuario(string numDocumento);

        ResultadoEjecucion<IEnumerable<UsuarioDetalleEO>> ConsultarUsariosDetalle();

        ResultadoEjecucion<UsuarioDetalleEO> ConsultarUsuarioDocumento(int tipoDocumento, string documento);
    }
}
