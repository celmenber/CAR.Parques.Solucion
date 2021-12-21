namespace CAR.Parques.Common.Models.Modelos.Parques
{
    using System.Collections.Generic;

    public class ParqueInformacionModel : ParqueDetalleModel
    {
        public IEnumerable<InformacionParqueModel> ListadoSeccioneInformacion { get; set; }
    }
}
