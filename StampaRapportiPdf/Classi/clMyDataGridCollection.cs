using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using S_Controls.Collections;
using ApplicationDataLayer.DBType;
using System.Reflection;

namespace StampaRapportiPdf.Classi
{
	/// <summary>
	/// Descrizione di riepilogo per clMyDataGridCollection.
	/// </summary>
	public class clMyDataGridCollection
	{
		public clMyDataGridCollection()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}

		public Hashtable SetControl(System.Web.UI.WebControls.DataGrid _MyGrid,Hashtable _HS,int pagina)
		{	
			foreach(DataGridItem o_Litem in _MyGrid.Items)
			{	
				for(int i=0;i<o_Litem.Cells.Count;i++)
				{
					SetVal(o_Litem.Cells[i].Controls,_HS,pagina);					
				}				
			}
			return _HS;			
		}

		public void GetControl(System.Web.UI.WebControls.DataGrid _MyGrid,Hashtable _HS,int pagina)
		{	
			foreach(DataGridItem o_Litem in _MyGrid.Items)
			{	
				for(int i=0;i<o_Litem.Cells.Count;i++)
				{
					GetVal(o_Litem.Cells[i].Controls,_HS,pagina);					
				}				
			}				
		}

		private void SetVal(System.Web.UI.ControlCollection ControlliWeb,Hashtable _HS,int pagina)
		{				
			clMyControl _myColl = new clMyControl();						
			
			foreach (System.Web.UI.Control _Controllo in ControlliWeb)
			{				            
				if(_Controllo is System.Web.UI.WebControls.TextBox)
				{
					_myColl.Valore =((System.Web.UI.WebControls.TextBox)_Controllo).Text;
					_myColl.NomeControllo = ((System.Web.UI.WebControls.TextBox)_Controllo).ClientID + pagina.ToString();													

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);								
				}
				if(_Controllo is System.Web.UI.HtmlControls.HtmlInputHidden)
				{
					_myColl.Valore =((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).Value;
					_myColl.NomeControllo = ((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).ClientID + pagina.ToString();										

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);				
				}
				if(_Controllo is System.Web.UI.WebControls.Label)
				{
					_myColl.Valore =((System.Web.UI.WebControls.Label)_Controllo).Text;
					_myColl.NomeControllo =((System.Web.UI.WebControls.Label)_Controllo).ClientID + pagina.ToString();										

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);				
				}
				if(_Controllo is System.Web.UI.WebControls.CheckBox)
				{
					_myColl.Valore =Convert.ToString(((System.Web.UI.WebControls.CheckBox)_Controllo).Checked);
					_myColl.NomeControllo =((System.Web.UI.WebControls.CheckBox)_Controllo).ClientID + pagina.ToString();					

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);				
					
				}		
				if(_Controllo is System.Web.UI.WebControls.ListBox)
				{
					_myColl.Valore =((System.Web.UI.WebControls.ListBox)_Controllo).SelectedValue;
					_myColl.NomeControllo =((System.Web.UI.WebControls.ListBox)_Controllo).ClientID + pagina.ToString();					

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);				
					
				}		
				if(_Controllo is System.Web.UI.WebControls.DropDownList)
				{
					_myColl.Valore =((System.Web.UI.WebControls.DropDownList)_Controllo).SelectedValue;
					_myColl.NomeControllo =((System.Web.UI.WebControls.DropDownList)_Controllo).ClientID + pagina.ToString();					

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);				
					
				}
				if(_Controllo is System.Web.UI.WebControls.RadioButton)
				{
					_myColl.Valore =Convert.ToString(((System.Web.UI.WebControls.RadioButton)_Controllo).Checked);
					_myColl.NomeControllo =((System.Web.UI.WebControls.RadioButton)_Controllo).ClientID + pagina.ToString();				

					string id = _myColl.NomeControllo;
					if(_HS.ContainsKey(id))
						_HS.Remove(id);								
					_HS.Add(id,_myColl.Valore);				
					
				}
								
				if (_Controllo.Controls.Count>0)
				{
					SetVal(_Controllo.Controls,_HS,pagina);
				}
			}
		}

		private void GetVal(System.Web.UI.ControlCollection ControlliWeb,Hashtable _HS,int pagina)
		{				
			string id = String.Empty;					
			
			foreach (System.Web.UI.Control _Controllo in ControlliWeb)
			{				            
				if(_Controllo is System.Web.UI.WebControls.TextBox)
				{	
					id = ((System.Web.UI.WebControls.TextBox)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.WebControls.TextBox)_Controllo).Text = _HS[id].ToString();
				}
				if(_Controllo is System.Web.UI.HtmlControls.HtmlInputHidden)
				{
					id = ((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).Value = _HS[id].ToString();
				}
				if(_Controllo is System.Web.UI.WebControls.Label)
				{
					id = ((System.Web.UI.WebControls.Label)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.WebControls.Label)_Controllo).Text = _HS[id].ToString();
				}
				if(_Controllo is System.Web.UI.WebControls.CheckBox)
				{
					id = ((System.Web.UI.WebControls.CheckBox)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.WebControls.CheckBox)_Controllo).Checked = Boolean.Parse(_HS[id].ToString());
				}		
				if(_Controllo is System.Web.UI.WebControls.ListBox)
				{
					id = ((System.Web.UI.WebControls.ListBox)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.WebControls.ListBox)_Controllo).SelectedValue = _HS[id].ToString();
				}		
				if(_Controllo is System.Web.UI.WebControls.DropDownList)
				{
					id = ((System.Web.UI.WebControls.DropDownList)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.WebControls.DropDownList)_Controllo).SelectedValue = _HS[id].ToString();
					
				}
				if(_Controllo is System.Web.UI.WebControls.RadioButton)
				{
					id = ((System.Web.UI.WebControls.RadioButton)_Controllo).ClientID + pagina.ToString();																		
					if(_HS.ContainsKey(id))
						((System.Web.UI.WebControls.RadioButton)_Controllo).Checked = Boolean.Parse(_HS[id].ToString());					
				}
								
				if (_Controllo.Controls.Count>0)
				{
					GetVal(_Controllo.Controls,_HS,pagina);
				}
			}
		}


		public class clMyControl
		{
				
			string _valore;
			string _NomeControllo;		

			public string Valore
			{
				get
				{
					return _valore;
				}

				set
				{
					_valore = value;
				}
		
			}

			public string NomeControllo
			{
				get
				{
					return _NomeControllo;
				}

				set
				{
					_NomeControllo = value;
				}
				
			}
		}

	}
}
