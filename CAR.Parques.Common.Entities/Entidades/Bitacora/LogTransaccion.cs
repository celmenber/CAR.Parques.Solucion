namespace CAR.Parques.Common.Entities.Entidades.Bitacora
{
    public class LogTransaccion : DatosTransaccion
    {
        public LogTransaccion()
        {
            DetalleEjecucion = string.Empty;
        }

        public int LogSistemaId { get; set; }
        public bool ResultadoExitoso { get; set; }
        public string Observacion { get; set; }
        public string DetalleEjecucion { get; set; }
        public string DatosEntrada { get; set; }
        public string DatosSalida { get; set; }
        public string FechaEvento { get; set; }
    }
}
