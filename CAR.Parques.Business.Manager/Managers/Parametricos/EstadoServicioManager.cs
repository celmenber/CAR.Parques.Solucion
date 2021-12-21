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

    [Export(typeof(IEstadoServicioManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EstadoServicioManager : ManagerBase, IEstadoServicioManager
    {
        private readonly ITransaccionEstadoServicioQO iTransaccionEstadoServicioRepository;

        [ImportingConstructor]
        public EstadoServicioManager(ILogManager logManagerRepository,
                                     ITransaccionEstadoServicioQO transaccionEstadoServicioRepository) : 
            base(logManagerRepository, "estado servicio")
        {
            iTransaccionEstadoServicioRepository = transaccionEstadoServicioRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(EstadoServicioEO entidad)
        {
            try
            {
                var resultado = iTransaccionEstadoServicioRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<EstadoServicioEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionEstadoServicioRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new EstadoServicioEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<EstadoServicioEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionEstadoServicioRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<EstadoServicioEO>)new List<EstadoServicioEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(EstadoServicioEO entidad)
        {
            try
            {
                var resultado = iTransaccionEstadoServicioRepository.Crear(entidad);
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
                var resultado = iTransaccionEstadoServicioRepository.Eliminar(id);
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
