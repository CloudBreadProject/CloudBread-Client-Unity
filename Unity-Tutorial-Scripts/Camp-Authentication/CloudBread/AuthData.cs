using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CloudBread
{
    class AuthData
    {
        public string authenticationToken { get; set; }
        public AzureUserData user { get; set; }
    }

    class AzureUserData
    {
        public string userId { get; set; }
    }
}
