namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;

    public class AdaptadorDataParque : Profile
    {
        public AdaptadorDataParque()
        {
            this.CrearMapArchivoParque();
            this.CrearMapParque();
            this.CrearMapServicioParque();
            this.CrearMapInformacionParque();
            this.CrearMapLinksExternosParque();
        }

        private void CrearMapArchivoParque()
        {
            CreateMap<ArchivoParqueEO, ArchivoParqueDTO>().ReverseMap();
        }

        private void CrearMapParque()
        {
            CreateMap<ParqueEO, ParqueDTO>().ReverseMap();
        }

        private void CrearMapServicioParque()
        {
            CreateMap<ServicioParqueEO, ServicioParqueDTO>().ReverseMap();
        }

        public void CrearMapInformacionParque()
        {
            CreateMap<InformacionParqueEO, InformacionParqueDTO>().ReverseMap();
        }

        public void CrearMapLinksExternosParque()
        {
            CreateMap<LinksExternosParqueEO, LinksExternosParqueDTO>().ReverseMap();
        }
    }
}
