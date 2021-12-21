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

    [Export(typeof(IMunicipioManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MunicipioManager : ManagerBase, IMunicipioManager
    {
        private readonly ITransaccionMunicipioQO iTransaccionMunicipioRepository;

        [ImportingConstructor]
        public MunicipioManager(ILogManager logManagerRepository,
                                ITransaccionMunicipioQO transaccionMunicipioRepository) : 
            base(logManagerRepository, "municipio")
        {
            iTransaccionMunicipioRepository = transaccionMunicipioRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(MunicipioEO entidad)
        {
            try
            {
                var resultado = iTransaccionMunicipioRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<MunicipioEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionMunicipioRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new MunicipioEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<MunicipioEO>> ConsultarMunicipiosXDepartamento(int departamentoId)
        {
            try
            {
                var resultado = iTransaccionMunicipioRepository.ConsultarMunicipiosXDepartamento(departamentoId);
                this.RegistrarExtisoLogTransaccion("Consulta Todos Por Departamento", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<MunicipioEO>)new List<MunicipioEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<MunicipioEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionMunicipioRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<MunicipioEO>)new List<MunicipioEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(MunicipioEO entidad)
        {
            try
            {
                var resultado = iTransaccionMunicipioRepository.Crear(entidad);
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
                var resultado = iTransaccionMunicipioRepository.Eliminar(id);
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
