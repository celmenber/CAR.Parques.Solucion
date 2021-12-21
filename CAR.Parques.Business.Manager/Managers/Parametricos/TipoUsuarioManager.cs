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

    [Export(typeof(ITipoUsuarioManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoUsuarioManager : ManagerBase, ITipoUsuarioManager
    {
        private readonly ITransaccionTipoUsuarioQO iTransaccionTipoUsuarioRepository;

        [ImportingConstructor]
        public TipoUsuarioManager(ILogManager logManagerRepository,
                                  ITransaccionTipoUsuarioQO transaccionTipoUsuarioRepository) : 
            base(logManagerRepository, "tipo usuario")
        {
            iTransaccionTipoUsuarioRepository = transaccionTipoUsuarioRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(TipoUsuarioEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoUsuarioRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<TipoUsuarioEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoUsuarioRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new TipoUsuarioEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoUsuarioEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionTipoUsuarioRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoUsuarioEO>)new List<TipoUsuarioEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(TipoUsuarioEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoUsuarioRepository.Crear(entidad);
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
                var resultado = iTransaccionTipoUsuarioRepository.Eliminar(id);
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
