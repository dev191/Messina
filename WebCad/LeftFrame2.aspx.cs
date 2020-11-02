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
using Microsoft.Web.UI.WebControls;
using WebCad.Classi.ClassiAnagrafiche;
using WebCad.WebControls;
using WebCad.WiewCad;
using WebCad.Edifici;

namespace WebCad
{

	public struct ParametriRicerca
	{
		public string tipo;
		public int tipoDataSet;
		public int blId;
		public int flId;
		public int servizioId;
		public string rmIds;
		public int catId;
		public int repartoId;
		public int destUsoId;
		public string stdEqIds;
		public string eqIds;
		public string ordinamento;
		public string fileDwg;

	}

	/// <summary>
	/// Descrizione di riepilogo per LeftFrame.
	/// </summary>
	public class LeftFrame2 : System.Web.UI.Page    // System.Web.UI.Page
	{

		
		/// <summary>
		/// idbl reppresenta l'Id dell'edificio
		/// idpiano reppresenta l'Id del piano
		/// </summary>
		

		protected MyDropDownList CategorieDropDownList;
		protected MyDropDownList repartiDropDownList;
		protected MyDropDownList destUsoDropDownList;
		protected WebControls.WebUserControlTreeView WebUserControlTreeView1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenEq;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenStanze;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenEqstd;
		protected System.Web.UI.HtmlControls.HtmlSelect ListBoxEQSTD;
		protected System.Web.UI.HtmlControls.HtmlSelect listBoxEQ;
		protected System.Web.UI.HtmlControls.HtmlSelect ListBoxStanze;
		protected System.Web.UI.HtmlControls.HtmlInputHidden stanzeDescription;
		protected System.Web.UI.HtmlControls.HtmlInputHidden eqDescription;
		protected System.Web.UI.HtmlControls.HtmlInputHidden eqStdDescription;

		protected System.Web.UI.WebControls.TextBox idEdif;
		protected System.Web.UI.WebControls.TextBox idPian;

		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPlanimetria;
		protected System.Web.UI.WebControls.Button btnVisualizzaEq;
		protected System.Web.UI.WebControls.Button btnVisualizza;		
		protected System.Web.UI.WebControls.Button Reset;

		protected string scriptDaEseguire="";
		//private bool _visDwf=false;		
		//private bool _visBl=false;
		protected string contesto;
		protected System.Web.UI.WebControls.TextBox idServ;
		protected System.Web.UI.WebControls.Button btnVisualizzaBlTree;
		protected System.Web.UI.WebControls.TextBox txtFiltraBlTree;
		protected string listBoxEQClId;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			this.listBoxEQClId=listBoxEQ.ClientID;

			ListBoxStanze.Attributes.Add("onkeydown","deleteitem(this,event);"); 
			ListBoxEQSTD.Attributes.Add("onkeydown","deleteitem(this,event);"); 
			listBoxEQ.Attributes.Add("onkeydown","deleteitem(this,event);"); 
			//btnVisualizza.Attributes.Add("onclick","AbilitaVisualizzaStatnze()");
			if(!IsPostBack)
			{
				//BindServizi();
				BindCategorie();
				BindReparti();
				BindDestUso();
//				DataSet ds = new WiewCad.Edifici().GetData();
//				WebUserControlTreeView1.BindData(ds);
//				idEdif.Text=Convert.ToString(ViewState["idBl"]);
//				idPian.Text=Convert.ToString(ViewState["idFl"]);
				ViewState["contesto"]="edificio";
			} 
			else 
			{
				;	
			}
			contesto = Convert.ToString(ViewState["contesto"]);

			if(Request["FromPaginaCreazioneRdl"]!=null)
			{
				InpostaNodoAlbero();
				RiempiTxtEdificioPianoServ();
			}
			if(Request["FromPaginaApprovaEmettiRdl"]!=null)
			{
				InpostaNodoAlbero();
				RiempiTxtEdificioPianoServPlanimetria();
			}

		}

		private void SetBlFl(int idBl, int idFl)
		{
			ViewState["idBl"]=idBl;
			ViewState["idFl"]=idFl;
		}

		/// <summary>
		/// Recupera tutte le categorie
		/// </summary>
		private void InpostaNodoAlbero()
		{
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdBl=  BlId_To_IdBl(BlId);
			WebUserControlTreeView1.SelezionaNodo(IdBl.ToString(), IdPiano.ToString());
		}
		private void RiempiTxtEdificioPianoServ()
		{
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdServizio = 0;
			if(Request["IdServizio"]!=String.Empty)
			{
				IdServizio = Convert.ToInt32(Request["IdServizio"]);
			}
			int IdBl=  BlId_To_IdBl(BlId);
			idEdif.Text = IdBl.ToString();
			idPian.Text = IdPiano.ToString();
			idServ.Text = IdServizio.ToString();
		}
		private void RiempiTxtEdificioPianoServPlanimetria()
		{
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdServizio = 0;
			if(Request["IdServizio"]!=String.Empty)
			{
				IdServizio = Convert.ToInt32(Request["IdServizio"]);
			}
			int IdBl=  BlId_To_IdBl(BlId);
			idEdif.Text = IdBl.ToString();
			idPian.Text = IdPiano.ToString();
			idServ.Text = IdServizio.ToString();
			hiddenPlanimetria.Value = Request["Planimetria"];
		}
		private int BlId_To_IdBl(string BlId)
		{
			WebCad.Classi.ClassiAnagrafiche.Buildings IdBlFromBlId = new WebCad.Classi.ClassiAnagrafiche.Buildings();
			return IdBlFromBlId.GetIdBl(BlId);
		}
		private void BindCategorie()
		{
			Categorie _categorie = new Categorie();
			DataSet Ds= _categorie.GetData();
			CategorieDropDownList.SetDataSet("descrizione","idcategoria","Tutte le categorie",Ds);
			CategorieDropDownList.SetLabel("Categorie");
		}

