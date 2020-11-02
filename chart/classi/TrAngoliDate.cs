// Decompiled with JetBrains decompiler
// Type: chart.classi.TrAngoliDate
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;

namespace chart.classi
{
  public class TrAngoliDate
  {
    private ArrayList _Rarr = new ArrayList();

    public float TraformaAngoliInGradi(float Angolo, float AngoloGiro) => Convert.ToSingle(360f * Angolo / AngoloGiro);

    public float TrasformaAngoliInRadianti(float Angolo, float AngoloGiro) => Convert.ToSingle(2.0 * Math.PI * (double) Angolo / (double) AngoloGiro);

    public float AngoloMeseGradi(int mese, int anno) => this.TraformaAngoliInGradi((float) this.GiorniDelMese(anno, mese), (float) this.GiorniDellAnno(anno));

    public float AngoloMeseRadianti(int mese, int anno) => this.TrasformaAngoliInRadianti((float) this.GiorniDelMese(anno, mese), (float) this.GiorniDellAnno(anno));

    public int GiorniDelMese(int anno, int mese)
    {
      int[] numArray = new int[12];
      DateTime dateTime1;
      DateTime dateTime2;
      for (int index = 0; index < 11; ++index)
      {
        dateTime1 = new DateTime(anno, index + 1, 1);
        dateTime2 = new DateTime(anno, index + 2, 1);
        TimeSpan timeSpan = dateTime2.Subtract(dateTime1);
        numArray[index] = timeSpan.Days;
      }
      dateTime1 = new DateTime(anno, 12, 1);
      dateTime2 = new DateTime(anno + 1, 1, 1);
      TimeSpan timeSpan1 = dateTime2.Subtract(dateTime1);
      numArray[11] = timeSpan1.Days;
      return numArray[mese];
    }

    public int GiorniDellAnno(int anno)
    {
      DateTime dateTime = new DateTime(anno, 1, 1);
      return new DateTime(anno + 1, 1, 1).Subtract(dateTime).Days;
    }

    public float TrRadGrad(float Rad) => Convert.ToSingle((double) Rad / Math.PI * 180.0);

    public float TrGradRad(float Grad) => Convert.ToSingle((double) Grad / 180.0 * Math.PI);

    public string strMese(int mese)
    {
      string str;
      switch (mese)
      {
        case 0:
          str = "Gennaio";
          break;
        case 1:
          str = "Febbraio";
          break;
        case 2:
          str = "Marzo";
          break;
        case 3:
          str = "Aprile";
          break;
        case 4:
          str = "Maggio";
          break;
        case 5:
          str = "Giugno";
          break;
        case 6:
          str = "Luglio";
          break;
        case 7:
          str = "Agosto";
          break;
        case 8:
          str = "Settembre";
          break;
        case 9:
          str = "Ottobre";
          break;
        case 10:
          str = "Novembre";
          break;
        case 11:
          str = "Dicembre";
          break;
        default:
          str = "";
          break;
      }
      return str;
    }
  }
}
