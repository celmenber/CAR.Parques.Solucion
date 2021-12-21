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

    [Export(typeof(IEstadoReservaManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EstadoReservaManager : ManagerBase, IEstadoReservaManager
    {
        private readonly ITransaccionEstadoReservaQO iTransaccionEstadoReservaRepository;

        [ImportingConstructor]
        public EstadoReservaManager(ILogManager logManagerRepository,
                                    ITransaccionEstadoReservaQO transaccionEstadoReservaRepository) : 
            base(logManagerRepository, "estado reserva")
        {
            iTransaccionEstadoReservaRepository = transaccionEstadoReservaRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(EstadoReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionEstadoReservaRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<EstadoReservaEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionEstadoReservaRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new EstadoReservaEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<EstadoReservaEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionEstadoReservaRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<EstadoReservaEO>)new List<EstadoReservaEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(EstadoReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionEstadoReservaRepository.Crear(entidad);
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
                var resultado = iTransaccionEstadoReservaRepository.Eliminar(id);
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
