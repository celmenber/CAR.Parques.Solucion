namespace CAR.Parques.Common.Core.BaseMapObjects
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;

    public class BaseMap
    {
        protected MapperConfiguration configuracion;

        [Obsolete]
        public T To<T>(object recurso) where T : class
        {
            if (recurso == null)
            {
                return null;
            }

            var objetivoTipo = typeof(T);
            var recursoTipo = recurso.GetType();
            var resultado = configuracion.CreateMapper().Map(recurso, recursoTipo, objetivoTipo);
            return resultado as T;
        }

        public T To<K, T>(K recurso) where T : class
        {
            var resultado = configuracion.CreateMapper().Map<K, T>(recurso);
            return resultado as T;
        }

        public IList<T> ToListTo<K, T>(IList<K> recurso) where T : class
        {
            var resultado = configuracion.CreateMapper().Map<IList<K>, IList<T>>(recurso);
            return resultado;
        }
    }
}
