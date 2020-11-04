using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.Classi
{	
	/// <summary>
	/// Descrizione di riepilogo per Function.
	/// </summary>
	public class Function
	{
		private string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];									
		private DataSet _Ds;
		public Function()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		public static void Tronca(string descrizione, int numcarvisual, System.Collections.ArrayList itmTooltip, int numcarvistool)
		{
			int appo=0;
			int appo1=0;
			
			if(numcarvistool==0)
				itmTooltip[0]="";
			else if(numcarvistool==-1)
				itmTooltip[0]=descrizione;
			else
			{
				if (descrizione.Length > numcarvistool)
				{
					if(descrizione.Substring(numcarvistool)!=" ")
					{
						appo=descrizione.LastIndexOf(" ",numcarvistool);
						itmTooltip[0]=descrizione.Substring(0,appo).ToString() + "..."; 
					}
					else
						itmTooltip[0]=descrizione.Substring(0,numcarvistool) + "...";
				}
				else
					itmTooltip[0]=descrizione;
			}
			

			if (descrizione.Length > numcarvisual)
			{
				if(descrizione.Substring(numcarvisual)!=" ")
				{
					appo1=descrizione.LastIndexOf(" ",numcarvisual);
					if (appo1 != -1)
					itmTooltip[1]=descrizione.Substring(0,appo1).ToString() + "..."; 
				}
				else
					itmTooltip[1]=descrizione.Substring(0,numcarvisual) + "..."; 
			}
			else
				itmTooltip[1]=descrizione;		
		}

		public DataSet ControllaDuplicato(string tabella, string campo_input, string valore,string campo_output)
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_Tabella = new S_Object();
			s_Tabella.ParameterName = "p_tabella";
			s_Tabella.DbType = CustomDBType.VarChar;
			s_Tabella.Direction = ParameterDirection.Input;
			s_Tabella.Index = 0;
			s_Tabella.Value = tabella ;			
			s_Tabella.Size = 50;

			S_Controls.Collections.S_Object s_campo = new S_Object();
			s_campo.ParameterName = "p_campo_input";
			s_campo.DbType = CustomDBType.VarChar;
			s_campo.Direction = ParameterDirection.Input;
			s_campo.Index = 1;
			s_campo.Value = campo_input;			
			s_campo.Size = 50;

			S_Controls.Collections.S_Object s_valore = new S_Object();
			s_valore.ParameterName = "p_valore";
			s_valore.DbType = CustomDBType.VarChar;
			s_valore.Direction = ParameterDirection.Input;
			s_valore.Index = 2;
			s_valore.Value = valore;			
			s_valore.Size = 50;

			S_Controls.Collections.S_Object s_campo_output = new S_Object();
			s_campo_output.ParameterName = "p_campo_output";
			s_campo_output.DbType = CustomDBType.VarChar;
			s_campo_output.Direction = ParameterDirection.Input;
			s_campo_output.Index = 3;
			s_campo_output.Value = campo_output;			
			s_campo_output.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 4;

			CollezioneControlli.Add(s_Tabella);
			CollezioneControlli.Add(s_campo);
			CollezioneControlli.Add(s_valore);
			CollezioneControlli.Add(s_campo_output);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_SEARCHDUPLICATO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			return _Ds;	
		}

		public DataSet ControllaDuplicatoRDL(string tabella, string campo_input, string valore, string valore2, string campo_output, string operazione)
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_Tabella = new S_Object();
			s_Tabella.ParameterName = "p_tabella";
			s_Tabella.DbType = CustomDBType.VarChar;
			s_Tabella.Direction = ParameterDirection.Input;
			s_Tabella.Index = 0;
			s_Tabella.Value = tabella ;			
			s_Tabella.Size = 50;

			S_Controls.Collections.S_Object s_campo = new S_Object();
			s_campo.ParameterName = "p_campo_input";
			s_campo.DbType = CustomDBType.VarChar;
			s_campo.Direction = ParameterDirection.Input;
			s_campo.Index = 1;
			s_campo.Value = campo_input;			
			s_campo.Size = 50;

			S_Controls.Collections.S_Object s_valore = new S_Object();
			s_valore.ParameterName = "p_valore";
			s_valore.DbType = CustomDBType.VarChar;
			s_valore.Direction = ParameterDirection.Input;
			s_valore.Index = 2;
			s_valore.Value = valore;			
			s_valore.Size = 50;

			S_Controls.Collections.S_Object s_valore2 = new S_Object();
			s_valore2.ParameterName = "p_valore2";
			s_valore2.DbType = CustomDBType.VarChar;
			s_valore2.Direction = ParameterDirection.Input;
			s_valore2.Index = 3;
			s_valore2.Value = valore2;			
			s_valore2.Size = 50;

			S_Controls.Collections.S_Object s_campo_output = new S_Object();
			s_campo_output.ParameterName = "p_campo_output";
			s_campo_output.DbType = CustomDBType.VarChar;
			s_campo_output.Direction = ParameterDirection.Input;
			s_campo_output.Index = 4;
			s_campo_output.Value = campo_output;			
			s_campo_output.Size = 50;

			S_Controls.Collections.S_Object s_operazione = new S_Object();
			s_operazione.ParameterName = "p_operazione";
			s_operazione.DbType = CustomDBType.VarChar;
			s_operazione.Direction = ParameterDirection.Input;
			s_operazione.Index = 5;
			s_operazione.Value = operazione;			
			s_operazione.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 6;

			CollezioneControlli.Add(s_Tabella);
			CollezioneControlli.Add(s_campo);
			CollezioneControlli.Add(s_valore);
			CollezioneControlli.Add(s_valore2);
			CollezioneControlli.Add(s_campo_output);
			CollezioneControlli.Add(s_operazione);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_SEARCHDUPLICATORDL";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			return _Ds;	
		}


		public DataSet ControllaDuplicatoPeriodo(string tabella, string campo_input, string campo_input1, string valore, string valore1, string campo_output)
		{
			S_ControlsCollection CollezioneControlli = new  S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_Tabella = new S_Object();
			s_Tabella.ParameterName = "p_tabella";
			s_Tabella.DbType = CustomDBType.VarChar;
			s_Tabella.Direction = ParameterDirection.Input;
			s_Tabella.Index = 0;
			s_Tabella.Value = tabella ;			
			s_Tabella.Size = 50;

			S_Controls.Collections.S_Object s_campo = new S_Object();
			s_campo.ParameterName = "p_campo_input";
			s_campo.DbType = CustomDBType.VarChar;
			s_campo.Direction = ParameterDirection.Input;
			s_campo.Index = 1;
			s_campo.Value = campo_input;			
			s_campo.Size = 50;

			S_Controls.Collections.S_Object s_campo1 = new S_Object();
			s_campo1.ParameterName = "p_campo_input1";
			s_campo1.DbType = CustomDBType.VarChar;
			s_campo1.Direction = ParameterDirection.Input;
			s_campo1.Index = 2;
			s_campo1.Value = campo_input1;			
			s_campo1.Size = 50;

			S_Controls.Collections.S_Object s_valore = new S_Object();
			s_valore.ParameterName = "p_valore";
			s_valore.DbType = CustomDBType.VarChar;
			s_valore.Direction = ParameterDirection.Input;
			s_valore.Index = 3;
			s_valore.Value = valore;			
			s_valore.Size = 50;

			S_Controls.Collections.S_Object s_valore1 = new S_Object();
			s_valore1.ParameterName = "p_valore1";
			s_valore1.DbType = CustomDBType.VarChar;
			s_valore1.Direction = ParameterDirection.Input;
			s_valore1.Index = 4;
			s_valore1.Value = valore;			
			s_valore1.Size = 50;

			S_Controls.Collections.S_Object s_campo_output = new S_Object();
			s_campo_output.ParameterName = "p_campo_output";
			s_campo_output.DbType = CustomDBType.VarChar;
			s_campo_output.Direction = ParameterDirection.Input;
			s_campo_output.Index = 5;
			s_campo_output.Value = campo_output;			
			s_campo_output.Size = 50;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 6;

			CollezioneControlli.Add(s_Tabella);
			CollezioneControlli.Add(s_campo);
			CollezioneControlli.Add(s_campo1);
			CollezioneControlli.Add(s_valore);
			CollezioneControlli.Add(s_valore1);
			CollezioneControlli.Add(s_campo_output);
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_SEARCHDUPLICATOPERIODO";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			return _Ds;	
		}



		public DataSet GetIdBL(string bl_id)
		{
			string sql = "select bl.id as id from bl where bl.bl_id='" + bl_id + "'";
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = sql;
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetWRfromWO(int wo_id)
		{
			string sql = "select wr.wr_id,wr.bl_id from  wr where wr.wo_id="+wo_id;
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = sql;
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}
		/// <summary>
		/// Restituisce la Parte Intera o quella Decimale di un numero
		/// </summary>
		/// <param name="numero">Numero che si vuole formattare</param>
		/// <param name="tipo">Indica la parte intera o decimale</param>
		/// <returns>- Stringa - Restituisce la Parte Intera o quella Decimale di un numero</returns>

		public static string GetTypeNumber (object numero,NumberType tipo)
		{
			
			if(System.Double.IsNaN(System.Double.Parse(numero.ToString())))
				return "";

			char[] del =",".ToCharArray();
			string[] num=numero.ToString().Split(del);
			
			if(num.Length>1)
			{
				if(tipo==NumberType.Intero)
					return num[0];
				else
					return num[1];			
			}
			else
			{
				if(tipo==NumberType.Intero)
					return num[0];			
				else
					return "00";			
			}
		}	

		public static string ImpostaMese(int mese,bool esteso)
		{
			if(esteso)
			{
				switch(mese)
				{
					case 1:										
						return "Gennaio";						
					case 2:	
						return "Febbraio";						
					case 3:
						return "Marzo";						
					case 4:
						return "Aprile";						
					case 5:
						return "Maggio";						
					case 6:
						return "Giugno";						
					case 7:
						return "Luglio";						
					case 8:
						return "Agosto";						
					case 9:
						return "Settembre";						
					case 10:
						return "Ottobre";						
					case 11:
						return "Novembre";						
					case 12:
						return "Dicembre";		
					default:
						return "";
			
				}	
			}
			else
			{
				switch(mese)
				{
					case 1:										
						return "Gen";						
					case 2:	
						return "Feb";						
					case 3:
						return "Mar";						
					case 4:
						return "Apr";						
					case 5:
						return "Mag";						
					case 6:
						return "Giu";						
					case 7:
						return "Lug";
					case 8:
						return "Ago";						
					case 9:
						return "Set";						
					case 10:
						return "Ott";						
					case 11:
						return "Nov";						
					case 12:
						return "Dic";
					default:
						return "";
				}	
			}

		}



	}
}
