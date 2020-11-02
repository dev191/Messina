using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassRichiedenti.
	/// </summary>
	public class ClassRichiedenti : Abstract
	{
		string UserName=string.Empty;

		public ClassRichiedenti(string username)
		{
		  UserName=username;
		}
		public DataSet GetRichiedenti(string NomeCompleto)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();		
		
			OracleParameter s_p_NomeCompleto = new OracleParameter();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.OracleType =OracleType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Value = NomeCompleto;
			Coll.Add(s_p_NomeCompleto);			

			OracleParameter s_Cursor = new OracleParameter();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.OracleType = OracleType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			Coll.Add(s_Cursor);
			
											
			DataSet _MyDs= base.GetData(Coll,"PACK_MAN_ORD.SP_GetRichiedenti");

			return _MyDs;	
		}

		public void setBinding(DataGrid Ctrl,string richiede)
		{
			DataSet Ds=	this.GetRichiedenti(richiede);
			if (Ds.Tables[0].Rows.Count >0)
			{
				Ctrl.DataSource=Ds.Tables[0];
				Ctrl.DataBind();
			}
		}
		private DataSet GetListaServizi(string CodEdificio)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();

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

			OracleParameter  p_Username=new OracleParameter();
			p_Username.ParameterName="p_Username";
			p_Username.Size=50;
			p_Username.Direction=ParameterDirection.Input;
			p_Username.OracleType=OracleType.VarChar;
			p_Username.Value =this.UserName;
			Coll.Add(p_Username);
			
			OracleParameter  PaCursor=new OracleParameter();
			PaCursor.ParameterName="IO_CURSOR";
			PaCursor.Direction=ParameterDirection.Output;
			PaCursor.OracleType=OracleType.Cursor;
			Coll.Add(PaCursor);
			

			DataSet _MyDs= base.GetData(Coll,"PACK_SERVIZI.SP_GETSERVIZI");

			return _MyDs;
		}

	}
}
