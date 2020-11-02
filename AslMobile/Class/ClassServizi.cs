using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassServizi.
	/// </summary>
	public class ClassServizi: Abstract
	{
		private string userName;
		public ClassServizi(string user)
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
			this.userName = user;
		}
		public void setDropDownList(DropDownList Servizi,string CodEdificio)
		{
			Servizi.Items.Clear();

			DataSet Ds=	this.GetListaServizi(CodEdificio);
			
			if(Ds.Tables[0].Rows.Count > 0)
			{
				Servizi.DataSource = this.ItemBlankDataSource(Ds.Tables[0],"DESCRIZIONE", "IDSERVIZIO", "Non Definito", "0");
				Servizi.DataTextField = "DESCRIZIONE";
				Servizi.DataValueField = "IDSERVIZIO";
				Servizi.DataBind();
			}
			else
			{
				string s_Messagggio = "Non Definito";
				Servizi.Items.Add(new ListItem(s_Messagggio,"0"));
			}

		}
		private DataSet GetListaServizi(string CodEdificio)
		{
			string s_StrSql = "PACK_SERVIZI.SP_GETALLSERVIZI";

			OracleParameterCollection Coll= new OracleParameterCollection();
			if (CodEdificio!="")
			{
				OracleParameter  p_Bl_Id=new OracleParameter();
				p_Bl_Id.ParameterName="p_Bl_Id";
				p_Bl_Id.Size=8;
				p_Bl_Id.Direction=ParameterDirection.Input;
				p_Bl_Id.OracleType=OracleType.VarChar;
				p_Bl_Id.Value =CodEdificio;
				Coll.Add(p_Bl_Id);		
			

				OracleParameter  s_ID_Servizio=new OracleParameter();
				s_ID_Servizio.ParameterName="p_ID_Servizio";
				s_ID_Servizio.Direction=ParameterDirection.Input;
				s_ID_Servizio.OracleType=OracleType.Int32;
				s_ID_Servizio.Value =0;
				Coll.Add(s_ID_Servizio);
				s_StrSql = "PACK_SERVIZI.SP_GETSERVIZI";
			}

			OracleParameter  p_Username=new OracleParameter();
			p_Username.ParameterName="p_Username";
			p_Username.Size=50;
			p_Username.Direction=ParameterDirection.Input;
			p_Username.OracleType=OracleType.VarChar;
			p_Username.Value =this.userName;
			Coll.Add(p_Username);
			
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			

			DataSet _MyDs= base.GetData(Coll,s_StrSql);

			return _MyDs;
		}
	}
}
