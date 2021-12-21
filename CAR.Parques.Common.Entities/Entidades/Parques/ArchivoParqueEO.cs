namespace CAR.Parques.Common.Entities.Entidades.Parques
{
    public class ArchivoParqueEO
    {
        public int ArchivoParqueId { get; set; }
        public int TipoArchivoId { get; set; }
        public string TituloArchivParque { get; set; }
        public string ObservacionArchivoParque { get; set; }
        public string RutaArchivoParque { get; set; }
        public int Orden { get; set; }
        public int ParqueId { get; set; }
        public byte[] ByteArchivo { get; set; }
    }
}
