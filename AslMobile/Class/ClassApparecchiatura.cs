using System;
using System.Data;
using System.Data.OracleClient; 
using System.Web.UI.WebControls;

namespace TheSite.AslMobile.Class
{
	/// <summary>
	/// Descrizione di riepilogo per ClassApparecchiatura.
	/// </summary>
	public class ClassApparecchiatura: Abstract
	{
		private string userName;

		public ClassApparecchiatura(string user)
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
			this.userName=user;
		}
		public void setDropDownListApparecchiature(DropDownList Apparecchiature,string CodEdificio,string CodServizi)
		{
			Apparecchiature.Items.Clear();
			string s_Messaggio = "- Selezionare uno Standard -";

			if (CodEdificio != string.Empty && CodServizi != "0")
			{
				DataSet Ds=	this.GetListaApparecchiatura(CodEdificio,CodServizi);
				if(Ds.Tables[0].Rows.Count > 0)
				{
					Apparecchiature.DataSource = this.ItemBlankDataSource(Ds.Tables[0],"DESCRIZIONE", "ID", s_Messaggio, "0");
					Apparecchiature.DataTextField = "DESCRIZIONE";
					Apparecchiature.DataValueField = "ID";
					Apparecchiature.DataBind();
				}
				else
				{
					Apparecchiature.Items.Add(new ListItem(s_Messaggio,"0"));
				}
			}
			else
			{
				Apparecchiature.Items.Add(new ListItem(s_Messaggio,"0"));
			}

		}
		public void setDropListCodApparecchiatura(DropDownList Apparecchiature, string CodEdificio,string CodServizio,string Apparecchiatura)
		{
			Apparecchiature.Items.Clear();
			string s_Messagggio = "- Selezionare una Apparecchiatura -";

			if (CodEdificio != string.Empty && CodServizio != "0" && Apparecchiatura !="0")
			{
				DataSet Ds=	this.GetCodApparecchiature(CodEdificio,CodServizio,Apparecchiatura);
				if(Ds.Tables[0].Rows.Count > 0)
				{
					Apparecchiature.DataSource = this.ItemBlankDataSource(Ds.Tables[0],"ID", "id_eq", s_Messagggio , "0");
					Apparecchiature.DataTextField = "ID";
					Apparecchiature.DataValueField = "id_eq";
					Apparecchiature.DataBind();
				}
				else
				{
					Apparecchiature.Items.Add(new ListItem(s_Messagggio,"0"));
				}
			}
			else
			{
				Apparecchiature.Items.Add(new ListItem(s_Messagggio,"0"));
			}
		}
		private DataSet GetCodApparecchiature(string CodEdificio,string CodServizio,string Apparecchiatura)
		{
			System.Data.OracleClient.OracleParameterCollection Coll= new System.Data.OracleClient.OracleParameterCollection();

			System.Data.OracleClient.OracleParameter  p_Bl_Id=new System.Data.OracleClient.OracleParameter();
			p_Bl_Id.ParameterName="p_Bl_Id";
			p_Bl_Id.Size=50;
			p_Bl_Id.Direction=ParameterDirection.Input;
			p_Bl_Id.OracleType=OracleType.VarChar;
			p_Bl_Id.Value ="";
			Coll.Add(p_Bl_Id);		

			OracleParameter  s_p_campus=new OracleParameter();
			s_p_campus.ParameterName="p_campus";
			s_p_campus.Direction=ParameterDirection.Input;
			s_p_campus.OracleType=OracleType.VarChar;
			s_p_campus.Value =CodEdificio;
			Coll.Add(s_p_campus	);	

			OracleParameter  s_p_Servizio=new OracleParameter();
			s_p_Servizio.ParameterName="p_Servizio";
			s_p_Servizio.Direction=ParameterDirection.Input;
			s_p_Servizio.OracleType=OracleType.Int32;
			s_p_Servizio.Value =(CodServizio == "")? 0:Int32.Parse(CodServizio);
			Coll.Add( s_p_Servizio );	


			OracleParameter  s_p_eqstdid=new OracleParameter();
			s_p_eqstdid.ParameterName="p_eqstdid";
			s_p_eqstdid.Direction=ParameterDirection.Input;
			s_p_eqstdid.OracleType=OracleType.Int32;
			s_p_eqstdid.Value =(Apparecchiatura == "")? 0:Int32.Parse(Apparecchiatura);
			s_p_eqstdid.Size =8;
			Coll.Add( s_p_eqstdid );	


			OracleParameter  s_p_eq_id=new OracleParameter();
			s_p_eq_id.ParameterName="p_eq_id";
			s_p_eq_id.Direction=ParameterDirection.Input;
			s_p_eq_id.OracleType=OracleType.VarChar;
			s_p_eq_id.Value ="";//(cmbEQ.SelectedValue==string.Empty)? "":cmbEQ.Items[cmbEQ.SelectedIndex].Text;
			s_p_eq_id.Size =50;
			Coll.Add( s_p_eq_id );	

			// 19-07-2005 Armando: aggiunto parametro
			OracleParameter  p_dismesso=new OracleParameter();
			p_dismesso.ParameterName="p_dismesso";
			p_dismesso.Direction=ParameterDirection.Input;
			p_dismesso.OracleType=OracleType.Int32;
			p_dismesso.Value =0;
			Coll.Add( p_dismesso );	
			// Armando fine

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
			

			DataSet _MyDs= base.GetData(Coll,"PACK_APPARECCHIATURE.SP_RICERCAAPPARECCHIATURA");

			return _MyDs;
		}

		private DataSet GetListaApparecchiatura(string CodEdificio,string CodServizio)
		{
			OracleParameterCollection Coll= new OracleParameterCollection();

			OracleParameter  p_Bl_Id=new OracleParameter();
			p_Bl_Id.ParameterName="p_Bl_Id";
			p_Bl_Id.Size=50;
			p_Bl_Id.Direction=ParameterDirection.Input;
			p_Bl_Id.OracleType=OracleType.VarChar;
			p_Bl_Id.Value =CodEdificio;
			Coll.Add(p_Bl_Id);		
		

			OracleParameter  s_ID_Servizio=new OracleParameter();
			s_ID_Servizio.ParameterName="p_Servizio";
			s_ID_Servizio.Direction=ParameterDirection.Input;
			s_ID_Servizio.OracleType=OracleType.Int32;
			s_ID_Servizio.Value =(CodServizio == "")? 0:Int32.Parse(CodServizio);
			Coll.Add(s_ID_Servizio);	


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
			

			DataSet _MyDs= base.GetData(Coll,"PACK_APPARECCHIATURE.SP_GETSTDAPPARECCHIATURE");

			return _MyDs;
		}

	}
}
