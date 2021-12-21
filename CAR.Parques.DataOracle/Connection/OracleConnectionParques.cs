namespace CAR.Parques.DataOracle.Connection
{
    //using Oracle.DataAccess.Client;
    using System.Configuration;

    public class OracleConnectionParques
    {
        private string strConexion;

        public OracleConnectionParques()
        {
            strConexion = ConfigurationManager.ConnectionStrings["ConStringBDOracle"].ConnectionString;
        }

        //public OracleConnection GenerarConexion()
        //{
        //    OracleConnection sqlConn;
        //    sqlConn = new OracleConnection(strConexion);
        //    return sqlConn;
        //}
    }
}
