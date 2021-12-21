namespace CAR.Parques.Data.ObjetosTransaccion.Usuario
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.Data.DataTransferObjects.DTO.Usuario;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using System.Configuration;
    using Oracle.DataAccess.Client;
    using System.Data;

    [Export(typeof(ITransaccionUsuarioQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionUsuarioQO : TransaccionBaseQO<UsuarioEO, UsuarioDTO>, ITransaccionUsuarioQO
    {
        private string strConexion;
        private OracleConnection sqlConn;

        public TransaccionUsuarioQO()
        {
            strConexion = ConfigurationManager.ConnectionStrings["ConStringBDOracle"].ConnectionString;
        }

        public OracleConnection GenerarConexion()
        {
            OracleConnection sqlConn;
            sqlConn = new OracleConnection(strConexion);
            return sqlConn;
        }


        public ResultadoEjecucion<string> verificarTipoUsuario(string numDocumento)
        {
            ResultadoEjecucion<string> resultadoEjecucion = new ResultadoEjecucion<string>();
            try
            {
                var tipoUsuario = obtenerTipoUsuario(numDocumento);
                resultadoEjecucion.Entidad = tipoUsuario;
            }
            catch(Exception ex)
            {
                resultadoEjecucion.Codigo = 0;
                resultadoEjecucion.Descripcion = ex.Message;
            }
            return resultadoEjecucion;
        }

        public ResultadoEjecucion<UsuarioDetalleEO> VerificarUsuario(string email, string password)
        {
            ResultadoEjecucion<UsuarioDetalleEO> usuarioConsulta = new ResultadoEjecucion<UsuarioDetalleEO>();
            using (context = new AppParquesContext())
            {
                var usuario = (from u in context.UsuarioSet
                               join p in context.PerfilSet on u.PerfilId equals p.PerfilId
                               where u.Email == email
                               && u.PasswordUsuario == password
                               select new UsuarioDetalleEO
                               {
                                   UsuarioId = u.UsuarioId,
                                   Apellido1 = u.Apellido1,
                                   Apellido2 = u.Apellido2,
                                   Documento = u.Documento,
                                   Email = u.Email,
                                   Nombre1 = u.Nombre1,
                                   Nombre2 = u.Nombre2,
                                   PasswordUsuario = u.PasswordUsuario,
                                   PerfilId = u.PerfilId,
                                   TipoDocumentoId = u.TipoDocumentoId,
                                   TipoUsuarioId = u.TipoUsuarioId,
                                   NombrePerfil = p.NombrePerfil
                               }).FirstOrDefault();
                if (usuario != null)
                {
                    var menu = (from m in context.MenuSet
                                    join mp in context.MenuPerfilSet on m.MenuId equals mp.MenuId
                                    where mp.PerfilId == usuario.PerfilId
                                    select m).ToList();

                    if (menu != null)
                    {
                        usuario.Menu = ConfiguracionDataMapper.GetInstance.To<IEnumerable<MenuDTO>, IEnumerable<MenuEO>>(menu);
                    }

                    usuarioConsulta.Entidad = usuario;
                    usuarioConsulta.Descripcion = "Usuario verificado.";
                    //var tipoUsuario = this.verificarTipoUsuario("1024539194");
                }
                else
                {
                    usuarioConsulta.Codigo = 0;
                    usuarioConsulta.Descripcion = "Documento y/o contraseña invalidos.";
                }
            }

            return usuarioConsulta;
        }

        public ResultadoEjecucion<IEnumerable<UsuarioDetalleEO>> ConsultarUsariosDetalle()
        {
            ResultadoEjecucion<IEnumerable<UsuarioDetalleEO>> resultadoConsulta = 
                new ResultadoEjecucion<IEnumerable<UsuarioDetalleEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var usuarios = (from u in context.UsuarioSet
                                    join p in context.PerfilSet on u.PerfilId equals p.PerfilId
                                    join tu in context.TipoUsuarioSet on u.TipoUsuarioId equals tu.TipoUsuarioId
                                    select new UsuarioDetalleEO
                                    {
                                        UsuarioId = u.UsuarioId,
                                        Apellido1 = u.Apellido1,
                                        Apellido2 = u.Apellido2,
                                        Documento = u.Documento,
                                        Email = u.Email,
                                        Nombre1 = u.Nombre1,
                                        Nombre2 = u.Nombre2,
                                        PasswordUsuario = u.PasswordUsuario,
                                        PerfilId = u.PerfilId,
                                        TipoDocumentoId = u.TipoDocumentoId,
                                        TipoUsuarioId = u.TipoUsuarioId,
                                        TipoUsuario = tu.NombreTipoUsuario,
                                        NombrePerfil = p.NombrePerfil
                                    }).ToList();

                    resultadoConsulta.Entidad = usuarios;
                    resultadoConsulta.Descripcion = "Consulta Exitosa.";
                }
            }
            catch (Exception ex)
            {
                resultadoConsulta.Entidad = null;
                resultadoConsulta.Descripcion = "Error Consulta Usuarios Detalle: " + ex.Message;
            }
            return resultadoConsulta;
        }

        public string obtenerTipoUsuario(string documento)
        {
            string respuesta = "NA";
            if (this.validarFuncionariosCAR(documento) > 0)
            {
                respuesta = "Funcionario";
            }
            else if (this.validarContratistasCAR(documento) > 0)
            {
                respuesta = "Constratista";
            }
            return respuesta;
        }

        public double validarFuncionariosCAR(string documento)
        {
            double dblTotal = 0;

            DataTable dtResultado = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            try
            {
                sqlConn = GenerarConexion();
                cmd.Connection = sqlConn;
                sqlConn.Open();
                cmd.InitialLONGFetchSize = 1000;
                cmd.CommandText = "sp_validarFuncionariosCAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_documentoIn", OracleDbType.Char).Value = documento;
                cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(dtResultado);
                sqlConn.Close();
                dblTotal = (double)dtResultado.Rows.Count;

            }
            catch (Exception ex)
            {
                string Mensaje = ex.ToString();
                sqlConn.Close();
            }

            return dblTotal;
        }

        public double validarContratistasCAR(string documento)
        {
            double dblTotal = 0;

            DataTable dtResultado = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            try
            {
                sqlConn = GenerarConexion();
                cmd.Connection = sqlConn;
                sqlConn.Open();

                cmd.InitialLONGFetchSize = 1000;
                cmd.CommandText = "sp_validarContratistasCAR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_documentoIn", OracleDbType.Char).Value = documento;
                cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(dtResultado);
                sqlConn.Close();
                dblTotal = (double)dtResultado.Rows.Count;

            }
            catch (Exception ex)
            {
                string Mensaje = ex.ToString();
                sqlConn.Close();
            }

            return dblTotal;
        }

        public ResultadoEjecucion<UsuarioDetalleEO> ConsultarUsuarioDocumento(int tipoDocumento, string documento)
        {
            ResultadoEjecucion<UsuarioDetalleEO> usuarioConsulta = new ResultadoEjecucion<UsuarioDetalleEO>();
            using (context = new AppParquesContext())
            {
                var usuario = (from u in context.UsuarioSet
                               join p in context.PerfilSet on u.PerfilId equals p.PerfilId
                               where u.TipoDocumentoId == tipoDocumento
                               && u.Documento == documento
                               select new UsuarioDetalleEO
                               {
                                   UsuarioId = u.UsuarioId,
                                   Apellido1 = u.Apellido1,
                                   Apellido2 = u.Apellido2,
                                   Documento = u.Documento,
                                   Email = u.Email,
                                   Nombre1 = u.Nombre1,
                                   Nombre2 = u.Nombre2,
                                   PasswordUsuario = u.PasswordUsuario,
                                   PerfilId = u.PerfilId,
                                   TipoDocumentoId = u.TipoDocumentoId,
                                   TipoUsuarioId = u.TipoUsuarioId,
                                   NombrePerfil = p.NombrePerfil
                               }).FirstOrDefault();
                usuarioConsulta.Entidad = usuario;
                usuarioConsulta.Descripcion = "Usuario Existente.";
            }

            return usuarioConsulta;
        }
    }
}
