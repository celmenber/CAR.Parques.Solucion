namespace CAR.Parques.Business.Manager.Managers.Utilitarios
{
    using CAR.Parques.Business.Contract.ManagerContracts.LogContract;
    using CAR.Parques.Business.Contract.ManagerContracts.Utilitarios;
    using CAR.Parques.Business.Manager.Managers.Base;
    using CAR.Parques.Common.Entities.Entidades.Base;
    using CAR.Parques.Common.Entities.Entidades.Utilidades;
    using CAR.Parques.DataContract.InterfacesTrasaccion.Utilitarios;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Configuration;
    using System.Net.Mail;

    [Export(typeof(IManejoCorreoManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ManejoCorreoManager : ManagerBase, IManejoCorreoManager
    {
        private readonly ITransaccionCorreoQO iTransaccionCorreoRepository;

        [ImportingConstructor]
        public ManejoCorreoManager(ILogManager logManagerRepository,
                            ITransaccionCorreoQO transaccionCorreoRepository) :
            base(logManagerRepository, "correo")
        {
            iTransaccionCorreoRepository = transaccionCorreoRepository;
        }

        public ResultadoEjecucion<bool> Actualizar(PlantillasCorreoEO entidad)
        {
            try
            {
                var resultado = iTransaccionCorreoRepository.Actualizar(entidad);
                this.RegistrarExtisoLogTransaccion("Actualización", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }

        public ResultadoEjecucion<PlantillasCorreoEO> Consultar(int id)
        {
            try
            {
                var resultado = iTransaccionCorreoRepository.Consultar(id);
                this.RegistrarExtisoLogTransaccion("Consulta", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new PlantillasCorreoEO(), 0);
            }
        }

        public ResultadoEjecucion<IEnumerable<PlantillasCorreoEO>> ConsultarTodos()
        {
            try
            {
                var resultado = iTransaccionCorreoRepository.ConsultarTodos();
                this.RegistrarExtisoLogTransaccion("Consulta Todos", false);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, (IEnumerable<PlantillasCorreoEO>)new List<PlantillasCorreoEO>(), 0);
            }
        }

        public ResultadoEjecucion<PlantillasCorreoEO> ConsultarCorreoXNombre(string nombreCorreo)
        {
            try
            {
                var resultado = iTransaccionCorreoRepository.ConsultarPlantillaCorreo(nombreCorreo);
                this.RegistrarExtisoLogTransaccion("Consulta Plantilla Correo ", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new PlantillasCorreoEO(), 0);
            }
        }

        public ResultadoEjecucion<int> Crear(PlantillasCorreoEO entidad)
        {
            try
            {
                var resultado = iTransaccionCorreoRepository.Crear(entidad);
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
                var resultado = iTransaccionCorreoRepository.Eliminar(id);
                this.RegistrarExtisoLogTransaccion("Eliminación", true);
                return resultado;
            }
            catch (Exception ex)
            {
                return this.RegistrarLogExepcionNoEsperada(ex, new bool(), 0);
            }
        }



        public ResultadoEjecucion<string> EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtml)
        {
            ResultadoEjecucion<string> resultado = new ResultadoEjecucion<string>();
            string respuesta;
            try
            {
                /*SmtpClient client = new SmtpClient();
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["portEmail"].ToString());
                client.Host = ConfigurationManager.AppSettings["servidorEmail"].ToString();
                client.EnableSsl = true;
                //client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cuentaEmailFrom"].ToString(), ConfigurationManager.AppSettings["claveEmailFrom"].ToString());

                MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["cuentaEmailFrom"].ToString(), destinatario, asunto, mensaje);
                mm.BodyEncoding = System.Text.UTF8Encoding.UTF8;
                mm.IsBodyHtml = esHtml;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;*/

                SmtpClient client = new SmtpClient();
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["portEmail"].ToString());
                client.Host = ConfigurationManager.AppSettings["servidorEmail"].ToString();
                client.EnableSsl = true;
                //client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cuentaEmailFrom"].ToString(), ConfigurationManager.AppSettings["claveEmailFrom"].ToString());

                MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["cuentaEmailFrom"].ToString(), destinatario, asunto, mensaje);
                mm.BodyEncoding = System.Text.UTF8Encoding.UTF8;
                mm.IsBodyHtml = esHtml;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                respuesta = "Ok";
                resultado.Entidad = respuesta;
            }
            catch (SmtpException ex)
            {
                resultado.Codigo = 0;
                resultado.Descripcion =  $"Envio Correo ERROR: {ex.Message}";
                resultado.Entidad = "";
            }
            return resultado;
        }
    }
}
