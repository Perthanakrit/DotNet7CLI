using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class MailGunEmailProviderOptions
    {
        // Option Pattern 
        public const string ConfigItem = "MailGunEmailProvider";

        public string APIURL { get; set; }
        public string APIKey { get; set; }
    }
}