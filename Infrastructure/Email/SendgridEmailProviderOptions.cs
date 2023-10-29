using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class SendgridEmailProviderOptions
    {
        public const string ConfigItem = "SendgridEmailProvider";

        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}