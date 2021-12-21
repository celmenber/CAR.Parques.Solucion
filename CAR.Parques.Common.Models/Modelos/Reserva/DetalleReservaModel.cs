namespace CAR.Parques.Common.Models.Modelos.Reserva
{
    using System;

    public class DetalleReservaModel
    {
        public int DetalleReservaId { get; set; }
        public int ReservaId { get; set; }
        public int ServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioTotalServicio { get; set; }
        public decimal PrecioTotalDescuento { get; set; }
        public bool AdquirioServicio { get; set; }
        public int Cantidad { get; set; }
    }

    public class DetalleReservaModelFecha
    {
        public int DetalleReservaId { get; set; }
        public int ReservaId { get; set; }
        public int ServicioId { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal PrecioTotalServicio { get; set; }
        public decimal PrecioTotalDescuento { get; set; }
        public bool AdquirioServicio { get; set; }
        public int Cantidad { get; set; }
    }
}
