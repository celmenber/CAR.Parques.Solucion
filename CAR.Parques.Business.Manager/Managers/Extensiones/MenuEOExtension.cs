using CAR.Parques.Common.Entities.Entidades.Usuario;
using System.Configuration;

namespace CAR.Parques.Business.Manager.Managers.Extensiones
{
    public static class MenuEOExtension
    {


        public static void SetPathByEnvironment(this MenuEO menu)
        {
            string environment = ConfigurationManager.AppSettings["ENVIRONMENT"];

            if (environment.ToUpper() != "PROD")
            {
                string folderRelease = ConfigurationManager.AppSettings["FOLDER_DEPLOY"];
                menu.RutaMenu = menu.RutaMenu.Replace(folderRelease, string.Empty);
            }
        }
    }
}
