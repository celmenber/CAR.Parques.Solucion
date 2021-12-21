namespace CAR.Parques.Business.Manager.Managers.Parque
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Utilitarios;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Parques;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Parque;
    using Contract.ManagerContracts.ParqueContract;
    using Manager.Managers.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    [Export(typeof(IParqueManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ParqueManager : ManagerBase, IParqueManager
    {
        private readonly ITransaccionParqueQO iTransaccionParqueRepository;
        private readonly IManejoCorreoManager iManagerManejoCorreoRepository;

        [ImportingConstructor]
        public ParqueManager(ILogManager logManagerRepository,
                            ITransaccionParqueQO transaccionParqueRepository,
                            IManejoCorreoManager managerManejoCorreoRepository) : 
            base(logManagerRepository, "parque")
        {
            iTransaccionParqueRepository = transaccionParqueRepository;
            iManagerManejoCorreoRepository = managerManejoCorreoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(ParqueEO entidad)
        {
            try
            {
                var resultado = iTransaccionParqueRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<ParqueEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionParqueRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ParqueEO(), 0);
            }
        }

        public ResultadoEjecucion<ParqueDetalleEO> ConsultarParquesDetalleXId(int parqueId)
        {
            try
            {
                var resultado = iTransaccionParqueRepository.ConsultarParquesDetalleXId(parqueId);
                this.RegistrarExtisoLogTransaccion("Consulta Detalle x Id", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ParqueDetalleEO(), 0);
            }
        }

        public ResultadoEjecucion<ParqueInformacionEO> ConsultarParquesInformacionXId(int parqueId)
        {
            try
            {
                var resultado = iTransaccionParqueRepository.ConsultarParquesInformacionXId(parqueId);
                this.RegistrarExtisoLogTransaccion("Consulta Detalle Informacion x Id", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new ParqueInformacionEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ParqueEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionParqueRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ParqueEO>)new List<ParqueEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ParqueEO>> ConsultarTodosParques()
        {
            try
            {
                var resultado = iTransaccionParqueRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ParqueEO>)new List<ParqueEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ParqueDetalleEO>> ConsultarTodosParquesDetalle()
        {
            try
            {
                var resultado = iTransaccionParqueRepository.ConsultarTodosParquesDetalle();
                this.RegistrarExtisoLogTransaccion("Consulta Todos Detalle", false);
                return resultado;
            }
            catch (Exception ex)
            {

                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ParqueDetalleEO>)new List<ParqueDetalleEO>(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<ParqueInformacionEO>> ConsultarTodosParquesInformacionDetalle()
        {
            try
            {
                var resultado = iTransaccionParqueRepository.ConsultarTodosParquesInformacionDetalle();
                //var correo = iManagerManejoCorreoRepository.ConsultarCorreoXNombre("Aprobación Reserva");
                //var resultadoCorreo = iManagerManejoCorreoRepository.EnviarCorreo("juancho93.alvarino@gmail.com", string.Format(correo.Entidad.Asunto, "123"), string.Format(correo.Entidad.CuerpoCorreo, "Este es un correo de prueba", "Prueba de envio transversal de correos"), correo.Entidad.EsHtml);
                //var resultadoCorreo2 = iManagerManejoCorreoRepository.EnviarCorreo("jalvarinoa@car.gov.co", string.Format(correo.Entidad.Asunto, "123"), string.Format(correo.Entidad.CuerpoCorreo, "Este es un correo de prueba", "Prueba de envio transversal de correos"), correo.Entidad.EsHtml);
                this.RegistrarExtisoLogTransaccion("Consulta Todos Información", false);
                return resultado;
            }
            catch (Exception ex)
            {

                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<ParqueInformacionEO>)new List<ParqueInformacionEO>(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(ParqueEO entidad)
        {
            try
            {
                var resultado = iTransaccionParqueRepository.Crear(entidad);
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
                var resultado = iTransaccionParqueRepository.Eliminar(id);
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
