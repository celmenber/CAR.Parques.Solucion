namespace CAR.Parques.UI.Proxy.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Usuario;
    using CAR.Parques.UI.Proxy.Contracts.Usuario;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IUsuarioProxy))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UsuarioProxy : BaseProxy, IUsuarioProxy
    {
        public ResultadoEjecucion<ResultadoEjecucion<bool>> ActualizarUsuario(UsuarioModel usuario)
        {
            this.AsociarServicio($"WaUsuario/Actualizar", string.Empty);
            return Put<ResultadoEjecucion<bool>>(usuario);
        }

        public ResultadoEjecucion<IEnumerable<UsuarioModel>> ConsultarTodosUsuarios()
        {
            this.AsociarServicio("WaUsuario/ConsultarTodos", string.Empty);
            ResultadoEjecucion<IEnumerable<UsuarioModel>> resultado = Get<ResultadoEjecucion<IEnumerable<UsuarioModel>>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<UsuarioDetalleModel>> ConsultarTodosUsuariosDetalles()
        {
            this.AsociarServicio("WaUsuario/ConsultarTodosDetalles", string.Empty);
            ResultadoEjecucion<IEnumerable<UsuarioDetalleModel>> resultado = Get<ResultadoEjecucion<IEnumerable<UsuarioDetalleModel>>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<UsuarioModel> ConsultarUsuario(int usuarioId)
        {
            this.AsociarServicio($"WaUsuario/Consultar/{usuarioId}", string.Empty);
            ResultadoEjecucion<UsuarioModel> resultado = Get<ResultadoEjecucion<UsuarioModel>>().Entidad;
            return resultado;
        }

        public ResultadoEjecucion<ResultadoEjecucion<int>> CrearUsuario(UsuarioModel usuario)
        {
            this.AsociarServicio("WaUsuario/Crear", string.Empty);
            return Post<ResultadoEjecucion<int>>(usuario);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> EliminarUsuario(int usuarioId)
        {
            this.AsociarServicio($"WaUsuario/Eliminar", string.Empty);
            return Delete<ResultadoEjecucion<bool>>(usuarioId);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> OlvidoContrasenia(UsuarioModel usuario)
        {
            this.AsociarServicio("WaUsuario/OlvidoContrasenia", string.Empty);
            return Post<ResultadoEjecucion<bool>>(usuario);
        }

        public ResultadoEjecucion<ResultadoEjecucion<bool>> Restablecer(RestablecerModel restablecer)
        {
            this.AsociarServicio("WaUsuario/Restablecer", string.Empty);
            return Post<ResultadoEjecucion<bool>>(restablecer);
        }

        public ResultadoEjecucion<ResultadoEjecucion<UsuarioDetalleModel>> VerificarUsuarioAsync(UsuarioModel usuario)
        {
            this.AsociarServicio("WaUsuario/VerificarUsuario", string.Empty);
            return Post<ResultadoEjecucion<UsuarioDetalleModel>>(usuario);
        }
    }
}
