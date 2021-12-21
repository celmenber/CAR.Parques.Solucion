namespace CAR.Parques.Common.Core.Utilidades
{
    using System.Net;
    using System.Net.Mail;

    public class SmtpEmail
    {
        public static void EnvioEmail(MailMessage mensaje, NetworkCredential credenciales, string host)
        {
            using (var email = new SmtpClient(host))
            {
                email.Credentials = credenciales;
                try
                {
                    email.Send(mensaje);
                }
                catch (SmtpException exSmtp)
                {
                    throw exSmtp;
                }
            }
        }
    }
}
