// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.CostiGesioneCumulativi.SiteJavaScript
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System.Text;
using System.Web.UI;

namespace TheSite.Classi.CostiGesioneCumulativi
{
  public class SiteJavaScript
  {
    private static string s_TestataScript = "<script language=\"javascript\">\n";
    private static string s_CodaScript = "</script>\n";
    public static string LastFunction = string.Empty;

    public static void ConfirmDelete(Page CurrentPage)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ConfirmDelete() {\n");
      stringBuilder.Append("flag = confirm('Si vuole cancellare l'informazione seleziona?');\n");
      stringBuilder.Append("return flag;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegistrationScript(CurrentPage, nameof (ConfirmDelete), stringBuilder.ToString());
      SiteJavaScript.LastFunction = "ConfirmDelete()";
    }

    public static void ShowFrameSollecito(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameAddSoll(sender,idquery,e){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"PopupAddSoll\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 10;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docAddSoll\").src=\"" + str + "CommonPage/Sollecito.aspx?\" + idquery + \"=\" + ctrl2;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "Sollecito", stringBuilder.ToString());
    }

    public static void ShowFrameVisSollecito(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameVisSoll(sender,idquery,e){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"PopupVisSoll\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 10;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docVisSoll\").src=\"" + str + "CommonPage/RiepilogoSolleciti.aspx?\" + idquery + \"=\" + ctrl2;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "VisSollecito", stringBuilder.ToString());
    }

    public static void ShowFrame(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrame(sender,idquery,e,idmodulo,ms){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"Popup\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"doc\").src=\"" + str + "CommonPage/ListaEdifici.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo + \"&ms=\" + ms;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "start", stringBuilder.ToString());
    }

    public static void ShowFrameReperibili(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameRep(sender,idquery,e){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"PopupRep\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 10;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docRep\").src=\"" + str + "CommonPage/RiepilogoReperibilita.aspx?\" + idquery + \"=\" + ctrl2;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "Reperibili", stringBuilder.ToString());
    }

    public static void ShowFrameReperibiliBL(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameRep(sender,idquery,e){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"PopupRep\").style;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docRep\").src=\"" + str + "CommonPage/RiepilogoReperibilita.aspx?\" + idquery + \"=\" + ctrl2;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "Reperibili", stringBuilder.ToString());
    }

    public static void ShowWindowOpen(
      Page CurrentPage,
      int NumDirectory,
      string url,
      int width,
      int height)
    {
      string str1 = "";
      for (int index = 0; index < NumDirectory; ++index)
        str1 += "../";
      if (NumDirectory > 0)
        url = str1 + url;
      string str2 = "window.open('" + url + "','name','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',width='" + (object) width + "',height='" + (object) height + "',align='center');";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ApriPopPup(){\n");
      stringBuilder.Append(str2);
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "start", stringBuilder.ToString());
    }

    public static void WindowModeless(
      Page CurrentPage,
      int NumDirectory,
      string url,
      int width,
      int height)
    {
      string str1 = "";
      for (int index = 0; index < NumDirectory; ++index)
        str1 += "../";
      if (NumDirectory > 0)
        url = str1 + url;
      StringBuilder stringBuilder = new StringBuilder();
      string str2 = "window.showModalDialog('" + url + "','','help:0;resizable:1;dialogWidth:" + (object) width + "px;dialogHeight:" + (object) height + "px');";
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append(str2);
      stringBuilder.Append("\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, url, stringBuilder.ToString());
    }

    public static void WindowOpen(
      Page CurrentPage,
      int NumDirectory,
      string url,
      int width,
      int height)
    {
      string str1 = "";
      for (int index = 0; index < NumDirectory; ++index)
        str1 += "../";
      if (NumDirectory > 0)
        url = str1 + url;
      StringBuilder stringBuilder = new StringBuilder();
      string str2 = "window.open('" + url + "','name','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',width='" + (object) width + "',height='" + (object) height + "',align='center');";
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append(str2);
      stringBuilder.Append("\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, url, stringBuilder.ToString());
    }

    public static void WindowOpen(
      Page CurrentPage,
      int NumDirectory,
      string url,
      int width,
      int height,
      string namewindow)
    {
      string str1 = "";
      for (int index = 0; index < NumDirectory; ++index)
        str1 += "../";
      if (NumDirectory > 0)
        url = str1 + url;
      StringBuilder stringBuilder = new StringBuilder();
      string str2 = namewindow + "=window.open('" + url + "','name','menubar=yes,toolbar=no,location=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no',width='" + (object) width + "',height='" + (object) height + "',align='center');";
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append(str2);
      stringBuilder.Append("\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, url, stringBuilder.ToString());
    }

    public static void msgBox(Page CurrentPage, string messaggio)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      string str = "alert('" + messaggio.Replace("'", "\\'") + "');";
      stringBuilder.Append(str);
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, nameof (msgBox), stringBuilder.ToString());
    }

    public static void OpenerReload(Page CurrentPage, string url)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      string str1 = "var wi='" + url + "';";
      string str2 = "opener.document.location.reload(wi);";
      stringBuilder.Append(str1);
      stringBuilder.Append(str2);
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "Reload", stringBuilder.ToString());
    }

    public static void ShowFrameMatricole(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameMatricole(sender,idquery,e,idmodulo){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"Popupmatricole\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+20;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docmatricole\").src=\"" + str + "CommonPage/ListaMatricole.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "matricole", stringBuilder.ToString());
    }

    public static void ShowFrameFascicolo(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameFascicolo(sender,idquery,e,idmodulo){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"Popupfascicolo\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+20;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docfascicolo\").src=\"" + str + "CommonPage/ListaFascicoli.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "fascicoli", stringBuilder.ToString());
    }

    public static void ShowFramePMP(Page CurrentPage, int NumDirectory)
    {
      string str = "";
      for (int index = 0; index < NumDirectory; ++index)
        str += "../";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowFrameMatricole(sender,idquery,e,idmodulo){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"Popupmatricole\").style;\n");
      stringBuilder.Append("var ideqstd = document.getElementById(\"cmdsStdApparecchiatura\").value;\n");
      stringBuilder.Append("var idservizio = document.getElementById(\"cmbsServizio\").value;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+20;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("ctrl2= document.getElementById(sender).value;\n");
      stringBuilder.Append("document.getElementById(\"docmatricole\").src=\"" + str + "CommonPage/ListaPMP.aspx?\" + idquery + \"=\" + ctrl2 + \"&idmodulo=\" + idmodulo+ \"&ideqstd=\" + ideqstd+ \"&idservizio=\" + idservizio;\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, "matricole", stringBuilder.ToString());
    }

    public static void ShowInfo(Page CurrentPage)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(SiteJavaScript.s_TestataScript);
      stringBuilder.Append("function ShowInfo(){\n");
      stringBuilder.Append("var ctrl = document.getElementById(\"Popup\").style;\n");
      stringBuilder.Append("x = e.clientX;\n");
      stringBuilder.Append("y = e.clientY;\n");
      stringBuilder.Append("ctrl.left = 50;\n");
      stringBuilder.Append("ctrl.top = y+30;\n");
      stringBuilder.Append("if (ctrl.display =='none') ctrl.display='block';\n");
      stringBuilder.Append("}\n");
      stringBuilder.Append(SiteJavaScript.s_CodaScript);
      SiteJavaScript.RegisterStartUpScritp(CurrentPage, nameof (ShowInfo), stringBuilder.ToString());
    }

    private static void RegistrationScript(Page CurrentPage, string ScriptId, string Script) => CurrentPage.RegisterClientScriptBlock(ScriptId, Script);

    private static void RegisterStartUpScritp(Page CurrentPage, string ScriptId, string Script)
    {
      if (CurrentPage.IsStartupScriptRegistered(ScriptId))
        return;
      CurrentPage.RegisterStartupScript(ScriptId, Script);
    }
  }
}
