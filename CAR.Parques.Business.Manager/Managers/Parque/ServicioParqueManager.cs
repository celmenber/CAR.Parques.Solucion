namespace CAR.Parques.Business.Manager.Managers.Parque
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.ParqueContract;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parque;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IServicioParqueManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ServicioParqueManager : ManagerBase, IServicioParqueManager
    {
        private readonly ITransaccionServicioParqueQO iTransaccionServicioParqueRepository;

        [ImportingConstructor]
        public ServicioParqueManager(ILogManager logManagerRepository,
                                     ITransaccionServicioParqueQO transaccionServicioParqueRepository) : 
            base(logManagerRepository, "servicio parque")
        {
            iTransaccionServicioParqueRepository = transaccionServicioParqueRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(ServicioParqueEO entidad)
        {
            try
            {
                var resultado = iTransaccionServicioParqueRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<ServicioParqueEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionServicioParqueRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ServicioParqueEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ServicioParqueDetalleEO>> ConsultarServiciosParque(int parqueId)
        {
            try
            {
                var resultado = iTransaccionServicioParqueRepository.ConsultarServiciosParque(parqueId);
                this.RegistrarExtisoLogTransaccion("Consulta Servicios Parque ", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ServicioParqueDetalleEO>)new List<ServicioParqueDetalleEO>(), 0);
            }
        }

        public ResultadoEjecucion<ServicioParqueDetalleEO> ConsultarServiciosParqueDetalleXId(int servicioParqueId)
        {
            try
            {
                var resultado = iTransaccionServicioParqueRepository.ConsultarServicioParquesDetalleXId(servicioParqueId);
                this.RegistrarExtisoLogTransaccion("Consulta Servicios Parque Detalle ", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ServicioParqueDetalleEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ServicioParqueEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionServicioParqueRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ServicioParqueEO>)new List<ServicioParqueEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(ServicioParqueEO entidad)
        {
            try
            {
                var resultado = iTransaccionServicioParqueRepository.Crear(entidad);
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
                var resultado = iTransaccionServicioParqueRepository.Eliminar(id);
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
