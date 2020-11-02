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
using  System.Drawing.Imaging;
using System.IO;

namespace WebCad.Apparecchiature
{
	/// <summary>
	/// Descrizione di riepilogo per PageImage.
	/// </summary>
	public class PageImage : System.Web.UI.Page
	{
		/// <summary>
		/// Variabili locale 
		/// Preview indica se bisogna visualizzare l'immagine in modalità priview ridimensionata
		/// ep_image indica il nome dell'immagine
		/// </summary>
		private bool Preview=false;
		private string ep_image=string.Empty;
		private string urlimage=string.Empty;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Inserire qui il codice utente necessario per inizializzare la pagina.
			if(!IsPostBack)
			{
				if(Request.QueryString["eq_image"]!=null)
				{
					this.ep_image=Request.QueryString["eq_image"];
					this.Preview=(Request.QueryString["p"]==null)?false:true;
					if (Request.QueryString["urlimage"]!=null)
					{
						this.urlimage =Server.UrlDecode((string)Request.QueryString["urlimage"]);
					}
					
					Thumbs();
				}
				else
				{
					GraphicError();
				}
			}
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

		/// <summary>
		/// Permette di ridimensionare l'immagine
		/// </summary>
		private void  Thumbs()
		{
	
			Bitmap photo;
			Int32 longestSide = 300;
			string path =string.Empty;

			if(this.urlimage==string.Empty)
				path =Path.Combine(Server.MapPath("../EQImages"),ep_image);
			else
				path =Path.Combine(Server.MapPath("../Doc_DB/" +this.urlimage),ep_image);

            Response.ContentType = "image/jpeg";
			System.Drawing.Image thumbnail=null;

			if (File.Exists(path))
			{
				photo =new Bitmap(path);
				try
				{
				

					if (Preview==true)
					{
						System.Drawing.Image.GetThumbnailImageAbort myCallback =new
							System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

						if(this.urlimage==string.Empty)
						{
							System.Single scale  = System.Convert.ToSingle((photo.Width > photo.Height)? System.Convert.ToSingle(longestSide) / System.Convert.ToSingle(photo.Width):
								System.Convert.ToSingle(longestSide) / System.Convert.ToSingle(photo.Height));
						
							thumbnail = photo.GetThumbnailImage(System.Convert.ToInt32 (Math.Ceiling((System.Convert.ToSingle(photo.Width) * scale))),
								System.Convert.ToInt32(Math.Ceiling((System.Convert.ToSingle(photo.Height) * scale))), myCallback, IntPtr.Zero);
						}
						else
						{
							longestSide=100;
							System.Single scale  = System.Convert.ToSingle((photo.Width > photo.Height)? System.Convert.ToSingle(longestSide) / System.Convert.ToSingle(photo.Width):
								System.Convert.ToSingle(longestSide) / System.Convert.ToSingle(photo.Height));
						
							thumbnail = photo.GetThumbnailImage(System.Convert.ToInt32 (Math.Ceiling((System.Convert.ToSingle(photo.Width) * scale))),
								80, myCallback, IntPtr.Zero);
						
						}
						thumbnail.Save(Response.OutputStream, ImageFormat.Jpeg);
					}
					else
					{
						photo.Save(Response.OutputStream, ImageFormat.Jpeg);
					}
					Response.End();
				} 
				catch(Exception ex) 
				{
					Console.WriteLine (ex.Message);
					GraphicError();
				} 
				finally 
				{
					if (!((photo == null))) 
					{ 
						photo.Dispose(); 
					} 
					if (!((thumbnail == null))) 
					{ 
						thumbnail.Dispose(); 
					}
				}
			}
			else
			{
			 GraphicError();
			}
		}
		private bool ThumbnailCallback()
		{
			return false;
		}

		/// <summary>
		/// In caso di errore viene generata una immagine alternativa
		/// </summary>
		private void GraphicError()
		{
			//Bitmap objBitmap = new Bitmap(180, 190);
			Bitmap objBitmap = new Bitmap(1, 1);
			//objBitmap.MakeTransparent(Color.White);
			Graphics objGraphic = Graphics.FromImage(objBitmap);
			SolidBrush drawBrush = new SolidBrush(Color.White);
			try
			{			
				objGraphic.DrawRectangle(Pens.Yellow,0,0,1,1);
				//objGraphic.DrawString("Immagine non disponibile!", new System.Drawing.Font("Verdana", 8), drawBrush, 0, 0);							
				Response.ContentType = "image/jpeg";
				objBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
				Response.End();
			} 
			catch(Exception ex) 
			  {
			     throw new Exception(ex.Message);
			  } 
			  finally 
			  {
				if (!((objBitmap == null))) 
				{ 
					objBitmap.Dispose(); 
				} 
				if (!((objGraphic == null))) 
				{ 
					objGraphic.Dispose(); 
				}
			  }
		}
																														
		
	}
}
