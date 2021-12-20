namespace CAR.Parques.Data.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.Bitacora;
    using CAR.Parques.Data.DataTransferObjects.DTO.Log;

    public class AdaptadorDataLog : Profile
    {
        public AdaptadorDataLog()
        {
            this.CrearMapEntidadLogTransaccionLogSistema();
        }

        private void CrearMapEntidadLogTransaccionLogSistema()
        {
            CreateMap<LogTransaccion, LogSistemaDTO>().ReverseMap();
        }
    }
}
