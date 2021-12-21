namespace CAR.Parques.Business.Manager.Managers.GestorContenido
{
    using CAR.Parques.Business.Contract.ManagerContracts.GestorContenido;
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.GestorContenido;
    using CAR.Parques.DataContract.InterfacesTrasaccion.GestorContenido;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IGestorContenidoManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GestorContenidoManager : ManagerBase, IGestorContenidoManager
    {
        private readonly ITransaccionGestorContenidoQO itransaccionGestorContenidoRepository;

        [ImportingConstructor]
        public GestorContenidoManager(ILogManager logManagerRepository,
                                      ITransaccionGestorContenidoQO transaccionGestorContenidoRepository) :
            base(logManagerRepository, "Gestor de Contenido")
        {
            itransaccionGestorContenidoRepository = transaccionGestorContenidoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(GestorContenidoEO entidad)
        {
            try
            {
                GestorContenidoEO gestorContenido = Consultar(entidad.ContenidoId).Entidad;

                gestorContenido.CuerpoContenido = entidad.CuerpoContenido;

                if (entidad.ImagenContenido != null && entidad.ImagenContenido.Length > 0)
                {
                    gestorContenido.TituloContenido = entidad.TituloContenido;
                    gestorContenido.ImagenContenido = entidad.ImagenContenido;
                }

                gestorContenido.FechaFinVigencia = entidad.FechaFinVigencia;
                gestorContenido.FechaInicioVigencia = entidad.FechaInicioVigencia;
                gestorContenido.NombreContenido = entidad.NombreContenido;
                gestorContenido.URLRedireccion = entidad.URLRedireccion;
                gestorContenido.Activo = entidad.Activo;

                var resultado = itransaccionGestorContenidoRepository.Actualizar(gestorContenido);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<GestorContenidoEO> Consultar(int id)
        {
            try
            {
                var resultado = itransaccionGestorContenidoRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new GestorContenidoEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<GestorContenidoEO>> ConsultarTodos()
        {
            try
            {
                var resultado = itransaccionGestorContenidoRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<GestorContenidoEO>)new List<GestorContenidoEO>(), 0);
            }
        }
        public ResultadoEjecucion<IEnumerable<GestorContenidoEO>> ConsultarTodosVigentes()
        {
            try
            {
                var resultado = itransaccionGestorContenidoRepository.ConsultarTodosVigentes();
                this.RegistrarExtisoLogTransaccion("Consulta Todos vigentes", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<GestorContenidoEO>)new List<GestorContenidoEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(GestorContenidoEO entidad)
        {
            try
            {
                var resultado = itransaccionGestorContenidoRepository.Crear(entidad);
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
                var resultado = itransaccionGestorContenidoRepository.Eliminar(id);
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
