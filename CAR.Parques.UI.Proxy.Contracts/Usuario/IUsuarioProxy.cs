namespace CAR.Parques.UI.Proxy.Contracts.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using System.Collections.Generic;

    public interface IUsuarioProxy : IBaseProxy
    {
        ResultadoEjecucion<ResultadoEjecucion<UsuarioDetalleModel>> VerificarUsuarioAsync(UsuarioModel usuario);
        ResultadoEjecucion<ResultadoEjecucion<int>> CrearUsuario(UsuarioModel usuario);
        ResultadoEjecucion<IEnumerable<UsuarioModel>> ConsultarTodosUsuarios();
        ResultadoEjecucion<IEnumerable<UsuarioDetalleModel>> ConsultarTodosUsuariosDetalles();
        ResultadoEjecucion<UsuarioModel> ConsultarUsuario(int usuarioId);
        ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarUsuario(UsuarioModel usuario);
        ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarUsuario(int usuarioId);
        ResultadoEjecucion<ResultadoEjecucion<bool>> OlvidoContrasenia(UsuarioModel usuario);
        ResultadoEjecucion<ResultadoEjecucion<bool>> Restablecer(RestablecerModel restablecer);
    }
}
