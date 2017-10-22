using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CloudBread
{
    class AzureMobileAppRequestHelper
    {
        // Header Default

        // ZUMO-API-VERSION
        private static string _api_version = "2.0.0";

        // X-ZUMO-AUTH
        public static string AuthToken;

        public Dictionary<string, string> getDefaultHeader()
        {
            var header = new Dictionary<string, string>();
            header["ZUMO-API-VERSION"] = _api_version;
            header["Accept"] = "application/json";
            header["X-ZUMO-FEATURES"] = "AJ";
            header["Content-Type"] = "application/json";

            if (AuthToken != null)
            {
                header["X-ZUMO-AUTH"] = AuthToken;
            }

            return header;
        }

        public static Dictionary<string, string> getHeader()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();

            header["ZUMO-API-VERSION"] = _api_version;
            header["Accept"] = "application/json";
            header["X-ZUMO-VERSION"] = "ZUMO/2.0 (lang=Managed; os=Windows Store; os_version=--; arch=X86; version=2.0.31217.0)";
            header["X-ZUMO-FEATURES"] = "AJ";
            header["X-ZUMO-INSTALLATION-ID"] = "fe52b710-0312-4cad-8d53-dfd28d4c6f9b";
            header["Content-Type"] = "application/json";

            if (AuthToken != null)
            {
                header["X-ZUMO-AUTH"] = AuthToken;
            }

            return header;
        }
    }
}
