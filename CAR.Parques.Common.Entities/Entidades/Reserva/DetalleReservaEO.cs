﻿namespace CAR.Parques.Common.Entities.Entidades.Reserva
{
    using System;

    public class DetalleReservaEO
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
}
