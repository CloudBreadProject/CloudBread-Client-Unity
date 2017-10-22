using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.CloudBread
{
    class AzureAuthentication
    {
        public class AuthenticationToken
        {
        }
        public class FacebookGoogleAuthenticationToken : AuthenticationToken
        {
            public string access_token;
        }
        public class MicrosoftAuthenticationToken : AuthenticationToken
        {
            public string authenticationToken;
        }

        public enum AuthenticationProvider
        {
            // Summary:
            //     Microsoft Account authentication provider.
            MicrosoftAccount = 0,
            //
            // Summary:
            //     Google authentication provider.
            Google = 1,
            //
            // Summary:
            //     Twitter authentication provider.
            Twitter = 2,
            //
            // Summary:
            //     Facebook authentication provider.
            Facebook = 3,
        }

        public static AuthenticationToken CreateToken(AuthenticationProvider provider, string token)
        {
            AuthenticationToken authToken = new AuthenticationToken();
            switch (provider)
            {
                case AuthenticationProvider.Facebook:
                case AuthenticationProvider.Google:
                case AuthenticationProvider.Twitter:
                    {
                        authToken = new FacebookGoogleAuthenticationToken() { access_token = token };
                        break;
                    }
                case AuthenticationProvider.MicrosoftAccount:
                    {
                        authToken = new MicrosoftAuthenticationToken() { authenticationToken = token };
                        break;
                    }
            }
            return authToken;
        }

    }
}
