using System;
using System.Collections;

namespace TheSite.Classi.AnalisiStatistiche
{
	
	/// <summary>
	/// Classe Astratta Per la generazione 
	/// della Query String.
	/// </summary>
	public abstract class AbractQryStr
	{
		
		public AbractQryStr()
		{
			//
			// TODO: Costruttore non implementato
			//
		}

		/// <summary>
		/// Aggiunge un controllo all'oggeto
		/// Generatore di query string
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="key"></param>
		/// 
		public abstract void AddCntr(object Control, string key);
		/// <summary>
		/// Rimuove il controllo che e'
		/// stato agginto con la key
		/// inserita
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="Key"></param>
		public abstract void RemCntr(string Key);
		/// <summary>
		/// Restituisce il nome del controllo con la key 
		/// inserita
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		/// 
		public abstract string Name(string key );
		/// <summary>
		/// Restituisce in formato stringa lo
		/// stato del controllo con la key
		/// inserita
		/// </summary>
		/// <param name="n"></param>
		/// <returns type="string"></returns>
		public abstract string Stato(string key);
		/// <summary>
		/// Restituisce il nome del controllo
		///  il suo valore
		/// Name=Stato con la
		/// key iserita
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public abstract string QryStr(string key);
		/// <summary>
		/// Restituisce la query string di tuetti 
		/// gli oggetti della collezione
		/// Name1=Stato1&Nome2&Stato2& ....  &NomeN=StatoN
		/// </summary>
		/// <returns></returns>
		public abstract string TotQueryString();

	}

}
