namespace CAR.Parques.Common.Core.Utilidades
{
    using Common.Entities.Entidades.Base;
    using System;

    public static class ManejoResultado
    {
        public static ResultadoEjecucion<K> MapearRespuestaExepcion<K>(Exception ex, K entidad, int cod)
        {
            ResultadoEjecucion<K> resultado = new ResultadoEjecucion<K>();
            resultado.Codigo = cod;
            resultado.Descripcion = "Error : " + ex.Message;
            resultado.Entidad = entidad;
            return resultado;
        }

        public static ResultadoEjecucion<K> MapearRespuestaExepcionControlado<K>(string mensaje, K entidad, int cod)
        {
            ResultadoEjecucion<K> resultado = new ResultadoEjecucion<K>();
            resultado.Codigo = cod;
            resultado.Descripcion = mensaje;
            resultado.Entidad = entidad;
            return resultado;
        }
    }
}
