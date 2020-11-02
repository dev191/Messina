using System;
using System.Data;
using System.Data.OracleClient; 
using System.Security.Cryptography;
using System.Text;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassUser.
	/// </summary>
	public class ClassUser: Abstract
	{
		public ClassUser()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		public int Autentica(OracleParameterCollection CollezioneControlli)
		{
		 DataSet _MyDs= base.GetData(CollezioneControlli,"PACK_UTENTI.SP_AUTENTICA_UTENTI");
			if (_MyDs.Tables[0].Rows.Count > 0)
				return Convert.ToInt32(_MyDs.Tables[0].Rows[0]["UTENTE_ID"].ToString());
			else
				return 0;
		}

		public string EncryptMD5(string cleanString) 
		{

			Byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
			Byte[] hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

			return BitConverter.ToString(hashedBytes);

		}
	}
}
