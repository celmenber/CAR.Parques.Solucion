namespace CAR.Parques.Common.Entities.Entidades.Parques
{
    public class ParqueEO
    {
        public int ParqueId { get; set; }
        public string NombreParque { get; set; }
        public string InicialesParque { get; set; }
        public bool Activo { get; set; }
        public string Direccion { get; set; }
        public int MunicipioId { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public string Color { get; set; }
        public string LinkUbicacionGoogle { get; set; }
    }
}
