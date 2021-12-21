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

    [Export(typeof(IBitacoraReservaManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BitacoraReservaManager : ManagerBase, IBitacoraReservaManager
    {
        private readonly ITransaccionBitacoraReservaQO iTransaccionBitacoraReservaRepository;

        [ImportingConstructor]
        public BitacoraReservaManager(ILogManager logManagerRepository,
                                      ITransaccionBitacoraReservaQO transaccionBitacoraReservaRepository) : 
            base(logManagerRepository, "bitacora reserva")
        {
            iTransaccionBitacoraReservaRepository = transaccionBitacoraReservaRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(BitacoraReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionBitacoraReservaRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<BitacoraReservaEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionBitacoraReservaRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new BitacoraReservaEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<BitacoraReservaEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionBitacoraReservaRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<BitacoraReservaEO>)new List<BitacoraReservaEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(BitacoraReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionBitacoraReservaRepository.Crear(entidad);
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
                var resultado = iTransaccionBitacoraReservaRepository.Eliminar(id);
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
