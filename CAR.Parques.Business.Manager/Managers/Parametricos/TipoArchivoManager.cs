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

    [Export(typeof(ITipoArchivoManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoArchivoManager : ManagerBase, ITipoArchivoManager
    {
        private readonly ITransaccionTipoArchivoQO iTransaccionTipoArchivoRepository;

        [ImportingConstructor]
        public TipoArchivoManager(ILogManager logManagerRepository,
                                  ITransaccionTipoArchivoQO transaccionTipoArchivoRepository) : 
            base(logManagerRepository, "tipo archivo")
        {
            iTransaccionTipoArchivoRepository = transaccionTipoArchivoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(TipoArchivoEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoArchivoRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<TipoArchivoEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoArchivoRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new TipoArchivoEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoArchivoEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionTipoArchivoRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoArchivoEO>)new List<TipoArchivoEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(TipoArchivoEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoArchivoRepository.Crear(entidad);
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
                var resultado = iTransaccionTipoArchivoRepository.Eliminar(id);
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
