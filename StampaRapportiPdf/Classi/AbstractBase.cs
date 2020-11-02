using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace StampaRapportiPdf.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per _AbstractBase.
	/// </summary>
	public abstract class AbstractBase
	{
		#region Dichiarazioni

		protected int i_Id = 0;
		protected string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];						

		#endregion

		public AbstractBase()
		{
			
		}

		#region Metodi Pubblici

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public abstract DataSet GetData();	

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public abstract DataSet GetData(S_ControlsCollection CollezioneControlli);		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public abstract DataSet GetSingleData(int itemId);	
	
		/// <summary>
		/// Aggiunge un record e restituisce l'id
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public virtual int Add(S_ControlsCollection CollezioneControlli)
		{
			return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Insert, 0);
		}

		/// <summary>
		/// Modifica un record e restituisce l'id
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public virtual int Update(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Update, itemId);
		}

		/// <summary>
		/// Elimina un record e restituisce -1 se ok
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public virtual int Delete(S_ControlsCollection CollezioneControlli, int itemId)
		{
			return this.ExecuteUpdate(CollezioneControlli, ExecuteType.Delete, itemId);
		}

		/// <summary>
		/// Restituisce gli utenti e le date di inserimento e modifica record
		/// </summary>
		/// <param name="Data"></param>
		/// <returns></returns>
		public virtual string GetFirstAndLastUser(DataRow Data)
		{
			System.Text.StringBuilder _StrBldFirst = new System.Text.StringBuilder();
			
			try
			{
				_StrBldFirst.Append("Creato da ");
				if (Data["FIRST"] != DBNull.Value)
					_StrBldFirst.Append(Data["FIRST"].ToString());

				_StrBldFirst.Append(" il ");
				if (Data["FIRSTMODIFIED"] != DBNull.Value)
					_StrBldFirst.Append(Data["FIRSTMODIFIED"].ToString());		
	
				_StrBldFirst.Append(" ");

				_StrBldFirst.Append("Modificato da ");
				if (Data["LAST"] != DBNull.Value)
					_StrBldFirst.Append(Data["LAST"].ToString());

				_StrBldFirst.Append(" il ");
				if (Data["LASTMODIFIED"] != DBNull.Value)
					_StrBldFirst.Append(Data["LASTMODIFIED"].ToString());
			}
			catch
			{
				_StrBldFirst.Append("");	
			}
			return _StrBldFirst.ToString();

		}

		#endregion

		#region Metodi Protetti

		protected abstract int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId);		

		#endregion

		#region Proprietà Pubbliche

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get {return i_Id;}
			set {i_Id = value;}
		}		

		#endregion
	}
}
