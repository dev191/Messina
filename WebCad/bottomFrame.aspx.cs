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
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;
using WebCad.WiewCad;
using WebCad.WebControls;


namespace WebCad
{
	public enum TipoDatagrid
	{
		SelezionePlanimetria = 1,
		NavigazioneSpazi=2,
		NavigazioneApparati=3
		
	};
	/// <summary>
	/// Descrizione di riepilogo per bottomFrame.
	/// </summary>
	public class bottomFrame : System.Web.UI.Page    // System.Web.UI.Page, IDataGridDinamico
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden tipo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden categoria;
		protected System.Web.UI.HtmlControls.HtmlInputHidden reparto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden destUso;
		protected System.Web.UI.HtmlControls.HtmlInputHidden stanze;
		protected System.Web.UI.HtmlControls.HtmlInputHidden stdApp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden App;
		protected DataGridRicercaCad DataGridRicercaCad1;
		protected string vbScriptDaEseguire="";
		protected System.Web.UI.HtmlControls.HtmlInputHidden accoda;
		private bool accodaselezioni=true;
		//protected string SetPlanimetriaFromApprovaEmettiRdl;

		public string stringaLayerStanze
		{
			get
			{ 
				return _listaEdifici;
			}
		}

		private void Page_Load(object sender, System.EventArgs e){

			if(Request.QueryString["accoda"]!=null)
			{
				if(Request.QueryString["accoda"]=="1")
					accodaselezioni=true;
				else
					accodaselezioni=false;
			}

			if (!IsPostBack)
			{
				if (Session["parametri"]!=null)
				{
					if(Convert.ToInt32(Request.Form["tipo"])>0)
						SetParametri(Convert.ToInt32(Request.Form["tipo"]));
				}
				if(Request["FromPaginaCreazioneRdl"]!=null)
				{
					DgSceltaPlanFromCreazioneRdl();
					return;
				}
				if(Request["FromPaginaApprovaEmettiRdl"]!=null)
				{
					DgSceltaPlanFromApprovaEmettiRdl();
					return;
				}
				if (Request.QueryString["idFl"]!=null)
				{
					DgSceltaPlan();
					return;
				}

				if (Request.QueryString["NomeFile"]!=null)
				{
					if (Session["parametri"]!=null)
					{
						WebCad.ParametriRicerca paremetri =(WebCad.ParametriRicerca)Session["parametri"];
						paremetri.fileDwg=Request.QueryString["NomeFile"].ToString();
						Session["parametri"]=paremetri;
					}
				}
	
				if (Request.QueryString["eq_id"]!=null)
				{
					string eq_id= Request.QueryString["eq_id"].ToString();
					int idEq = getSelectedEd(eq_id);
			

					if (Session["parametri"]!=null)
					{
						WebCad.ParametriRicerca paremetri =(WebCad.ParametriRicerca)Session["parametri"];
						if (accodaselezioni)
						{
							if (paremetri.eqIds==null)
								paremetri.eqIds=String.Empty;

							if(paremetri.eqIds.Trim()=="")
							{
								paremetri.eqIds=idEq.ToString();
							}
							else
							{
								paremetri.eqIds+=","+idEq.ToString();
							}
						}
						else
						{
							paremetri.eqIds=idEq.ToString();
						}
						paremetri.rmIds=string.Empty;
						paremetri.tipoDataSet=(int)TipoDatagrid.NavigazioneApparati;
						paremetri.stdEqIds=string.Empty;
						Session["parametri"]=paremetri;
					}
				}

				if (Request.QueryString["rm_id"]!=null)
				{
					if (Session["parametri"]!=null)
					{
						WebCad.ParametriRicerca paremetri =(WebCad.ParametriRicerca)Session["parametri"];
						string rm_id= Request.QueryString["rm_id"].ToString();
						int idRm = getSelectedRm(rm_id, paremetri.fileDwg);		
				
						if (accodaselezioni)
						{
							if (paremetri.rmIds==null)
								paremetri.rmIds=String.Empty;

							if(paremetri.rmIds.Trim()=="")
							{
								paremetri.rmIds=idRm.ToString();
							}
							else
							{
								paremetri.rmIds+=","+idRm.ToString();
							}
						}
						else
						{
							paremetri.rmIds=idRm.ToString();
						}
						paremetri.eqIds=string.Empty;
						paremetri.stdEqIds=string.Empty;
						paremetri.tipoDataSet=(int)TipoDatagrid.NavigazioneSpazi;
						Session["parametri"]=paremetri;
					}
				}

				if (Request.QueryString["fl_id"]!=null)
				{
					if (Session["parametri"]!=null)
					{
						WebCad.ParametriRicerca paremetri =(WebCad.ParametriRicerca)Session["parametri"];
						paremetri.tipoDataSet=(int)TipoDatagrid.NavigazioneSpazi;
						Session["parametri"]=paremetri;
					}
				}

				if (Request.QueryString["reparto"]!=null)
				{
					if (Session["parametri"]!=null)
					{
						WebCad.ParametriRicerca paremetri =(WebCad.ParametriRicerca)Session["parametri"];
						paremetri.repartoId=Convert.ToInt32(Request.QueryString["reparto"]);
						paremetri.tipoDataSet=(int)TipoDatagrid.NavigazioneSpazi;
						Session["parametri"]=paremetri;
					}
				}
			}
		}

