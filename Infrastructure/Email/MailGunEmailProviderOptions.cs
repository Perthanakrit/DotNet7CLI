using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class MailGunEmailProviderOptions
    {
        // เป็น Option Pattern for MailGunEmailProvider เพื่อเป็น Configuration ในการติดต่อกับ MailGun
        public const string ConfigItem = "MailGunEmailProvider";

        public string APIURL { get; set; }
        public string APIKey { get; set; }
    }
}