using System;

namespace CAR.Parques.Common.Models.Modelos.GestorContenido
{
    public class GestorContenidoModel
    {
        public int ContenidoId { get; set; }
        public int TipoContenidoId { get; set; }
        public string NombreContenido { get; set; }
        public string TituloContenido { get; set; }
        public string CuerpoContenido { get; set; }
        public byte[] ImagenContenido { get; set; }
        public string URLRedireccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinVigencia { get; set; }
        public bool Activo { get; set; }
    }
}
