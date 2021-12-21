namespace CAR.Parques.Business.Manager.Managers.Reserva
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Reserva;
    using CAR.Parques.Business.Contract.ManagerContracts.Utilitarios;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Reserva;
    using CAR.Parques.Common.Models.Modelos.Reserva;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Reserva;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Configuration;

    [Export(typeof(IReservaManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReservaManager : ManagerBase, IReservaManager
    {
        private readonly ITransaccionReservaQO iTransaccionReservaRepository;
        private readonly IDetalleReservaManager iDetallereservaManager;
        private readonly IArchivoReservaManager _IArchivoReservaManager;
        private readonly IManejoCorreoManager _IManagerManejoCorreoRepository;

        [ImportingConstructor]
        public ReservaManager(ILogManager logManagerRepository,
                              ITransaccionReservaQO transaccionReservaRepository,
                              IDetalleReservaManager detallereservaManager,
                              IArchivoReservaManager archivoReservaManager,
                              IManejoCorreoManager manejoCorreoManager) :
            base(logManagerRepository, "reserva")
        {
            iTransaccionReservaRepository = transaccionReservaRepository;
            iDetallereservaManager = detallereservaManager;
            _IArchivoReservaManager = archivoReservaManager;
            _IManagerManejoCorreoRepository = manejoCorreoManager;
        }

        public ResultadoEjecucion<bool> Actualizar(ReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<ReservaEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ReservaEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasDetalleServicio(int estadoId, int parqueId, string fechaIncio, string fechaFin)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.ConsultarReservasDetalleServicio(estadoId, parqueId, fechaIncio, fechaFin);
                this.RegistrarExtisoLogTransaccion("Consulta Reserva Detalle Servicio Parque ", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ReservaDetalleServicioEO>)new List<ReservaDetalleServicioEO>(), 0);
            }
        }


        public ResultadoEjecucion<IEnumerable<ReservaEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionReservaRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ReservaEO>)new List<ReservaEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.ConsultarReservasUsuario(usuarioId);
                this.RegistrarExtisoLogTransaccion("Consulta reservas usuario", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ReservaDetalleServicioEO>)new List<ReservaDetalleServicioEO>(), 0);
            }
        }
        public ResultadoEjecucion<IEnumerable<ReservaDetalleServicioEO>> ConsultarReservasUsuario(int usuarioId, int estadoId)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.ConsultarReservasUsuario(usuarioId, estadoId);
                this.RegistrarExtisoLogTransaccion("Consulta reservas usuario", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ReservaDetalleServicioEO>)new List<ReservaDetalleServicioEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(ReservaEO entidad)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.Crear(entidad);
                //iDetallereservaManager.Crear()
                this.RegistrarExtisoLogTransaccion("Creación ", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new int(), 0);
            }
        }

        //public ResultadoEjecucion<int> CrearDetalle(ReservaEO entidad)
        public ResultadoEjecucion<int> CrearDetalle(ReservaEO entidad, IEnumerable<DetalleReservaEO> detalles)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.Crear(entidad);

                foreach (var item in detalles)
                {
                    //item.FechaInicio = DateTime.Now;
                    //item.FechaFin = DateTime.Now;
                    item.ReservaId = resultado.Entidad;
                    //var resultadodetalle = iDetallereservaManager.Crear(item);
                }
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
                var resultado = iTransaccionReservaRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }


        public ResultadoEjecucion<bool> ActualizarEstadoReserva(ReservaModel reservaModel)
        {
       
            try
            {
                var reserva = iTransaccionReservaRepository.Consultar(reservaModel.ReservaId);
                if (reserva != null)
                {
                    reserva.Entidad.EstadoId = reservaModel.EstadoId;
                    var resutlado = iTransaccionReservaRepository.Actualizar(reserva.Entidad);
                    this.RegistrarExtisoLogTransaccion("Actualizar estado reserva", true);
                    return resutlado;
                }

                return new ResultadoEjecucion<bool> {Codigo = 0, Descripcion = "No se encuentra la reserva", Entidad = false  };

            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }
        public ResultadoEjecucion<ArchivoReservaEO> ObtenerArchivoComprobanteReserva(int reservaId)
        {
            try
            {
                var archivoReserva = _IArchivoReservaManager.ConsultarArchivoReserva(reservaId);
                this.RegistrarExtisoLogTransaccion("Consulta archivo reserva usuario", true);
                return archivoReserva;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ArchivoReservaEO(), 0);
            }
        }

        public ResultadoEjecucion<int> CargarArchivoReserva(ArchivoReservaEO entidad)
        {
            var responseArchivo = new ResultadoEjecucion<int>();

            var archivoActual = _IArchivoReservaManager.ConsultarArchivoReserva(entidad.ReservaId);

            if (archivoActual.Codigo == 1 && archivoActual.Descripcion.ToLower() == "ejecución exitosa.")
            {
                if (archivoActual.Entidad != null)
                {
                    archivoActual.Entidad.ByteArchivo = entidad.ByteArchivo;
                    _IArchivoReservaManager.Actualizar(archivoActual.Entidad);
                    responseArchivo.Entidad = archivoActual.Entidad.ArchivoReservaId;
                }
                else
                {
                    responseArchivo = _IArchivoReservaManager.Crear(entidad);
                }
            }
            else
            {
                responseArchivo.Codigo = archivoActual.Codigo;
                responseArchivo.Descripcion = archivoActual.Descripcion;
            }

            if (responseArchivo.Codigo == 1 && responseArchivo.Descripcion.ToLower() == "ejecución exitosa.")
            {
                var respuestaReservaUsuario = ConsultarReservaUsuario(entidad.ReservaId);

                if (respuestaReservaUsuario.Codigo == 1 && respuestaReservaUsuario.Descripcion.ToLower() == "ejecución exitosa.")
                {
                    string asunto = $"Comprobante de pago - Reserva #{entidad.ReservaId} - { respuestaReservaUsuario.Entidad.UsuarioReserva }";

                    string mensaje = $@"Buen día.
                                        El usuario {respuestaReservaUsuario.Entidad.UsuarioReserva} ha cargado el comprobante de pago de la prereserva #{entidad.ReservaId}.
                                        Por favor validarlo.
                                        Gracias.";

                    _IManagerManejoCorreoRepository.EnviarCorreo(ConfigurationManager.AppSettings["emailAdminReservas"], asunto, mensaje, false);
                }
            }

            return responseArchivo;
        }

        private ResultadoEjecucion<ReservaDetalleServicioEO> ConsultarReservaUsuario(int reservaId)
        {
            try
            {
                var resultado = iTransaccionReservaRepository.ConsultarReservaUsuario(reservaId);
                this.RegistrarExtisoLogTransaccion("Consulta reserva usuario", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ReservaDetalleServicioEO(), 0);
            }
        }


        public ResultadoEjecucion<int> ValidarPreReserva(DetalleReservaEO detalleReserva)
        {
            return iDetallereservaManager.ValidarPreReserva(detalleReserva);
        }
    }
}
