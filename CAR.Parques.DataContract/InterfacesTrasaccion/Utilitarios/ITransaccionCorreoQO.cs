namespace CAR.Parques.DataContract.InterfacesTrasaccion.Utilitarios
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Utilidades;
    using CAR.Parques.Data.DataTransferObjects.DTO.Utilitarios;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;

    public interface ITransaccionCorreoQO : ITransaccionBaseQO<PlantillasCorreoEO, PlantillasCorreoDTO>
    {
        ResultadoEjecucion<PlantillasCorreoEO> ConsultarPlantillaCorreo(string nombrePlantilla);
    }
}
