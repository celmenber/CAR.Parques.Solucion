namespace CAR.Parques.Common.Entities.Entidades.Base
{
    public class EntidadBase
    {
        public bool ProcesoExitoso { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public EntidadBase()
        {
            ProcesoExitoso = true;
            Codigo = 1;
            Descripcion = "Proceso Exitoso.";
        }
    }
}
