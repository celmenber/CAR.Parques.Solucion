namespace CAR.Parques.Common.Models.Modelos.Base
{
    public class ResultadoEjecucionModel
    {
        public ResultadoEjecucionModel()
        {
            Codigo = 1;
            Descripcion = "Ejecución Exitosa.";
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }

    public class ResultadoEjecucionModel<T>
    {
        public ResultadoEjecucionModel()
        {
            Codigo = 1;
            Descripcion = "Ejecución Exitosa.";
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public T Entidad { get; set; }
    }
}
