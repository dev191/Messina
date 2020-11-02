// Decompiled with JetBrains decompiler
// Type: TheSite.AnagrafeImpianti.PageImage
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

namespace TheSite.AnagrafeImpianti
{
  public class PageImage : Page
  {
    private bool Preview = false;
    private string ep_image = string.Empty;
    private string urlimage = string.Empty;

    private void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["eq_image"] != null)
      {
        this.ep_image = this.Request.QueryString["eq_image"];
        this.Preview = this.Request.QueryString["p"] != null;
        if (this.Request.QueryString["urlimage"] != null)
          this.urlimage = this.Server.UrlDecode(this.Request.QueryString["urlimage"]);
        this.Thumbs();
      }
      else
        this.GraphicError();
    }

    protected override void OnInit(EventArgs e)
    {
      this.InitializeComponent();
      base.OnInit(e);
    }

    private void InitializeComponent() => this.Load += new EventHandler(this.Page_Load);

    private void Thumbs()
    {
      int num1 = 300;
      string empty = string.Empty;
      string str = !(this.urlimage == string.Empty) ? Path.Combine(this.Server.MapPath("../Doc_DB/" + this.urlimage), this.ep_image) : Path.Combine(this.Server.MapPath("../EQImages"), this.ep_image);
      this.Response.ContentType = "image/jpeg";
      Image image = (Image) null;
      if (File.Exists(str))
      {
        Bitmap bitmap = new Bitmap(str);
        try
        {
          if (this.Preview)
          {
            Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(this.ThumbnailCallback);
            if (this.urlimage == string.Empty)
            {
              float single = Convert.ToSingle(bitmap.Width > bitmap.Height ? Convert.ToSingle(num1) / Convert.ToSingle(bitmap.Width) : Convert.ToSingle(num1) / Convert.ToSingle(bitmap.Height));
              image = bitmap.GetThumbnailImage(Convert.ToInt32(Math.Ceiling((double) Convert.ToSingle(bitmap.Width) * (double) single)), Convert.ToInt32(Math.Ceiling((double) Convert.ToSingle(bitmap.Height) * (double) single)), callback, IntPtr.Zero);
            }
            else
            {
              int num2 = 100;
              float single = Convert.ToSingle(bitmap.Width > bitmap.Height ? Convert.ToSingle(num2) / Convert.ToSingle(bitmap.Width) : Convert.ToSingle(num2) / Convert.ToSingle(bitmap.Height));
              image = bitmap.GetThumbnailImage(Convert.ToInt32(Math.Ceiling((double) Convert.ToSingle(bitmap.Width) * (double) single)), 80, callback, IntPtr.Zero);
            }
            image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
          }
          else
            bitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
          this.Response.End();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
          this.GraphicError();
        }
        finally
        {
          bitmap?.Dispose();
          image?.Dispose();
        }
      }
      else
        this.GraphicError();
    }

    private bool ThumbnailCallback() => false;

    private void GraphicError()
    {
      Bitmap bitmap = new Bitmap(1, 1);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      SolidBrush solidBrush = new SolidBrush(Color.White);
      try
      {
        graphics.DrawRectangle(Pens.Yellow, 0, 0, 1, 1);
        this.Response.ContentType = "image/jpeg";
        bitmap.Save(this.Response.OutputStream, ImageFormat.Jpeg);
        this.Response.End();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
      finally
      {
        bitmap?.Dispose();
        graphics?.Dispose();
      }
    }
  }
}
