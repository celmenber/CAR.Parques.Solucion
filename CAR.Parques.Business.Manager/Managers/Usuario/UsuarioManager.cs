namespace CAR.Parques.Business.Manager.Managers.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Usuario;
    using CAR.Parques.Business.Contract.ManagerContracts.Utilitarios;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Business.Manager.Managers.Extensiones;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Configuration;
    using System.Linq;

    [Export(typeof(IUsuarioManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UsuarioManager : ManagerBase, IUsuarioManager
    {
        private readonly ITransaccionUsuarioQO iTransaccionUsuarioRepository;
        private readonly ITransaccionPerfilQO iTransaccionPerfilRepository;
        private readonly ITransaccionTipoUsuarioQO iTransaccionTipoUsurioRepository;
        private readonly ITransaccionTokenRestablecimientoQO iTransaccionTokenRestablecimientoRepository;
        private readonly IManejoCorreoManager iManagerManejoCorreoRepository;

        [ImportingConstructor]
        public UsuarioManager(ILogManager logManagerRepository,
                              ITransaccionUsuarioQO transaccionUsuarioRepository,
                              ITransaccionPerfilQO transaccionPerfilRepository,
                              ITransaccionTipoUsuarioQO transaccionTipoUsurioRepository,
                              IManejoCorreoManager managerManejoCorreoRepository,
                              ITransaccionTokenRestablecimientoQO transaccionTokenRestablecimientoRepository) :
            base(logManagerRepository, "usuario")
        {
            iTransaccionUsuarioRepository = transaccionUsuarioRepository;
            iTransaccionPerfilRepository = transaccionPerfilRepository;
            iTransaccionTipoUsurioRepository = transaccionTipoUsurioRepository;
            iManagerManejoCorreoRepository = managerManejoCorreoRepository;
            iTransaccionTokenRestablecimientoRepository = transaccionTokenRestablecimientoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(UsuarioEO entidad)
        {
            try
            {
                if (entidad.TipoUsuarioId == 0)
                {
                    var tipoUsuarioInfo = iTransaccionUsuarioRepository.verificarTipoUsuario(entidad.Documento);
                    entidad.TipoUsuarioId = tipoUsuarioInfo.Entidad == "Funcionario" ? 1 : tipoUsuarioInfo.Entidad == "Constratista" ? 2 : 3;
                }

                var resultado = iTransaccionUsuarioRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<UsuarioEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionUsuarioRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new UsuarioEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<UsuarioEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionUsuarioRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<UsuarioEO>)new List<UsuarioEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<UsuarioDetalleEO>> ConsultarUsariosDetalle()
        {
            try
            {
                var resultado = iTransaccionUsuarioRepository.ConsultarUsariosDetalle();
                this.RegistrarExtisoLogTransaccion("Consulta Todos Detalle", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<UsuarioDetalleEO>)new List<UsuarioDetalleEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(UsuarioEO entidad)
        {
            try
            {
                if (entidad.PerfilId == 0)
                {
                    entidad.PerfilId = iTransaccionPerfilRepository.ConsultarIdPerfilNombre("Usuario Convencional");
                }

                if (entidad.TipoUsuarioId == 0)
                {
                    var tipoUsuarioInfo = iTransaccionUsuarioRepository.verificarTipoUsuario(entidad.Documento);
                    entidad.TipoUsuarioId = tipoUsuarioInfo.Entidad == "Funcionario" ? 1 : tipoUsuarioInfo.Entidad == "Constratista" ? 2 : 3;
                }

                var resultado = iTransaccionUsuarioRepository.Crear(entidad);
                this.RegistrarExtisoLogTransaccion("Creación ", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new int(), 0);
            }
        }

        public ResultadoEjecucion<bool> Eliminar(int id)
        {
            try
            {
                var resultado = iTransaccionUsuarioRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<bool> OlvidoContrasenia(UsuarioEO entidad)
        {
            ResultadoEjecucion<bool> resultado = new ResultadoEjecucion<bool>();
            try
            {
                var usuario = iTransaccionUsuarioRepository.ConsultarUsuarioDocumento(entidad.TipoDocumentoId, entidad.Documento);
                if (usuario.Entidad != null)
                {
                    Guid token = Guid.NewGuid();
                    var resultadoRegistro = iTransaccionTokenRestablecimientoRepository.Crear(new TokenRestablecimientoEO
                    {
                        UsuarioId = usuario.Entidad.UsuarioId,
                        Utilizado = false,
                        FechaGeneracion = DateTime.Now,
                        Token = token.ToString()
                    });
                    if (resultadoRegistro.Codigo == 1)
                    {
                        var correo = iManagerManejoCorreoRepository.ConsultarCorreoXNombre("Restablecimiento Clave");
                        string UrlRestablecimiento = string.Format(ConfigurationManager.AppSettings["UrlRestablecer"], token.ToString());
                        var resultadoCorreo =
                            iManagerManejoCorreoRepository.EnviarCorreo(
                                entidad.Email,
                                correo.Entidad.Asunto,
                                string.Format(correo.Entidad.CuerpoCorreo, entidad.Documento, UrlRestablecimiento, "Atentamente CAR"),
                                correo.Entidad.EsHtml);
                        resultado.Entidad = true;
                    }
                    else
                    {
                        resultado.Codigo = 0;
                        resultado.Descripcion = resultadoRegistro.Descripcion;
                        resultado.Entidad = false;
                        this.RegistrarNoExtisoLogTransaccionControlado("Olvido Contrasenia", false, new bool(), resultado.Descripcion);
                    }
                }
                else
                {
                    resultado.Codigo = 0;
                    resultado.Descripcion = "El usuario no esta registrado en la aplicación.";
                    resultado.Entidad = false;
                    this.RegistrarNoExtisoLogTransaccionControlado("Olvido Contrasenia", false, new bool(), resultado.Descripcion);
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "Error Olvido Contraseña - ERROR : " + ex.Message;
                resultado.Entidad = false;
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
            return resultado;
        }

        public ResultadoEjecucion<bool> RestablecerContrasenia(string contrasenia, string token)
        {
            ResultadoEjecucion<bool> resultado = new ResultadoEjecucion<bool>();
            try
            {
                var tokenInfo = iTransaccionTokenRestablecimientoRepository.ConsultarTokenRestablecimiento(token);
                if (tokenInfo.Entidad != null
                    && tokenInfo.Entidad.Utilizado == false
                    && (DateTime.Now - tokenInfo.Entidad.FechaGeneracion).TotalHours < 1)
                {
                    var usuario = iTransaccionUsuarioRepository.Consultar(tokenInfo.Entidad.UsuarioId);
                    usuario.Entidad.PasswordUsuario = contrasenia;
                    var resultadoActualizacion = iTransaccionUsuarioRepository.Actualizar(usuario.Entidad);
                    resultado.Entidad = true;
                    if (resultadoActualizacion.Codigo == 0)
                    {
                        resultado.Codigo = 0;
                        resultado.Descripcion = "No fue posible realizar la actualización";
                        resultado.Entidad = false;
                        this.RegistrarNoExtisoLogTransaccionControlado("Restablecer", false, new bool(), resultado.Descripcion);
                    }
                    else
                    {
                        tokenInfo.Entidad.Utilizado = true;
                        iTransaccionTokenRestablecimientoRepository.Actualizar(tokenInfo.Entidad);
                    }
                }
                else
                {
                    resultado.Codigo = 0;
                    resultado.Descripcion = "El token asociado es invalido o esta vencido.";
                    resultado.Entidad = false;
                    this.RegistrarNoExtisoLogTransaccionControlado("Restablecer", false, new bool(), resultado.Descripcion);
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "Error Olvido Contraseña - ERROR : " + ex.Message;
                resultado.Entidad = false;
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
            return resultado;
        }

        public ResultadoEjecucion<UsuarioDetalleEO> VerificarUsuario(string email, string password)
        {
            try
            {
                var resultado = iTransaccionUsuarioRepository.VerificarUsuario(email, password);
                this.RegistrarExtisoLogTransaccion($"Verificación Login Usuario Email: {email}, {resultado.Descripcion}", true);

                resultado.Entidad.Menu.ToList().ForEach(m => m.SetPathByEnvironment());

                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new UsuarioDetalleEO(), 0);
            }
        }
    }
}
