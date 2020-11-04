using System;
using System.Text.RegularExpressions;

namespace GIC.App_Code
{
	/// <summary>
	/// Descrizione di riepilogo per Util.
	/// </summary>
	public class Util
	{
		private Util()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		/// <summary>
		/// Rimuove i Tag Html e restituisce il testo contenuto in esso
		/// </summary>
		/// <param name="text">Testo con Html</param>
		/// <returns>Testo Privo di HTML</returns>
		public static string RemoveHTML(string text)
		{
			text=System.Web.HttpUtility.HtmlDecode(text); 
			return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
			//return Regex.Replace(text, "&nbsp;", string.Empty);
		}
		/// <summary>
		/// Tronca il Testo in base ad un numero di caratteri.
		/// Se viene Passato 0 la funzione restituisce l'intera stringa passata
		/// </summary>
		/// <param name="input">Testo da Troncare</param>
		/// <param name="characterLimit">Limite di caratteri da visualizzare</param>
		/// <returns>Testo troncato</returns>
		public static string Truncate(string input, int characterLimit) 
		{
			string output = input;
			if (output.Length > characterLimit && characterLimit > 0) 
			{
				output = output.Substring(0,characterLimit);
				if (input.Substring(output.Length,1) != " ") 
				{
					int LastSpace = output.LastIndexOf(" ");
					if (LastSpace != -1) 
						output = output.Substring(0,LastSpace);  
				}
				output += "...";    
			}
			return output;
		}
		public static string Truncate(object input, int characterLimit) 
		{
			return Truncate(input.ToString(),characterLimit);
		}


		public static bool CheckString(string stringa, string delimitatore)
		{
			return stringa.StartsWith(delimitatore) && stringa.EndsWith(delimitatore);
		}

	}
}
