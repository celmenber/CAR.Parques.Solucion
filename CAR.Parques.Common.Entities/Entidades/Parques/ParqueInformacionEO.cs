namespace CAR.Parques.Common.Entities.Entidades.Parques
{
    using System.Collections.Generic;

    public class ParqueInformacionEO : ParqueDetalleEO
    {
        public IEnumerable<InformacionParqueEO> ListadoSeccioneInformacion { get; set; }
    }
}
