namespace CAR.Parques.Common.Core.Utilidades
{
    using System.Configuration;

    public static class ConfiguracionSitio
    {
        public static string ObtenerValorConfiguracion(string llave)
        {
            AppSettingsReader reader = new AppSettingsReader();
            string value = reader.GetValue(llave, typeof(string)).ToString();
            return value;
        }
    }
}
