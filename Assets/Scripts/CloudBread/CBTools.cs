using System;
using System.Text;

namespace AssemblyCSharp
{
	public class CBTools
	{
		public CBTools ()
		{
		}

		public static string encoding(string jsonString){
			// utf-8 인코딩
			byte [] bytesForEncoding = Encoding.UTF8.GetBytes ( jsonString ) ;
			string encodedString = Convert.ToBase64String (bytesForEncoding );

			// utf-8 디코딩
			byte[] decodedBytes = Convert.FromBase64String (encodedString );
			string decodedString = Encoding.UTF8.GetString (decodedBytes );

			return decodedString;
		}
	}
}

