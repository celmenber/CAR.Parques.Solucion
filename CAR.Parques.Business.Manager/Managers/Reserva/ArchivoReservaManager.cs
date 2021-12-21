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

    [Export(typeof(IArchivoReservaManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ArchivoReservaManager : ManagerBase, IArchivoReservaManager
    {
        private readonly ITransaccionArchivoReservaQO iTransaccionArchivoReservaRepository;

        [ImportingConstructor]
        public ArchivoReservaManager(ILogManager logManagerRepository,
                                    ITransaccionArchivoReservaQO transaccionArchivoReservaRepository) : 
            base(logManagerRepository, "archivo reserva")
        {
            iTransaccionArchivoReservaRepository = transaccionArchivoReservaRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(ArchivoReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionArchivoReservaRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<ArchivoReservaEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionArchivoReservaRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ArchivoReservaEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ArchivoReservaEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionArchivoReservaRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ArchivoReservaEO>)new List<ArchivoReservaEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(ArchivoReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionArchivoReservaRepository.Crear(entidad);
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
                var resultado = iTransaccionArchivoReservaRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<ArchivoReservaEO> ConsultarArchivoReserva(int reservaId)
        {
            try
            {
                var resultado = iTransaccionArchivoReservaRepository.ConsultarArchivoReserva(reservaId);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ArchivoReservaEO(), 0);
            }
        }
    }
}
