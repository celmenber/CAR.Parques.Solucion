namespace CAR.Parques.Data.ObjetosTransaccion.Parque
{
    using CAR.Parques.Data.Context;
    using CAR.Parques.Data.DataTransferObjects.DTO.Parques;
    using CAR.Parques.Data.ObjetosTransaccion.Base;
    using Common.Entities.Entidades.Base;
    using Common.Entities.Entidades.Parques;
    using DataContract.InterfacesTrasaccion.Parque;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(ITransaccionParqueQO))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TransaccionParqueQO : TransaccionBaseQO<ParqueEO, ParqueDTO>, ITransaccionParqueQO
    {
        public ResultadoEjecucion<ParqueDetalleEO> ConsultarParquesDetalleXId(int parqueId)
        {
            ResultadoEjecucion<ParqueDetalleEO> resultado = new ResultadoEjecucion<ParqueDetalleEO>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var parque = (from p in context.ParqueSet
                                  join m in context.MunicipioSet on p.MunicipioId equals m.MunicipioId
                                  join d in context.DepartamentoSet on m.DepartamentoId equals d.DepartamentoId
                                  where p.ParqueId == parqueId
                                  select new ParqueDetalleEO
                                  {
                                      Color = p.Color,
                                      Activo = p.Activo,
                                      Direccion = p.Direccion,
                                      InicialesParque = p.InicialesParque,
                                      NombreParque = p.NombreParque,
                                      Observacion = p.Observacion,
                                      ParqueId = p.ParqueId,
                                      Telefono = p.Telefono,
                                      MunicipioId = m.MunicipioId,
                                      NombreMunicipio = m.NombreMunicipio,
                                      DepartamentoId = d.DepartamentoId,
                                      NombreDepartamento = d.NombreDepartamento
                                  }).FirstOrDefault();
                    resultado.Entidad = parque;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error Consulta Parque Detalle X Id: {ex.Message}";
            }

            return resultado;
        }

        public ResultadoEjecucion<ParqueInformacionEO> ConsultarParquesInformacionXId(int parqueId)
        {
            ResultadoEjecucion<ParqueInformacionEO> resultado = new ResultadoEjecucion<ParqueInformacionEO>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var parque = (from p in context.ParqueSet
                                  join m in context.MunicipioSet on p.MunicipioId equals m.MunicipioId
                                  join d in context.DepartamentoSet on m.DepartamentoId equals d.DepartamentoId
                                  where p.ParqueId == parqueId
                                  select new ParqueInformacionEO
                                  {
                                      Color = p.Color,
                                      Activo = p.Activo,
                                      Direccion = p.Direccion,
                                      InicialesParque = p.InicialesParque,
                                      NombreParque = p.NombreParque,
                                      Observacion = p.Observacion,
                                      ParqueId = p.ParqueId,
                                      Telefono = p.Telefono,
                                      MunicipioId = m.MunicipioId,
                                      NombreMunicipio = m.NombreMunicipio,
                                      DepartamentoId = d.DepartamentoId,
                                      NombreDepartamento = d.NombreDepartamento,
                                      LinkUbicacionGoogle = p.LinkUbicacionGoogle
                                  }).FirstOrDefault();
                    resultado.Entidad = parque;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error Consulta Parque Información X Id: {ex.Message}";
            }

            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ParqueEO>> ConsultarTodosParques()
        {
            return new ResultadoEjecucion<IEnumerable<ParqueEO>>
            {
                Codigo = 1,
                Descripcion = "Resultado Parques",
                Entidad = new List<ParqueEO>
                {
                    new ParqueEO
                    {
                        NombreParque = "Parque Prueba Update",
                    Observacion = "Prueba parque",
                    Activo = false,
                    Direccion = "Cr 234",
                    InicialesParque = "HH",
                    MunicipioId = 1,
                    Telefono ="22222",
                    ParqueId = 2
                    },
                    new ParqueEO
                    {
                        NombreParque = "Parque Prueba Update",
                    Observacion = "Prueba parque",
                    Activo = false,
                    Direccion = "Cr 234",
                    InicialesParque = "HH",
                    MunicipioId = 1,
                    Telefono ="22222",
                    ParqueId = 2
                    },
                    new ParqueEO
                    {
                        NombreParque = "Parque Prueba Update",
                    Observacion = "Prueba parque",
                    Activo = false,
                    Direccion = "Cr 234",
                    InicialesParque = "HH",
                    MunicipioId = 1,
                    Telefono ="22222",
                    ParqueId = 2
                    }
                }
            };
        }

        public ResultadoEjecucion<IEnumerable<ParqueDetalleEO>> ConsultarTodosParquesDetalle()
        {
            ResultadoEjecucion<IEnumerable<ParqueDetalleEO>> resultado = 
                new ResultadoEjecucion<IEnumerable<ParqueDetalleEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var parqueList = (from p in context.ParqueSet
                                      join m in context.MunicipioSet on p.MunicipioId equals m.MunicipioId
                                      join d in context.DepartamentoSet on m.DepartamentoId equals d.DepartamentoId
                                      select new ParqueDetalleEO
                                      {
                                          Color = p.Color,
                                          Activo = p.Activo,
                                          Direccion = p.Direccion,
                                          InicialesParque = p.InicialesParque,
                                          NombreParque = p.NombreParque,
                                          Observacion = p.Observacion,
                                          ParqueId = p.ParqueId,
                                          Telefono = p.Telefono,
                                          MunicipioId = m.MunicipioId,
                                          NombreMunicipio = m.NombreMunicipio,
                                          DepartamentoId = d.DepartamentoId,
                                          NombreDepartamento = d.NombreDepartamento,
                                          LinkUbicacionGoogle = p.LinkUbicacionGoogle
                                      }).ToList();
                    resultado.Entidad = parqueList;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error Detalle parque. {ex.Message}";
            }
            return resultado;
        }

        public ResultadoEjecucion<IEnumerable<ParqueInformacionEO>> ConsultarTodosParquesInformacionDetalle()
        {
            ResultadoEjecucion<IEnumerable<ParqueInformacionEO>> resultado =
                new ResultadoEjecucion<IEnumerable<ParqueInformacionEO>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var parqueList = (from p in context.ParqueSet
                                      join m in context.MunicipioSet on p.MunicipioId equals m.MunicipioId
                                      join d in context.DepartamentoSet on m.DepartamentoId equals d.DepartamentoId
                                      select new ParqueInformacionEO
                                      {
                                          Color = p.Color,
                                          Activo = p.Activo,
                                          Direccion = p.Direccion,
                                          InicialesParque = p.InicialesParque,
                                          NombreParque = p.NombreParque,
                                          Observacion = p.Observacion,
                                          ParqueId = p.ParqueId,
                                          Telefono = p.Telefono,
                                          MunicipioId = m.MunicipioId,
                                          NombreMunicipio = m.NombreMunicipio,
                                          DepartamentoId = d.DepartamentoId,
                                          NombreDepartamento = d.NombreDepartamento,
                                          LinkUbicacionGoogle = p.LinkUbicacionGoogle,
                                          ListadoSeccioneInformacion = (from i in context.InformacionParqueSet
                                                                        where i.ParqueId == p.ParqueId
                                                                        select new InformacionParqueLinksEO {
                                                                            Alias = i.Alias,
                                                                            Cuerpo = i.Cuerpo,
                                                                            EsFijo = i.EsFijo,
                                                                            EsUbicacion = i.EsUbicacion,
                                                                            Hover = i.Hover,
                                                                            ImagenSeccion = i.ImagenSeccion,
                                                                            InformacionId = i.InformacionId,
                                                                            Nombre = i.Nombre,
                                                                            ParqueId = i.ParqueId,
                                                                            ListadoLinksExternos = (from l in context.LinksExternosParqueSet
                                                                                                    where l.InformacionId == i.InformacionId
                                                                                                    select new LinksExternosParqueEO
                                                                                                    {
                                                                                                        InformacionId = l.InformacionId,
                                                                                                        DescripcionCorta = l.DescripcionCorta,
                                                                                                        Imagen = l.Imagen,
                                                                                                        LinkExterno = l.LinkExterno,
                                                                                                        LinkId = l.LinkId,
                                                                                                        Titulo = l.Titulo
                                                                                                    })
                                                                        })
                                          
                                      }).ToList();
                    resultado.Entidad = parqueList;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = $"Error Detalle Información parque. {ex.Message}";
            }
            return resultado;
        }
    }
}
