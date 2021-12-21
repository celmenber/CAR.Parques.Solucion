namespace CAR.Parques.Business.Manager.Managers.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Reserva;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IDetalleReservaManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DetalleReservaManager : ManagerBase, IDetalleReservaManager
    {
        private readonly ITransaccionDetalleReservaQO iTransaccionDetalleReservaRepository;

        [ImportingConstructor]
        public DetalleReservaManager(ILogManager logManagerRepository,
                                     ITransaccionDetalleReservaQO transaccionDetalleReservaRepository) :
            base(logManagerRepository, "detalle reserva")
        {
            iTransaccionDetalleReservaRepository = transaccionDetalleReservaRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(DetalleReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionDetalleReservaRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<DetalleReservaEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionDetalleReservaRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new DetalleReservaEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<DetalleReservaEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionDetalleReservaRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<DetalleReservaEO>)new List<DetalleReservaEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(DetalleReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionDetalleReservaRepository.Crear(entidad);
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
                var resultado = iTransaccionDetalleReservaRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }
        public ResultadoEjecucion<int> ValidarPreReserva(DetalleReservaEO detalleReserva)
        {
            try
            {
                var resultado = iTransaccionDetalleReservaRepository.ValidarPreReserva(detalleReserva);
                this.RegistrarExtisoLogTransaccion("Validación", true);
                return resultado;
            }
            catch (Exception ex)
            {

                return this.RegistrarLogExepcionNoEsperada(ex, new int(), 0);
            }
        }
    }
}
