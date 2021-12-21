namespace CAR.Parques.Common.Models.Modelos.Usuario
{
    public class MenuModel
    {
        public int MenuId { get; set; }
        public string NombreMenu { get; set; }
        public int TipoModuloId { get; set; }
        public string RutaMenu { get; set; }
        public int OrdenMenu { get; set; }
        public string DescripcionMenu { get; set; }
        public int MenuPadreId { get; set; }
    }
}
