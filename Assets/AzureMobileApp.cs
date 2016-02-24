using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class AzureMobileApp {

		private string _azureEndPoint;
		private string _applicationKey;

		private string _sever_address;
		private string _auth_token;

		public AzureMobileApp(string ServerAddress, string Auth_Token){
			_sever_address = ServerAddress;
			_auth_token = Auth_Token;
		}


	}
}