		private void DgSceltaPlan()
		{
			WebCad.ParametriRicerca parametri = new WebCad.ParametriRicerca();
			parametri.tipoDataSet=(int)WebCad.TipoDatagrid.SelezionePlanimetria;
			parametri.tipo="";
			parametri.flId=Convert.ToInt32(Request.QueryString["idFl"]);
			parametri.blId=Convert.ToInt32(Request.QueryString["idBl"]);

			parametri.servizioId=0;

			Session["parametri"]=parametri;
			//vbScriptDaEseguire="reloadPage";
			//Response.Flush();
		}
		private void DgSceltaPlanFromCreazioneRdl()
		{	
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdBl=  BlId_To_IdBl(BlId);
			int IdServizio =0;
			if(Request["IdServizio"]!= string.Empty)
			{
				IdServizio =  Convert.ToInt32(Request["IdServizio"]);
			}
			WebCad.ParametriRicerca parametri = new WebCad.ParametriRicerca();
			parametri.tipoDataSet=(int)WebCad.TipoDatagrid.SelezionePlanimetria;

			parametri.tipo="";
			parametri.flId=IdPiano;
			parametri.blId=IdBl;
			parametri.servizioId = IdServizio;
			Session["parametri"]=parametri;

			//vbScriptDaEseguire="reloadPage";
			//Response.Flush();
		}
		private void DgSceltaPlanFromApprovaEmettiRdl()
		{
			string BlId = Request["BlId"];
			int IdPiano = Convert.ToInt32(Request["IdPiano"]);
			int IdBl=  BlId_To_IdBl(BlId);
			int IdServizio =0;
			if(Request["IdServizio"]!= string.Empty)
			{
				IdServizio =  Convert.ToInt32(Request["IdServizio"]);
			}
			WebCad.ParametriRicerca parametri = new WebCad.ParametriRicerca();
			parametri.tipoDataSet=(int)WebCad.TipoDatagrid.SelezionePlanimetria;
			string DescrizioneServizio=String.Empty;
			if(IdServizio !=0 )
			{
				 DescrizioneServizio = Idservizio_To_DecServizio(IdServizio);
			}

			parametri.tipo="";
			parametri.flId=IdPiano;
			parametri.blId=IdBl;
			parametri.servizioId = IdServizio;
			Session["parametri"]=parametri;
			string Planimetria = Request["Planimetria"];
			//SetPlanimetriaFromApprovaEmettiRdl = "window.parent.frames(0).setPlanimetria \"" + Planimetria +"\"";
		}
		private int BlId_To_IdBl(string BlId)
		{
			
			WebCad.Classi.ClassiAnagrafiche.Buildings IdBlFromBlId = new WebCad.Classi.ClassiAnagrafiche.Buildings();
			return IdBlFromBlId.GetIdBl(BlId);
		}
		private void SetParametri(int td)
		{
			WebCad.ParametriRicerca parametri = (WebCad.ParametriRicerca)Session["parametri"];
			parametri.tipoDataSet=td;
			
			parametri.servizioId=0;

			string stringaRm = Request.Form["stanze"];
			parametri.rmIds=stringaRm.Replace(" ","").Replace(";;",";");

			if(Request.Form["categoria"]!="")
				parametri.catId=Convert.ToInt32(Request.Form["categoria"]);
			else parametri.catId=0;
			if(Request.Form["reparto"]!="")
				parametri.repartoId=Convert.ToInt32(Request.Form["reparto"]);
			else parametri.repartoId=0;
			if(Request.Form["destUso"]!="")
				parametri.destUsoId=Convert.ToInt32(Request.Form["destUso"]);
			else parametri.destUsoId=0;
		
			string stringaEq=Request.Form["app"];
			parametri.eqIds=stringaEq.Replace(" ","").Replace(";;",";");

			string stringaEqStd=Request.Form["stdApp"];
			parametri.stdEqIds=stringaEqStd.Replace(" ","").Replace(";;",";");
			
			Session["parametri"]=parametri;
		}

