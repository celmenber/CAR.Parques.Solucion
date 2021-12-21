namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class MunicipioDTO
    {
        [Key]
        public int MunicipioId { get; set; }
        public string NombreMunicipio { get; set; }
        public string Observacion { get; set; }
        public int DepartamentoId { get; set; }
    }
}
