using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SistRent.Application.Interfaces;
using SistRent.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendPasswordResetAsync(string email,string resetLink)
        {
            var message = new MimeMessage();

            // Remitente
            message.From.Add(new MailboxAddress(
                _settings.SenderName,
                _settings.SenderEmail));

            // Destinatario
            message.To.Add(MailboxAddress.Parse(email));

            // Asunto
            message.Subject = "Recuperación de contraseña - SistRental";

            // Contenido
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                    <html>
                    <body>
                        <h2>Recuperación de contraseña</h2>

                        <p>Hemos recibido una solicitud para
                        restablecer tu contraseña.</p>

                        <p>Haz clic en el siguiente enlace:</p>

                        <a href=""{System.Net.WebUtility.HtmlEncode(resetLink)}"">
                            Restablecer contraseña
                        </a>

                        <p>Este enlace expirará en 15 minutos.</p>

                        <p>Si no solicitaste este cambio,
                        puedes ignorar este mensaje.</p>

                        <br/>
                        <p>Equipo SistRental</p>
                    </body>
                    </html>"
            };

            message.Body = bodyBuilder.ToMessageBody();

            // Conexión SMTP
            using var client = new SmtpClient();

            await client.ConnectAsync(
                _settings.SmtpServer,
                _settings.Port,
                _settings.EnableSsl
                    ? SecureSocketOptions.SslOnConnect
                    : SecureSocketOptions.StartTls);

            // Autenticación
            await client.AuthenticateAsync(
                _settings.Username,
                _settings.Password);

            // Enviar correo
            await client.SendAsync(message);

            // Desconectar
            await client.DisconnectAsync(true);
        }
    }
}