		private int getSelectedEd(string eqId)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p_ED_ID = new S_Object();
			p_ED_ID.ParameterName = "p_ED_ID";
			p_ED_ID.DbType = CustomDBType.VarChar;
			p_ED_ID.Direction = ParameterDirection.Input;
			p_ED_ID.Size=100;
			p_ED_ID.Value=eqId;
			p_ED_ID.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ED_ID);

			WebCad.WiewCad.RiferimentiCad _riferimentiCad = new WebCad.WiewCad.RiferimentiCad();
			DataSet Ds = _riferimentiCad.GetIDEQfromCodice(CollezioneControlli);
			if (Ds.Tables[0].Rows.Count>0)
			{
				return Convert.ToInt32(Ds.Tables[0].Rows[0][0].ToString());
			} 
			else 
			{
				return -1;
			}

		}

		private int getSelectedRm(string rmId, string nomeFile)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p_ED_ID = new S_Object();
			p_ED_ID.ParameterName = "p_RM_ID";
			p_ED_ID.DbType = CustomDBType.VarChar;
			p_ED_ID.Direction = ParameterDirection.Input;
			p_ED_ID.Size=100;
			p_ED_ID.Value=rmId;
			p_ED_ID.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ED_ID);

			S_Controls.Collections.S_Object p_NomeFile = new S_Object();
			p_NomeFile.ParameterName = "p_NomeFile";
			p_NomeFile.DbType = CustomDBType.VarChar;
			p_NomeFile.Direction = ParameterDirection.Input;
			p_NomeFile.Size=100;
			p_NomeFile.Value=nomeFile;
			p_NomeFile.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_NomeFile);

			WebCad.WiewCad.RiferimentiCad _riferimentiCad = new WebCad.WiewCad.RiferimentiCad();
			DataSet Ds = _riferimentiCad.GetIDRMfromCodice(CollezioneControlli);
			if (Ds.Tables[0].Rows.Count>0)
			{
				return Convert.ToInt32(Ds.Tables[0].Rows[0][0].ToString());
			} 
			else 
			{
				return -1;
			}

		}

		# region metodi per datalayer
		private DataSet GetDataSet(WebCad.ParametriRicerca parametri)
		{

		
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p_bl_id = new S_Object();
			p_bl_id.ParameterName = "p_bl_id";
			p_bl_id.DbType = CustomDBType.Integer;
			p_bl_id.Direction = ParameterDirection.Input;
			p_bl_id.Value=parametri.blId;
			p_bl_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_bl_id);


			//p_fl_id in integer, 
			S_Controls.Collections.S_Object p_fl_id = new S_Object();
			p_fl_id.ParameterName = "p_fl_id";
			p_fl_id.DbType = CustomDBType.Integer;
			p_fl_id.Direction = ParameterDirection.Input;
			p_fl_id.Value=parametri.flId;
			p_fl_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_fl_id);

			//p_fl_id in integer, 
			S_Controls.Collections.S_Object p_sv_id = new S_Object();
			p_sv_id.ParameterName = "p_servizio_id";
			p_sv_id.DbType = CustomDBType.Integer;
			p_sv_id.Direction = ParameterDirection.Input;
			p_sv_id.Value=parametri.servizioId;
			p_sv_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_sv_id);

				
			//p_ordinamento in varchar2
			S_Controls.Collections.S_Object p_ordinamento = new S_Object();
			p_ordinamento.ParameterName = "p_ordinamento";
			p_ordinamento.DbType = CustomDBType.VarChar;
			p_ordinamento.Direction = ParameterDirection.Input;
			p_ordinamento.Size=500;
			if (parametri.ordinamento==null)
				parametri.ordinamento="Edificio";
			p_ordinamento.Value=parametri.ordinamento;
			p_ordinamento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ordinamento);


			WebCad.WiewCad.RiferimentiCad _riferimentiCad = new WebCad.WiewCad.RiferimentiCad();
			return _riferimentiCad.GetData(CollezioneControlli);
		
		}


		private DataSet getDataSetperDWG(WebCad.ParametriRicerca parametri, string nomeDWG)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p_bl_id = new S_Object();
			p_bl_id.ParameterName = "p_bl_id";
			p_bl_id.DbType = CustomDBType.Integer;
			p_bl_id.Direction = ParameterDirection.Input;
			p_bl_id.Value=parametri.blId;
			p_bl_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_bl_id);


			//p_fl_id in integer, 
			S_Controls.Collections.S_Object p_fl_id = new S_Object();
			p_fl_id.ParameterName = "p_fl_id";
			p_fl_id.DbType = CustomDBType.Integer;
			p_fl_id.Direction = ParameterDirection.Input;
			p_fl_id.Value=parametri.flId;
			p_fl_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_fl_id);

			// p_rm_ids in varchar2,
			S_Controls.Collections.S_Object p_rm_ids = new S_Object();
			p_rm_ids.ParameterName = "p_rm_ids";
			p_rm_ids.DbType = CustomDBType.VarChar;
			p_rm_ids.Size=256;
			p_rm_ids.Direction = ParameterDirection.Input;
			p_rm_ids.Value=parametri.rmIds.Trim();
			p_rm_ids.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_rm_ids);

			// p_cat_id in integer,
			S_Controls.Collections.S_Object p_cat_id = new S_Object();
			p_cat_id.ParameterName = "p_cat_id";
			p_cat_id.DbType = CustomDBType.Integer;
			p_cat_id.Direction = ParameterDirection.Input;
			p_cat_id.Value=parametri.catId;
			p_cat_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_cat_id);
			                
			//p_reparto_id in integer,
			S_Controls.Collections.S_Object p_reparto_id = new S_Object();
			p_reparto_id.ParameterName = "p_reparto_id";
			p_reparto_id.DbType = CustomDBType.Integer;
			p_reparto_id.Direction = ParameterDirection.Input;
			p_reparto_id.Value=parametri.repartoId;
			p_reparto_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_reparto_id);
			
			//p_dest_uso_id in integer,
			S_Controls.Collections.S_Object p_dest_uso_id = new S_Object();
			p_dest_uso_id.ParameterName = "p_dest_uso_id";
			p_dest_uso_id.DbType = CustomDBType.Integer;
			p_dest_uso_id.Direction = ParameterDirection.Input;
			p_dest_uso_id.Value=parametri.destUsoId;
			p_dest_uso_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_dest_uso_id);
			
			//p_std_eq_ids in varchar2,
			S_Controls.Collections.S_Object p_std_eq_ids = new S_Object();
			p_std_eq_ids.ParameterName = "p_std_eq_ids";
			p_std_eq_ids.DbType = CustomDBType.VarChar;
			p_std_eq_ids.Direction = ParameterDirection.Input;
			p_std_eq_ids.Size=256;
			p_std_eq_ids.Value=parametri.stdEqIds.Trim();
			p_std_eq_ids.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_std_eq_ids);
			
			//p_eq_ids in varchar2,
			S_Controls.Collections.S_Object p_eq_ids = new S_Object();
			p_eq_ids.ParameterName = "p_eq_ids";
			p_eq_ids.DbType = CustomDBType.VarChar;
			p_eq_ids.Direction = ParameterDirection.Input;
			p_eq_ids.Size=256;
			p_eq_ids.Value=parametri.eqIds.Trim();
			p_eq_ids.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_eq_ids);

			//p_nome_dwg in varchar2,
			S_Controls.Collections.S_Object p_nome_dwg = new S_Object();
			p_nome_dwg.ParameterName = "p_nome_dwg";
			p_nome_dwg.DbType = CustomDBType.VarChar;
			p_nome_dwg.Direction = ParameterDirection.Input;
			p_nome_dwg.Size=256;
			p_nome_dwg.Value=parametri.fileDwg;;
			p_nome_dwg.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_nome_dwg);
				
			//p_ordinamento in varchar2
			S_Controls.Collections.S_Object p_ordinamento = new S_Object();
			p_ordinamento.ParameterName = "p_ordinamento";
			p_ordinamento.DbType = CustomDBType.VarChar;
			p_ordinamento.Direction = ParameterDirection.Input;
			p_ordinamento.Size=500;
			if (parametri.ordinamento==null)
				parametri.ordinamento="Edificio";
			p_ordinamento.Value=parametri.ordinamento;
			p_ordinamento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ordinamento);

			//p_prima_riga in integer,
			S_Controls.Collections.S_Object p_prima_riga = new S_Object();
			p_prima_riga.ParameterName = "p_prima_riga";
			p_prima_riga.DbType = CustomDBType.Integer;
			p_prima_riga.Direction = ParameterDirection.Input;
			p_prima_riga.Value=DataGridRicercaCad1.GetNumeroPagina()*DataGridRicercaCad1.GetRecordPerPagina();
			p_prima_riga.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_prima_riga);

			//p_ultima_riga in integer,
			S_Controls.Collections.S_Object p_ultima_riga = new S_Object();
			p_ultima_riga.ParameterName = "p_ultima_riga";
			p_ultima_riga.DbType = CustomDBType.Integer;
			p_ultima_riga.Direction = ParameterDirection.Input;
			p_ultima_riga.Value=(DataGridRicercaCad1.GetNumeroPagina()+1)*DataGridRicercaCad1.GetRecordPerPagina();
			p_ultima_riga.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ultima_riga);

			WebCad.WiewCad.RiferimentiCad _riferimentiCad = new WebCad.WiewCad.RiferimentiCad();
			return _riferimentiCad.GetDataPerDwf(CollezioneControlli);
		}


		private DataSet getDataSetperDWGapp(WebCad.ParametriRicerca parametri, string nomeDWG)
		{
			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object p_bl_id = new S_Object();
			p_bl_id.ParameterName = "p_bl_id";
			p_bl_id.DbType = CustomDBType.Integer;
			p_bl_id.Direction = ParameterDirection.Input;
			p_bl_id.Value=parametri.blId;
			p_bl_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_bl_id);


			//p_fl_id in integer, 
			S_Controls.Collections.S_Object p_fl_id = new S_Object();
			p_fl_id.ParameterName = "p_fl_id";
			p_fl_id.DbType = CustomDBType.Integer;
			p_fl_id.Direction = ParameterDirection.Input;
			p_fl_id.Value=parametri.flId;
			p_fl_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_fl_id);

			// p_rm_ids in varchar2,
			S_Controls.Collections.S_Object p_rm_ids = new S_Object();
			p_rm_ids.ParameterName = "p_rm_ids";
			p_rm_ids.DbType = CustomDBType.VarChar;
			p_rm_ids.Size=256;
			p_rm_ids.Direction = ParameterDirection.Input;
			p_rm_ids.Value=parametri.rmIds.Trim();
			p_rm_ids.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_rm_ids);

			// p_cat_id in integer,
			S_Controls.Collections.S_Object p_cat_id = new S_Object();
			p_cat_id.ParameterName = "p_cat_id";
			p_cat_id.DbType = CustomDBType.Integer;
			p_cat_id.Direction = ParameterDirection.Input;
			p_cat_id.Value=parametri.catId;
			p_cat_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_cat_id);
			                
			//p_reparto_id in integer,
			S_Controls.Collections.S_Object p_reparto_id = new S_Object();
			p_reparto_id.ParameterName = "p_reparto_id";
			p_reparto_id.DbType = CustomDBType.Integer;
			p_reparto_id.Direction = ParameterDirection.Input;
			p_reparto_id.Value=parametri.repartoId;
			p_reparto_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_reparto_id);
			
			//p_dest_uso_id in integer,
			S_Controls.Collections.S_Object p_dest_uso_id = new S_Object();
			p_dest_uso_id.ParameterName = "p_dest_uso_id";
			p_dest_uso_id.DbType = CustomDBType.Integer;
			p_dest_uso_id.Direction = ParameterDirection.Input;
			p_dest_uso_id.Value=parametri.destUsoId;
			p_dest_uso_id.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_dest_uso_id);
			
			//p_std_eq_ids in varchar2,
			S_Controls.Collections.S_Object p_std_eq_ids = new S_Object();
			p_std_eq_ids.ParameterName = "p_std_eq_ids";
			p_std_eq_ids.DbType = CustomDBType.VarChar;
			p_std_eq_ids.Direction = ParameterDirection.Input;
			p_std_eq_ids.Size=256;
			p_std_eq_ids.Value=parametri.stdEqIds.Trim();
			p_std_eq_ids.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_std_eq_ids);
			
			//p_eq_ids in varchar2,
			S_Controls.Collections.S_Object p_eq_ids = new S_Object();
			p_eq_ids.ParameterName = "p_eq_ids";
			p_eq_ids.DbType = CustomDBType.VarChar;
			p_eq_ids.Direction = ParameterDirection.Input;
			p_eq_ids.Size=256;
			p_eq_ids.Value=parametri.eqIds.Trim();
			p_eq_ids.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_eq_ids);

			//p_nome_dwg in varchar2,
			S_Controls.Collections.S_Object p_nome_dwg = new S_Object();
			p_nome_dwg.ParameterName = "p_nome_dwg";
			p_nome_dwg.DbType = CustomDBType.VarChar;
			p_nome_dwg.Direction = ParameterDirection.Input;
			p_nome_dwg.Size=256;
			p_nome_dwg.Value=parametri.fileDwg;;
			p_nome_dwg.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_nome_dwg);
				
			//p_ordinamento in varchar2
			S_Controls.Collections.S_Object p_ordinamento = new S_Object();
			p_ordinamento.ParameterName = "p_ordinamento";
			p_ordinamento.DbType = CustomDBType.VarChar;
			p_ordinamento.Direction = ParameterDirection.Input;
			p_ordinamento.Size=500;
			if (parametri.ordinamento==null)
				parametri.ordinamento="Edificio";
			p_ordinamento.Value=parametri.ordinamento;
			p_ordinamento.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ordinamento);

			//p_prima_riga in integer,
			S_Controls.Collections.S_Object p_prima_riga = new S_Object();
			p_prima_riga.ParameterName = "p_prima_riga";
			p_prima_riga.DbType = CustomDBType.Integer;
			p_prima_riga.Direction = ParameterDirection.Input;
			p_prima_riga.Value=DataGridRicercaCad1.GetNumeroPagina()*DataGridRicercaCad1.GetRecordPerPagina();
			p_prima_riga.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_prima_riga);

			//p_ultima_riga in integer,
			S_Controls.Collections.S_Object p_ultima_riga = new S_Object();
			p_ultima_riga.ParameterName = "p_ultima_riga";
			p_ultima_riga.DbType = CustomDBType.Integer;
			p_ultima_riga.Direction = ParameterDirection.Input;
			p_ultima_riga.Value=(DataGridRicercaCad1.GetNumeroPagina()+1)*DataGridRicercaCad1.GetRecordPerPagina();
			p_ultima_riga.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(p_ultima_riga);

			WebCad.WiewCad.RiferimentiCad _riferimentiCad = new WebCad.WiewCad.RiferimentiCad();
			return _riferimentiCad.GetDataPerDwfApp(CollezioneControlli);
		}

		#endregion

		private string _listaEdifici="";
		//Metodo dell'interfaccia.
		public DataSet Popola(WebCad.ParametriRicerca parametri)
		{
			if (parametri.tipoDataSet==(int)TipoDatagrid.SelezionePlanimetria)
			{
				return GetDataSet(parametri);;
			}

			if (parametri.tipoDataSet==(int)TipoDatagrid.NavigazioneSpazi)
			{
				DataSet ds = getDataSetperDWG(parametri, Convert.ToString(ViewState["nomeDWG"]));

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					if (dr["layer"].ToString().Substring(0,5)=="z-RM_")
					{
						if (_listaEdifici=="")
						{
							_listaEdifici += dr["layer"].ToString();
						}
						else
						{
							_listaEdifici += ";"+dr["layer"].ToString();
						}
					}
				}

				return ds;
			}

			if (parametri.tipoDataSet==(int)TipoDatagrid.NavigazioneApparati)
			{
				return getDataSetperDWGapp(parametri, Convert.ToString(ViewState["nomeDWG"]));
			}

			throw new ApplicationException("Parametro per il tipo di datagrid non specificato");
		}
		private string Idservizio_To_DecServizio(int IdServizio)
		{
			WebCad.Classi.ClassiDettaglio.Servizi srv = new WebCad.Classi.ClassiDettaglio.Servizi();
			return srv.GetDecServizioById(IdServizio);
		}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
