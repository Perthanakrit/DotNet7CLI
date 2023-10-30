using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Email;
using Microsoft.Extensions.Options;

namespace Infrastructure.Email
{
    public class SendgridEmailProvider : IEmailProvider
    {
        // พัฒนาการส่งเมล์โดยการสมมติว่ากำลังต่อกับ Email Provider ชื่อ Sendgrid
        protected readonly SendgridEmailProviderOptions _options;
        public SendgridEmailProvider(IOptions<SendgridEmailProviderOptions> options)
        {
            _options = options.Value;
        }

        public async Task<string> SendEmailAsync(string subject, string message, List<string> recepients)
        {
            string sendingResult = "";

            await Task.Run(() =>
            {
                sendingResult = $"Email Provider: !! SENDGRID - SMTP !! {Environment.NewLine}" +
                $"Host: {_options.Host} {Environment.NewLine}" +
                $"UserName: {_options.UserName} {Environment.NewLine}" +
                $"Password: {_options.Password} {Environment.NewLine}" +
                $"Subject: {subject} {Environment.NewLine}" +
                $"Message: {message} {Environment.NewLine}" +
                $"Recepients Provider: {String.Join(", ", recepients)}";
            });

            return sendingResult;
        }
    }
}