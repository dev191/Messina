// Decompiled with JetBrains decompiler
// Type: WebCad.bottomFrame
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using ApplicationDataLayer.Collections;
using ApplicationDataLayer.DBType;
using S_Controls.Collections;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using WebCad.Classi.ClassiAnagrafiche;
using WebCad.WebControls;
using WebCad.WiewCad;

namespace WebCad
{
  public class bottomFrame : Page, IDataGridDinamico
  {
    protected HtmlInputHidden tipo;
    protected HtmlInputHidden categoria;
    protected HtmlInputHidden reparto;
    protected HtmlInputHidden destUso;
    protected HtmlInputHidden stanze;
    protected HtmlInputHidden stdApp;
    protected HtmlInputHidden App;
    protected DataGridRicercaCad DataGridRicercaCad1;
    protected string vbScriptDaEseguire = "";
    protected HtmlInputHidden accoda;
    private bool accodaselezioni = true;
    private string _listaEdifici = "";

    public string stringaLayerStanze => this._listaEdifici;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["accoda"] != null)
        this.accodaselezioni = this.Request.QueryString["accoda"] == "1";
      if (this.IsPostBack)
        return;
      if (this.Session["parametri"] != null && Convert.ToInt32(this.Request.Form["tipo"]) > 0)
        this.SetParametri(Convert.ToInt32(this.Request.Form["tipo"]));
      if (this.Request["FromPaginaCreazioneRdl"] != null)
        this.DgSceltaPlanFromCreazioneRdl();
      else if (this.Request["FromPaginaApprovaEmettiRdl"] != null)
        this.DgSceltaPlanFromApprovaEmettiRdl();
      else if (this.Request.QueryString["idFl"] != null)
      {
        this.DgSceltaPlan();
      }
      else
      {
        if (this.Request.QueryString["NomeFile"] != null && this.Session["parametri"] != null)
        {
          ParametriRicerca parametriRicerca = (ParametriRicerca) this.Session["parametri"];
          parametriRicerca.fileDwg = this.Request.QueryString["NomeFile"].ToString();
          this.Session["parametri"] = (object) parametriRicerca;
        }
        if (this.Request.QueryString["eq_id"] != null)
        {
          int selectedEd = this.getSelectedEd(this.Request.QueryString["eq_id"].ToString());
          if (this.Session["parametri"] != null)
          {
            ParametriRicerca parametriRicerca = (ParametriRicerca) this.Session["parametri"];
            if (this.accodaselezioni)
            {
              if (parametriRicerca.eqIds == null)
                parametriRicerca.eqIds = string.Empty;
              if (parametriRicerca.eqIds.Trim() == "")
              {
                parametriRicerca.eqIds = selectedEd.ToString();
              }
              else
              {
                ref ParametriRicerca local = ref parametriRicerca;
                local.eqIds = local.eqIds + "," + selectedEd.ToString();
              }
            }
            else
              parametriRicerca.eqIds = selectedEd.ToString();
            parametriRicerca.rmIds = string.Empty;
            parametriRicerca.tipoDataSet = 3;
            parametriRicerca.stdEqIds = string.Empty;
            this.Session["parametri"] = (object) parametriRicerca;
          }
        }
        if (this.Request.QueryString["rm_id"] != null && this.Session["parametri"] != null)
        {
          ParametriRicerca parametriRicerca = (ParametriRicerca) this.Session["parametri"];
          int selectedRm = this.getSelectedRm(this.Request.QueryString["rm_id"].ToString(), parametriRicerca.fileDwg);
          if (this.accodaselezioni)
          {
            if (parametriRicerca.rmIds == null)
              parametriRicerca.rmIds = string.Empty;
            if (parametriRicerca.rmIds.Trim() == "")
            {
              parametriRicerca.rmIds = selectedRm.ToString();
            }
            else
            {
              ref ParametriRicerca local = ref parametriRicerca;
              local.rmIds = local.rmIds + "," + selectedRm.ToString();
            }
          }
          else
            parametriRicerca.rmIds = selectedRm.ToString();
          parametriRicerca.eqIds = string.Empty;
          parametriRicerca.stdEqIds = string.Empty;
          parametriRicerca.tipoDataSet = 2;
          this.Session["parametri"] = (object) parametriRicerca;
        }
        if (this.Request.QueryString["fl_id"] != null && this.Session["parametri"] != null)
        {
          ParametriRicerca parametriRicerca = (ParametriRicerca) this.Session["parametri"];
          parametriRicerca.tipoDataSet = 2;
          this.Session["parametri"] = (object) parametriRicerca;
        }
        if (this.Request.QueryString["reparto"] == null || this.Session["parametri"] == null)
          return;
        ParametriRicerca parametriRicerca1 = (ParametriRicerca) this.Session["parametri"];
        parametriRicerca1.repartoId = Convert.ToInt32(this.Request.QueryString["reparto"]);
        parametriRicerca1.tipoDataSet = 2;
        this.Session["parametri"] = (object) parametriRicerca1;
      }
    }

    private void DgSceltaPlan() => this.Session["parametri"] = (object) new ParametriRicerca()
    {
      tipoDataSet = 1,
      tipo = "",
      flId = Convert.ToInt32(this.Request.QueryString["idFl"]),
      blId = Convert.ToInt32(this.Request.QueryString["idBl"]),
      servizioId = 0
    };

    private void DgSceltaPlanFromCreazioneRdl()
    {
      string BlId = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      int idBl = this.BlId_To_IdBl(BlId);
      int num = 0;
      if (this.Request["IdServizio"] != string.Empty)
        num = Convert.ToInt32(this.Request["IdServizio"]);
      this.Session["parametri"] = (object) new ParametriRicerca()
      {
        tipoDataSet = 1,
        tipo = "",
        flId = int32,
        blId = idBl,
        servizioId = num
      };
    }

    private void DgSceltaPlanFromApprovaEmettiRdl()
    {
      string BlId = this.Request["BlId"];
      int int32 = Convert.ToInt32(this.Request["IdPiano"]);
      int idBl = this.BlId_To_IdBl(BlId);
      int IdServizio = 0;
      if (this.Request["IdServizio"] != string.Empty)
        IdServizio = Convert.ToInt32(this.Request["IdServizio"]);
      ParametriRicerca parametriRicerca = new ParametriRicerca();
      parametriRicerca.tipoDataSet = 1;
      string empty = string.Empty;
      if (IdServizio != 0)
        this.Idservizio_To_DecServizio(IdServizio);
      parametriRicerca.tipo = "";
      parametriRicerca.flId = int32;
      parametriRicerca.blId = idBl;
      parametriRicerca.servizioId = IdServizio;
      this.Session["parametri"] = (object) parametriRicerca;
      string str = this.Request["Planimetria"];
    }

    private int BlId_To_IdBl(string BlId) => new Buildings().GetIdBl(BlId);

    private void SetParametri(int td)
    {
      ParametriRicerca parametriRicerca = (ParametriRicerca) this.Session["parametri"];
      parametriRicerca.tipoDataSet = td;
      parametriRicerca.servizioId = 0;
      string str1 = this.Request.Form["stanze"];
      parametriRicerca.rmIds = str1.Replace(" ", "").Replace(";;", ";");
      parametriRicerca.catId = !(this.Request.Form["categoria"] != "") ? 0 : Convert.ToInt32(this.Request.Form["categoria"]);
      parametriRicerca.repartoId = !(this.Request.Form["reparto"] != "") ? 0 : Convert.ToInt32(this.Request.Form["reparto"]);
      parametriRicerca.destUsoId = !(this.Request.Form["destUso"] != "") ? 0 : Convert.ToInt32(this.Request.Form["destUso"]);
      string str2 = this.Request.Form["app"];
      parametriRicerca.eqIds = str2.Replace(" ", "").Replace(";;", ";");
      string str3 = this.Request.Form["stdApp"];
      parametriRicerca.stdEqIds = str3.Replace(" ", "").Replace(";;", ";");
      this.Session["parametri"] = (object) parametriRicerca;
    }

    private int getSelectedEd(string eqId)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject = new S_Object();
      ((ParameterObject) sObject).set_ParameterName("p_ED_ID");
      ((ParameterObject) sObject).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject).set_Size(100);
      ((ParameterObject) sObject).set_Value((object) eqId);
      ((ParameterObject) sObject).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject);
      DataSet ideQfromCodice = new RiferimentiCad().GetIDEQfromCodice(CollezioneControlli);
      return ideQfromCodice.Tables[0].Rows.Count > 0 ? Convert.ToInt32(ideQfromCodice.Tables[0].Rows[0][0].ToString()) : -1;
    }

    private int getSelectedRm(string rmId, string nomeFile)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_RM_ID");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Size(100);
      ((ParameterObject) sObject1).set_Value((object) rmId);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_NomeFile");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Size(100);
      ((ParameterObject) sObject2).set_Value((object) nomeFile);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      DataSet idrMfromCodice = new RiferimentiCad().GetIDRMfromCodice(CollezioneControlli);
      return idrMfromCodice.Tables[0].Rows.Count > 0 ? Convert.ToInt32(idrMfromCodice.Tables[0].Rows[0][0].ToString()) : -1;
    }

    private DataSet GetDataSet(ParametriRicerca parametri)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) parametri.blId);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_fl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) parametri.flId);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_servizio_id");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) parametri.servizioId);
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_ordinamento");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Size(500);
      if (parametri.ordinamento == null)
        parametri.ordinamento = "Edificio";
      ((ParameterObject) sObject4).set_Value((object) parametri.ordinamento);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject4);
      return new RiferimentiCad().GetData(CollezioneControlli);
    }

    private DataSet getDataSetperDWG(ParametriRicerca parametri, string nomeDWG)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) parametri.blId);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_fl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) parametri.flId);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_rm_ids");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(256);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) parametri.rmIds.Trim());
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_cat_id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) parametri.catId);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_reparto_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) parametri.repartoId);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_dest_uso_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Value((object) parametri.destUsoId);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_std_eq_ids");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(256);
      ((ParameterObject) sObject7).set_Value((object) parametri.stdEqIds.Trim());
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_eq_ids");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(256);
      ((ParameterObject) sObject8).set_Value((object) parametri.eqIds.Trim());
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_nome_dwg");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(256);
      ((ParameterObject) sObject9).set_Value((object) parametri.fileDwg);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_ordinamento");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(500);
      if (parametri.ordinamento == null)
        parametri.ordinamento = "Edificio";
      ((ParameterObject) sObject10).set_Value((object) parametri.ordinamento);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_prima_riga");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Value((object) (this.DataGridRicercaCad1.GetNumeroPagina() * this.DataGridRicercaCad1.GetRecordPerPagina()));
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_ultima_riga");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Value((object) ((this.DataGridRicercaCad1.GetNumeroPagina() + 1) * this.DataGridRicercaCad1.GetRecordPerPagina()));
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject12);
      return new RiferimentiCad().GetDataPerDwf(CollezioneControlli);
    }

    private DataSet getDataSetperDWGapp(ParametriRicerca parametri, string nomeDWG)
    {
      S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
      S_Object sObject1 = new S_Object();
      ((ParameterObject) sObject1).set_ParameterName("p_bl_id");
      ((ParameterObject) sObject1).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject1).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject1).set_Value((object) parametri.blId);
      ((ParameterObject) sObject1).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject1);
      S_Object sObject2 = new S_Object();
      ((ParameterObject) sObject2).set_ParameterName("p_fl_id");
      ((ParameterObject) sObject2).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject2).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject2).set_Value((object) parametri.flId);
      ((ParameterObject) sObject2).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject2);
      S_Object sObject3 = new S_Object();
      ((ParameterObject) sObject3).set_ParameterName("p_rm_ids");
      ((ParameterObject) sObject3).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject3).set_Size(256);
      ((ParameterObject) sObject3).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject3).set_Value((object) parametri.rmIds.Trim());
      ((ParameterObject) sObject3).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject3);
      S_Object sObject4 = new S_Object();
      ((ParameterObject) sObject4).set_ParameterName("p_cat_id");
      ((ParameterObject) sObject4).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject4).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject4).set_Value((object) parametri.catId);
      ((ParameterObject) sObject4).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject4);
      S_Object sObject5 = new S_Object();
      ((ParameterObject) sObject5).set_ParameterName("p_reparto_id");
      ((ParameterObject) sObject5).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject5).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject5).set_Value((object) parametri.repartoId);
      ((ParameterObject) sObject5).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject5);
      S_Object sObject6 = new S_Object();
      ((ParameterObject) sObject6).set_ParameterName("p_dest_uso_id");
      ((ParameterObject) sObject6).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject6).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject6).set_Value((object) parametri.destUsoId);
      ((ParameterObject) sObject6).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject6);
      S_Object sObject7 = new S_Object();
      ((ParameterObject) sObject7).set_ParameterName("p_std_eq_ids");
      ((ParameterObject) sObject7).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject7).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject7).set_Size(256);
      ((ParameterObject) sObject7).set_Value((object) parametri.stdEqIds.Trim());
      ((ParameterObject) sObject7).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject7);
      S_Object sObject8 = new S_Object();
      ((ParameterObject) sObject8).set_ParameterName("p_eq_ids");
      ((ParameterObject) sObject8).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject8).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject8).set_Size(256);
      ((ParameterObject) sObject8).set_Value((object) parametri.eqIds.Trim());
      ((ParameterObject) sObject8).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject8);
      S_Object sObject9 = new S_Object();
      ((ParameterObject) sObject9).set_ParameterName("p_nome_dwg");
      ((ParameterObject) sObject9).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject9).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject9).set_Size(256);
      ((ParameterObject) sObject9).set_Value((object) parametri.fileDwg);
      ((ParameterObject) sObject9).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject9);
      S_Object sObject10 = new S_Object();
      ((ParameterObject) sObject10).set_ParameterName("p_ordinamento");
      ((ParameterObject) sObject10).set_DbType((CustomDBType) 2);
      ((ParameterObject) sObject10).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject10).set_Size(500);
      if (parametri.ordinamento == null)
        parametri.ordinamento = "Edificio";
      ((ParameterObject) sObject10).set_Value((object) parametri.ordinamento);
      ((ParameterObject) sObject10).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject10);
      S_Object sObject11 = new S_Object();
      ((ParameterObject) sObject11).set_ParameterName("p_prima_riga");
      ((ParameterObject) sObject11).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject11).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject11).set_Value((object) (this.DataGridRicercaCad1.GetNumeroPagina() * this.DataGridRicercaCad1.GetRecordPerPagina()));
      ((ParameterObject) sObject11).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject11);
      S_Object sObject12 = new S_Object();
      ((ParameterObject) sObject12).set_ParameterName("p_ultima_riga");
      ((ParameterObject) sObject12).set_DbType((CustomDBType) 1);
      ((ParameterObject) sObject12).set_Direction(ParameterDirection.Input);
      ((ParameterObject) sObject12).set_Value((object) ((this.DataGridRicercaCad1.GetNumeroPagina() + 1) * this.DataGridRicercaCad1.GetRecordPerPagina()));
      ((ParameterObject) sObject12).set_Index(((CollectionBase) CollezioneControlli).Count + 1);
      CollezioneControlli.Add(sObject12);
      return new RiferimentiCad().GetDataPerDwfApp(CollezioneControlli);
    }

    public DataSet Popola(ParametriRicerca parametri)
    {
      if (parametri.tipoDataSet == 1)
        return this.GetDataSet(parametri);
      if (parametri.tipoDataSet == 2)
      {
        DataSet dataSetperDwg = this.getDataSetperDWG(parametri, Convert.ToString(this.ViewState["nomeDWG"]));
        foreach (DataRow row in (InternalDataCollectionBase) dataSetperDwg.Tables[0].Rows)
        {
          if (row["layer"].ToString().Substring(0, 5) == "z-RM_")
          {
            if (this._listaEdifici == "")
            {
              this._listaEdifici += row["layer"].ToString();
            }
            else
            {
              bottomFrame bottomFrame = this;
              bottomFrame._listaEdifici = bottomFrame._listaEdifici + ";" + row["layer"].ToString();
            }
          }
        }
        return dataSetperDwg;
      }
      return parametri.tipoDataSet == 3 ? this.getDataSetperDWGapp(parametri, Convert.ToString(this.ViewState["nomeDWG"])) : throw new ApplicationException("Parametro per il tipo di datagrid non specificato");
    }

    private string Idservizio_To_DecServizio(int IdServizio) => new WebCad.Classi.ClassiDettaglio.Servizi().GetDecServizioById(IdServizio);

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
