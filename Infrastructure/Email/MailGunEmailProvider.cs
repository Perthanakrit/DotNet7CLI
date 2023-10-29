using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces.Infra.Email;
using Microsoft.Extensions.Options;

namespace Infrastructure.Email
{
    // พัฒนาการส่งเมล์โดยการสมมติว่ากำลังต่อกับ Email Provider ที่ชื่อว่า MailGun
    public class MailGunEmailProvider : IEmailProvider
    {
        protected readonly MailGunEmailProviderOptions _options;
        public MailGunEmailProvider(IOptions<MailGunEmailProviderOptions> options)
        {
            _options = options.Value;
        }

        public async Task<string> SendEmailAsync(string subject, string message, List<string> recepients)
        {
            string sendingResult = "";

            await Task.Run(() =>
            {
                sendingResult = $"Email Provider: !! MAILGUN - RESTFul API !! {Environment.NewLine}" +
                $"APIURL: {_options.APIURL} {Environment.NewLine}" +
                $"APIKey: {_options.APIKey} {Environment.NewLine}" +
                $"Subject: {subject} {Environment.NewLine}" +
                $"Message: {message} {Environment.NewLine}" +
                $"Recepients Provider: {String.Join(", ", recepients)}";
            });

            return sendingResult;
        }
    }
}