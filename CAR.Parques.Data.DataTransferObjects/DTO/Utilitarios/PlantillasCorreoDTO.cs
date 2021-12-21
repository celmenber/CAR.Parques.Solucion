namespace CAR.Parques.Data.DataTransferObjects.DTO.Utilitarios
{
    using System.ComponentModel.DataAnnotations;

    public class PlantillasCorreoDTO
    {
        [Key]
        public int CorreoId { get; set; }
        public string NombreCorreo { get; set; }
        public string DescripcionCorreo { get; set; }
        public string Asunto { get; set; }
        public string CuerpoCorreo { get; set; }
        public bool EsHtml { get; set; }
    }
}
