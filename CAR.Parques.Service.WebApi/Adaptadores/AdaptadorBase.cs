namespace CAR.Parques.Service.WebApi.Adaptadores
{
    using AutoMapper;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Models.Modelos.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AdaptadorBase : Profile
    {
        public AdaptadorBase()
        {
            this.CrearMapeoIndicadoresRespuesta();
        }

        public void CrearMapeoIndicadoresRespuesta()
        {
            CreateMap<EntidadBase, ModeloBase>().ReverseMap();
        }
    }
}