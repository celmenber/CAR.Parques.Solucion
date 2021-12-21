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

    [Export(typeof(IPerfilManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PerfilManager : ManagerBase, IPerfilManager
    {
        private readonly ITransaccionPerfilQO iTransaccionPerfilRepository;

        [ImportingConstructor]
        public PerfilManager(ILogManager logManagerRepository,
                             ITransaccionPerfilQO transaccionPerfilRepository) : 
            base(logManagerRepository, "perfil")
        {
            iTransaccionPerfilRepository = transaccionPerfilRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(PerfilEO entidad)
        {
            try
            {
                var resultado = iTransaccionPerfilRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<PerfilEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionPerfilRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new PerfilEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<PerfilEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionPerfilRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<PerfilEO>)new List<PerfilEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(PerfilEO entidad)
        {
            try
            {
                var resultado = iTransaccionPerfilRepository.Crear(entidad);
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
                var resultado = iTransaccionPerfilRepository.Eliminar(id);
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
