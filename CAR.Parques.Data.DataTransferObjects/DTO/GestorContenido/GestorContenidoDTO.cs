namespace CAR.Parques.Data.DataTransferObjects.DTO.GestorContenido
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class GestorContenidoDTO
    {
        [Key]
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
