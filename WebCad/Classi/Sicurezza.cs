using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace WebCad.Classi
{
	/// <summary>
	/// Gestione Sicurezza Sito
	/// </summary>
	public class Sicurezza
	{

		public Sicurezza(){}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cleanString"></param>
		/// <returns></returns>
		public string EncryptMD5(string cleanString) 
		{

			Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
			Byte[] hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

			return BitConverter.ToString(hashedBytes);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cleanString"></param>
		/// <returns></returns>
		public string EncryptSHA1(string cleanString) 
		{

			Encoding endcod = Encoding.ASCII;
			Byte[] clearBytes = endcod.GetBytes(cleanString);
			byte[] result; 
 
			SHA1 sha = new SHA1CryptoServiceProvider(); 
			// This is one implementation of the abstract class SHA1.
			result = sha.ComputeHash(clearBytes);
			
			return ToString(result);

		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public bool IsInRole(String role) 
		{

			return HttpContext.Current.User.IsInRole(role);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="roles"></param>
		/// <returns></returns>
		public bool IsInRoles(String roles) 
		{

			HttpContext context = HttpContext.Current;

			foreach (String role in roles.Split( new char[] {';'} )) 
			{
            
				if (role != "" && role != null && (context.User.IsInRole(role))) 
				{
					return true;
				}
			}

			return false;
		}

		#region Metodi Privati

		/// <summary>
		/// Conversione in stringa di un array di byte
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		private string ToString(byte[] bytes) 
		{
			char[] chars = new char[bytes.Length];
			for (int i = 0; i < bytes.Length; i++) 
			{
				int b = bytes[i];
				chars[i] = Convert.ToChar(b);				
			}
			return new string(chars);
		}

		#endregion

	}
}
