using System;
using System.Collections;
using System.Text;
namespace TheSite.Classi.AnalisiStatistiche
{
	/// <summary>
	/// Classe Per la generazione della query String.
	/// </summary>
	public class GenetoreQryStr 
	{
		private Hashtable _HSControl= new Hashtable();
		 public GenetoreQryStr()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
	
		public  void Add(Object ControlValue, string key)
		{
			_HSControl.Add(key,ControlValue);
		}
		public  void Rem(string Key)
		{
			_HSControl.Remove(Key);
		}
		public  string QryStr(string key)
		{
			return key + "=" + _HSControl[key].ToString();
		}
		public  string TotQueryString()
		{
			IDictionaryEnumerator myEnumerator = _HSControl.GetEnumerator();
			StringBuilder sb = new StringBuilder();
			sb.Append("?");
			while ( myEnumerator.MoveNext())
			{
				sb.Append(myEnumerator.Key.ToString());
				sb.Append("=");
				sb.Append(myEnumerator.Value.ToString());
				sb.Append("&");
			}
			return sb.ToString();
		}
	}
}
