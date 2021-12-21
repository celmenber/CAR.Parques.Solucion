namespace CAR.Parques.Data.ObjetosTransaccion.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Data.Adaptadores;
    using CAR.Parques.Data.Context;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Base;

    public class TransaccionBaseQO<T, K> : ITransaccionBaseQO<T, K> where T : class where K : class
    {
        public AppParquesContext context;

        public ResultadoEjecucion<bool> Actualizar(T entidad)
        {
            ResultadoEjecucion<bool> resultado = new ResultadoEjecucion<bool>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var entidadData = ConfiguracionDataMapper.GetInstance.To<T, K>(entidad);
                    object valorBusqueda = ObtenerValorPrincipalBusqueda(entidadData);
                    var resultadoBusqueda = context.Set<K>().Find(valorBusqueda);
                    if (resultadoBusqueda != null)
                    {
                        context.Entry(resultadoBusqueda).CurrentValues.SetValues(entidadData);
                        context.SaveChanges();
                        resultado.Entidad = true;
                    }
                    else
                    {
                        resultado.Entidad = false;
                        resultado.Codigo = 0;
                        resultado.Descripcion = "El registro no existe en la base de datos.";
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "ERROR: " + ex.Message;
                resultado.Entidad = false;
                return resultado;
            }
        }

        public ResultadoEjecucion<T> Consultar(int id)
        {
            ResultadoEjecucion<T> resultado = new ResultadoEjecucion<T>();
            try
            {
                using (context = new AppParquesContext())
                {
                    resultado.Entidad =
                        ConfiguracionDataMapper.GetInstance.To<K, T>(context.Set<K>().Find(id));
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "ERROR: " + ex.Message;
                return resultado;
            }
        }

        public ResultadoEjecucion<IEnumerable<T>> ConsultarTodos()
        {
            ResultadoEjecucion<IEnumerable<T>> resultado = new ResultadoEjecucion<IEnumerable<T>>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var resultadoConsulta = (from e in context.Set<K>()
                                            select e).ToList();
                    resultado.Entidad = 
                        ConfiguracionDataMapper.GetInstance.ToListTo<K, T>(resultadoConsulta);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "ERROR: " + ex.Message;
                return resultado;
            }
        }

        public ResultadoEjecucion<int> Crear(T entidad)
        {
            ResultadoEjecucion<int> resultado = new ResultadoEjecucion<int>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var entidadData = ConfiguracionDataMapper.GetInstance.To<T, K>(entidad);
                    context.Set<K>().Add(entidadData);
                    context.SaveChanges();
                    int codigo = Convert.ToInt32(ObtenerValorPrincipalBusqueda(entidadData));
                    resultado.Entidad = codigo;
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "ERROR: " + ex.Message;
                resultado.Entidad = 0;
                return resultado;
            }
        }

        private object ObtenerValorPrincipalBusqueda(K entidadData)
        {
            var objectSet = ObtenerLlavePrimaria();
            var valorBusqueda = ObtenerValorLlavePrimaria(entidadData, objectSet);
            return valorBusqueda;
        }

        private ReadOnlyMetadataCollection<EdmMember> ObtenerLlavePrimaria()
        {
            return ((IObjectContextAdapter)context)
                .ObjectContext.CreateObjectSet<K>().EntitySet
                .ElementType.KeyMembers;
        }

        private static object ObtenerValorLlavePrimaria(K entidadData, ReadOnlyMetadataCollection<EdmMember> objectSet)
        {
            return entidadData.GetType().GetProperty(
                                        objectSet.FirstOrDefault().Name).GetValue(entidadData);
        }

        public ResultadoEjecucion<bool> Eliminar(int id)
        {
            ResultadoEjecucion<bool> resultado = new ResultadoEjecucion<bool>();
            try
            {
                using (context = new AppParquesContext())
                {
                    var entidadConsulta = context.Set<K>().Find(id);
                    if (entidadConsulta != null)
                    {
                        context.Set<K>().Remove(entidadConsulta);
                        context.SaveChanges();
                        resultado.Entidad = true;
                    }
                    else
                    {
                        resultado.Entidad = false;
                        resultado.Codigo = 0;
                        resultado.Descripcion = "El registro no existe en la base de datos.";
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion = "ERROR: " + ex.Message;
                resultado.Entidad = false;
                return resultado;
            }
        }
    }
}
