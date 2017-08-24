using System;

namespace AssemblyCSharp
{
	class AuthData{
		public string authenticationToken { get; set; }
		public AzureUserData user { get; set; }
	}

	class AzureUserData{
		public string userId { get; set; }
	}
}

