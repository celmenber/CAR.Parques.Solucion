namespace CAR.Parques.Common.Core.Extenciones
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public static class TypeExtension
    {
        public static bool IsNull<T>(this T instancia)
        {
            return instancia == null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> instancia)
        {
            return instancia.IsNull() || !instancia.Any();
        }

        public static string ObtenerElementosString(this string datos, char separador, int indice)
        {
            var arrayDatos = datos?.Split(separador);
            return datos?.Length > indice ? arrayDatos?[indice] : string.Empty;
        }

        public static string SerializarObjeto<T>(T aSerializar)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(aSerializar.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, aSerializar);
                return textWriter.ToString();
            }
        }
    }
}
