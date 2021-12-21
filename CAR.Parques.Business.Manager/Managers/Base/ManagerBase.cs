namespace CAR.Parques.Business.Manager.Managers.Base
{
    using CAR.Parques.Common.Core.Enumerables;
    using CAR.Parques.Common.Core.Utilidades;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using Common.Core.Extenciones;
    using Common.Entities.Entidades.Bitacora;
    using Contract.ManagerContracts.LogContract;
    using System;
    using System.ComponentModel.Composition;

    public class ManagerBase
    {
        private readonly ILogManager iLogManagerRepository;
        public string claseManager = "";
        private readonly DatosTransaccion datosTransaccion;

        [ImportingConstructor]
        public ManagerBase(ILogManager logManagerRepository, string nombreManager)
        {
            iLogManagerRepository = logManagerRepository;
            this.datosTransaccion = new DatosTransaccion();
            this.claseManager = nombreManager;
        }

        public void RegistrarExtisoLogTransaccion(string accion, bool singular)
        {
            RegistrarLogTransaccion(
                                ($"{accion} {this.claseManager}" + (singular ? "." : "s.")),
                                "Proceso ejecutado con exito",
                                true);
        }

        public ResultadoEjecucion<T> RegistrarNoExtisoLogTransaccionControlado<T>(string accion, bool singular, T tipoResultado, string mensaje)
        {
            RegistrarLogTransaccion(
                                ($"{accion} {this.claseManager}" + (singular ? "." : "s.")),
                                "Proceso bloqueado",
                                true);
            return ManejoResultado.MapearRespuestaExepcionControlado(mensaje, tipoResultado, 0);
        }

        public ResultadoEjecucion<T> RegistrarLogExepcionNoEsperada<T>(Exception ex, T tipoResultado, int cod)
        {
            this.RegistrarLogTransaccion(
                                "StacTrace: " + ex.StackTrace,
                                "Error: " + ex.Message,
                                false);
            return ManejoResultado.MapearRespuestaExepcion(ex, tipoResultado, cod);
        }

        public DatosTransaccion DatosTransaccion
        {
            get
            {
                return this.datosTransaccion;
            }
        }

        public void RegistrarLogTransaccionDatos<T, K>(
            string detalle, string observacion, bool transaccionExitosa, T datosEntrada, K datosSalida)
        {
                string cadenaDatoEntrada = null, cadenaDatoSalida = null;
                if (datosEntrada != null)
                {
                    cadenaDatoEntrada = TypeExtension.SerializarObjeto<T>(datosEntrada);
                }

                if (datosSalida != null)
                {
                    cadenaDatoSalida = TypeExtension.SerializarObjeto<K>(datosSalida);
                }

                this.RegistrarLog(new LogTransaccion
                {
                    DetalleEjecucion = detalle,
                    Observacion = observacion,
                    ResultadoExitoso = transaccionExitosa,
                    DatosEntrada = cadenaDatoEntrada,
                    DatosSalida = cadenaDatoSalida
                });
        }

        public void RegistrarLogTransaccion(string detalle, string observacion, bool transaccionExitosa)
        {
            if (DatosTransaccion != null && DatosTransaccion.UsuarioId != 0)
            {
                this.RegistrarLog(new LogTransaccion
                {
                    DetalleEjecucion = detalle,
                    Observacion = observacion,
                    ResultadoExitoso = transaccionExitosa
                });
            }
        }

        private void RegistrarLog(LogTransaccion log)
        {
            try
            {
                log.UsuarioId = DatosTransaccion.UsuarioId;
                log.MenuId = DatosTransaccion.MenuId;
                log.FechaEvento = DateTime.Now.ToString();
                var resupesta = iLogManagerRepository.RegistrarLog(log);

                if (!resupesta.Entidad)
                {
                    throw new Exception(resupesta.Descripcion);
                }
            }
            catch (Exception ex)
            {
                string[] mensajeError =
                {
                    "==============================Inicio Error LOG===========================",
                    "ERROR: " + ex.Message,
                    "Detalle: " + log.DetalleEjecucion,
                    "Observacion: " + log.Observacion,
                    "UsuarioId: " + log.UsuarioId.ToString(),
                    "MenuId: " + log.MenuId.ToString(),
                    "Fecha: " + DateTime.Now.ToString(),
                    "==============================Fin Error LOG===========================",
                    ""
                };
                ArchivoRegistroTranccion.EscribirArchivo(
                    "Log_", true, TipoCaracteristicaArchivoPlanoType.LOG, mensajeError);
            }
        }
    }
}
