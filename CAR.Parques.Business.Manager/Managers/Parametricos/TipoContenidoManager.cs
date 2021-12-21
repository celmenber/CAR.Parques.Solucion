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

    [Export(typeof(ITipoContenidoManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoContenidoManager : ManagerBase, ITipoContenidoManager
    {
        private readonly ITransaccionTipoContenidoQO iTransaccionTipoContenidoRepository;

        [ImportingConstructor]
        public TipoContenidoManager(ILogManager logManagerRepository, 
                                    ITransaccionTipoContenidoQO transaccionTipoContenidoRepository) : 
            base(logManagerRepository, "tipo contenido")
        {
            iTransaccionTipoContenidoRepository = transaccionTipoContenidoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(TipoContenidoEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoContenidoRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<TipoContenidoEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoContenidoRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new TipoContenidoEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoContenidoEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionTipoContenidoRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoContenidoEO>)new List<TipoContenidoEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(TipoContenidoEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoContenidoRepository.Crear(entidad);
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
                var resultado = iTransaccionTipoContenidoRepository.Eliminar(id);
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
