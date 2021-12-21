namespace CAR.Parques.Data.DataTransferObjects.DTO.Parametricos
{
    using System.ComponentModel.DataAnnotations;

    public class DepartamentoDTO
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }
        public string Observacion { get; set; }
    }
}
