namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    public class DetalleServicioReservaModel : DetalleReservaModel
    {
        public string NombreServicio { get; set; }
        public string TipoServicio { get; set; }
        public string NombreParque { get; set; }
    }
}
