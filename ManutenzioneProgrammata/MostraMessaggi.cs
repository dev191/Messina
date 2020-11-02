// Decompiled with JetBrains decompiler
// Type: TheSite.ManutenzioneProgrammata.MostraMessaggi
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheSite.ManutenzioneProgrammata
{
  public class MostraMessaggi : Page
  {
    protected Label lblErroreINIT;
    protected Label lblAnno;
    protected Label lblMEse;
    protected Label lblEdificio;
    protected Label lblServizio;
    protected Label lblClasseelemento;
    protected Label lblFINEerr;

    private void Page_Load(object sender, EventArgs e) => this.GeneraMessaggio();

    private void GeneraMessaggio()
    {
      Hashtable hashtable1 = new Hashtable();
      Hashtable hashtable2 = (Hashtable) this.Session["DataERRmp"];
      this.lblAnno.Text = "Anno: " + hashtable2[(object) "Anno"].ToString();
      this.lblMEse.Text = "Mese: " + hashtable2[(object) "MeseEsteso"].ToString();
      this.lblEdificio.Text = "Edificio: " + hashtable2[(object) "Eedificio"].ToString();
      this.lblServizio.Text = "Categoria Tenologica: " + hashtable2[(object) "Servizio"].ToString();
      this.lblClasseelemento.Text = "Classe Elemento: " + hashtable2[(object) "ClasseElemento"].ToString();
      hashtable2.Clear();
      if (this.Session["DataERRmp"] == null)
        return;
      this.Session.Remove("DataERRmp");
    }

    private string recuperaEqId()
    {
      string str = string.Empty;
      if (this.Session["DatiList"] != null)
      {
        IDictionaryEnumerator enumerator = ((Hashtable) this.Session["DatiList"]).GetEnumerator();
        while (enumerator.MoveNext())
          str = str + enumerator.Value + ",";
        str = str.Remove(str.Length - 1, 1);
      }
      else
      {
        this.Response.Write("Sessione Vuota");
        this.Response.End();
      }
      return str;
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);
  }
}
