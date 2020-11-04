using System;
using System.Web.UI.WebControls;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using ApplicationDataLayer.Collections;
using S_Controls;
using S_Controls.Collections;
using System.Data;

namespace TheSite.Classi.AnalisiStatistiche
{
	/// <summary>
	/// Descrizione di riepilogo per bindCombo.
	/// </summary>
	public class bindCombo : AbstractBase
	{
		private string _nomeSoredProcedure, _tipoValue,_testoItemZero;
		private DropDownList _cmb;
		public bindCombo(string nomeSoredProcedure,DropDownList cmb,string tipoValue)
		{
			_cmb = cmb;
			_tipoValue = tipoValue;
			_nomeSoredProcedure = nomeSoredProcedure;
			_testoItemZero = "";
		}
		
		public override DataSet GetData()
		{
			return null;
		}

		public override System.Data.DataSet GetData(S_Controls.Collections.S_ControlsCollection CollezioneControlli)
		{
			System.Data.DataSet _DSet;
			ApplicationDataLayer.OracleDataLayer _OraDl = new ApplicationDataLayer.OracleDataLayer(s_ConnStr);	
			_DSet =  _OraDl.GetRows(CollezioneControlli, _nomeSoredProcedure).Copy();
			return _DSet;	
		}
		public override System.Data.DataSet GetSingleData(int itemId)
		{
			return null;
		}
		protected override int ExecuteUpdate(S_Controls.Collections.S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			return 0;
		}


		public void getComboBox()
		{
			DataSet ds;
			ds = BindCmb(_nomeSoredProcedure);
			//ds = BindCmb("RapportiPdf.bind_edifici");
			DataTable dt = new DataTable();
			
			DataColumn dcTesto = colonna("testo","System.String");
			DataColumn dcValore = colonna("valore", _tipoValue);
			dt.Columns.Add(dcValore);
			dt.Columns.Add(dcTesto);
			
			DataRow drFirst = dt.NewRow();
			drFirst[1]=_testoItemZero;
			switch(_tipoValue)
			{
				case "System.String":
					drFirst[0]="";
					break;
				case "System.Int32":
					drFirst[0] = 0;
					break;
				default:
					drFirst[0]="";
					break;
			}
			dt.Rows.Add(drFirst);
			for(int i = 0; i <= ds.Tables[0].Rows.Count -1; i++)
			{
				DataRow dr = dt.NewRow();
				dr[0]=  ds.Tables[0].Rows[i][0];
				dr[1] = ds.Tables[0].Rows[i][1];
				dt.Rows.Add(dr);
			}
			DataView dv = new DataView(dt);
			_cmb.DataTextField = "Testo";
			_cmb.DataValueField = "Valore";
			_cmb.DataSource = dv;
			_cmb.DataBind();
		}
		private DataSet BindCmb(string StoredProcedure)
		{
			
			S_ControlsCollection clDatiRicerca = new S_ControlsCollection();

			if (StoredProcedure== "PACK_RPT_PIANO_MAN_PROG.GetEdifici")
			{
				S_Controls.Collections.S_Object s_p_username= new S_Object();
				s_p_username.ParameterName = "p_username";
				s_p_username.DbType =  CustomDBType.VarChar;
				s_p_username.Size=50;
				s_p_username.Value= System.Web.HttpContext.Current.User.Identity.Name;
				s_p_username.Direction = ParameterDirection.Input;
				s_p_username.Index = clDatiRicerca.Count;
				clDatiRicerca.Add(s_p_username);
			}
			S_Controls.Collections.S_Object Cursor = new S_Object();
			Cursor.ParameterName = "IO_CURSOR";
			Cursor.DbType =  CustomDBType.Cursor;
			Cursor.Direction = ParameterDirection.Output;
			Cursor.Index = clDatiRicerca.Count;
			clDatiRicerca.Add(Cursor);

			DataSet dsDatiRicerca = new DataSet();
			dsDatiRicerca = GetData(clDatiRicerca).Copy();
			return dsDatiRicerca;
		}
		private DataColumn colonna(string nome,string tipo)
		{
			DataColumn dc = new DataColumn(nome);
			dc.DataType = System.Type.GetType(tipo);
			return dc;
		}

		public string testoItemZero
		{
			get {return _testoItemZero;}
			set {_testoItemZero = value;}
		}
		public string nomeSoredProcedure
		{
			get {return _nomeSoredProcedure;}
			set {_nomeSoredProcedure = value;}
		}
		public string tipoValue
		{
			get {return _tipoValue;}
			set {_tipoValue = value;}
		}
		public DropDownList cmb
		{
			get {return _cmb;}
			set {_cmb = value;}
		}
	}
}
