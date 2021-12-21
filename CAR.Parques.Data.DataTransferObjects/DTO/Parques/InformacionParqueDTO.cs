using System.ComponentModel.DataAnnotations;

namespace CAR.Parques.Data.DataTransferObjects.DTO.Parques
{
    public class InformacionParqueDTO
    {
        [Key]
        public int InformacionId { get; set; }
        public int ParqueId { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public string ImagenSeccion { get; set; }
        public string Cuerpo { get; set; }
        public bool EsFijo { get; set; }
        public bool EsUbicacion { get; set; }
        public bool Hover { get; set; }
    }
}
