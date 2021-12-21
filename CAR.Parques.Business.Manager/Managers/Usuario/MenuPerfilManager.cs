namespace CAR.Parques.Business.Manager.Managers.Usuario
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Usuario;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Business.Manager.Managers.Extensiones;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Usuario;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Usuario;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    [Export(typeof(IMenuPerfilManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MenuPerfilManager : ManagerBase, IMenuPerfilManager
    {
        private readonly ITransaccionMenuPerfilQO iTransaccionMenuPerfilRepository;
        private readonly ITransaccionMenuQO iTransaccionMenuRepository;
        private readonly ITransaccionPerfilQO iTransaccionPerfilQO;

        [ImportingConstructor]
        public MenuPerfilManager(ILogManager logManagerRepository,
                                 ITransaccionMenuPerfilQO transaccionMenuPerfilRepository,
                                 ITransaccionMenuQO transaccionMenuRepository,
                                 ITransaccionPerfilQO transaccionPerfilQO) :
            base(logManagerRepository, "menu perfil")
        {
            iTransaccionMenuPerfilRepository = transaccionMenuPerfilRepository;
            iTransaccionMenuRepository = transaccionMenuRepository;
            iTransaccionPerfilQO = transaccionPerfilQO;
        }

        public ResultadoEjecucion<bool> Actualizar(MenuPerfilEO entidad)
        {
            try
            {
                var resultado = iTransaccionMenuPerfilRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<MenuPerfilEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionMenuPerfilRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new MenuPerfilEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<MenuPerfilEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionMenuPerfilRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<MenuPerfilEO>)new List<MenuPerfilEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(MenuPerfilEO entidad)
        {
            try
            {
                var resultado = iTransaccionMenuPerfilRepository.Crear(entidad);
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
                var resultado = iTransaccionMenuPerfilRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<MenuEO>> ConsultaMenuPorPerfil(int idPerfil)
        {
            try
            {
                if (idPerfil == 0)
                {
                    idPerfil = iTransaccionPerfilQO.ConsultarIdPerfilNombre("NA");
                }

                var resultado = iTransaccionMenuRepository.ConsultaMenuPorPerfil(idPerfil);
                this.RegistrarExtisoLogTransaccion("Consulta Menu Perfil", true);
                resultado.Entidad.ToList().ForEach(m => m.SetPathByEnvironment());
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<MenuEO>)new List<MenuEO>(), 0);
            }
        }
    }
}
