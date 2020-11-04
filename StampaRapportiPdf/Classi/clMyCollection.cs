using System;
using System.Collections;
using System.Runtime.Serialization;


namespace StampaRapportiPdf.Classi
{


	public enum ParentType
	{
		Page = 0,
		WebControl = 1		
	}
	/// <summary>
	/// Descrizione di riepilogo per clMyCollection.
	/// </summary>
	/// 
	[Serializable()]
	public class clMyCollection
	{	
		ArrayList _myArray = new ArrayList();

		public void AddControl(System.Web.UI.ControlCollection ControlliWeb, ParentType _myParent)
		{				
			
			foreach (System.Web.UI.Control _Controllo in ControlliWeb)
			{
				clMyControl _myColl = new clMyControl(_myParent);						
	            
					if(_Controllo is System.Web.UI.WebControls.TextBox)
					{
						_myColl.Valore =((System.Web.UI.WebControls.TextBox)_Controllo).Text;
						_myColl.NomeControllo = ((System.Web.UI.WebControls.TextBox)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}
					if(_Controllo is System.Web.UI.HtmlControls.HtmlInputHidden)
					{
						_myColl.Valore =((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).Value;
						_myColl.NomeControllo = ((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}
					if(_Controllo is System.Web.UI.WebControls.Label)
					{
						_myColl.Valore =((System.Web.UI.WebControls.Label)_Controllo).Text;
						_myColl.NomeControllo =((System.Web.UI.WebControls.Label)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}
					if(_Controllo is System.Web.UI.WebControls.CheckBox)
					{
						_myColl.Valore =Convert.ToString(((System.Web.UI.WebControls.CheckBox)_Controllo).Checked);
						_myColl.NomeControllo =((System.Web.UI.WebControls.CheckBox)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}		
					if(_Controllo is System.Web.UI.WebControls.ListBox)
					{
						_myColl.Valore =((System.Web.UI.WebControls.ListBox)_Controllo).SelectedValue;
						_myColl.NomeControllo =((System.Web.UI.WebControls.ListBox)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}		
					if(_Controllo is System.Web.UI.WebControls.DropDownList)
					{
						_myColl.Valore =((System.Web.UI.WebControls.DropDownList)_Controllo).SelectedValue;
						_myColl.NomeControllo =((System.Web.UI.WebControls.DropDownList)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}
					if(_Controllo is System.Web.UI.WebControls.RadioButton)
					{
						_myColl.Valore =Convert.ToString(((System.Web.UI.WebControls.RadioButton)_Controllo).Checked);
						_myColl.NomeControllo =((System.Web.UI.WebControls.RadioButton)_Controllo).ClientID;
						_myArray.Add(_myColl);
					}	

								
				if (_Controllo.Controls.Count>0)
				{
					AddControl(_Controllo.Controls, _myParent);
				}
			}
		}

		public void SetValues(System.Web.UI.ControlCollection Controlli)
		{	
			foreach(System.Web.UI.Control _Controllo in Controlli)
			{
				foreach (clMyControl _myColl in _myArray)			
				{
					if(_myColl.NomeControllo==_Controllo.ClientID)
					{
							if (_Controllo is System.Web.UI.WebControls.TextBox)
							{                         
								((System.Web.UI.WebControls.TextBox)_Controllo).Text = _myColl.Valore;
							}
							if (_Controllo is System.Web.UI.HtmlControls.HtmlInputHidden)
	                        {					
								((System.Web.UI.HtmlControls.HtmlInputHidden)_Controllo).Value = _myColl.Valore;
							}
							if (_Controllo is System.Web.UI.WebControls.Label)
							{					
								((System.Web.UI.WebControls.Label)_Controllo).Text = _myColl.Valore;
							}
							if (_Controllo is System.Web.UI.WebControls.CheckBox)
							{					
								((System.Web.UI.WebControls.CheckBox)_Controllo).Checked =Convert.ToBoolean( _myColl.Valore);
							}
							if (_Controllo is System.Web.UI.WebControls.ListBox)						
							{
								((System.Web.UI.WebControls.ListBox)_Controllo).SelectedValue =_myColl.Valore;
							}
							if (_Controllo is System.Web.UI.WebControls.DropDownList)						
							{					
								((System.Web.UI.WebControls.DropDownList)_Controllo).SelectedValue =_myColl.Valore;
							}
							if (_Controllo is System.Web.UI.WebControls.RadioButton)						
							{											
								((System.Web.UI.WebControls.RadioButton)_Controllo).Checked =Convert.ToBoolean( _myColl.Valore);
							}						
					}
				}
				
				if (_Controllo.Controls.Count  >0)
				{
					SetValues(_Controllo.Controls);
				}
			}

		}

	}
	[Serializable()]
	public class clMyControl
			{
				
				string _valore;
				string _NomeControllo;
				public ParentType _parent = ParentType.Page;

				public clMyControl(ParentType myParent)	
				{
					this._parent = myParent;
				}
			

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
