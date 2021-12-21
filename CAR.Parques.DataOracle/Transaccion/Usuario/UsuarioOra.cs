namespace CAR.Parques.DataOracle.Transaccion.Usuario
{
    using CAR.Parques.DataOracle.Connection;
    //using Oracle.DataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UsuarioOra
    {
       // private int intRegAfectados;
        //private OracleConnection sqlConn;
        //private OracleCommand objCmd;

        public string obtenerTipoUsuario(string documento)
        {
            string respuesta = "NA";
            if (this.validarFuncionariosCAR(documento) > 1)
            {
                respuesta = "Funcionario";
            }
            else if (this.validarContratistasCAR(documento) > 1)
            {
                respuesta = "Constratista";
            }
            return respuesta;
        }

        public double validarFuncionariosCAR(string documento)
        {
            double dblTotal = 0;

            DataTable dtResultado = new DataTable();
            //OracleDataAdapter da = new OracleDataAdapter();
            //OracleCommand cmd = new OracleCommand();
            //try
            //{
            //    sqlConn = new OracleConnectionParques().GenerarConexion();
            //    cmd.Connection = sqlConn;
            //    sqlConn.Open();
            //    cmd.InitialLONGFetchSize = 1000;
            //    cmd.CommandText = "sp_validarFuncionariosCAR";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("p_documentoIn", OracleDbType.Char).Value = documento;
            //    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            //    da.SelectCommand = cmd;
            //    da.Fill(dtResultado);
            //    sqlConn.Close();
            //    dblTotal = (double)dtResultado.Rows.Count;

            //}
            //catch (Exception ex)
            //{
            //    string Mensaje = ex.ToString();
            //    sqlConn.Close();
            //}

            return dblTotal;
        }

        public double validarContratistasCAR(string documento)
        {
            double dblTotal = 0;

            DataTable dtResultado = new DataTable();
            //OracleDataAdapter da = new OracleDataAdapter();
            //OracleCommand cmd = new OracleCommand();
            //try
            //{
            //    sqlConn = new OracleConnectionParques().GenerarConexion();
            //    cmd.Connection = sqlConn;
            //    sqlConn.Open();

            //    cmd.InitialLONGFetchSize = 1000;
            //    cmd.CommandText = "sp_validarContratistasCAR";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("p_documentoIn", OracleDbType.Char).Value = documento;
            //    cmd.Parameters.Add("pcursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            //    da.SelectCommand = cmd;
            //    da.Fill(dtResultado);
            //    sqlConn.Close();
            //    dblTotal = (double)dtResultado.Rows.Count;

            //}
            //catch (Exception ex)
            //{
            //    string Mensaje = ex.ToString();
            //    sqlConn.Close();
            //}

            return dblTotal;
        }
    }
}
