using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Web.SessionState;
using System.Web.UI;

namespace TheSite.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per Helper.
	/// </summary>
	public class Helper
	{
		public static string GetApplicationName()
		{
			string ApplicationName="Engie Servizi s.p.a.";
			if(HttpContext.Current.User.IsInRole("MA") && !HttpContext.Current.User.IsInRole("PA"))
				ApplicationName="Martino";

			if(!HttpContext.Current.User.IsInRole("MA") && HttpContext.Current.User.IsInRole("PA"))
				ApplicationName="Papardo";

			return ApplicationName;
		}
	}
}
