namespace CAR.Parques.Business.Contract.ManagerContracts.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using System.Collections.Generic;

    public interface IUsuarioManager : IBaseAccionManager<UsuarioEO>
    {
        ResultadoEjecucion<UsuarioDetalleEO> VerificarUsuario(string email, string password);
        ResultadoEjecucion<IEnumerable<UsuarioDetalleEO>> ConsultarUsariosDetalle();
        ResultadoEjecucion<bool> OlvidoContrasenia(UsuarioEO entidad);
        ResultadoEjecucion<bool> RestablecerContrasenia(string contrasenia, string token);
    }
}