namespace CAR.Parques.Common.Entities.Entidades.Base
{
    public class ResultadoEjecucion
    {
        public ResultadoEjecucion()
        {
            Codigo = 1;
            Descripcion = "Ejecución Exitosa.";
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }

    public class ResultadoEjecucion<T>
    {
        public ResultadoEjecucion()
        {
            Codigo = 1;
            Descripcion = "Ejecución Exitosa.";
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public T Entidad { get; set; }
    }
}
