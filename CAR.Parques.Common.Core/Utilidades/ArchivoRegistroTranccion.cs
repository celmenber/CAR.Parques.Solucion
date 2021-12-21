using CAR.Parques.Common.Core.Enumerables;
namespace CAR.Parques.Common.Core.Utilidades
{
    using System;
    using System.IO;

    public static class ArchivoRegistroTranccion
    {
        public static bool EscribirArchivo(
            string nombreArchivo, bool porFecha, TipoCaracteristicaArchivoPlanoType tipo, string[] contenido)
        {
            try
            {
                #if DEBUG
                string pathRaiz = Path.Combine("D:\\",tipo.ToString());
                #else
                string pathRaiz = Path.Combine(Directory.GetCurrentDirectory(), tipo.ToString());
                #endif

                if (!Directory.Exists(pathRaiz))
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathRaiz);
                }

                if (porFecha)
                {
                    pathRaiz = Path.Combine(pathRaiz, nombreArchivo + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                }

                File.AppendAllLines(pathRaiz, contenido);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
