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

    [Export(typeof(IDepartamentoManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DepartamentoManager : ManagerBase, IDepartamentoManager
    {
        private readonly ITransaccionDepartamentoQO iTransaccionDepartamentoRepository;

        [ImportingConstructor]
        public DepartamentoManager(ILogManager logManagerRepository, 
                                   ITransaccionDepartamentoQO transaccionDepartamentoRepository) : 
            base(logManagerRepository, "Departamento")
        {
            iTransaccionDepartamentoRepository = transaccionDepartamentoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(DepartamentoEO entidad)
        {
            try
            {
                var resultado = iTransaccionDepartamentoRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<DepartamentoEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionDepartamentoRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new DepartamentoEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<DepartamentoEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionDepartamentoRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<DepartamentoEO>)new List<DepartamentoEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(DepartamentoEO entidad)
        {
            try
            {
                var resultado = iTransaccionDepartamentoRepository.Crear(entidad);
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
                var resultado = iTransaccionDepartamentoRepository.Eliminar(id);
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
