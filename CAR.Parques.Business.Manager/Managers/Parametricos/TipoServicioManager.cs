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

    [Export(typeof(ITipoServicioManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TipoServicioManager : ManagerBase, ITipoServicioManager
    {
        private readonly ITransaccionTipoServicioQO iTransaccionTipoServicioRespository;

        [ImportingConstructor]
        public TipoServicioManager(ILogManager logManagerRepository,
                                   ITransaccionTipoServicioQO transaccionTipoServicioRespository) : 
            base(logManagerRepository, "tipo servicio")
        {
            iTransaccionTipoServicioRespository = transaccionTipoServicioRespository;
        }

        public ResultadoEjecucion<bool> Actualizar(TipoServicioEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoServicioRespository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<TipoServicioEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionTipoServicioRespository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new TipoServicioEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<TipoServicioEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionTipoServicioRespository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<TipoServicioEO>)new List<TipoServicioEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(TipoServicioEO entidad)
        {
            try
            {
                var resultado = iTransaccionTipoServicioRespository.Crear(entidad);
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
                var resultado = iTransaccionTipoServicioRespository.Eliminar(id);
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
