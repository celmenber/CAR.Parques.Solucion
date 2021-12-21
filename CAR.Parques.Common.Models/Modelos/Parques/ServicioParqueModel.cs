namespace CAR.Parques.Common.Models.Modelos.Parques
{
    public class ServicioParqueModel
    {
        public int ServicioParqueId { get; set; }
        public string NombreServicioParque { get; set; }
        public string DescripcionServicioParque { get; set; }
        public string FechaCreacion { get; set; }
        public int CreadoPorUsuarioId { get; set; }
        public decimal PrecioServicio { get; set; }
        public decimal ImpuestoServicio { get; set; }
        public int ParqueId { get; set; }
        public int EstadoServicioId { get; set; }
        public int TipoServicioId { get; set; }
    }
}
