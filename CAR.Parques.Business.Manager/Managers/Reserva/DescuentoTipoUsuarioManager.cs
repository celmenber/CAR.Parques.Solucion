namespace CAR.Parques.Business.Manager.Managers.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Reserva;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IDescuentoTipoUsuarioManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DescuentoTipoUsuarioManager : ManagerBase, IDescuentoTipoUsuarioManager
    {
        private readonly ITransaccionDescuentoTipoUsuarioQO iTransaccionDescuentoTipoUsuarioRepository;

        [ImportingConstructor]
        public DescuentoTipoUsuarioManager(ILogManager logManagerRepository,
                                           ITransaccionDescuentoTipoUsuarioQO transaccionDescuentoTipoUsuarioRepository) : 
            base(logManagerRepository, "descuento tipo usuario")
        {
            iTransaccionDescuentoTipoUsuarioRepository = transaccionDescuentoTipoUsuarioRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(DescuentoTipoUsuarioEO entidad)
        {
            try
            {
                var resultado = iTransaccionDescuentoTipoUsuarioRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<DescuentoTipoUsuarioEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionDescuentoTipoUsuarioRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new DescuentoTipoUsuarioEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<DescuentoTipoUsuarioEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionDescuentoTipoUsuarioRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<DescuentoTipoUsuarioEO>)new List<DescuentoTipoUsuarioEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(DescuentoTipoUsuarioEO entidad)
        {
            try
            {
                var descuentoServicio = iTransaccionDescuentoTipoUsuarioRepository.ConsultarDescuentoTipoUsuarioxServicio(entidad.ServicioId);
                if(descuentoServicio.Entidad.Where(x => x.TipoUsuarioId == entidad.TipoUsuarioId).ToList().Count == 0)
                {
                    var resultado = iTransaccionDescuentoTipoUsuarioRepository.Crear(entidad);
                    this.RegistrarExtisoLogTransaccion("Creación ", true);
                    return resultado;
                }
                else
                {
                    return this.RegistrarNoExtisoLogTransaccionControlado("Crear Descuento", true, new int(), "Descuento ya existente");
                }
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
                var resultado = iTransaccionDescuentoTipoUsuarioRepository.Eliminar(id);
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
