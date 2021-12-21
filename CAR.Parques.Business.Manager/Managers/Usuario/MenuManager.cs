namespace CAR.Parques.Business.Manager.Managers.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Usuario;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IMenuManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuManager : ManagerBase, IMenuManager
    {
        private readonly ITransaccionMenuQO iTransaccionMenuRepository;

        [ImportingConstructor]
        public MenuManager(ILogManager logManagerRepository,
                           ITransaccionMenuQO transaccionMenuRepository) : 
            base(logManagerRepository, "menú")
        {
            iTransaccionMenuRepository = transaccionMenuRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(MenuEO entidad)
        {
            try
            {
                var resultado = iTransaccionMenuRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<MenuEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionMenuRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new MenuEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<MenuEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionMenuRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<MenuEO>)new List<MenuEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(MenuEO entidad)
        {
            try
            {
                var resultado = iTransaccionMenuRepository.Crear(entidad);
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
                var resultado = iTransaccionMenuRepository.Eliminar(id);
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
