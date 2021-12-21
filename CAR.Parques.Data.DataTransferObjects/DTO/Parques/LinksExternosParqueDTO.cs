namespace CAR.Parques.Data.DataTransferObjects.DTO.Parques
{
    using System.ComponentModel.DataAnnotations;

    public class LinksExternosParqueDTO
    {
        [Key]
        public int LinkId { get; set; }
        public string Titulo { get; set; }
        public string DescripcionCorta { get; set; }
        public string LinkExterno { get; set; }
        public string Imagen { get; set; }
        public int InformacionId { get; set; }
    }
}
