namespace CAR.Parques.Data.DataTransferObjects.DTO.Log
{
    public class LogSistemaDTO
    {
        public int LogSistemaId { get; set; }
        public int UsuarioId { get; set; }
        public int MenuId { get; set; }
        public bool ResultadoExitoso { get; set; }
        public string Observacion { get; set; }
        public string DetalleEjecucion { get; set; }
        public string DatosEntrada { get; set; }
        public string DatosSalida { get; set; }
        public string FechaEvento { get; set; }
    }
}
