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

    [Export(typeof(ITipoDocumentoManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoDocumentoManager : ManagerBase, ITipoDocumentoManager
    {
        private readonly ITransaccionTipoDocumentoQO iTransaccionTipoDocumentoRepository;

        [ImportingConstructor]
        public TipoDocumentoManager(ILogManager logManagerRepository, 
                                    ITransaccionTipoDocumentoQO transaccionTipoDocumentoRepository) : 
            base(logManagerRepository, "tipo documento")
        {
            iTransaccionTipoDocumentoRepository = transaccionTipoDocumentoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(TipoDocumentoEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoDocumentoRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<TipoDocumentoEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoDocumentoRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new TipoDocumentoEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoDocumentoEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionTipoDocumentoRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoDocumentoEO>)new List<TipoDocumentoEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(TipoDocumentoEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoDocumentoRepository.Crear(entidad);
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
                var resultado = iTransaccionTipoDocumentoRepository.Eliminar(id);
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
