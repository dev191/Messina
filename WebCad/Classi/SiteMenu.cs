using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;

namespace WebCad.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per SiteMenu.
	/// </summary>
	public class SiteMenu
	{
		#region Dichiarazioni

		private string s_ConnStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];						

		#endregion

		public SiteMenu()
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public System.IO.StringWriter GetMenu()
		{
			System.Xml.XmlDocument _xdoc = new System.Xml.XmlDocument();

			System.IO.StringWriter _Xss = new System.IO.StringWriter();
			XmlTextWriter _xTxtW = new XmlTextWriter(_Xss);
			_xTxtW.Formatting = Formatting.Indented;
		
			_xTxtW.Indentation = 2;
			_xTxtW.WriteStartDocument(true);
			_xTxtW.WriteStartElement("menu");

			this.ItemMenu(0,_xTxtW);

			_xTxtW.WriteEndElement();
			_xTxtW.WriteEndDocument();
			_xTxtW.Close();			

			return _Xss;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IdMenuPadre"></param>
		/// <param name="xTextWriter"></param>
		private void ItemMenu(int IdMenuPadre, XmlTextWriter xTextWriter)
		{
			if (IdMenuPadre > 0)
				xTextWriter.WriteStartElement("subMenu");			
			
			try 
			{				
				DataSet _MyDs = this.GetItemMenuData(IdMenuPadre);
				
				if (_MyDs.Tables[0].Rows.Count > 0)
				{
					Sicurezza _Sic = new Sicurezza();
					foreach(DataRow DtRo in _MyDs.Tables[0].Rows)
					{				
													
						xTextWriter.WriteStartElement("menuItem");
						xTextWriter.WriteElementString("text",DtRo["DESCRIZIONE"].ToString());
						if (DtRo["LINK"] != DBNull.Value && DtRo["LINK"].ToString() != "")
						{
							string s_FunzioneId = DtRo["FUNZIONE_ID"].ToString();
							string s_Link = DtRo["LINK"].ToString();
							s_Link += "?FunId=" + s_FunzioneId;
							xTextWriter.WriteElementString("url",s_Link);
						}
						
						xTextWriter.WriteElementString("target",DtRo["TARGET"].ToString());
						xTextWriter.WriteElementString("tooltip",DtRo["TOOLTIP"].ToString());
						xTextWriter.WriteElementString("cssclass",DtRo["CSSCLASS"].ToString());
				
						int i_Totf = 0;
						if (DtRo["TOTF"].ToString().Trim() == "")
							i_Totf = 0;
						else
							i_Totf = Convert.ToInt32(DtRo["TOTF"].ToString());
						if (i_Totf > 0)
							ItemMenu(Convert.ToInt32(DtRo["FUNZIONE_MENU_ID"]), xTextWriter);

						xTextWriter.WriteEndElement();
				
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (IdMenuPadre > 0)
					xTextWriter.WriteEndElement();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="IdMenuPadre"></param>
		/// <returns></returns>
		private DataSet GetItemMenuData(int IdMenuPadre)
		{			
			
			System.Web.HttpContext context = System.Web.HttpContext.Current;

			ParameterObjectCollection _PColl = new ParameterObjectCollection();
			
			ParameterObject _PMenuPadreId = new ParameterObject();

			_PMenuPadreId.ParameterName = "p_Menu_Padre_Id";
			_PMenuPadreId.DbType = CustomDBType.Integer;
			_PMenuPadreId.Direction = ParameterDirection.Input;
			_PMenuPadreId.Value = IdMenuPadre;
			_PMenuPadreId.Index = 0;

			ParameterObject _PRuoli = new ParameterObject();
			_PRuoli.ParameterName = "p_UserName";
			_PRuoli.DbType = CustomDBType.VarChar;
			_PRuoli.Direction = ParameterDirection.Input;
			_PRuoli.Value = context.User.Identity.Name;
			_PRuoli.Index = 1;
			
			ParameterObject _PCursor = new ParameterObject();

			_PCursor.ParameterName = "IO_CURSOR";
			_PCursor.DbType = CustomDBType.Cursor;
			_PCursor.Direction = ParameterDirection.Output;
			_PCursor.Index = 2;

			_PColl.Add(_PMenuPadreId);
			_PColl.Add(_PRuoli);
			_PColl.Add(_PCursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			DataSet _MyDs = _OraDl.GetRows(_PColl, "PACK_UTENTI.SP_MENU_UTENTI").Copy();

			return  _MyDs;

		}

	}
}
