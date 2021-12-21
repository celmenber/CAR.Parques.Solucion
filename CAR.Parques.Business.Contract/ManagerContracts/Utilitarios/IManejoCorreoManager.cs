namespace CAR.Parques.Business.Contract.ManagerContracts.Utilitarios
{
    using CAR.Parques.Business.Contract.ManagerContracts.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Utilidades;

    public interface IManejoCorreoManager : IBaseAccionManager<PlantillasCorreoEO>
    {
        ResultadoEjecucion<PlantillasCorreoEO> ConsultarCorreoXNombre(string nombreCorreo);
        ResultadoEjecucion<string> EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtml);
    }
}
