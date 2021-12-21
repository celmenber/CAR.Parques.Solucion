namespace CAR.Parques.Common.Entities.Entidades.Parques
{
    using System.Collections.Generic;

    public class InformacionParqueLinksEO : InformacionParqueEO
    {
        public IEnumerable<LinksExternosParqueEO> ListadoLinksExternos { get; set; }
    }
}
