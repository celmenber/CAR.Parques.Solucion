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

    [Export(typeof(IArchivoParqueManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ArchivoParqueManager : ManagerBase, IArchivoParqueManager
    {
        private readonly ITransaccionArchivoParqueQO iTransaccionArchivoParqueRepository;

        [ImportingConstructor]
        public ArchivoParqueManager(ILogManager logManagerRepository,
                                    ITransaccionArchivoParqueQO transaccionArchivoParqueRepository) : 
            base(logManagerRepository, "archivo parque")
        {
            iTransaccionArchivoParqueRepository = transaccionArchivoParqueRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(ArchivoParqueEO entidad)
        {
            try
            {
                var resultado = iTransaccionArchivoParqueRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<ArchivoParqueEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionArchivoParqueRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ArchivoParqueEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ArchivoParqueEO>> ConsultarListadoArchivosParque(int tipoArchivoId, int parqueId)
        {
            try
            {
                var resultado = iTransaccionArchivoParqueRepository.ConsultarListadoArchivosParque(tipoArchivoId, parqueId);
                this.RegistrarExtisoLogTransaccion("Consultar Archivos Parque", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ArchivoParqueEO>)new List<ArchivoParqueEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoArchivoEO>> ConsultarTiposArchivo()
        {
            try
            {
                var resultado = iTransaccionArchivoParqueRepository.ConsultarTiposArchivo();
                this.RegistrarExtisoLogTransaccion("Consultar Tipos archivo", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoArchivoEO>)new List<TipoArchivoEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ArchivoParqueEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionArchivoParqueRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ArchivoParqueEO>)new List<ArchivoParqueEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(ArchivoParqueEO entidad)
        {
            try
            {
                var resultado = iTransaccionArchivoParqueRepository.Crear(entidad);
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
                var resultado = iTransaccionArchivoParqueRepository.Eliminar(id);
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
