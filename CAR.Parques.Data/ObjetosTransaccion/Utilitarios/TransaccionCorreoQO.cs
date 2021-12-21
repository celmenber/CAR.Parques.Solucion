namespace CAR.Parques.Data.ObjetosTransaccion.Utilitarios
{
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Utilidades;
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Utilitarios;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Utilitarios;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionCorreoQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionCorreoQO : TransaccionBaseQO<PlantillasCorreoEO, PlantillasCorreoDTO>, ITransaccionCorreoQO
    {
        public ResultadoEjecucion<PlantillasCorreoEO> ConsultarPlantillaCorreo(string nombrePlantilla)
        {
            ResultadoEjecucion<PlantillasCorreoEO> correoConsulta = new ResultadoEjecucion<PlantillasCorreoEO>();
            using (context = new AppParquesContext())
            {
                var correo = (from c in context.PlantillaCorreoSet
                              where c.NombreCorreo == nombrePlantilla
                              select new PlantillasCorreoEO
                              {
                                  CorreoId = c.CorreoId,
                                  NombreCorreo = c.NombreCorreo,
                                  DescripcionCorreo = c.DescripcionCorreo,
                                  Asunto = c.Asunto,
                                  CuerpoCorreo = c.CuerpoCorreo,
                                  EsHtml = c.EsHtml
                              }).FirstOrDefault();

                correoConsulta.Entidad = correo;
            }

            return correoConsulta;
        }
    }
}