		/// <summary>
		/// Recupera tutti i reparti
		/// </summary>
		private void BindReparti()
		{
			Reparti _reparti = new Reparti();
			DataSet Ds= _reparti.GetData();
			repartiDropDownList.SetDataSet("reparto","idreparto","Tutti i reparti",Ds);
			repartiDropDownList.SetLabel("Reparti");
		}

		/// <summary>
		/// Recupera tutte le destinazioni d'uso
		/// </summary>
		private void BindDestUso()
		{
			DestUso _destUso = new DestUso();
			DataSet Ds= _destUso.GetData();
			destUsoDropDownList.SetDataSet("reparto","idreparto","Tutte le destinazioni d'uso",Ds);
			destUsoDropDownList.SetLabel("Destinazione d'uso");
		}
		

		/// <summary>
		/// Recupera i Servizi legati all'edificio
		/// </summary>
//		private void BindServizi()
//		{
//		  Servizi _Servizi = new Servizi();
//          DataSet Ds= _Servizi.GetServiziEdifici(int.Parse(this.idbl));
//		  CheckBoxServizi.DataTextField="Descrizione";
//		  CheckBoxServizi.DataValueField="id";
//		  CheckBoxServizi.DataSource=Ds.Tables[0];
//		  CheckBoxServizi.DataBind();
//		}
		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata è richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnVisualizzaBlTree.Click += new System.EventHandler(this.btnVisualizzaBlTree_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LoadListStanze()
		{
			string[] Ite = stanzeDescription.Value.Split(new char[] {','});
			string[] Itevalue = hiddenStanze.Value.Split(new char[] {','});
			ListBoxStanze.Items.Clear(); 
			Int32 j=0;
			foreach (string itestr in Itevalue)
			{				
				ListBoxStanze.Items.Add(new ListItem(Ite[j],itestr )); 
				j+=1;
			}
		}

		private void LoadListEq()
		{

			string[] Ite = eqDescription.Value.Split(new char[] {','});
			string[] Itevalue = hiddenEq.Value.Split(new char[] {','});
			listBoxEQ.Items.Clear(); 
			Int32 j=0;
			foreach (string itestr in Itevalue)
			{
				listBoxEQ.Items.Add(new ListItem(Ite[j],itestr )); 
				j+=1;
			}
		}


		private void LoadListEqStd()
		{

			string[] Ite = eqStdDescription.Value.Split(new char[] {','});
			string[] Itevalue = hiddenEqstd.Value.Split(new char[] {','});
			ListBoxEQSTD.Items.Clear(); 
			Int32 j=0;
			foreach (string itestr in Itevalue)
			{
				ListBoxEQSTD.Items.Add(new ListItem(Ite[j],itestr )); 
				j+=1;
			}
		}

		private void SetParametri(string tipo, int td)
		{
			ParametriRicerca parametri = new ParametriRicerca();
			parametri.tipoDataSet=td;
			parametri.tipo=tipo;
			//parametri.blId= Convert.ToInt32(WebUserControlTreeView1.getSelectedEdificio());
			//parametri.flId= Convert.ToInt32(WebUserControlTreeView1.getSelectedPiano());

			parametri.blId= Convert.ToInt32(idEdif.Text);
			parametri.flId= Convert.ToInt32(idPian.Text);
			parametri.fileDwg=hiddenPlanimetria.Value;

			SetBlFl(Convert.ToInt32(idEdif.Text),Convert.ToInt32(idPian.Text));

			LoadListStanze();
			string stringaRm = "";
			foreach (ListItem rm in ListBoxStanze.Items)
			{
				if (stringaRm=="")
				{
					stringaRm+=rm.Value;
				}
				else
				{
					stringaRm+=","+rm.Value;
				}
			}
			parametri.rmIds=stringaRm;


			if(CategorieDropDownList.getTesto()!="")
				parametri.catId=Convert.ToInt32(CategorieDropDownList.getTesto());
			else parametri.catId=0;
			if(repartiDropDownList.getTesto()!="")
				parametri.repartoId=Convert.ToInt32(repartiDropDownList.getTesto());
			else parametri.repartoId=0;
			if(destUsoDropDownList.getTesto()!="")
				parametri.destUsoId=Convert.ToInt32(destUsoDropDownList.getTesto());
			else parametri.destUsoId=0;
		
			LoadListEq();
			string stringaEq="";
			foreach (ListItem eq in listBoxEQ.Items)
			{
				if (stringaEq=="")
					stringaEq+=eq.Value;
				else
					stringaEq+=","+eq.Value;
			}
			parametri.eqIds=stringaEq;

			LoadListEqStd();
			string stringaEqStd="";
			foreach (ListItem eq in ListBoxEQSTD.Items)
			{
				if (stringaEqStd=="")
					stringaEqStd+=eq.Value;
				else
					stringaEqStd+=","+eq.Value;
			}
			parametri.stdEqIds=stringaEqStd;
			Session["parametri"]=parametri;
		}

		private void btnVisualizzaBlTree_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new WiewCad.Edifici().GetDataByCampus(txtFiltraBlTree.Text);
			WebUserControlTreeView1.BindData(ds);
			idEdif.Text=Convert.ToString(ViewState["idBl"]);
			idPian.Text=Convert.ToString(ViewState["idFl"]);
		}

	}
}
