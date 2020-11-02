using System;
using System.Web;
using System.Configuration;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassGlobal.
	/// </summary>
	public class ClassGlobal
	{
		public ClassGlobal()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
		/// <summary>
		/// Indica se la richiesta è stata effetuata da un Browser Mobile
		/// </summary>
		public static bool IsMobileDevice 
		{
			get 
			{
				HttpContext context = HttpContext.Current;
				return context.Request.Browser["IsMobileDevice"] == "true" || context.Request.Browser.Platform == "WinCE";
			}
		}
	}
}
