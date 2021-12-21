namespace CAR.Parques.Business.Manager.Managers.Parametricos
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Parametricos;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parametricos;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parametricos;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(ITipoModuloManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoModuloManager : ManagerBase, ITipoModuloManager
    {
        private readonly ITransaccionTipoModuloQO iTransaccionTipoModuloRepository;

        [ImportingConstructor]
        public TipoModuloManager(ILogManager logManagerRepository,
                                 ITransaccionTipoModuloQO transaccionTipoModuloRepository) : 
            base(logManagerRepository, "tipo modulo")
        {
            iTransaccionTipoModuloRepository = transaccionTipoModuloRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(TipoModuloEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoModuloRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<TipoModuloEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoModuloRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new TipoModuloEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoModuloEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionTipoModuloRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoModuloEO>)new List<TipoModuloEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(TipoModuloEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoModuloRepository.Crear(entidad);
                this.RegistrarExtisoLogTransaccion("Creación ", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new int(), 0);
            }
        }

        public ResultadoEjecucion<bool> Eliminar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoModuloRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }
    }
}
