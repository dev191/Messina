// Decompiled with JetBrains decompiler
// Type: TheSite.SchemiXSD.NewDataSet
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace TheSite.SchemiXSD
{
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [ToolboxItem(true)]
  [Serializable]
  public class NewDataSet : DataSet
  {
    private NewDataSet.TblGeneraleDataTable tableTblGenerale;
    private NewDataSet.TblDatiTecniciDataTable tableTblDatiTecnici;
    private NewDataSet.TblPmpPassiDataTable tableTblPmpPassi;
    private NewDataSet.TblAllDataDataTable tableTblAllData;
    private NewDataSet.TblAllegatiDataTable tableTblAllegati;
    private NewDataSet.TblDatiTecniciEstesaDataTable tableTblDatiTecniciEstesa;
    private NewDataSet.TblAllegatiEstesaDataTable tableTblAllegatiEstesa;
    private NewDataSet.TblManRicDataTable tableTblManRic;
    private NewDataSet.TblManProgDataTable tableTblManProg;
    private NewDataSet.TblManStraDataTable tableTblManStra;

    public NewDataSet()
    {
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    protected NewDataSet(SerializationInfo info, StreamingContext context)
    {
      string s = (string) info.GetValue("XmlSchema", typeof (string));
      if (s != null)
      {
        DataSet dataSet = new DataSet();
        dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        if (dataSet.Tables[nameof (TblGenerale)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblGeneraleDataTable(dataSet.Tables[nameof (TblGenerale)]));
        if (dataSet.Tables[nameof (TblDatiTecnici)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblDatiTecniciDataTable(dataSet.Tables[nameof (TblDatiTecnici)]));
        if (dataSet.Tables[nameof (TblPmpPassi)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblPmpPassiDataTable(dataSet.Tables[nameof (TblPmpPassi)]));
        if (dataSet.Tables[nameof (TblAllData)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblAllDataDataTable(dataSet.Tables[nameof (TblAllData)]));
        if (dataSet.Tables[nameof (TblAllegati)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblAllegatiDataTable(dataSet.Tables[nameof (TblAllegati)]));
        if (dataSet.Tables[nameof (TblDatiTecniciEstesa)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblDatiTecniciEstesaDataTable(dataSet.Tables[nameof (TblDatiTecniciEstesa)]));
        if (dataSet.Tables[nameof (TblAllegatiEstesa)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblAllegatiEstesaDataTable(dataSet.Tables[nameof (TblAllegatiEstesa)]));
        if (dataSet.Tables[nameof (TblManRic)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblManRicDataTable(dataSet.Tables[nameof (TblManRic)]));
        if (dataSet.Tables[nameof (TblManProg)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblManProgDataTable(dataSet.Tables[nameof (TblManProg)]));
        if (dataSet.Tables[nameof (TblManStra)] != null)
          this.Tables.Add((DataTable) new NewDataSet.TblManStraDataTable(dataSet.Tables[nameof (TblManStra)]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
        this.InitClass();
      this.GetSerializationData(info, context);
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NewDataSet.TblGeneraleDataTable TblGenerale => this.tableTblGenerale;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NewDataSet.TblDatiTecniciDataTable TblDatiTecnici => this.tableTblDatiTecnici;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NewDataSet.TblPmpPassiDataTable TblPmpPassi => this.tableTblPmpPassi;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public NewDataSet.TblAllDataDataTable TblAllData => this.tableTblAllData;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public NewDataSet.TblAllegatiDataTable TblAllegati => this.tableTblAllegati;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NewDataSet.TblDatiTecniciEstesaDataTable TblDatiTecniciEstesa => this.tableTblDatiTecniciEstesa;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NewDataSet.TblAllegatiEstesaDataTable TblAllegatiEstesa => this.tableTblAllegatiEstesa;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public NewDataSet.TblManRicDataTable TblManRic => this.tableTblManRic;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public NewDataSet.TblManProgDataTable TblManProg => this.tableTblManProg;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public NewDataSet.TblManStraDataTable TblManStra => this.tableTblManStra;

    public override DataSet Clone()
    {
      NewDataSet newDataSet = (NewDataSet) base.Clone();
      newDataSet.InitVars();
      return (DataSet) newDataSet;
    }

    protected override bool ShouldSerializeTables() => false;

    protected override bool ShouldSerializeRelations() => false;

    protected override void ReadXmlSerializable(XmlReader reader)
    {
      this.Reset();
      DataSet dataSet = new DataSet();
      int num = (int) dataSet.ReadXml(reader);
      if (dataSet.Tables["TblGenerale"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblGeneraleDataTable(dataSet.Tables["TblGenerale"]));
      if (dataSet.Tables["TblDatiTecnici"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblDatiTecniciDataTable(dataSet.Tables["TblDatiTecnici"]));
      if (dataSet.Tables["TblPmpPassi"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblPmpPassiDataTable(dataSet.Tables["TblPmpPassi"]));
      if (dataSet.Tables["TblAllData"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblAllDataDataTable(dataSet.Tables["TblAllData"]));
      if (dataSet.Tables["TblAllegati"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblAllegatiDataTable(dataSet.Tables["TblAllegati"]));
      if (dataSet.Tables["TblDatiTecniciEstesa"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblDatiTecniciEstesaDataTable(dataSet.Tables["TblDatiTecniciEstesa"]));
      if (dataSet.Tables["TblAllegatiEstesa"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblAllegatiEstesaDataTable(dataSet.Tables["TblAllegatiEstesa"]));
      if (dataSet.Tables["TblManRic"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblManRicDataTable(dataSet.Tables["TblManRic"]));
      if (dataSet.Tables["TblManProg"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblManProgDataTable(dataSet.Tables["TblManProg"]));
      if (dataSet.Tables["TblManStra"] != null)
        this.Tables.Add((DataTable) new NewDataSet.TblManStraDataTable(dataSet.Tables["TblManStra"]));
      this.DataSetName = dataSet.DataSetName;
      this.Prefix = dataSet.Prefix;
      this.Namespace = dataSet.Namespace;
      this.Locale = dataSet.Locale;
      this.CaseSensitive = dataSet.CaseSensitive;
      this.EnforceConstraints = dataSet.EnforceConstraints;
      this.Merge(dataSet, false, MissingSchemaAction.Add);
      this.InitVars();
    }

    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    internal void InitVars()
    {
      this.tableTblGenerale = (NewDataSet.TblGeneraleDataTable) this.Tables["TblGenerale"];
      if (this.tableTblGenerale != null)
        this.tableTblGenerale.InitVars();
      this.tableTblDatiTecnici = (NewDataSet.TblDatiTecniciDataTable) this.Tables["TblDatiTecnici"];
      if (this.tableTblDatiTecnici != null)
        this.tableTblDatiTecnici.InitVars();
      this.tableTblPmpPassi = (NewDataSet.TblPmpPassiDataTable) this.Tables["TblPmpPassi"];
      if (this.tableTblPmpPassi != null)
        this.tableTblPmpPassi.InitVars();
      this.tableTblAllData = (NewDataSet.TblAllDataDataTable) this.Tables["TblAllData"];
      if (this.tableTblAllData != null)
        this.tableTblAllData.InitVars();
      this.tableTblAllegati = (NewDataSet.TblAllegatiDataTable) this.Tables["TblAllegati"];
      if (this.tableTblAllegati != null)
        this.tableTblAllegati.InitVars();
      this.tableTblDatiTecniciEstesa = (NewDataSet.TblDatiTecniciEstesaDataTable) this.Tables["TblDatiTecniciEstesa"];
      if (this.tableTblDatiTecniciEstesa != null)
        this.tableTblDatiTecniciEstesa.InitVars();
      this.tableTblAllegatiEstesa = (NewDataSet.TblAllegatiEstesaDataTable) this.Tables["TblAllegatiEstesa"];
      if (this.tableTblAllegatiEstesa != null)
        this.tableTblAllegatiEstesa.InitVars();
      this.tableTblManRic = (NewDataSet.TblManRicDataTable) this.Tables["TblManRic"];
      if (this.tableTblManRic != null)
        this.tableTblManRic.InitVars();
      this.tableTblManProg = (NewDataSet.TblManProgDataTable) this.Tables["TblManProg"];
      if (this.tableTblManProg != null)
        this.tableTblManProg.InitVars();
      this.tableTblManStra = (NewDataSet.TblManStraDataTable) this.Tables["TblManStra"];
      if (this.tableTblManStra == null)
        return;
      this.tableTblManStra.InitVars();
    }

    private void InitClass()
    {
      this.DataSetName = nameof (NewDataSet);
      this.Prefix = "";
      this.Namespace = "";
      this.Locale = new CultureInfo("it-IT");
      this.CaseSensitive = false;
      this.EnforceConstraints = true;
      this.tableTblGenerale = new NewDataSet.TblGeneraleDataTable();
      this.Tables.Add((DataTable) this.tableTblGenerale);
      this.tableTblDatiTecnici = new NewDataSet.TblDatiTecniciDataTable();
      this.Tables.Add((DataTable) this.tableTblDatiTecnici);
      this.tableTblPmpPassi = new NewDataSet.TblPmpPassiDataTable();
      this.Tables.Add((DataTable) this.tableTblPmpPassi);
      this.tableTblAllData = new NewDataSet.TblAllDataDataTable();
      this.Tables.Add((DataTable) this.tableTblAllData);
      this.tableTblAllegati = new NewDataSet.TblAllegatiDataTable();
      this.Tables.Add((DataTable) this.tableTblAllegati);
      this.tableTblDatiTecniciEstesa = new NewDataSet.TblDatiTecniciEstesaDataTable();
      this.Tables.Add((DataTable) this.tableTblDatiTecniciEstesa);
      this.tableTblAllegatiEstesa = new NewDataSet.TblAllegatiEstesaDataTable();
      this.Tables.Add((DataTable) this.tableTblAllegatiEstesa);
      this.tableTblManRic = new NewDataSet.TblManRicDataTable();
      this.Tables.Add((DataTable) this.tableTblManRic);
      this.tableTblManProg = new NewDataSet.TblManProgDataTable();
      this.Tables.Add((DataTable) this.tableTblManProg);
      this.tableTblManStra = new NewDataSet.TblManStraDataTable();
      this.Tables.Add((DataTable) this.tableTblManStra);
    }

    private bool ShouldSerializeTblGenerale() => false;

    private bool ShouldSerializeTblDatiTecnici() => false;

    private bool ShouldSerializeTblPmpPassi() => false;

    private bool ShouldSerializeTblAllData() => false;

    private bool ShouldSerializeTblAllegati() => false;

    private bool ShouldSerializeTblDatiTecniciEstesa() => false;

    private bool ShouldSerializeTblAllegatiEstesa() => false;

    private bool ShouldSerializeTblManRic() => false;

    private bool ShouldSerializeTblManProg() => false;

    private bool ShouldSerializeTblManStra() => false;

    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    public delegate void TblGeneraleRowChangeEventHandler(
      object sender,
      NewDataSet.TblGeneraleRowChangeEvent e);

    public delegate void TblDatiTecniciRowChangeEventHandler(
      object sender,
      NewDataSet.TblDatiTecniciRowChangeEvent e);

    public delegate void TblPmpPassiRowChangeEventHandler(
      object sender,
      NewDataSet.TblPmpPassiRowChangeEvent e);

    public delegate void TblAllDataRowChangeEventHandler(
      object sender,
      NewDataSet.TblAllDataRowChangeEvent e);

    public delegate void TblAllegatiRowChangeEventHandler(
      object sender,
      NewDataSet.TblAllegatiRowChangeEvent e);

    public delegate void TblDatiTecniciEstesaRowChangeEventHandler(
      object sender,
      NewDataSet.TblDatiTecniciEstesaRowChangeEvent e);

    public delegate void TblAllegatiEstesaRowChangeEventHandler(
      object sender,
      NewDataSet.TblAllegatiEstesaRowChangeEvent e);

    public delegate void TblManRicRowChangeEventHandler(
      object sender,
      NewDataSet.TblManRicRowChangeEvent e);

    public delegate void TblManProgRowChangeEventHandler(
      object sender,
      NewDataSet.TblManProgRowChangeEvent e);

    public delegate void TblManStraRowChangeEventHandler(
      object sender,
      NewDataSet.TblManStraRowChangeEvent e);

    [DebuggerStepThrough]
    public class TblGeneraleDataTable : DataTable, IEnumerable
    {
      private DataColumn columnEQ_ID;
      private DataColumn columnEQ_OPTION1;
      private DataColumn columnEQ_CONDITION;
      private DataColumn columnEQ_CRITICALITY;
      private DataColumn columnEQ_OPTION2;
      private DataColumn columnEQ_GARANZIA;
      private DataColumn columnEQSTD_MODELNO;
      private DataColumn columnEQ_IMAGE_EQ_ASSY;
      private DataColumn columnEQ_RM_ID;
      private DataColumn columnEQ_BL_ID;
      private DataColumn columnEQ_VN_ID;
      private DataColumn columnEQ_LOC_COLUMN;
      private DataColumn columnEQ_LOC_MAINT_MANL;
      private DataColumn columnEQ_EQ_COMMENTS;
      private DataColumn columnEQ_POTENZA;
      private DataColumn columnEQ_FUEL_ID;
      private DataColumn columnEQ_DATE_MANUFACTURED;
      private DataColumn columnEQ_DATE_INSTALLED;
      private DataColumn columnEQ_DATE_IN_SERVICE;
      private DataColumn columnEQ_UTENZA;
      private DataColumn columnEQ_EQSTD;
      private DataColumn columnEQ_EQSTD_ID;
      private DataColumn columnEQ_QTY_PMS;
      private DataColumn columnEQSTD_OPTION2;
      private DataColumn columnEQ_NUM_SERIAL;
      private DataColumn columnEQ_SOTTOCOMPONENTE;
      private DataColumn columnEQSTD_MFR;
      private DataColumn columnEQSTD_CATEGORY;
      private DataColumn columnEQSTD_OPTION1;
      private DataColumn columnEQSTD_DESCRIPTION;
      private DataColumn columnEQSTD_EQ_STD;
      private DataColumn columnPIANI_DESC_ID_DESCRIZIONE;
      private DataColumn columnRM_RM_ID_DESCRIZIONE;
      private DataColumn columnBL_NAME;
      private DataColumn columnEQ_IMMAGINI_IMMAGINE;
      private DataColumn columnIdEqstd;
      private DataColumn columnIdEq;

      internal TblGeneraleDataTable()
        : base("TblGenerale")
        => this.InitClass();

      internal TblGeneraleDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn EQ_IDColumn => this.columnEQ_ID;

      internal DataColumn EQ_OPTION1Column => this.columnEQ_OPTION1;

      internal DataColumn EQ_CONDITIONColumn => this.columnEQ_CONDITION;

      internal DataColumn EQ_CRITICALITYColumn => this.columnEQ_CRITICALITY;

      internal DataColumn EQ_OPTION2Column => this.columnEQ_OPTION2;

      internal DataColumn EQ_GARANZIAColumn => this.columnEQ_GARANZIA;

      internal DataColumn EQSTD_MODELNOColumn => this.columnEQSTD_MODELNO;

      internal DataColumn EQ_IMAGE_EQ_ASSYColumn => this.columnEQ_IMAGE_EQ_ASSY;

      internal DataColumn EQ_RM_IDColumn => this.columnEQ_RM_ID;

      internal DataColumn EQ_BL_IDColumn => this.columnEQ_BL_ID;

      internal DataColumn EQ_VN_IDColumn => this.columnEQ_VN_ID;

      internal DataColumn EQ_LOC_COLUMNColumn => this.columnEQ_LOC_COLUMN;

      internal DataColumn EQ_LOC_MAINT_MANLColumn => this.columnEQ_LOC_MAINT_MANL;

      internal DataColumn EQ_EQ_COMMENTSColumn => this.columnEQ_EQ_COMMENTS;

      internal DataColumn EQ_POTENZAColumn => this.columnEQ_POTENZA;

      internal DataColumn EQ_FUEL_IDColumn => this.columnEQ_FUEL_ID;

      internal DataColumn EQ_DATE_MANUFACTUREDColumn => this.columnEQ_DATE_MANUFACTURED;

      internal DataColumn EQ_DATE_INSTALLEDColumn => this.columnEQ_DATE_INSTALLED;

      internal DataColumn EQ_DATE_IN_SERVICEColumn => this.columnEQ_DATE_IN_SERVICE;

      internal DataColumn EQ_UTENZAColumn => this.columnEQ_UTENZA;

      internal DataColumn EQ_EQSTDColumn => this.columnEQ_EQSTD;

      internal DataColumn EQ_EQSTD_IDColumn => this.columnEQ_EQSTD_ID;

      internal DataColumn EQ_QTY_PMSColumn => this.columnEQ_QTY_PMS;

      internal DataColumn EQSTD_OPTION2Column => this.columnEQSTD_OPTION2;

      internal DataColumn EQ_NUM_SERIALColumn => this.columnEQ_NUM_SERIAL;

      internal DataColumn EQ_SOTTOCOMPONENTEColumn => this.columnEQ_SOTTOCOMPONENTE;

      internal DataColumn EQSTD_MFRColumn => this.columnEQSTD_MFR;

      internal DataColumn EQSTD_CATEGORYColumn => this.columnEQSTD_CATEGORY;

      internal DataColumn EQSTD_OPTION1Column => this.columnEQSTD_OPTION1;

      internal DataColumn EQSTD_DESCRIPTIONColumn => this.columnEQSTD_DESCRIPTION;

      internal DataColumn EQSTD_EQ_STDColumn => this.columnEQSTD_EQ_STD;

      internal DataColumn PIANI_DESC_ID_DESCRIZIONEColumn => this.columnPIANI_DESC_ID_DESCRIZIONE;

      internal DataColumn RM_RM_ID_DESCRIZIONEColumn => this.columnRM_RM_ID_DESCRIZIONE;

      internal DataColumn BL_NAMEColumn => this.columnBL_NAME;

      internal DataColumn EQ_IMMAGINI_IMMAGINEColumn => this.columnEQ_IMMAGINI_IMMAGINE;

      internal DataColumn IdEqstdColumn => this.columnIdEqstd;

      internal DataColumn IdEqColumn => this.columnIdEq;

      public NewDataSet.TblGeneraleRow this[int index] => (NewDataSet.TblGeneraleRow) this.Rows[index];

      public event NewDataSet.TblGeneraleRowChangeEventHandler TblGeneraleRowChanged;

      public event NewDataSet.TblGeneraleRowChangeEventHandler TblGeneraleRowChanging;

      public event NewDataSet.TblGeneraleRowChangeEventHandler TblGeneraleRowDeleted;

      public event NewDataSet.TblGeneraleRowChangeEventHandler TblGeneraleRowDeleting;

      public void AddTblGeneraleRow(NewDataSet.TblGeneraleRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblGeneraleRow AddTblGeneraleRow(
        string EQ_ID,
        string EQ_OPTION1,
        string EQ_CONDITION,
        string EQ_CRITICALITY,
        string EQ_OPTION2,
        string EQ_GARANZIA,
        string EQSTD_MODELNO,
        string EQ_IMAGE_EQ_ASSY,
        string EQ_RM_ID,
        string EQ_BL_ID,
        string EQ_VN_ID,
        string EQ_LOC_COLUMN,
        string EQ_LOC_MAINT_MANL,
        string EQ_EQ_COMMENTS,
        string EQ_POTENZA,
        string EQ_FUEL_ID,
        string EQ_DATE_MANUFACTURED,
        string EQ_DATE_INSTALLED,
        string EQ_DATE_IN_SERVICE,
        string EQ_UTENZA,
        string EQ_EQSTD,
        string EQ_EQSTD_ID,
        string EQ_QTY_PMS,
        string EQSTD_OPTION2,
        string EQ_NUM_SERIAL,
        string EQ_SOTTOCOMPONENTE,
        string EQSTD_MFR,
        string EQSTD_CATEGORY,
        string EQSTD_OPTION1,
        string EQSTD_DESCRIPTION,
        string EQSTD_EQ_STD,
        string PIANI_DESC_ID_DESCRIZIONE,
        string RM_RM_ID_DESCRIZIONE,
        string BL_NAME,
        byte[] EQ_IMMAGINI_IMMAGINE,
        Decimal IdEqstd,
        Decimal IdEq)
      {
        NewDataSet.TblGeneraleRow tblGeneraleRow = (NewDataSet.TblGeneraleRow) this.NewRow();
        tblGeneraleRow.ItemArray = new object[37]
        {
          (object) EQ_ID,
          (object) EQ_OPTION1,
          (object) EQ_CONDITION,
          (object) EQ_CRITICALITY,
          (object) EQ_OPTION2,
          (object) EQ_GARANZIA,
          (object) EQSTD_MODELNO,
          (object) EQ_IMAGE_EQ_ASSY,
          (object) EQ_RM_ID,
          (object) EQ_BL_ID,
          (object) EQ_VN_ID,
          (object) EQ_LOC_COLUMN,
          (object) EQ_LOC_MAINT_MANL,
          (object) EQ_EQ_COMMENTS,
          (object) EQ_POTENZA,
          (object) EQ_FUEL_ID,
          (object) EQ_DATE_MANUFACTURED,
          (object) EQ_DATE_INSTALLED,
          (object) EQ_DATE_IN_SERVICE,
          (object) EQ_UTENZA,
          (object) EQ_EQSTD,
          (object) EQ_EQSTD_ID,
          (object) EQ_QTY_PMS,
          (object) EQSTD_OPTION2,
          (object) EQ_NUM_SERIAL,
          (object) EQ_SOTTOCOMPONENTE,
          (object) EQSTD_MFR,
          (object) EQSTD_CATEGORY,
          (object) EQSTD_OPTION1,
          (object) EQSTD_DESCRIPTION,
          (object) EQSTD_EQ_STD,
          (object) PIANI_DESC_ID_DESCRIZIONE,
          (object) RM_RM_ID_DESCRIZIONE,
          (object) BL_NAME,
          (object) EQ_IMMAGINI_IMMAGINE,
          (object) IdEqstd,
          (object) IdEq
        };
        this.Rows.Add((DataRow) tblGeneraleRow);
        return tblGeneraleRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblGeneraleDataTable generaleDataTable = (NewDataSet.TblGeneraleDataTable) base.Clone();
        generaleDataTable.InitVars();
        return (DataTable) generaleDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblGeneraleDataTable();

      internal void InitVars()
      {
        this.columnEQ_ID = this.Columns["EQ_ID"];
        this.columnEQ_OPTION1 = this.Columns["EQ_OPTION1"];
        this.columnEQ_CONDITION = this.Columns["EQ_CONDITION"];
        this.columnEQ_CRITICALITY = this.Columns["EQ_CRITICALITY"];
        this.columnEQ_OPTION2 = this.Columns["EQ_OPTION2"];
        this.columnEQ_GARANZIA = this.Columns["EQ_GARANZIA"];
        this.columnEQSTD_MODELNO = this.Columns["EQSTD_MODELNO"];
        this.columnEQ_IMAGE_EQ_ASSY = this.Columns["EQ_IMAGE_EQ_ASSY"];
        this.columnEQ_RM_ID = this.Columns["EQ_RM_ID"];
        this.columnEQ_BL_ID = this.Columns["EQ_BL_ID"];
        this.columnEQ_VN_ID = this.Columns["EQ_VN_ID"];
        this.columnEQ_LOC_COLUMN = this.Columns["EQ_LOC_COLUMN"];
        this.columnEQ_LOC_MAINT_MANL = this.Columns["EQ_LOC_MAINT_MANL"];
        this.columnEQ_EQ_COMMENTS = this.Columns["EQ_EQ_COMMENTS"];
        this.columnEQ_POTENZA = this.Columns["EQ_POTENZA"];
        this.columnEQ_FUEL_ID = this.Columns["EQ_FUEL_ID"];
        this.columnEQ_DATE_MANUFACTURED = this.Columns["EQ_DATE_MANUFACTURED"];
        this.columnEQ_DATE_INSTALLED = this.Columns["EQ_DATE_INSTALLED"];
        this.columnEQ_DATE_IN_SERVICE = this.Columns["EQ_DATE_IN_SERVICE"];
        this.columnEQ_UTENZA = this.Columns["EQ_UTENZA"];
        this.columnEQ_EQSTD = this.Columns["EQ_EQSTD"];
        this.columnEQ_EQSTD_ID = this.Columns["EQ_EQSTD_ID"];
        this.columnEQ_QTY_PMS = this.Columns["EQ_QTY_PMS"];
        this.columnEQSTD_OPTION2 = this.Columns["EQSTD_OPTION2"];
        this.columnEQ_NUM_SERIAL = this.Columns["EQ_NUM_SERIAL"];
        this.columnEQ_SOTTOCOMPONENTE = this.Columns["EQ_SOTTOCOMPONENTE"];
        this.columnEQSTD_MFR = this.Columns["EQSTD_MFR"];
        this.columnEQSTD_CATEGORY = this.Columns["EQSTD_CATEGORY"];
        this.columnEQSTD_OPTION1 = this.Columns["EQSTD_OPTION1"];
        this.columnEQSTD_DESCRIPTION = this.Columns["EQSTD_DESCRIPTION"];
        this.columnEQSTD_EQ_STD = this.Columns["EQSTD_EQ_STD"];
        this.columnPIANI_DESC_ID_DESCRIZIONE = this.Columns["PIANI_DESC_ID_DESCRIZIONE"];
        this.columnRM_RM_ID_DESCRIZIONE = this.Columns["RM_RM_ID_DESCRIZIONE"];
        this.columnBL_NAME = this.Columns["BL_NAME"];
        this.columnEQ_IMMAGINI_IMMAGINE = this.Columns["EQ_IMMAGINI_IMMAGINE"];
        this.columnIdEqstd = this.Columns["IdEqstd"];
        this.columnIdEq = this.Columns["IdEq"];
      }

      private void InitClass()
      {
        this.columnEQ_ID = new DataColumn("EQ_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID);
        this.columnEQ_OPTION1 = new DataColumn("EQ_OPTION1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_OPTION1);
        this.columnEQ_CONDITION = new DataColumn("EQ_CONDITION", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_CONDITION);
        this.columnEQ_CRITICALITY = new DataColumn("EQ_CRITICALITY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_CRITICALITY);
        this.columnEQ_OPTION2 = new DataColumn("EQ_OPTION2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_OPTION2);
        this.columnEQ_GARANZIA = new DataColumn("EQ_GARANZIA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_GARANZIA);
        this.columnEQSTD_MODELNO = new DataColumn("EQSTD_MODELNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_MODELNO);
        this.columnEQ_IMAGE_EQ_ASSY = new DataColumn("EQ_IMAGE_EQ_ASSY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_IMAGE_EQ_ASSY);
        this.columnEQ_RM_ID = new DataColumn("EQ_RM_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_RM_ID);
        this.columnEQ_BL_ID = new DataColumn("EQ_BL_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_BL_ID);
        this.columnEQ_VN_ID = new DataColumn("EQ_VN_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_VN_ID);
        this.columnEQ_LOC_COLUMN = new DataColumn("EQ_LOC_COLUMN", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_LOC_COLUMN);
        this.columnEQ_LOC_MAINT_MANL = new DataColumn("EQ_LOC_MAINT_MANL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_LOC_MAINT_MANL);
        this.columnEQ_EQ_COMMENTS = new DataColumn("EQ_EQ_COMMENTS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_EQ_COMMENTS);
        this.columnEQ_POTENZA = new DataColumn("EQ_POTENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_POTENZA);
        this.columnEQ_FUEL_ID = new DataColumn("EQ_FUEL_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_FUEL_ID);
        this.columnEQ_DATE_MANUFACTURED = new DataColumn("EQ_DATE_MANUFACTURED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_DATE_MANUFACTURED);
        this.columnEQ_DATE_INSTALLED = new DataColumn("EQ_DATE_INSTALLED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_DATE_INSTALLED);
        this.columnEQ_DATE_IN_SERVICE = new DataColumn("EQ_DATE_IN_SERVICE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_DATE_IN_SERVICE);
        this.columnEQ_UTENZA = new DataColumn("EQ_UTENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_UTENZA);
        this.columnEQ_EQSTD = new DataColumn("EQ_EQSTD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_EQSTD);
        this.columnEQ_EQSTD_ID = new DataColumn("EQ_EQSTD_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_EQSTD_ID);
        this.columnEQ_QTY_PMS = new DataColumn("EQ_QTY_PMS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_QTY_PMS);
        this.columnEQSTD_OPTION2 = new DataColumn("EQSTD_OPTION2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_OPTION2);
        this.columnEQ_NUM_SERIAL = new DataColumn("EQ_NUM_SERIAL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_NUM_SERIAL);
        this.columnEQ_SOTTOCOMPONENTE = new DataColumn("EQ_SOTTOCOMPONENTE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_SOTTOCOMPONENTE);
        this.columnEQSTD_MFR = new DataColumn("EQSTD_MFR", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_MFR);
        this.columnEQSTD_CATEGORY = new DataColumn("EQSTD_CATEGORY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_CATEGORY);
        this.columnEQSTD_OPTION1 = new DataColumn("EQSTD_OPTION1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_OPTION1);
        this.columnEQSTD_DESCRIPTION = new DataColumn("EQSTD_DESCRIPTION", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_DESCRIPTION);
        this.columnEQSTD_EQ_STD = new DataColumn("EQSTD_EQ_STD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_EQ_STD);
        this.columnPIANI_DESC_ID_DESCRIZIONE = new DataColumn("PIANI_DESC_ID_DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPIANI_DESC_ID_DESCRIZIONE);
        this.columnRM_RM_ID_DESCRIZIONE = new DataColumn("RM_RM_ID_DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRM_RM_ID_DESCRIZIONE);
        this.columnBL_NAME = new DataColumn("BL_NAME", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBL_NAME);
        this.columnEQ_IMMAGINI_IMMAGINE = new DataColumn("EQ_IMMAGINI_IMMAGINE", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_IMMAGINI_IMMAGINE);
        this.columnIdEqstd = new DataColumn("IdEqstd", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEqstd);
        this.columnIdEq = new DataColumn("IdEq", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEq);
      }

      public NewDataSet.TblGeneraleRow NewTblGeneraleRow() => (NewDataSet.TblGeneraleRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblGeneraleRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblGeneraleRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblGeneraleRowChanged == null)
          return;
        this.TblGeneraleRowChanged((object) this, new NewDataSet.TblGeneraleRowChangeEvent((NewDataSet.TblGeneraleRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblGeneraleRowChanging == null)
          return;
        this.TblGeneraleRowChanging((object) this, new NewDataSet.TblGeneraleRowChangeEvent((NewDataSet.TblGeneraleRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblGeneraleRowDeleted == null)
          return;
        this.TblGeneraleRowDeleted((object) this, new NewDataSet.TblGeneraleRowChangeEvent((NewDataSet.TblGeneraleRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblGeneraleRowDeleting == null)
          return;
        this.TblGeneraleRowDeleting((object) this, new NewDataSet.TblGeneraleRowChangeEvent((NewDataSet.TblGeneraleRow) e.Row, e.Action));
      }

      public void RemoveTblGeneraleRow(NewDataSet.TblGeneraleRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblGeneraleRow : DataRow
    {
      private NewDataSet.TblGeneraleDataTable tableTblGenerale;

      internal TblGeneraleRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblGenerale = (NewDataSet.TblGeneraleDataTable) this.Table;

      public string EQ_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_IDColumn] = (object) value;
      }

      public string EQ_OPTION1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_OPTION1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_OPTION1Column] = (object) value;
      }

      public string EQ_CONDITION
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_CONDITIONColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_CONDITIONColumn] = (object) value;
      }

      public string EQ_CRITICALITY
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_CRITICALITYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_CRITICALITYColumn] = (object) value;
      }

      public string EQ_OPTION2
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_OPTION2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_OPTION2Column] = (object) value;
      }

      public string EQ_GARANZIA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_GARANZIAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_GARANZIAColumn] = (object) value;
      }

      public string EQSTD_MODELNO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_MODELNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_MODELNOColumn] = (object) value;
      }

      public string EQ_IMAGE_EQ_ASSY
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_IMAGE_EQ_ASSYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_IMAGE_EQ_ASSYColumn] = (object) value;
      }

      public string EQ_RM_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_RM_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_RM_IDColumn] = (object) value;
      }

      public string EQ_BL_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_BL_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_BL_IDColumn] = (object) value;
      }

      public string EQ_VN_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_VN_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_VN_IDColumn] = (object) value;
      }

      public string EQ_LOC_COLUMN
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_LOC_COLUMNColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_LOC_COLUMNColumn] = (object) value;
      }

      public string EQ_LOC_MAINT_MANL
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_LOC_MAINT_MANLColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_LOC_MAINT_MANLColumn] = (object) value;
      }

      public string EQ_EQ_COMMENTS
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_EQ_COMMENTSColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_EQ_COMMENTSColumn] = (object) value;
      }

      public string EQ_POTENZA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_POTENZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_POTENZAColumn] = (object) value;
      }

      public string EQ_FUEL_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_FUEL_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_FUEL_IDColumn] = (object) value;
      }

      public string EQ_DATE_MANUFACTURED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_DATE_MANUFACTUREDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_DATE_MANUFACTUREDColumn] = (object) value;
      }

      public string EQ_DATE_INSTALLED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_DATE_INSTALLEDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_DATE_INSTALLEDColumn] = (object) value;
      }

      public string EQ_DATE_IN_SERVICE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_DATE_IN_SERVICEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_DATE_IN_SERVICEColumn] = (object) value;
      }

      public string EQ_UTENZA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_UTENZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_UTENZAColumn] = (object) value;
      }

      public string EQ_EQSTD
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_EQSTDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_EQSTDColumn] = (object) value;
      }

      public string EQ_EQSTD_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_EQSTD_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_EQSTD_IDColumn] = (object) value;
      }

      public string EQ_QTY_PMS
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_QTY_PMSColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_QTY_PMSColumn] = (object) value;
      }

      public string EQSTD_OPTION2
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_OPTION2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_OPTION2Column] = (object) value;
      }

      public string EQ_NUM_SERIAL
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_NUM_SERIALColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_NUM_SERIALColumn] = (object) value;
      }

      public string EQ_SOTTOCOMPONENTE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQ_SOTTOCOMPONENTEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_SOTTOCOMPONENTEColumn] = (object) value;
      }

      public string EQSTD_MFR
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_MFRColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_MFRColumn] = (object) value;
      }

      public string EQSTD_CATEGORY
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_CATEGORYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_CATEGORYColumn] = (object) value;
      }

      public string EQSTD_OPTION1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_OPTION1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_OPTION1Column] = (object) value;
      }

      public string EQSTD_DESCRIPTION
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_DESCRIPTIONColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_DESCRIPTIONColumn] = (object) value;
      }

      public string EQSTD_EQ_STD
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.EQSTD_EQ_STDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQSTD_EQ_STDColumn] = (object) value;
      }

      public string PIANI_DESC_ID_DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.PIANI_DESC_ID_DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.PIANI_DESC_ID_DESCRIZIONEColumn] = (object) value;
      }

      public string RM_RM_ID_DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.RM_RM_ID_DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.RM_RM_ID_DESCRIZIONEColumn] = (object) value;
      }

      public string BL_NAME
      {
        get
        {
          try
          {
            return (string) this[this.tableTblGenerale.BL_NAMEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.BL_NAMEColumn] = (object) value;
      }

      public byte[] EQ_IMMAGINI_IMMAGINE
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableTblGenerale.EQ_IMMAGINI_IMMAGINEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.EQ_IMMAGINI_IMMAGINEColumn] = (object) value;
      }

      public Decimal IdEqstd
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblGenerale.IdEqstdColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.IdEqstdColumn] = (object) value;
      }

      public Decimal IdEq
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblGenerale.IdEqColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblGenerale.IdEqColumn] = (object) value;
      }

      public bool IsEQ_IDNull() => this.IsNull(this.tableTblGenerale.EQ_IDColumn);

      public void SetEQ_IDNull() => this[this.tableTblGenerale.EQ_IDColumn] = Convert.DBNull;

      public bool IsEQ_OPTION1Null() => this.IsNull(this.tableTblGenerale.EQ_OPTION1Column);

      public void SetEQ_OPTION1Null() => this[this.tableTblGenerale.EQ_OPTION1Column] = Convert.DBNull;

      public bool IsEQ_CONDITIONNull() => this.IsNull(this.tableTblGenerale.EQ_CONDITIONColumn);

      public void SetEQ_CONDITIONNull() => this[this.tableTblGenerale.EQ_CONDITIONColumn] = Convert.DBNull;

      public bool IsEQ_CRITICALITYNull() => this.IsNull(this.tableTblGenerale.EQ_CRITICALITYColumn);

      public void SetEQ_CRITICALITYNull() => this[this.tableTblGenerale.EQ_CRITICALITYColumn] = Convert.DBNull;

      public bool IsEQ_OPTION2Null() => this.IsNull(this.tableTblGenerale.EQ_OPTION2Column);

      public void SetEQ_OPTION2Null() => this[this.tableTblGenerale.EQ_OPTION2Column] = Convert.DBNull;

      public bool IsEQ_GARANZIANull() => this.IsNull(this.tableTblGenerale.EQ_GARANZIAColumn);

      public void SetEQ_GARANZIANull() => this[this.tableTblGenerale.EQ_GARANZIAColumn] = Convert.DBNull;

      public bool IsEQSTD_MODELNONull() => this.IsNull(this.tableTblGenerale.EQSTD_MODELNOColumn);

      public void SetEQSTD_MODELNONull() => this[this.tableTblGenerale.EQSTD_MODELNOColumn] = Convert.DBNull;

      public bool IsEQ_IMAGE_EQ_ASSYNull() => this.IsNull(this.tableTblGenerale.EQ_IMAGE_EQ_ASSYColumn);

      public void SetEQ_IMAGE_EQ_ASSYNull() => this[this.tableTblGenerale.EQ_IMAGE_EQ_ASSYColumn] = Convert.DBNull;

      public bool IsEQ_RM_IDNull() => this.IsNull(this.tableTblGenerale.EQ_RM_IDColumn);

      public void SetEQ_RM_IDNull() => this[this.tableTblGenerale.EQ_RM_IDColumn] = Convert.DBNull;

      public bool IsEQ_BL_IDNull() => this.IsNull(this.tableTblGenerale.EQ_BL_IDColumn);

      public void SetEQ_BL_IDNull() => this[this.tableTblGenerale.EQ_BL_IDColumn] = Convert.DBNull;

      public bool IsEQ_VN_IDNull() => this.IsNull(this.tableTblGenerale.EQ_VN_IDColumn);

      public void SetEQ_VN_IDNull() => this[this.tableTblGenerale.EQ_VN_IDColumn] = Convert.DBNull;

      public bool IsEQ_LOC_COLUMNNull() => this.IsNull(this.tableTblGenerale.EQ_LOC_COLUMNColumn);

      public void SetEQ_LOC_COLUMNNull() => this[this.tableTblGenerale.EQ_LOC_COLUMNColumn] = Convert.DBNull;

      public bool IsEQ_LOC_MAINT_MANLNull() => this.IsNull(this.tableTblGenerale.EQ_LOC_MAINT_MANLColumn);

      public void SetEQ_LOC_MAINT_MANLNull() => this[this.tableTblGenerale.EQ_LOC_MAINT_MANLColumn] = Convert.DBNull;

      public bool IsEQ_EQ_COMMENTSNull() => this.IsNull(this.tableTblGenerale.EQ_EQ_COMMENTSColumn);

      public void SetEQ_EQ_COMMENTSNull() => this[this.tableTblGenerale.EQ_EQ_COMMENTSColumn] = Convert.DBNull;

      public bool IsEQ_POTENZANull() => this.IsNull(this.tableTblGenerale.EQ_POTENZAColumn);

      public void SetEQ_POTENZANull() => this[this.tableTblGenerale.EQ_POTENZAColumn] = Convert.DBNull;

      public bool IsEQ_FUEL_IDNull() => this.IsNull(this.tableTblGenerale.EQ_FUEL_IDColumn);

      public void SetEQ_FUEL_IDNull() => this[this.tableTblGenerale.EQ_FUEL_IDColumn] = Convert.DBNull;

      public bool IsEQ_DATE_MANUFACTUREDNull() => this.IsNull(this.tableTblGenerale.EQ_DATE_MANUFACTUREDColumn);

      public void SetEQ_DATE_MANUFACTUREDNull() => this[this.tableTblGenerale.EQ_DATE_MANUFACTUREDColumn] = Convert.DBNull;

      public bool IsEQ_DATE_INSTALLEDNull() => this.IsNull(this.tableTblGenerale.EQ_DATE_INSTALLEDColumn);

      public void SetEQ_DATE_INSTALLEDNull() => this[this.tableTblGenerale.EQ_DATE_INSTALLEDColumn] = Convert.DBNull;

      public bool IsEQ_DATE_IN_SERVICENull() => this.IsNull(this.tableTblGenerale.EQ_DATE_IN_SERVICEColumn);

      public void SetEQ_DATE_IN_SERVICENull() => this[this.tableTblGenerale.EQ_DATE_IN_SERVICEColumn] = Convert.DBNull;

      public bool IsEQ_UTENZANull() => this.IsNull(this.tableTblGenerale.EQ_UTENZAColumn);

      public void SetEQ_UTENZANull() => this[this.tableTblGenerale.EQ_UTENZAColumn] = Convert.DBNull;

      public bool IsEQ_EQSTDNull() => this.IsNull(this.tableTblGenerale.EQ_EQSTDColumn);

      public void SetEQ_EQSTDNull() => this[this.tableTblGenerale.EQ_EQSTDColumn] = Convert.DBNull;

      public bool IsEQ_EQSTD_IDNull() => this.IsNull(this.tableTblGenerale.EQ_EQSTD_IDColumn);

      public void SetEQ_EQSTD_IDNull() => this[this.tableTblGenerale.EQ_EQSTD_IDColumn] = Convert.DBNull;

      public bool IsEQ_QTY_PMSNull() => this.IsNull(this.tableTblGenerale.EQ_QTY_PMSColumn);

      public void SetEQ_QTY_PMSNull() => this[this.tableTblGenerale.EQ_QTY_PMSColumn] = Convert.DBNull;

      public bool IsEQSTD_OPTION2Null() => this.IsNull(this.tableTblGenerale.EQSTD_OPTION2Column);

      public void SetEQSTD_OPTION2Null() => this[this.tableTblGenerale.EQSTD_OPTION2Column] = Convert.DBNull;

      public bool IsEQ_NUM_SERIALNull() => this.IsNull(this.tableTblGenerale.EQ_NUM_SERIALColumn);

      public void SetEQ_NUM_SERIALNull() => this[this.tableTblGenerale.EQ_NUM_SERIALColumn] = Convert.DBNull;

      public bool IsEQ_SOTTOCOMPONENTENull() => this.IsNull(this.tableTblGenerale.EQ_SOTTOCOMPONENTEColumn);

      public void SetEQ_SOTTOCOMPONENTENull() => this[this.tableTblGenerale.EQ_SOTTOCOMPONENTEColumn] = Convert.DBNull;

      public bool IsEQSTD_MFRNull() => this.IsNull(this.tableTblGenerale.EQSTD_MFRColumn);

      public void SetEQSTD_MFRNull() => this[this.tableTblGenerale.EQSTD_MFRColumn] = Convert.DBNull;

      public bool IsEQSTD_CATEGORYNull() => this.IsNull(this.tableTblGenerale.EQSTD_CATEGORYColumn);

      public void SetEQSTD_CATEGORYNull() => this[this.tableTblGenerale.EQSTD_CATEGORYColumn] = Convert.DBNull;

      public bool IsEQSTD_OPTION1Null() => this.IsNull(this.tableTblGenerale.EQSTD_OPTION1Column);

      public void SetEQSTD_OPTION1Null() => this[this.tableTblGenerale.EQSTD_OPTION1Column] = Convert.DBNull;

      public bool IsEQSTD_DESCRIPTIONNull() => this.IsNull(this.tableTblGenerale.EQSTD_DESCRIPTIONColumn);

      public void SetEQSTD_DESCRIPTIONNull() => this[this.tableTblGenerale.EQSTD_DESCRIPTIONColumn] = Convert.DBNull;

      public bool IsEQSTD_EQ_STDNull() => this.IsNull(this.tableTblGenerale.EQSTD_EQ_STDColumn);

      public void SetEQSTD_EQ_STDNull() => this[this.tableTblGenerale.EQSTD_EQ_STDColumn] = Convert.DBNull;

      public bool IsPIANI_DESC_ID_DESCRIZIONENull() => this.IsNull(this.tableTblGenerale.PIANI_DESC_ID_DESCRIZIONEColumn);

      public void SetPIANI_DESC_ID_DESCRIZIONENull() => this[this.tableTblGenerale.PIANI_DESC_ID_DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsRM_RM_ID_DESCRIZIONENull() => this.IsNull(this.tableTblGenerale.RM_RM_ID_DESCRIZIONEColumn);

      public void SetRM_RM_ID_DESCRIZIONENull() => this[this.tableTblGenerale.RM_RM_ID_DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsBL_NAMENull() => this.IsNull(this.tableTblGenerale.BL_NAMEColumn);

      public void SetBL_NAMENull() => this[this.tableTblGenerale.BL_NAMEColumn] = Convert.DBNull;

      public bool IsEQ_IMMAGINI_IMMAGINENull() => this.IsNull(this.tableTblGenerale.EQ_IMMAGINI_IMMAGINEColumn);

      public void SetEQ_IMMAGINI_IMMAGINENull() => this[this.tableTblGenerale.EQ_IMMAGINI_IMMAGINEColumn] = Convert.DBNull;

      public bool IsIdEqstdNull() => this.IsNull(this.tableTblGenerale.IdEqstdColumn);

      public void SetIdEqstdNull() => this[this.tableTblGenerale.IdEqstdColumn] = Convert.DBNull;

      public bool IsIdEqNull() => this.IsNull(this.tableTblGenerale.IdEqColumn);

      public void SetIdEqNull() => this[this.tableTblGenerale.IdEqColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblGeneraleRowChangeEvent : EventArgs
    {
      private NewDataSet.TblGeneraleRow eventRow;
      private DataRowAction eventAction;

      public TblGeneraleRowChangeEvent(NewDataSet.TblGeneraleRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblGeneraleRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblDatiTecniciDataTable : DataTable, IEnumerable
    {
      private DataColumn columnDATITECNICIID;
      private DataColumn columnEQID;
      private DataColumn columnTIPOLOGIAID;
      private DataColumn columnDESCRIZIONE;
      private DataColumn columnTIPOLOGIA;

      internal TblDatiTecniciDataTable()
        : base("TblDatiTecnici")
        => this.InitClass();

      internal TblDatiTecniciDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn DATITECNICIIDColumn => this.columnDATITECNICIID;

      internal DataColumn EQIDColumn => this.columnEQID;

      internal DataColumn TIPOLOGIAIDColumn => this.columnTIPOLOGIAID;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      internal DataColumn TIPOLOGIAColumn => this.columnTIPOLOGIA;

      public NewDataSet.TblDatiTecniciRow this[int index] => (NewDataSet.TblDatiTecniciRow) this.Rows[index];

      public event NewDataSet.TblDatiTecniciRowChangeEventHandler TblDatiTecniciRowChanged;

      public event NewDataSet.TblDatiTecniciRowChangeEventHandler TblDatiTecniciRowChanging;

      public event NewDataSet.TblDatiTecniciRowChangeEventHandler TblDatiTecniciRowDeleted;

      public event NewDataSet.TblDatiTecniciRowChangeEventHandler TblDatiTecniciRowDeleting;

      public void AddTblDatiTecniciRow(NewDataSet.TblDatiTecniciRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblDatiTecniciRow AddTblDatiTecniciRow(
        Decimal DATITECNICIID,
        Decimal EQID,
        Decimal TIPOLOGIAID,
        string DESCRIZIONE,
        string TIPOLOGIA)
      {
        NewDataSet.TblDatiTecniciRow tblDatiTecniciRow = (NewDataSet.TblDatiTecniciRow) this.NewRow();
        tblDatiTecniciRow.ItemArray = new object[5]
        {
          (object) DATITECNICIID,
          (object) EQID,
          (object) TIPOLOGIAID,
          (object) DESCRIZIONE,
          (object) TIPOLOGIA
        };
        this.Rows.Add((DataRow) tblDatiTecniciRow);
        return tblDatiTecniciRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblDatiTecniciDataTable tecniciDataTable = (NewDataSet.TblDatiTecniciDataTable) base.Clone();
        tecniciDataTable.InitVars();
        return (DataTable) tecniciDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblDatiTecniciDataTable();

      internal void InitVars()
      {
        this.columnDATITECNICIID = this.Columns["DATITECNICIID"];
        this.columnEQID = this.Columns["EQID"];
        this.columnTIPOLOGIAID = this.Columns["TIPOLOGIAID"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
        this.columnTIPOLOGIA = this.Columns["TIPOLOGIA"];
      }

      private void InitClass()
      {
        this.columnDATITECNICIID = new DataColumn("DATITECNICIID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATITECNICIID);
        this.columnEQID = new DataColumn("EQID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQID);
        this.columnTIPOLOGIAID = new DataColumn("TIPOLOGIAID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIPOLOGIAID);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnTIPOLOGIA = new DataColumn("TIPOLOGIA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIPOLOGIA);
      }

      public NewDataSet.TblDatiTecniciRow NewTblDatiTecniciRow() => (NewDataSet.TblDatiTecniciRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblDatiTecniciRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblDatiTecniciRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblDatiTecniciRowChanged == null)
          return;
        this.TblDatiTecniciRowChanged((object) this, new NewDataSet.TblDatiTecniciRowChangeEvent((NewDataSet.TblDatiTecniciRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblDatiTecniciRowChanging == null)
          return;
        this.TblDatiTecniciRowChanging((object) this, new NewDataSet.TblDatiTecniciRowChangeEvent((NewDataSet.TblDatiTecniciRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblDatiTecniciRowDeleted == null)
          return;
        this.TblDatiTecniciRowDeleted((object) this, new NewDataSet.TblDatiTecniciRowChangeEvent((NewDataSet.TblDatiTecniciRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblDatiTecniciRowDeleting == null)
          return;
        this.TblDatiTecniciRowDeleting((object) this, new NewDataSet.TblDatiTecniciRowChangeEvent((NewDataSet.TblDatiTecniciRow) e.Row, e.Action));
      }

      public void RemoveTblDatiTecniciRow(NewDataSet.TblDatiTecniciRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblDatiTecniciRow : DataRow
    {
      private NewDataSet.TblDatiTecniciDataTable tableTblDatiTecnici;

      internal TblDatiTecniciRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblDatiTecnici = (NewDataSet.TblDatiTecniciDataTable) this.Table;

      public Decimal DATITECNICIID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblDatiTecnici.DATITECNICIIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecnici.DATITECNICIIDColumn] = (object) value;
      }

      public Decimal EQID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblDatiTecnici.EQIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecnici.EQIDColumn] = (object) value;
      }

      public Decimal TIPOLOGIAID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblDatiTecnici.TIPOLOGIAIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecnici.TIPOLOGIAIDColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDatiTecnici.DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecnici.DESCRIZIONEColumn] = (object) value;
      }

      public string TIPOLOGIA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDatiTecnici.TIPOLOGIAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecnici.TIPOLOGIAColumn] = (object) value;
      }

      public bool IsDATITECNICIIDNull() => this.IsNull(this.tableTblDatiTecnici.DATITECNICIIDColumn);

      public void SetDATITECNICIIDNull() => this[this.tableTblDatiTecnici.DATITECNICIIDColumn] = Convert.DBNull;

      public bool IsEQIDNull() => this.IsNull(this.tableTblDatiTecnici.EQIDColumn);

      public void SetEQIDNull() => this[this.tableTblDatiTecnici.EQIDColumn] = Convert.DBNull;

      public bool IsTIPOLOGIAIDNull() => this.IsNull(this.tableTblDatiTecnici.TIPOLOGIAIDColumn);

      public void SetTIPOLOGIAIDNull() => this[this.tableTblDatiTecnici.TIPOLOGIAIDColumn] = Convert.DBNull;

      public bool IsDESCRIZIONENull() => this.IsNull(this.tableTblDatiTecnici.DESCRIZIONEColumn);

      public void SetDESCRIZIONENull() => this[this.tableTblDatiTecnici.DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsTIPOLOGIANull() => this.IsNull(this.tableTblDatiTecnici.TIPOLOGIAColumn);

      public void SetTIPOLOGIANull() => this[this.tableTblDatiTecnici.TIPOLOGIAColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblDatiTecniciRowChangeEvent : EventArgs
    {
      private NewDataSet.TblDatiTecniciRow eventRow;
      private DataRowAction eventAction;

      public TblDatiTecniciRowChangeEvent(NewDataSet.TblDatiTecniciRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblDatiTecniciRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblPmpPassiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnFREQUENZA;
      private DataColumn columnUNITS;
      private DataColumn columnUNITS_HOUR;
      private DataColumn columnTR_ID;
      private DataColumn columnID;
      private DataColumn columnPM_GROUP;
      private DataColumn columnEQ_STD;
      private DataColumn columnPMP;
      private DataColumn columnPASSO;
      private DataColumn columnISTRUZIONE;
      private DataColumn columnTEMPO;
      private DataColumn columnIdEqstd;
      private DataColumn columnIdEq;
      private DataColumn columndescription;

      internal TblPmpPassiDataTable()
        : base("TblPmpPassi")
        => this.InitClass();

      internal TblPmpPassiDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn FREQUENZAColumn => this.columnFREQUENZA;

      internal DataColumn UNITSColumn => this.columnUNITS;

      internal DataColumn UNITS_HOURColumn => this.columnUNITS_HOUR;

      internal DataColumn TR_IDColumn => this.columnTR_ID;

      internal DataColumn IDColumn => this.columnID;

      internal DataColumn PM_GROUPColumn => this.columnPM_GROUP;

      internal DataColumn EQ_STDColumn => this.columnEQ_STD;

      internal DataColumn PMPColumn => this.columnPMP;

      internal DataColumn PASSOColumn => this.columnPASSO;

      internal DataColumn ISTRUZIONEColumn => this.columnISTRUZIONE;

      internal DataColumn TEMPOColumn => this.columnTEMPO;

      internal DataColumn IdEqstdColumn => this.columnIdEqstd;

      internal DataColumn IdEqColumn => this.columnIdEq;

      internal DataColumn descriptionColumn => this.columndescription;

      public NewDataSet.TblPmpPassiRow this[int index] => (NewDataSet.TblPmpPassiRow) this.Rows[index];

      public event NewDataSet.TblPmpPassiRowChangeEventHandler TblPmpPassiRowChanged;

      public event NewDataSet.TblPmpPassiRowChangeEventHandler TblPmpPassiRowChanging;

      public event NewDataSet.TblPmpPassiRowChangeEventHandler TblPmpPassiRowDeleted;

      public event NewDataSet.TblPmpPassiRowChangeEventHandler TblPmpPassiRowDeleting;

      public void AddTblPmpPassiRow(NewDataSet.TblPmpPassiRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblPmpPassiRow AddTblPmpPassiRow(
        string FREQUENZA,
        string UNITS,
        Decimal UNITS_HOUR,
        string TR_ID,
        Decimal ID,
        string PM_GROUP,
        string EQ_STD,
        string PMP,
        Decimal PASSO,
        string ISTRUZIONE,
        Decimal TEMPO,
        Decimal IdEqstd,
        Decimal IdEq,
        string description)
      {
        NewDataSet.TblPmpPassiRow tblPmpPassiRow = (NewDataSet.TblPmpPassiRow) this.NewRow();
        tblPmpPassiRow.ItemArray = new object[14]
        {
          (object) FREQUENZA,
          (object) UNITS,
          (object) UNITS_HOUR,
          (object) TR_ID,
          (object) ID,
          (object) PM_GROUP,
          (object) EQ_STD,
          (object) PMP,
          (object) PASSO,
          (object) ISTRUZIONE,
          (object) TEMPO,
          (object) IdEqstd,
          (object) IdEq,
          (object) description
        };
        this.Rows.Add((DataRow) tblPmpPassiRow);
        return tblPmpPassiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblPmpPassiDataTable pmpPassiDataTable = (NewDataSet.TblPmpPassiDataTable) base.Clone();
        pmpPassiDataTable.InitVars();
        return (DataTable) pmpPassiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblPmpPassiDataTable();

      internal void InitVars()
      {
        this.columnFREQUENZA = this.Columns["FREQUENZA"];
        this.columnUNITS = this.Columns["UNITS"];
        this.columnUNITS_HOUR = this.Columns["UNITS_HOUR"];
        this.columnTR_ID = this.Columns["TR_ID"];
        this.columnID = this.Columns["ID"];
        this.columnPM_GROUP = this.Columns["PM_GROUP"];
        this.columnEQ_STD = this.Columns["EQ_STD"];
        this.columnPMP = this.Columns["PMP"];
        this.columnPASSO = this.Columns["PASSO"];
        this.columnISTRUZIONE = this.Columns["ISTRUZIONE"];
        this.columnTEMPO = this.Columns["TEMPO"];
        this.columnIdEqstd = this.Columns["IdEqstd"];
        this.columnIdEq = this.Columns["IdEq"];
        this.columndescription = this.Columns["description"];
      }

      private void InitClass()
      {
        this.columnFREQUENZA = new DataColumn("FREQUENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFREQUENZA);
        this.columnUNITS = new DataColumn("UNITS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUNITS);
        this.columnUNITS_HOUR = new DataColumn("UNITS_HOUR", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUNITS_HOUR);
        this.columnTR_ID = new DataColumn("TR_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTR_ID);
        this.columnID = new DataColumn("ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnPM_GROUP = new DataColumn("PM_GROUP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPM_GROUP);
        this.columnEQ_STD = new DataColumn("EQ_STD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_STD);
        this.columnPMP = new DataColumn("PMP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPMP);
        this.columnPASSO = new DataColumn("PASSO", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPASSO);
        this.columnISTRUZIONE = new DataColumn("ISTRUZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnISTRUZIONE);
        this.columnTEMPO = new DataColumn("TEMPO", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTEMPO);
        this.columnIdEqstd = new DataColumn("IdEqstd", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEqstd);
        this.columnIdEq = new DataColumn("IdEq", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEq);
        this.columndescription = new DataColumn("description", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columndescription);
      }

      public NewDataSet.TblPmpPassiRow NewTblPmpPassiRow() => (NewDataSet.TblPmpPassiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblPmpPassiRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblPmpPassiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblPmpPassiRowChanged == null)
          return;
        this.TblPmpPassiRowChanged((object) this, new NewDataSet.TblPmpPassiRowChangeEvent((NewDataSet.TblPmpPassiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblPmpPassiRowChanging == null)
          return;
        this.TblPmpPassiRowChanging((object) this, new NewDataSet.TblPmpPassiRowChangeEvent((NewDataSet.TblPmpPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblPmpPassiRowDeleted == null)
          return;
        this.TblPmpPassiRowDeleted((object) this, new NewDataSet.TblPmpPassiRowChangeEvent((NewDataSet.TblPmpPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblPmpPassiRowDeleting == null)
          return;
        this.TblPmpPassiRowDeleting((object) this, new NewDataSet.TblPmpPassiRowChangeEvent((NewDataSet.TblPmpPassiRow) e.Row, e.Action));
      }

      public void RemoveTblPmpPassiRow(NewDataSet.TblPmpPassiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblPmpPassiRow : DataRow
    {
      private NewDataSet.TblPmpPassiDataTable tableTblPmpPassi;

      internal TblPmpPassiRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblPmpPassi = (NewDataSet.TblPmpPassiDataTable) this.Table;

      public string FREQUENZA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.FREQUENZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.FREQUENZAColumn] = (object) value;
      }

      public string UNITS
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.UNITSColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.UNITSColumn] = (object) value;
      }

      public Decimal UNITS_HOUR
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblPmpPassi.UNITS_HOURColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.UNITS_HOURColumn] = (object) value;
      }

      public string TR_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.TR_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.TR_IDColumn] = (object) value;
      }

      public Decimal ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblPmpPassi.IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.IDColumn] = (object) value;
      }

      public string PM_GROUP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.PM_GROUPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.PM_GROUPColumn] = (object) value;
      }

      public string EQ_STD
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.EQ_STDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.EQ_STDColumn] = (object) value;
      }

      public string PMP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.PMPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.PMPColumn] = (object) value;
      }

      public Decimal PASSO
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblPmpPassi.PASSOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.PASSOColumn] = (object) value;
      }

      public string ISTRUZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.ISTRUZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.ISTRUZIONEColumn] = (object) value;
      }

      public Decimal TEMPO
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblPmpPassi.TEMPOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.TEMPOColumn] = (object) value;
      }

      public Decimal IdEqstd
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblPmpPassi.IdEqstdColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.IdEqstdColumn] = (object) value;
      }

      public Decimal IdEq
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblPmpPassi.IdEqColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.IdEqColumn] = (object) value;
      }

      public string description
      {
        get
        {
          try
          {
            return (string) this[this.tableTblPmpPassi.descriptionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblPmpPassi.descriptionColumn] = (object) value;
      }

      public bool IsFREQUENZANull() => this.IsNull(this.tableTblPmpPassi.FREQUENZAColumn);

      public void SetFREQUENZANull() => this[this.tableTblPmpPassi.FREQUENZAColumn] = Convert.DBNull;

      public bool IsUNITSNull() => this.IsNull(this.tableTblPmpPassi.UNITSColumn);

      public void SetUNITSNull() => this[this.tableTblPmpPassi.UNITSColumn] = Convert.DBNull;

      public bool IsUNITS_HOURNull() => this.IsNull(this.tableTblPmpPassi.UNITS_HOURColumn);

      public void SetUNITS_HOURNull() => this[this.tableTblPmpPassi.UNITS_HOURColumn] = Convert.DBNull;

      public bool IsTR_IDNull() => this.IsNull(this.tableTblPmpPassi.TR_IDColumn);

      public void SetTR_IDNull() => this[this.tableTblPmpPassi.TR_IDColumn] = Convert.DBNull;

      public bool IsIDNull() => this.IsNull(this.tableTblPmpPassi.IDColumn);

      public void SetIDNull() => this[this.tableTblPmpPassi.IDColumn] = Convert.DBNull;

      public bool IsPM_GROUPNull() => this.IsNull(this.tableTblPmpPassi.PM_GROUPColumn);

      public void SetPM_GROUPNull() => this[this.tableTblPmpPassi.PM_GROUPColumn] = Convert.DBNull;

      public bool IsEQ_STDNull() => this.IsNull(this.tableTblPmpPassi.EQ_STDColumn);

      public void SetEQ_STDNull() => this[this.tableTblPmpPassi.EQ_STDColumn] = Convert.DBNull;

      public bool IsPMPNull() => this.IsNull(this.tableTblPmpPassi.PMPColumn);

      public void SetPMPNull() => this[this.tableTblPmpPassi.PMPColumn] = Convert.DBNull;

      public bool IsPASSONull() => this.IsNull(this.tableTblPmpPassi.PASSOColumn);

      public void SetPASSONull() => this[this.tableTblPmpPassi.PASSOColumn] = Convert.DBNull;

      public bool IsISTRUZIONENull() => this.IsNull(this.tableTblPmpPassi.ISTRUZIONEColumn);

      public void SetISTRUZIONENull() => this[this.tableTblPmpPassi.ISTRUZIONEColumn] = Convert.DBNull;

      public bool IsTEMPONull() => this.IsNull(this.tableTblPmpPassi.TEMPOColumn);

      public void SetTEMPONull() => this[this.tableTblPmpPassi.TEMPOColumn] = Convert.DBNull;

      public bool IsIdEqstdNull() => this.IsNull(this.tableTblPmpPassi.IdEqstdColumn);

      public void SetIdEqstdNull() => this[this.tableTblPmpPassi.IdEqstdColumn] = Convert.DBNull;

      public bool IsIdEqNull() => this.IsNull(this.tableTblPmpPassi.IdEqColumn);

      public void SetIdEqNull() => this[this.tableTblPmpPassi.IdEqColumn] = Convert.DBNull;

      public bool IsdescriptionNull() => this.IsNull(this.tableTblPmpPassi.descriptionColumn);

      public void SetdescriptionNull() => this[this.tableTblPmpPassi.descriptionColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblPmpPassiRowChangeEvent : EventArgs
    {
      private NewDataSet.TblPmpPassiRow eventRow;
      private DataRowAction eventAction;

      public TblPmpPassiRowChangeEvent(NewDataSet.TblPmpPassiRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblPmpPassiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblAllDataDataTable : DataTable, IEnumerable
    {
      private DataColumn columnEQ_ID;
      private DataColumn columnEQ_OPTION1;
      private DataColumn columnEQ_CONDITION;
      private DataColumn columnEQ_CRITICALITY;
      private DataColumn columnEQ_OPTION2;
      private DataColumn columnEQ_GARANZIA;
      private DataColumn columnEQSTD_MODELNO;
      private DataColumn columnEQ_IMAGE_EQ_ASSY;
      private DataColumn columnEQ_RM_ID;
      private DataColumn columnEQ_BL_ID;
      private DataColumn columnEQ_VN_ID;
      private DataColumn columnEQ_LOC_COLUMN;
      private DataColumn columnEQ_LOC_MAINT_MANL;
      private DataColumn columnEQ_EQ_COMMENTS;
      private DataColumn columnEQ_POTENZA;
      private DataColumn columnEQ_FUEL_ID;
      private DataColumn columnEQ_DATE_MANUFACTURED;
      private DataColumn columnEQ_DATE_INSTALLED;
      private DataColumn columnEQ_DATE_IN_SERVICE;
      private DataColumn columnEQ_UTENZA;
      private DataColumn columnEQ_EQSTD;
      private DataColumn columnEQ_EQSTD_ID;
      private DataColumn columnEQ_QTY_PMS;
      private DataColumn columnEQSTD_OPTION2;
      private DataColumn columnEQ_NUM_SERIAL;
      private DataColumn columnEQ_SOTTOCOMPONENTE;
      private DataColumn columnEQSTD_MFR;
      private DataColumn columnEQSTD_CATEGORY;
      private DataColumn columnEQSTD_OPTION1;
      private DataColumn columnEQSTD_DESCRIPTION;
      private DataColumn columnEQSTD_EQ_STD;
      private DataColumn columnPIANI_DESC_ID_DESCRIZIONE;
      private DataColumn columnRM_RM_ID_DESCRIZIONE;
      private DataColumn columnBL_NAME;
      private DataColumn columnIDEQSTD;
      private DataColumn columnIDEQ;
      private DataColumn columnFREQUENZA;
      private DataColumn columnUNITS;
      private DataColumn columnUNITS_HOUR;
      private DataColumn columnTR_ID;
      private DataColumn columnID;
      private DataColumn columnPM_GROUP;
      private DataColumn columnPMP;
      private DataColumn columnPASSO;
      private DataColumn columnISTRUZIONE;
      private DataColumn columnTEMPO;
      private DataColumn columnEQSTD_ID;
      private DataColumn columnDATITECNICIID;
      private DataColumn columnEQID;
      private DataColumn columnTIPOLOGIAID;
      private DataColumn columnDESCRIZIONE;
      private DataColumn columnTIPOLOGIA;
      private DataColumn columnEQ_IMMAGINI_IMMAGINE;

      internal TblAllDataDataTable()
        : base("TblAllData")
        => this.InitClass();

      internal TblAllDataDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn EQ_IDColumn => this.columnEQ_ID;

      internal DataColumn EQ_OPTION1Column => this.columnEQ_OPTION1;

      internal DataColumn EQ_CONDITIONColumn => this.columnEQ_CONDITION;

      internal DataColumn EQ_CRITICALITYColumn => this.columnEQ_CRITICALITY;

      internal DataColumn EQ_OPTION2Column => this.columnEQ_OPTION2;

      internal DataColumn EQ_GARANZIAColumn => this.columnEQ_GARANZIA;

      internal DataColumn EQSTD_MODELNOColumn => this.columnEQSTD_MODELNO;

      internal DataColumn EQ_IMAGE_EQ_ASSYColumn => this.columnEQ_IMAGE_EQ_ASSY;

      internal DataColumn EQ_RM_IDColumn => this.columnEQ_RM_ID;

      internal DataColumn EQ_BL_IDColumn => this.columnEQ_BL_ID;

      internal DataColumn EQ_VN_IDColumn => this.columnEQ_VN_ID;

      internal DataColumn EQ_LOC_COLUMNColumn => this.columnEQ_LOC_COLUMN;

      internal DataColumn EQ_LOC_MAINT_MANLColumn => this.columnEQ_LOC_MAINT_MANL;

      internal DataColumn EQ_EQ_COMMENTSColumn => this.columnEQ_EQ_COMMENTS;

      internal DataColumn EQ_POTENZAColumn => this.columnEQ_POTENZA;

      internal DataColumn EQ_FUEL_IDColumn => this.columnEQ_FUEL_ID;

      internal DataColumn EQ_DATE_MANUFACTUREDColumn => this.columnEQ_DATE_MANUFACTURED;

      internal DataColumn EQ_DATE_INSTALLEDColumn => this.columnEQ_DATE_INSTALLED;

      internal DataColumn EQ_DATE_IN_SERVICEColumn => this.columnEQ_DATE_IN_SERVICE;

      internal DataColumn EQ_UTENZAColumn => this.columnEQ_UTENZA;

      internal DataColumn EQ_EQSTDColumn => this.columnEQ_EQSTD;

      internal DataColumn EQ_EQSTD_IDColumn => this.columnEQ_EQSTD_ID;

      internal DataColumn EQ_QTY_PMSColumn => this.columnEQ_QTY_PMS;

      internal DataColumn EQSTD_OPTION2Column => this.columnEQSTD_OPTION2;

      internal DataColumn EQ_NUM_SERIALColumn => this.columnEQ_NUM_SERIAL;

      internal DataColumn EQ_SOTTOCOMPONENTEColumn => this.columnEQ_SOTTOCOMPONENTE;

      internal DataColumn EQSTD_MFRColumn => this.columnEQSTD_MFR;

      internal DataColumn EQSTD_CATEGORYColumn => this.columnEQSTD_CATEGORY;

      internal DataColumn EQSTD_OPTION1Column => this.columnEQSTD_OPTION1;

      internal DataColumn EQSTD_DESCRIPTIONColumn => this.columnEQSTD_DESCRIPTION;

      internal DataColumn EQSTD_EQ_STDColumn => this.columnEQSTD_EQ_STD;

      internal DataColumn PIANI_DESC_ID_DESCRIZIONEColumn => this.columnPIANI_DESC_ID_DESCRIZIONE;

      internal DataColumn RM_RM_ID_DESCRIZIONEColumn => this.columnRM_RM_ID_DESCRIZIONE;

      internal DataColumn BL_NAMEColumn => this.columnBL_NAME;

      internal DataColumn IDEQSTDColumn => this.columnIDEQSTD;

      internal DataColumn IDEQColumn => this.columnIDEQ;

      internal DataColumn FREQUENZAColumn => this.columnFREQUENZA;

      internal DataColumn UNITSColumn => this.columnUNITS;

      internal DataColumn UNITS_HOURColumn => this.columnUNITS_HOUR;

      internal DataColumn TR_IDColumn => this.columnTR_ID;

      internal DataColumn IDColumn => this.columnID;

      internal DataColumn PM_GROUPColumn => this.columnPM_GROUP;

      internal DataColumn PMPColumn => this.columnPMP;

      internal DataColumn PASSOColumn => this.columnPASSO;

      internal DataColumn ISTRUZIONEColumn => this.columnISTRUZIONE;

      internal DataColumn TEMPOColumn => this.columnTEMPO;

      internal DataColumn EQSTD_IDColumn => this.columnEQSTD_ID;

      internal DataColumn DATITECNICIIDColumn => this.columnDATITECNICIID;

      internal DataColumn EQIDColumn => this.columnEQID;

      internal DataColumn TIPOLOGIAIDColumn => this.columnTIPOLOGIAID;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      internal DataColumn TIPOLOGIAColumn => this.columnTIPOLOGIA;

      internal DataColumn EQ_IMMAGINI_IMMAGINEColumn => this.columnEQ_IMMAGINI_IMMAGINE;

      public NewDataSet.TblAllDataRow this[int index] => (NewDataSet.TblAllDataRow) this.Rows[index];

      public event NewDataSet.TblAllDataRowChangeEventHandler TblAllDataRowChanged;

      public event NewDataSet.TblAllDataRowChangeEventHandler TblAllDataRowChanging;

      public event NewDataSet.TblAllDataRowChangeEventHandler TblAllDataRowDeleted;

      public event NewDataSet.TblAllDataRowChangeEventHandler TblAllDataRowDeleting;

      public void AddTblAllDataRow(NewDataSet.TblAllDataRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblAllDataRow AddTblAllDataRow(
        string EQ_ID,
        string EQ_OPTION1,
        string EQ_CONDITION,
        string EQ_CRITICALITY,
        string EQ_OPTION2,
        string EQ_GARANZIA,
        string EQSTD_MODELNO,
        string EQ_IMAGE_EQ_ASSY,
        string EQ_RM_ID,
        string EQ_BL_ID,
        string EQ_VN_ID,
        string EQ_LOC_COLUMN,
        string EQ_LOC_MAINT_MANL,
        string EQ_EQ_COMMENTS,
        string EQ_POTENZA,
        string EQ_FUEL_ID,
        string EQ_DATE_MANUFACTURED,
        string EQ_DATE_INSTALLED,
        string EQ_DATE_IN_SERVICE,
        string EQ_UTENZA,
        string EQ_EQSTD,
        string EQ_EQSTD_ID,
        string EQ_QTY_PMS,
        string EQSTD_OPTION2,
        string EQ_NUM_SERIAL,
        string EQ_SOTTOCOMPONENTE,
        string EQSTD_MFR,
        string EQSTD_CATEGORY,
        string EQSTD_OPTION1,
        string EQSTD_DESCRIPTION,
        string EQSTD_EQ_STD,
        string PIANI_DESC_ID_DESCRIZIONE,
        string RM_RM_ID_DESCRIZIONE,
        string BL_NAME,
        Decimal IDEQSTD,
        Decimal IDEQ,
        string FREQUENZA,
        string UNITS,
        Decimal UNITS_HOUR,
        string TR_ID,
        Decimal ID,
        string PM_GROUP,
        string PMP,
        Decimal PASSO,
        string ISTRUZIONE,
        Decimal TEMPO,
        Decimal EQSTD_ID,
        Decimal DATITECNICIID,
        Decimal EQID,
        Decimal TIPOLOGIAID,
        string DESCRIZIONE,
        string TIPOLOGIA,
        byte[] EQ_IMMAGINI_IMMAGINE)
      {
        NewDataSet.TblAllDataRow tblAllDataRow = (NewDataSet.TblAllDataRow) this.NewRow();
        tblAllDataRow.ItemArray = new object[53]
        {
          (object) EQ_ID,
          (object) EQ_OPTION1,
          (object) EQ_CONDITION,
          (object) EQ_CRITICALITY,
          (object) EQ_OPTION2,
          (object) EQ_GARANZIA,
          (object) EQSTD_MODELNO,
          (object) EQ_IMAGE_EQ_ASSY,
          (object) EQ_RM_ID,
          (object) EQ_BL_ID,
          (object) EQ_VN_ID,
          (object) EQ_LOC_COLUMN,
          (object) EQ_LOC_MAINT_MANL,
          (object) EQ_EQ_COMMENTS,
          (object) EQ_POTENZA,
          (object) EQ_FUEL_ID,
          (object) EQ_DATE_MANUFACTURED,
          (object) EQ_DATE_INSTALLED,
          (object) EQ_DATE_IN_SERVICE,
          (object) EQ_UTENZA,
          (object) EQ_EQSTD,
          (object) EQ_EQSTD_ID,
          (object) EQ_QTY_PMS,
          (object) EQSTD_OPTION2,
          (object) EQ_NUM_SERIAL,
          (object) EQ_SOTTOCOMPONENTE,
          (object) EQSTD_MFR,
          (object) EQSTD_CATEGORY,
          (object) EQSTD_OPTION1,
          (object) EQSTD_DESCRIPTION,
          (object) EQSTD_EQ_STD,
          (object) PIANI_DESC_ID_DESCRIZIONE,
          (object) RM_RM_ID_DESCRIZIONE,
          (object) BL_NAME,
          (object) IDEQSTD,
          (object) IDEQ,
          (object) FREQUENZA,
          (object) UNITS,
          (object) UNITS_HOUR,
          (object) TR_ID,
          (object) ID,
          (object) PM_GROUP,
          (object) PMP,
          (object) PASSO,
          (object) ISTRUZIONE,
          (object) TEMPO,
          (object) EQSTD_ID,
          (object) DATITECNICIID,
          (object) EQID,
          (object) TIPOLOGIAID,
          (object) DESCRIZIONE,
          (object) TIPOLOGIA,
          (object) EQ_IMMAGINI_IMMAGINE
        };
        this.Rows.Add((DataRow) tblAllDataRow);
        return tblAllDataRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblAllDataDataTable allDataDataTable = (NewDataSet.TblAllDataDataTable) base.Clone();
        allDataDataTable.InitVars();
        return (DataTable) allDataDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblAllDataDataTable();

      internal void InitVars()
      {
        this.columnEQ_ID = this.Columns["EQ_ID"];
        this.columnEQ_OPTION1 = this.Columns["EQ_OPTION1"];
        this.columnEQ_CONDITION = this.Columns["EQ_CONDITION"];
        this.columnEQ_CRITICALITY = this.Columns["EQ_CRITICALITY"];
        this.columnEQ_OPTION2 = this.Columns["EQ_OPTION2"];
        this.columnEQ_GARANZIA = this.Columns["EQ_GARANZIA"];
        this.columnEQSTD_MODELNO = this.Columns["EQSTD_MODELNO"];
        this.columnEQ_IMAGE_EQ_ASSY = this.Columns["EQ_IMAGE_EQ_ASSY"];
        this.columnEQ_RM_ID = this.Columns["EQ_RM_ID"];
        this.columnEQ_BL_ID = this.Columns["EQ_BL_ID"];
        this.columnEQ_VN_ID = this.Columns["EQ_VN_ID"];
        this.columnEQ_LOC_COLUMN = this.Columns["EQ_LOC_COLUMN"];
        this.columnEQ_LOC_MAINT_MANL = this.Columns["EQ_LOC_MAINT_MANL"];
        this.columnEQ_EQ_COMMENTS = this.Columns["EQ_EQ_COMMENTS"];
        this.columnEQ_POTENZA = this.Columns["EQ_POTENZA"];
        this.columnEQ_FUEL_ID = this.Columns["EQ_FUEL_ID"];
        this.columnEQ_DATE_MANUFACTURED = this.Columns["EQ_DATE_MANUFACTURED"];
        this.columnEQ_DATE_INSTALLED = this.Columns["EQ_DATE_INSTALLED"];
        this.columnEQ_DATE_IN_SERVICE = this.Columns["EQ_DATE_IN_SERVICE"];
        this.columnEQ_UTENZA = this.Columns["EQ_UTENZA"];
        this.columnEQ_EQSTD = this.Columns["EQ_EQSTD"];
        this.columnEQ_EQSTD_ID = this.Columns["EQ_EQSTD_ID"];
        this.columnEQ_QTY_PMS = this.Columns["EQ_QTY_PMS"];
        this.columnEQSTD_OPTION2 = this.Columns["EQSTD_OPTION2"];
        this.columnEQ_NUM_SERIAL = this.Columns["EQ_NUM_SERIAL"];
        this.columnEQ_SOTTOCOMPONENTE = this.Columns["EQ_SOTTOCOMPONENTE"];
        this.columnEQSTD_MFR = this.Columns["EQSTD_MFR"];
        this.columnEQSTD_CATEGORY = this.Columns["EQSTD_CATEGORY"];
        this.columnEQSTD_OPTION1 = this.Columns["EQSTD_OPTION1"];
        this.columnEQSTD_DESCRIPTION = this.Columns["EQSTD_DESCRIPTION"];
        this.columnEQSTD_EQ_STD = this.Columns["EQSTD_EQ_STD"];
        this.columnPIANI_DESC_ID_DESCRIZIONE = this.Columns["PIANI_DESC_ID_DESCRIZIONE"];
        this.columnRM_RM_ID_DESCRIZIONE = this.Columns["RM_RM_ID_DESCRIZIONE"];
        this.columnBL_NAME = this.Columns["BL_NAME"];
        this.columnIDEQSTD = this.Columns["IDEQSTD"];
        this.columnIDEQ = this.Columns["IDEQ"];
        this.columnFREQUENZA = this.Columns["FREQUENZA"];
        this.columnUNITS = this.Columns["UNITS"];
        this.columnUNITS_HOUR = this.Columns["UNITS_HOUR"];
        this.columnTR_ID = this.Columns["TR_ID"];
        this.columnID = this.Columns["ID"];
        this.columnPM_GROUP = this.Columns["PM_GROUP"];
        this.columnPMP = this.Columns["PMP"];
        this.columnPASSO = this.Columns["PASSO"];
        this.columnISTRUZIONE = this.Columns["ISTRUZIONE"];
        this.columnTEMPO = this.Columns["TEMPO"];
        this.columnEQSTD_ID = this.Columns["EQSTD_ID"];
        this.columnDATITECNICIID = this.Columns["DATITECNICIID"];
        this.columnEQID = this.Columns["EQID"];
        this.columnTIPOLOGIAID = this.Columns["TIPOLOGIAID"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
        this.columnTIPOLOGIA = this.Columns["TIPOLOGIA"];
        this.columnEQ_IMMAGINI_IMMAGINE = this.Columns["EQ_IMMAGINI_IMMAGINE"];
      }

      private void InitClass()
      {
        this.columnEQ_ID = new DataColumn("EQ_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID);
        this.columnEQ_OPTION1 = new DataColumn("EQ_OPTION1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_OPTION1);
        this.columnEQ_CONDITION = new DataColumn("EQ_CONDITION", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_CONDITION);
        this.columnEQ_CRITICALITY = new DataColumn("EQ_CRITICALITY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_CRITICALITY);
        this.columnEQ_OPTION2 = new DataColumn("EQ_OPTION2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_OPTION2);
        this.columnEQ_GARANZIA = new DataColumn("EQ_GARANZIA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_GARANZIA);
        this.columnEQSTD_MODELNO = new DataColumn("EQSTD_MODELNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_MODELNO);
        this.columnEQ_IMAGE_EQ_ASSY = new DataColumn("EQ_IMAGE_EQ_ASSY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_IMAGE_EQ_ASSY);
        this.columnEQ_RM_ID = new DataColumn("EQ_RM_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_RM_ID);
        this.columnEQ_BL_ID = new DataColumn("EQ_BL_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_BL_ID);
        this.columnEQ_VN_ID = new DataColumn("EQ_VN_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_VN_ID);
        this.columnEQ_LOC_COLUMN = new DataColumn("EQ_LOC_COLUMN", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_LOC_COLUMN);
        this.columnEQ_LOC_MAINT_MANL = new DataColumn("EQ_LOC_MAINT_MANL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_LOC_MAINT_MANL);
        this.columnEQ_EQ_COMMENTS = new DataColumn("EQ_EQ_COMMENTS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_EQ_COMMENTS);
        this.columnEQ_POTENZA = new DataColumn("EQ_POTENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_POTENZA);
        this.columnEQ_FUEL_ID = new DataColumn("EQ_FUEL_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_FUEL_ID);
        this.columnEQ_DATE_MANUFACTURED = new DataColumn("EQ_DATE_MANUFACTURED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_DATE_MANUFACTURED);
        this.columnEQ_DATE_INSTALLED = new DataColumn("EQ_DATE_INSTALLED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_DATE_INSTALLED);
        this.columnEQ_DATE_IN_SERVICE = new DataColumn("EQ_DATE_IN_SERVICE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_DATE_IN_SERVICE);
        this.columnEQ_UTENZA = new DataColumn("EQ_UTENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_UTENZA);
        this.columnEQ_EQSTD = new DataColumn("EQ_EQSTD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_EQSTD);
        this.columnEQ_EQSTD_ID = new DataColumn("EQ_EQSTD_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_EQSTD_ID);
        this.columnEQ_QTY_PMS = new DataColumn("EQ_QTY_PMS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_QTY_PMS);
        this.columnEQSTD_OPTION2 = new DataColumn("EQSTD_OPTION2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_OPTION2);
        this.columnEQ_NUM_SERIAL = new DataColumn("EQ_NUM_SERIAL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_NUM_SERIAL);
        this.columnEQ_SOTTOCOMPONENTE = new DataColumn("EQ_SOTTOCOMPONENTE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_SOTTOCOMPONENTE);
        this.columnEQSTD_MFR = new DataColumn("EQSTD_MFR", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_MFR);
        this.columnEQSTD_CATEGORY = new DataColumn("EQSTD_CATEGORY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_CATEGORY);
        this.columnEQSTD_OPTION1 = new DataColumn("EQSTD_OPTION1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_OPTION1);
        this.columnEQSTD_DESCRIPTION = new DataColumn("EQSTD_DESCRIPTION", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_DESCRIPTION);
        this.columnEQSTD_EQ_STD = new DataColumn("EQSTD_EQ_STD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_EQ_STD);
        this.columnPIANI_DESC_ID_DESCRIZIONE = new DataColumn("PIANI_DESC_ID_DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPIANI_DESC_ID_DESCRIZIONE);
        this.columnRM_RM_ID_DESCRIZIONE = new DataColumn("RM_RM_ID_DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRM_RM_ID_DESCRIZIONE);
        this.columnBL_NAME = new DataColumn("BL_NAME", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBL_NAME);
        this.columnIDEQSTD = new DataColumn("IDEQSTD", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIDEQSTD);
        this.columnIDEQ = new DataColumn("IDEQ", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIDEQ);
        this.columnFREQUENZA = new DataColumn("FREQUENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFREQUENZA);
        this.columnUNITS = new DataColumn("UNITS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUNITS);
        this.columnUNITS_HOUR = new DataColumn("UNITS_HOUR", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUNITS_HOUR);
        this.columnTR_ID = new DataColumn("TR_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTR_ID);
        this.columnID = new DataColumn("ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnPM_GROUP = new DataColumn("PM_GROUP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPM_GROUP);
        this.columnPMP = new DataColumn("PMP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPMP);
        this.columnPASSO = new DataColumn("PASSO", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPASSO);
        this.columnISTRUZIONE = new DataColumn("ISTRUZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnISTRUZIONE);
        this.columnTEMPO = new DataColumn("TEMPO", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTEMPO);
        this.columnEQSTD_ID = new DataColumn("EQSTD_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQSTD_ID);
        this.columnDATITECNICIID = new DataColumn("DATITECNICIID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATITECNICIID);
        this.columnEQID = new DataColumn("EQID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQID);
        this.columnTIPOLOGIAID = new DataColumn("TIPOLOGIAID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIPOLOGIAID);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnTIPOLOGIA = new DataColumn("TIPOLOGIA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIPOLOGIA);
        this.columnEQ_IMMAGINI_IMMAGINE = new DataColumn("EQ_IMMAGINI_IMMAGINE", typeof (byte[]), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_IMMAGINI_IMMAGINE);
      }

      public NewDataSet.TblAllDataRow NewTblAllDataRow() => (NewDataSet.TblAllDataRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblAllDataRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblAllDataRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblAllDataRowChanged == null)
          return;
        this.TblAllDataRowChanged((object) this, new NewDataSet.TblAllDataRowChangeEvent((NewDataSet.TblAllDataRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblAllDataRowChanging == null)
          return;
        this.TblAllDataRowChanging((object) this, new NewDataSet.TblAllDataRowChangeEvent((NewDataSet.TblAllDataRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblAllDataRowDeleted == null)
          return;
        this.TblAllDataRowDeleted((object) this, new NewDataSet.TblAllDataRowChangeEvent((NewDataSet.TblAllDataRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblAllDataRowDeleting == null)
          return;
        this.TblAllDataRowDeleting((object) this, new NewDataSet.TblAllDataRowChangeEvent((NewDataSet.TblAllDataRow) e.Row, e.Action));
      }

      public void RemoveTblAllDataRow(NewDataSet.TblAllDataRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblAllDataRow : DataRow
    {
      private NewDataSet.TblAllDataDataTable tableTblAllData;

      internal TblAllDataRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblAllData = (NewDataSet.TblAllDataDataTable) this.Table;

      public string EQ_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_IDColumn] = (object) value;
      }

      public string EQ_OPTION1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_OPTION1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_OPTION1Column] = (object) value;
      }

      public string EQ_CONDITION
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_CONDITIONColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_CONDITIONColumn] = (object) value;
      }

      public string EQ_CRITICALITY
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_CRITICALITYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_CRITICALITYColumn] = (object) value;
      }

      public string EQ_OPTION2
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_OPTION2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_OPTION2Column] = (object) value;
      }

      public string EQ_GARANZIA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_GARANZIAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_GARANZIAColumn] = (object) value;
      }

      public string EQSTD_MODELNO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_MODELNOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_MODELNOColumn] = (object) value;
      }

      public string EQ_IMAGE_EQ_ASSY
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_IMAGE_EQ_ASSYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_IMAGE_EQ_ASSYColumn] = (object) value;
      }

      public string EQ_RM_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_RM_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_RM_IDColumn] = (object) value;
      }

      public string EQ_BL_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_BL_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_BL_IDColumn] = (object) value;
      }

      public string EQ_VN_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_VN_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_VN_IDColumn] = (object) value;
      }

      public string EQ_LOC_COLUMN
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_LOC_COLUMNColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_LOC_COLUMNColumn] = (object) value;
      }

      public string EQ_LOC_MAINT_MANL
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_LOC_MAINT_MANLColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_LOC_MAINT_MANLColumn] = (object) value;
      }

      public string EQ_EQ_COMMENTS
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_EQ_COMMENTSColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_EQ_COMMENTSColumn] = (object) value;
      }

      public string EQ_POTENZA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_POTENZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_POTENZAColumn] = (object) value;
      }

      public string EQ_FUEL_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_FUEL_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_FUEL_IDColumn] = (object) value;
      }

      public string EQ_DATE_MANUFACTURED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_DATE_MANUFACTUREDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_DATE_MANUFACTUREDColumn] = (object) value;
      }

      public string EQ_DATE_INSTALLED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_DATE_INSTALLEDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_DATE_INSTALLEDColumn] = (object) value;
      }

      public string EQ_DATE_IN_SERVICE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_DATE_IN_SERVICEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_DATE_IN_SERVICEColumn] = (object) value;
      }

      public string EQ_UTENZA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_UTENZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_UTENZAColumn] = (object) value;
      }

      public string EQ_EQSTD
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_EQSTDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_EQSTDColumn] = (object) value;
      }

      public string EQ_EQSTD_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_EQSTD_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_EQSTD_IDColumn] = (object) value;
      }

      public string EQ_QTY_PMS
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_QTY_PMSColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_QTY_PMSColumn] = (object) value;
      }

      public string EQSTD_OPTION2
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_OPTION2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_OPTION2Column] = (object) value;
      }

      public string EQ_NUM_SERIAL
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_NUM_SERIALColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_NUM_SERIALColumn] = (object) value;
      }

      public string EQ_SOTTOCOMPONENTE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQ_SOTTOCOMPONENTEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_SOTTOCOMPONENTEColumn] = (object) value;
      }

      public string EQSTD_MFR
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_MFRColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_MFRColumn] = (object) value;
      }

      public string EQSTD_CATEGORY
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_CATEGORYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_CATEGORYColumn] = (object) value;
      }

      public string EQSTD_OPTION1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_OPTION1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_OPTION1Column] = (object) value;
      }

      public string EQSTD_DESCRIPTION
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_DESCRIPTIONColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_DESCRIPTIONColumn] = (object) value;
      }

      public string EQSTD_EQ_STD
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.EQSTD_EQ_STDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_EQ_STDColumn] = (object) value;
      }

      public string PIANI_DESC_ID_DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.PIANI_DESC_ID_DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.PIANI_DESC_ID_DESCRIZIONEColumn] = (object) value;
      }

      public string RM_RM_ID_DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.RM_RM_ID_DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.RM_RM_ID_DESCRIZIONEColumn] = (object) value;
      }

      public string BL_NAME
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.BL_NAMEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.BL_NAMEColumn] = (object) value;
      }

      public Decimal IDEQSTD
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.IDEQSTDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.IDEQSTDColumn] = (object) value;
      }

      public Decimal IDEQ
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.IDEQColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.IDEQColumn] = (object) value;
      }

      public string FREQUENZA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.FREQUENZAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.FREQUENZAColumn] = (object) value;
      }

      public string UNITS
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.UNITSColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.UNITSColumn] = (object) value;
      }

      public Decimal UNITS_HOUR
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.UNITS_HOURColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.UNITS_HOURColumn] = (object) value;
      }

      public string TR_ID
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.TR_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.TR_IDColumn] = (object) value;
      }

      public Decimal ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.IDColumn] = (object) value;
      }

      public string PM_GROUP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.PM_GROUPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.PM_GROUPColumn] = (object) value;
      }

      public string PMP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.PMPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.PMPColumn] = (object) value;
      }

      public Decimal PASSO
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.PASSOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.PASSOColumn] = (object) value;
      }

      public string ISTRUZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.ISTRUZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.ISTRUZIONEColumn] = (object) value;
      }

      public Decimal TEMPO
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.TEMPOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.TEMPOColumn] = (object) value;
      }

      public Decimal EQSTD_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.EQSTD_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQSTD_IDColumn] = (object) value;
      }

      public Decimal DATITECNICIID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.DATITECNICIIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.DATITECNICIIDColumn] = (object) value;
      }

      public Decimal EQID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.EQIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQIDColumn] = (object) value;
      }

      public Decimal TIPOLOGIAID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllData.TIPOLOGIAIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.TIPOLOGIAIDColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.DESCRIZIONEColumn] = (object) value;
      }

      public string TIPOLOGIA
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllData.TIPOLOGIAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.TIPOLOGIAColumn] = (object) value;
      }

      public byte[] EQ_IMMAGINI_IMMAGINE
      {
        get
        {
          try
          {
            return (byte[]) this[this.tableTblAllData.EQ_IMMAGINI_IMMAGINEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllData.EQ_IMMAGINI_IMMAGINEColumn] = (object) value;
      }

      public bool IsEQ_IDNull() => this.IsNull(this.tableTblAllData.EQ_IDColumn);

      public void SetEQ_IDNull() => this[this.tableTblAllData.EQ_IDColumn] = Convert.DBNull;

      public bool IsEQ_OPTION1Null() => this.IsNull(this.tableTblAllData.EQ_OPTION1Column);

      public void SetEQ_OPTION1Null() => this[this.tableTblAllData.EQ_OPTION1Column] = Convert.DBNull;

      public bool IsEQ_CONDITIONNull() => this.IsNull(this.tableTblAllData.EQ_CONDITIONColumn);

      public void SetEQ_CONDITIONNull() => this[this.tableTblAllData.EQ_CONDITIONColumn] = Convert.DBNull;

      public bool IsEQ_CRITICALITYNull() => this.IsNull(this.tableTblAllData.EQ_CRITICALITYColumn);

      public void SetEQ_CRITICALITYNull() => this[this.tableTblAllData.EQ_CRITICALITYColumn] = Convert.DBNull;

      public bool IsEQ_OPTION2Null() => this.IsNull(this.tableTblAllData.EQ_OPTION2Column);

      public void SetEQ_OPTION2Null() => this[this.tableTblAllData.EQ_OPTION2Column] = Convert.DBNull;

      public bool IsEQ_GARANZIANull() => this.IsNull(this.tableTblAllData.EQ_GARANZIAColumn);

      public void SetEQ_GARANZIANull() => this[this.tableTblAllData.EQ_GARANZIAColumn] = Convert.DBNull;

      public bool IsEQSTD_MODELNONull() => this.IsNull(this.tableTblAllData.EQSTD_MODELNOColumn);

      public void SetEQSTD_MODELNONull() => this[this.tableTblAllData.EQSTD_MODELNOColumn] = Convert.DBNull;

      public bool IsEQ_IMAGE_EQ_ASSYNull() => this.IsNull(this.tableTblAllData.EQ_IMAGE_EQ_ASSYColumn);

      public void SetEQ_IMAGE_EQ_ASSYNull() => this[this.tableTblAllData.EQ_IMAGE_EQ_ASSYColumn] = Convert.DBNull;

      public bool IsEQ_RM_IDNull() => this.IsNull(this.tableTblAllData.EQ_RM_IDColumn);

      public void SetEQ_RM_IDNull() => this[this.tableTblAllData.EQ_RM_IDColumn] = Convert.DBNull;

      public bool IsEQ_BL_IDNull() => this.IsNull(this.tableTblAllData.EQ_BL_IDColumn);

      public void SetEQ_BL_IDNull() => this[this.tableTblAllData.EQ_BL_IDColumn] = Convert.DBNull;

      public bool IsEQ_VN_IDNull() => this.IsNull(this.tableTblAllData.EQ_VN_IDColumn);

      public void SetEQ_VN_IDNull() => this[this.tableTblAllData.EQ_VN_IDColumn] = Convert.DBNull;

      public bool IsEQ_LOC_COLUMNNull() => this.IsNull(this.tableTblAllData.EQ_LOC_COLUMNColumn);

      public void SetEQ_LOC_COLUMNNull() => this[this.tableTblAllData.EQ_LOC_COLUMNColumn] = Convert.DBNull;

      public bool IsEQ_LOC_MAINT_MANLNull() => this.IsNull(this.tableTblAllData.EQ_LOC_MAINT_MANLColumn);

      public void SetEQ_LOC_MAINT_MANLNull() => this[this.tableTblAllData.EQ_LOC_MAINT_MANLColumn] = Convert.DBNull;

      public bool IsEQ_EQ_COMMENTSNull() => this.IsNull(this.tableTblAllData.EQ_EQ_COMMENTSColumn);

      public void SetEQ_EQ_COMMENTSNull() => this[this.tableTblAllData.EQ_EQ_COMMENTSColumn] = Convert.DBNull;

      public bool IsEQ_POTENZANull() => this.IsNull(this.tableTblAllData.EQ_POTENZAColumn);

      public void SetEQ_POTENZANull() => this[this.tableTblAllData.EQ_POTENZAColumn] = Convert.DBNull;

      public bool IsEQ_FUEL_IDNull() => this.IsNull(this.tableTblAllData.EQ_FUEL_IDColumn);

      public void SetEQ_FUEL_IDNull() => this[this.tableTblAllData.EQ_FUEL_IDColumn] = Convert.DBNull;

      public bool IsEQ_DATE_MANUFACTUREDNull() => this.IsNull(this.tableTblAllData.EQ_DATE_MANUFACTUREDColumn);

      public void SetEQ_DATE_MANUFACTUREDNull() => this[this.tableTblAllData.EQ_DATE_MANUFACTUREDColumn] = Convert.DBNull;

      public bool IsEQ_DATE_INSTALLEDNull() => this.IsNull(this.tableTblAllData.EQ_DATE_INSTALLEDColumn);

      public void SetEQ_DATE_INSTALLEDNull() => this[this.tableTblAllData.EQ_DATE_INSTALLEDColumn] = Convert.DBNull;

      public bool IsEQ_DATE_IN_SERVICENull() => this.IsNull(this.tableTblAllData.EQ_DATE_IN_SERVICEColumn);

      public void SetEQ_DATE_IN_SERVICENull() => this[this.tableTblAllData.EQ_DATE_IN_SERVICEColumn] = Convert.DBNull;

      public bool IsEQ_UTENZANull() => this.IsNull(this.tableTblAllData.EQ_UTENZAColumn);

      public void SetEQ_UTENZANull() => this[this.tableTblAllData.EQ_UTENZAColumn] = Convert.DBNull;

      public bool IsEQ_EQSTDNull() => this.IsNull(this.tableTblAllData.EQ_EQSTDColumn);

      public void SetEQ_EQSTDNull() => this[this.tableTblAllData.EQ_EQSTDColumn] = Convert.DBNull;

      public bool IsEQ_EQSTD_IDNull() => this.IsNull(this.tableTblAllData.EQ_EQSTD_IDColumn);

      public void SetEQ_EQSTD_IDNull() => this[this.tableTblAllData.EQ_EQSTD_IDColumn] = Convert.DBNull;

      public bool IsEQ_QTY_PMSNull() => this.IsNull(this.tableTblAllData.EQ_QTY_PMSColumn);

      public void SetEQ_QTY_PMSNull() => this[this.tableTblAllData.EQ_QTY_PMSColumn] = Convert.DBNull;

      public bool IsEQSTD_OPTION2Null() => this.IsNull(this.tableTblAllData.EQSTD_OPTION2Column);

      public void SetEQSTD_OPTION2Null() => this[this.tableTblAllData.EQSTD_OPTION2Column] = Convert.DBNull;

      public bool IsEQ_NUM_SERIALNull() => this.IsNull(this.tableTblAllData.EQ_NUM_SERIALColumn);

      public void SetEQ_NUM_SERIALNull() => this[this.tableTblAllData.EQ_NUM_SERIALColumn] = Convert.DBNull;

      public bool IsEQ_SOTTOCOMPONENTENull() => this.IsNull(this.tableTblAllData.EQ_SOTTOCOMPONENTEColumn);

      public void SetEQ_SOTTOCOMPONENTENull() => this[this.tableTblAllData.EQ_SOTTOCOMPONENTEColumn] = Convert.DBNull;

      public bool IsEQSTD_MFRNull() => this.IsNull(this.tableTblAllData.EQSTD_MFRColumn);

      public void SetEQSTD_MFRNull() => this[this.tableTblAllData.EQSTD_MFRColumn] = Convert.DBNull;

      public bool IsEQSTD_CATEGORYNull() => this.IsNull(this.tableTblAllData.EQSTD_CATEGORYColumn);

      public void SetEQSTD_CATEGORYNull() => this[this.tableTblAllData.EQSTD_CATEGORYColumn] = Convert.DBNull;

      public bool IsEQSTD_OPTION1Null() => this.IsNull(this.tableTblAllData.EQSTD_OPTION1Column);

      public void SetEQSTD_OPTION1Null() => this[this.tableTblAllData.EQSTD_OPTION1Column] = Convert.DBNull;

      public bool IsEQSTD_DESCRIPTIONNull() => this.IsNull(this.tableTblAllData.EQSTD_DESCRIPTIONColumn);

      public void SetEQSTD_DESCRIPTIONNull() => this[this.tableTblAllData.EQSTD_DESCRIPTIONColumn] = Convert.DBNull;

      public bool IsEQSTD_EQ_STDNull() => this.IsNull(this.tableTblAllData.EQSTD_EQ_STDColumn);

      public void SetEQSTD_EQ_STDNull() => this[this.tableTblAllData.EQSTD_EQ_STDColumn] = Convert.DBNull;

      public bool IsPIANI_DESC_ID_DESCRIZIONENull() => this.IsNull(this.tableTblAllData.PIANI_DESC_ID_DESCRIZIONEColumn);

      public void SetPIANI_DESC_ID_DESCRIZIONENull() => this[this.tableTblAllData.PIANI_DESC_ID_DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsRM_RM_ID_DESCRIZIONENull() => this.IsNull(this.tableTblAllData.RM_RM_ID_DESCRIZIONEColumn);

      public void SetRM_RM_ID_DESCRIZIONENull() => this[this.tableTblAllData.RM_RM_ID_DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsBL_NAMENull() => this.IsNull(this.tableTblAllData.BL_NAMEColumn);

      public void SetBL_NAMENull() => this[this.tableTblAllData.BL_NAMEColumn] = Convert.DBNull;

      public bool IsIDEQSTDNull() => this.IsNull(this.tableTblAllData.IDEQSTDColumn);

      public void SetIDEQSTDNull() => this[this.tableTblAllData.IDEQSTDColumn] = Convert.DBNull;

      public bool IsIDEQNull() => this.IsNull(this.tableTblAllData.IDEQColumn);

      public void SetIDEQNull() => this[this.tableTblAllData.IDEQColumn] = Convert.DBNull;

      public bool IsFREQUENZANull() => this.IsNull(this.tableTblAllData.FREQUENZAColumn);

      public void SetFREQUENZANull() => this[this.tableTblAllData.FREQUENZAColumn] = Convert.DBNull;

      public bool IsUNITSNull() => this.IsNull(this.tableTblAllData.UNITSColumn);

      public void SetUNITSNull() => this[this.tableTblAllData.UNITSColumn] = Convert.DBNull;

      public bool IsUNITS_HOURNull() => this.IsNull(this.tableTblAllData.UNITS_HOURColumn);

      public void SetUNITS_HOURNull() => this[this.tableTblAllData.UNITS_HOURColumn] = Convert.DBNull;

      public bool IsTR_IDNull() => this.IsNull(this.tableTblAllData.TR_IDColumn);

      public void SetTR_IDNull() => this[this.tableTblAllData.TR_IDColumn] = Convert.DBNull;

      public bool IsIDNull() => this.IsNull(this.tableTblAllData.IDColumn);

      public void SetIDNull() => this[this.tableTblAllData.IDColumn] = Convert.DBNull;

      public bool IsPM_GROUPNull() => this.IsNull(this.tableTblAllData.PM_GROUPColumn);

      public void SetPM_GROUPNull() => this[this.tableTblAllData.PM_GROUPColumn] = Convert.DBNull;

      public bool IsPMPNull() => this.IsNull(this.tableTblAllData.PMPColumn);

      public void SetPMPNull() => this[this.tableTblAllData.PMPColumn] = Convert.DBNull;

      public bool IsPASSONull() => this.IsNull(this.tableTblAllData.PASSOColumn);

      public void SetPASSONull() => this[this.tableTblAllData.PASSOColumn] = Convert.DBNull;

      public bool IsISTRUZIONENull() => this.IsNull(this.tableTblAllData.ISTRUZIONEColumn);

      public void SetISTRUZIONENull() => this[this.tableTblAllData.ISTRUZIONEColumn] = Convert.DBNull;

      public bool IsTEMPONull() => this.IsNull(this.tableTblAllData.TEMPOColumn);

      public void SetTEMPONull() => this[this.tableTblAllData.TEMPOColumn] = Convert.DBNull;

      public bool IsEQSTD_IDNull() => this.IsNull(this.tableTblAllData.EQSTD_IDColumn);

      public void SetEQSTD_IDNull() => this[this.tableTblAllData.EQSTD_IDColumn] = Convert.DBNull;

      public bool IsDATITECNICIIDNull() => this.IsNull(this.tableTblAllData.DATITECNICIIDColumn);

      public void SetDATITECNICIIDNull() => this[this.tableTblAllData.DATITECNICIIDColumn] = Convert.DBNull;

      public bool IsEQIDNull() => this.IsNull(this.tableTblAllData.EQIDColumn);

      public void SetEQIDNull() => this[this.tableTblAllData.EQIDColumn] = Convert.DBNull;

      public bool IsTIPOLOGIAIDNull() => this.IsNull(this.tableTblAllData.TIPOLOGIAIDColumn);

      public void SetTIPOLOGIAIDNull() => this[this.tableTblAllData.TIPOLOGIAIDColumn] = Convert.DBNull;

      public bool IsDESCRIZIONENull() => this.IsNull(this.tableTblAllData.DESCRIZIONEColumn);

      public void SetDESCRIZIONENull() => this[this.tableTblAllData.DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsTIPOLOGIANull() => this.IsNull(this.tableTblAllData.TIPOLOGIAColumn);

      public void SetTIPOLOGIANull() => this[this.tableTblAllData.TIPOLOGIAColumn] = Convert.DBNull;

      public bool IsEQ_IMMAGINI_IMMAGINENull() => this.IsNull(this.tableTblAllData.EQ_IMMAGINI_IMMAGINEColumn);

      public void SetEQ_IMMAGINI_IMMAGINENull() => this[this.tableTblAllData.EQ_IMMAGINI_IMMAGINEColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblAllDataRowChangeEvent : EventArgs
    {
      private NewDataSet.TblAllDataRow eventRow;
      private DataRowAction eventAction;

      public TblAllDataRowChangeEvent(NewDataSet.TblAllDataRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblAllDataRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblAllegatiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnDOC_EQ_ID;
      private DataColumn columnNOMEFILE;
      private DataColumn columnDESCRIZIONE;
      private DataColumn columnEQ_ID;

      internal TblAllegatiDataTable()
        : base("TblAllegati")
        => this.InitClass();

      internal TblAllegatiDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn DOC_EQ_IDColumn => this.columnDOC_EQ_ID;

      internal DataColumn NOMEFILEColumn => this.columnNOMEFILE;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      internal DataColumn EQ_IDColumn => this.columnEQ_ID;

      public NewDataSet.TblAllegatiRow this[int index] => (NewDataSet.TblAllegatiRow) this.Rows[index];

      public event NewDataSet.TblAllegatiRowChangeEventHandler TblAllegatiRowChanged;

      public event NewDataSet.TblAllegatiRowChangeEventHandler TblAllegatiRowChanging;

      public event NewDataSet.TblAllegatiRowChangeEventHandler TblAllegatiRowDeleted;

      public event NewDataSet.TblAllegatiRowChangeEventHandler TblAllegatiRowDeleting;

      public void AddTblAllegatiRow(NewDataSet.TblAllegatiRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblAllegatiRow AddTblAllegatiRow(
        Decimal DOC_EQ_ID,
        string NOMEFILE,
        string DESCRIZIONE,
        Decimal EQ_ID)
      {
        NewDataSet.TblAllegatiRow tblAllegatiRow = (NewDataSet.TblAllegatiRow) this.NewRow();
        tblAllegatiRow.ItemArray = new object[4]
        {
          (object) DOC_EQ_ID,
          (object) NOMEFILE,
          (object) DESCRIZIONE,
          (object) EQ_ID
        };
        this.Rows.Add((DataRow) tblAllegatiRow);
        return tblAllegatiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblAllegatiDataTable allegatiDataTable = (NewDataSet.TblAllegatiDataTable) base.Clone();
        allegatiDataTable.InitVars();
        return (DataTable) allegatiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblAllegatiDataTable();

      internal void InitVars()
      {
        this.columnDOC_EQ_ID = this.Columns["DOC_EQ_ID"];
        this.columnNOMEFILE = this.Columns["NOMEFILE"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
        this.columnEQ_ID = this.Columns["EQ_ID"];
      }

      private void InitClass()
      {
        this.columnDOC_EQ_ID = new DataColumn("DOC_EQ_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDOC_EQ_ID);
        this.columnNOMEFILE = new DataColumn("NOMEFILE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNOMEFILE);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnEQ_ID = new DataColumn("EQ_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID);
      }

      public NewDataSet.TblAllegatiRow NewTblAllegatiRow() => (NewDataSet.TblAllegatiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblAllegatiRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblAllegatiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblAllegatiRowChanged == null)
          return;
        this.TblAllegatiRowChanged((object) this, new NewDataSet.TblAllegatiRowChangeEvent((NewDataSet.TblAllegatiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblAllegatiRowChanging == null)
          return;
        this.TblAllegatiRowChanging((object) this, new NewDataSet.TblAllegatiRowChangeEvent((NewDataSet.TblAllegatiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblAllegatiRowDeleted == null)
          return;
        this.TblAllegatiRowDeleted((object) this, new NewDataSet.TblAllegatiRowChangeEvent((NewDataSet.TblAllegatiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblAllegatiRowDeleting == null)
          return;
        this.TblAllegatiRowDeleting((object) this, new NewDataSet.TblAllegatiRowChangeEvent((NewDataSet.TblAllegatiRow) e.Row, e.Action));
      }

      public void RemoveTblAllegatiRow(NewDataSet.TblAllegatiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblAllegatiRow : DataRow
    {
      private NewDataSet.TblAllegatiDataTable tableTblAllegati;

      internal TblAllegatiRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblAllegati = (NewDataSet.TblAllegatiDataTable) this.Table;

      public Decimal DOC_EQ_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllegati.DOC_EQ_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegati.DOC_EQ_IDColumn] = (object) value;
      }

      public string NOMEFILE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllegati.NOMEFILEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegati.NOMEFILEColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllegati.DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegati.DESCRIZIONEColumn] = (object) value;
      }

      public Decimal EQ_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllegati.EQ_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegati.EQ_IDColumn] = (object) value;
      }

      public bool IsDOC_EQ_IDNull() => this.IsNull(this.tableTblAllegati.DOC_EQ_IDColumn);

      public void SetDOC_EQ_IDNull() => this[this.tableTblAllegati.DOC_EQ_IDColumn] = Convert.DBNull;

      public bool IsNOMEFILENull() => this.IsNull(this.tableTblAllegati.NOMEFILEColumn);

      public void SetNOMEFILENull() => this[this.tableTblAllegati.NOMEFILEColumn] = Convert.DBNull;

      public bool IsDESCRIZIONENull() => this.IsNull(this.tableTblAllegati.DESCRIZIONEColumn);

      public void SetDESCRIZIONENull() => this[this.tableTblAllegati.DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsEQ_IDNull() => this.IsNull(this.tableTblAllegati.EQ_IDColumn);

      public void SetEQ_IDNull() => this[this.tableTblAllegati.EQ_IDColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblAllegatiRowChangeEvent : EventArgs
    {
      private NewDataSet.TblAllegatiRow eventRow;
      private DataRowAction eventAction;

      public TblAllegatiRowChangeEvent(NewDataSet.TblAllegatiRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblAllegatiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblDatiTecniciEstesaDataTable : DataTable, IEnumerable
    {
      private DataColumn columnDESCRIZIONEP;
      private DataColumn columnTIPOLOGIAP;
      private DataColumn columnDESCRIZIONED;
      private DataColumn columnTIPOLOOGIAD;
      private DataColumn columnIDEq;

      internal TblDatiTecniciEstesaDataTable()
        : base("TblDatiTecniciEstesa")
        => this.InitClass();

      internal TblDatiTecniciEstesaDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn DESCRIZIONEPColumn => this.columnDESCRIZIONEP;

      internal DataColumn TIPOLOGIAPColumn => this.columnTIPOLOGIAP;

      internal DataColumn DESCRIZIONEDColumn => this.columnDESCRIZIONED;

      internal DataColumn TIPOLOOGIADColumn => this.columnTIPOLOOGIAD;

      internal DataColumn IDEqColumn => this.columnIDEq;

      public NewDataSet.TblDatiTecniciEstesaRow this[int index] => (NewDataSet.TblDatiTecniciEstesaRow) this.Rows[index];

      public event NewDataSet.TblDatiTecniciEstesaRowChangeEventHandler TblDatiTecniciEstesaRowChanged;

      public event NewDataSet.TblDatiTecniciEstesaRowChangeEventHandler TblDatiTecniciEstesaRowChanging;

      public event NewDataSet.TblDatiTecniciEstesaRowChangeEventHandler TblDatiTecniciEstesaRowDeleted;

      public event NewDataSet.TblDatiTecniciEstesaRowChangeEventHandler TblDatiTecniciEstesaRowDeleting;

      public void AddTblDatiTecniciEstesaRow(NewDataSet.TblDatiTecniciEstesaRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblDatiTecniciEstesaRow AddTblDatiTecniciEstesaRow(
        string DESCRIZIONEP,
        string TIPOLOGIAP,
        string DESCRIZIONED,
        string TIPOLOOGIAD,
        Decimal IDEq)
      {
        NewDataSet.TblDatiTecniciEstesaRow tecniciEstesaRow = (NewDataSet.TblDatiTecniciEstesaRow) this.NewRow();
        tecniciEstesaRow.ItemArray = new object[5]
        {
          (object) DESCRIZIONEP,
          (object) TIPOLOGIAP,
          (object) DESCRIZIONED,
          (object) TIPOLOOGIAD,
          (object) IDEq
        };
        this.Rows.Add((DataRow) tecniciEstesaRow);
        return tecniciEstesaRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblDatiTecniciEstesaDataTable tecniciEstesaDataTable = (NewDataSet.TblDatiTecniciEstesaDataTable) base.Clone();
        tecniciEstesaDataTable.InitVars();
        return (DataTable) tecniciEstesaDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblDatiTecniciEstesaDataTable();

      internal void InitVars()
      {
        this.columnDESCRIZIONEP = this.Columns["DESCRIZIONEP"];
        this.columnTIPOLOGIAP = this.Columns["TIPOLOGIAP"];
        this.columnDESCRIZIONED = this.Columns["DESCRIZIONED"];
        this.columnTIPOLOOGIAD = this.Columns["TIPOLOOGIAD"];
        this.columnIDEq = this.Columns["IDEq"];
      }

      private void InitClass()
      {
        this.columnDESCRIZIONEP = new DataColumn("DESCRIZIONEP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONEP);
        this.columnTIPOLOGIAP = new DataColumn("TIPOLOGIAP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIPOLOGIAP);
        this.columnDESCRIZIONED = new DataColumn("DESCRIZIONED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONED);
        this.columnTIPOLOOGIAD = new DataColumn("TIPOLOOGIAD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIPOLOOGIAD);
        this.columnIDEq = new DataColumn("IDEq", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIDEq);
      }

      public NewDataSet.TblDatiTecniciEstesaRow NewTblDatiTecniciEstesaRow() => (NewDataSet.TblDatiTecniciEstesaRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblDatiTecniciEstesaRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblDatiTecniciEstesaRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblDatiTecniciEstesaRowChanged == null)
          return;
        this.TblDatiTecniciEstesaRowChanged((object) this, new NewDataSet.TblDatiTecniciEstesaRowChangeEvent((NewDataSet.TblDatiTecniciEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblDatiTecniciEstesaRowChanging == null)
          return;
        this.TblDatiTecniciEstesaRowChanging((object) this, new NewDataSet.TblDatiTecniciEstesaRowChangeEvent((NewDataSet.TblDatiTecniciEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblDatiTecniciEstesaRowDeleted == null)
          return;
        this.TblDatiTecniciEstesaRowDeleted((object) this, new NewDataSet.TblDatiTecniciEstesaRowChangeEvent((NewDataSet.TblDatiTecniciEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblDatiTecniciEstesaRowDeleting == null)
          return;
        this.TblDatiTecniciEstesaRowDeleting((object) this, new NewDataSet.TblDatiTecniciEstesaRowChangeEvent((NewDataSet.TblDatiTecniciEstesaRow) e.Row, e.Action));
      }

      public void RemoveTblDatiTecniciEstesaRow(NewDataSet.TblDatiTecniciEstesaRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblDatiTecniciEstesaRow : DataRow
    {
      private NewDataSet.TblDatiTecniciEstesaDataTable tableTblDatiTecniciEstesa;

      internal TblDatiTecniciEstesaRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblDatiTecniciEstesa = (NewDataSet.TblDatiTecniciEstesaDataTable) this.Table;

      public string DESCRIZIONEP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDatiTecniciEstesa.DESCRIZIONEPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecniciEstesa.DESCRIZIONEPColumn] = (object) value;
      }

      public string TIPOLOGIAP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDatiTecniciEstesa.TIPOLOGIAPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecniciEstesa.TIPOLOGIAPColumn] = (object) value;
      }

      public string DESCRIZIONED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDatiTecniciEstesa.DESCRIZIONEDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecniciEstesa.DESCRIZIONEDColumn] = (object) value;
      }

      public string TIPOLOOGIAD
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDatiTecniciEstesa.TIPOLOOGIADColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecniciEstesa.TIPOLOOGIADColumn] = (object) value;
      }

      public Decimal IDEq
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblDatiTecniciEstesa.IDEqColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDatiTecniciEstesa.IDEqColumn] = (object) value;
      }

      public bool IsDESCRIZIONEPNull() => this.IsNull(this.tableTblDatiTecniciEstesa.DESCRIZIONEPColumn);

      public void SetDESCRIZIONEPNull() => this[this.tableTblDatiTecniciEstesa.DESCRIZIONEPColumn] = Convert.DBNull;

      public bool IsTIPOLOGIAPNull() => this.IsNull(this.tableTblDatiTecniciEstesa.TIPOLOGIAPColumn);

      public void SetTIPOLOGIAPNull() => this[this.tableTblDatiTecniciEstesa.TIPOLOGIAPColumn] = Convert.DBNull;

      public bool IsDESCRIZIONEDNull() => this.IsNull(this.tableTblDatiTecniciEstesa.DESCRIZIONEDColumn);

      public void SetDESCRIZIONEDNull() => this[this.tableTblDatiTecniciEstesa.DESCRIZIONEDColumn] = Convert.DBNull;

      public bool IsTIPOLOOGIADNull() => this.IsNull(this.tableTblDatiTecniciEstesa.TIPOLOOGIADColumn);

      public void SetTIPOLOOGIADNull() => this[this.tableTblDatiTecniciEstesa.TIPOLOOGIADColumn] = Convert.DBNull;

      public bool IsIDEqNull() => this.IsNull(this.tableTblDatiTecniciEstesa.IDEqColumn);

      public void SetIDEqNull() => this[this.tableTblDatiTecniciEstesa.IDEqColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblDatiTecniciEstesaRowChangeEvent : EventArgs
    {
      private NewDataSet.TblDatiTecniciEstesaRow eventRow;
      private DataRowAction eventAction;

      public TblDatiTecniciEstesaRowChangeEvent(
        NewDataSet.TblDatiTecniciEstesaRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblDatiTecniciEstesaRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblAllegatiEstesaDataTable : DataTable, IEnumerable
    {
      private DataColumn columnNOMEFILEP;
      private DataColumn columnDESCRIZIONEP;
      private DataColumn columnNOMEFILED;
      private DataColumn columnDESCRIZIONED;
      private DataColumn columnEQ_ID;

      internal TblAllegatiEstesaDataTable()
        : base("TblAllegatiEstesa")
        => this.InitClass();

      internal TblAllegatiEstesaDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn NOMEFILEPColumn => this.columnNOMEFILEP;

      internal DataColumn DESCRIZIONEPColumn => this.columnDESCRIZIONEP;

      internal DataColumn NOMEFILEDColumn => this.columnNOMEFILED;

      internal DataColumn DESCRIZIONEDColumn => this.columnDESCRIZIONED;

      internal DataColumn EQ_IDColumn => this.columnEQ_ID;

      public NewDataSet.TblAllegatiEstesaRow this[int index] => (NewDataSet.TblAllegatiEstesaRow) this.Rows[index];

      public event NewDataSet.TblAllegatiEstesaRowChangeEventHandler TblAllegatiEstesaRowChanged;

      public event NewDataSet.TblAllegatiEstesaRowChangeEventHandler TblAllegatiEstesaRowChanging;

      public event NewDataSet.TblAllegatiEstesaRowChangeEventHandler TblAllegatiEstesaRowDeleted;

      public event NewDataSet.TblAllegatiEstesaRowChangeEventHandler TblAllegatiEstesaRowDeleting;

      public void AddTblAllegatiEstesaRow(NewDataSet.TblAllegatiEstesaRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblAllegatiEstesaRow AddTblAllegatiEstesaRow(
        string NOMEFILEP,
        string DESCRIZIONEP,
        string NOMEFILED,
        string DESCRIZIONED,
        Decimal EQ_ID)
      {
        NewDataSet.TblAllegatiEstesaRow allegatiEstesaRow = (NewDataSet.TblAllegatiEstesaRow) this.NewRow();
        allegatiEstesaRow.ItemArray = new object[5]
        {
          (object) NOMEFILEP,
          (object) DESCRIZIONEP,
          (object) NOMEFILED,
          (object) DESCRIZIONED,
          (object) EQ_ID
        };
        this.Rows.Add((DataRow) allegatiEstesaRow);
        return allegatiEstesaRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblAllegatiEstesaDataTable allegatiEstesaDataTable = (NewDataSet.TblAllegatiEstesaDataTable) base.Clone();
        allegatiEstesaDataTable.InitVars();
        return (DataTable) allegatiEstesaDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblAllegatiEstesaDataTable();

      internal void InitVars()
      {
        this.columnNOMEFILEP = this.Columns["NOMEFILEP"];
        this.columnDESCRIZIONEP = this.Columns["DESCRIZIONEP"];
        this.columnNOMEFILED = this.Columns["NOMEFILED"];
        this.columnDESCRIZIONED = this.Columns["DESCRIZIONED"];
        this.columnEQ_ID = this.Columns["EQ_ID"];
      }

      private void InitClass()
      {
        this.columnNOMEFILEP = new DataColumn("NOMEFILEP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNOMEFILEP);
        this.columnDESCRIZIONEP = new DataColumn("DESCRIZIONEP", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONEP);
        this.columnNOMEFILED = new DataColumn("NOMEFILED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNOMEFILED);
        this.columnDESCRIZIONED = new DataColumn("DESCRIZIONED", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONED);
        this.columnEQ_ID = new DataColumn("EQ_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID);
      }

      public NewDataSet.TblAllegatiEstesaRow NewTblAllegatiEstesaRow() => (NewDataSet.TblAllegatiEstesaRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblAllegatiEstesaRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblAllegatiEstesaRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblAllegatiEstesaRowChanged == null)
          return;
        this.TblAllegatiEstesaRowChanged((object) this, new NewDataSet.TblAllegatiEstesaRowChangeEvent((NewDataSet.TblAllegatiEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblAllegatiEstesaRowChanging == null)
          return;
        this.TblAllegatiEstesaRowChanging((object) this, new NewDataSet.TblAllegatiEstesaRowChangeEvent((NewDataSet.TblAllegatiEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblAllegatiEstesaRowDeleted == null)
          return;
        this.TblAllegatiEstesaRowDeleted((object) this, new NewDataSet.TblAllegatiEstesaRowChangeEvent((NewDataSet.TblAllegatiEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblAllegatiEstesaRowDeleting == null)
          return;
        this.TblAllegatiEstesaRowDeleting((object) this, new NewDataSet.TblAllegatiEstesaRowChangeEvent((NewDataSet.TblAllegatiEstesaRow) e.Row, e.Action));
      }

      public void RemoveTblAllegatiEstesaRow(NewDataSet.TblAllegatiEstesaRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblAllegatiEstesaRow : DataRow
    {
      private NewDataSet.TblAllegatiEstesaDataTable tableTblAllegatiEstesa;

      internal TblAllegatiEstesaRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblAllegatiEstesa = (NewDataSet.TblAllegatiEstesaDataTable) this.Table;

      public string NOMEFILEP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllegatiEstesa.NOMEFILEPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegatiEstesa.NOMEFILEPColumn] = (object) value;
      }

      public string DESCRIZIONEP
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllegatiEstesa.DESCRIZIONEPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegatiEstesa.DESCRIZIONEPColumn] = (object) value;
      }

      public string NOMEFILED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllegatiEstesa.NOMEFILEDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegatiEstesa.NOMEFILEDColumn] = (object) value;
      }

      public string DESCRIZIONED
      {
        get
        {
          try
          {
            return (string) this[this.tableTblAllegatiEstesa.DESCRIZIONEDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegatiEstesa.DESCRIZIONEDColumn] = (object) value;
      }

      public Decimal EQ_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblAllegatiEstesa.EQ_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblAllegatiEstesa.EQ_IDColumn] = (object) value;
      }

      public bool IsNOMEFILEPNull() => this.IsNull(this.tableTblAllegatiEstesa.NOMEFILEPColumn);

      public void SetNOMEFILEPNull() => this[this.tableTblAllegatiEstesa.NOMEFILEPColumn] = Convert.DBNull;

      public bool IsDESCRIZIONEPNull() => this.IsNull(this.tableTblAllegatiEstesa.DESCRIZIONEPColumn);

      public void SetDESCRIZIONEPNull() => this[this.tableTblAllegatiEstesa.DESCRIZIONEPColumn] = Convert.DBNull;

      public bool IsNOMEFILEDNull() => this.IsNull(this.tableTblAllegatiEstesa.NOMEFILEDColumn);

      public void SetNOMEFILEDNull() => this[this.tableTblAllegatiEstesa.NOMEFILEDColumn] = Convert.DBNull;

      public bool IsDESCRIZIONEDNull() => this.IsNull(this.tableTblAllegatiEstesa.DESCRIZIONEDColumn);

      public void SetDESCRIZIONEDNull() => this[this.tableTblAllegatiEstesa.DESCRIZIONEDColumn] = Convert.DBNull;

      public bool IsEQ_IDNull() => this.IsNull(this.tableTblAllegatiEstesa.EQ_IDColumn);

      public void SetEQ_IDNull() => this[this.tableTblAllegatiEstesa.EQ_IDColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblAllegatiEstesaRowChangeEvent : EventArgs
    {
      private NewDataSet.TblAllegatiEstesaRow eventRow;
      private DataRowAction eventAction;

      public TblAllegatiEstesaRowChangeEvent(
        NewDataSet.TblAllegatiEstesaRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblAllegatiEstesaRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblManRicDataTable : DataTable, IEnumerable
    {
      private DataColumn columnIdEq;
      private DataColumn columnWR_ID;
      private DataColumn columnDATA_WR;
      private DataColumn columnWO_ID;
      private DataColumn columnPIANIFICATA;
      private DataColumn columnCOMPLETATA;
      private DataColumn columnSTATO;
      private DataColumn columnDESCRIZIONE;
      private DataColumn columnADDETTO;
      private DataColumn columnMANUTENZIONE;

      internal TblManRicDataTable()
        : base("TblManRic")
        => this.InitClass();

      internal TblManRicDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn IdEqColumn => this.columnIdEq;

      internal DataColumn WR_IDColumn => this.columnWR_ID;

      internal DataColumn DATA_WRColumn => this.columnDATA_WR;

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn PIANIFICATAColumn => this.columnPIANIFICATA;

      internal DataColumn COMPLETATAColumn => this.columnCOMPLETATA;

      internal DataColumn STATOColumn => this.columnSTATO;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      internal DataColumn ADDETTOColumn => this.columnADDETTO;

      internal DataColumn MANUTENZIONEColumn => this.columnMANUTENZIONE;

      public NewDataSet.TblManRicRow this[int index] => (NewDataSet.TblManRicRow) this.Rows[index];

      public event NewDataSet.TblManRicRowChangeEventHandler TblManRicRowChanged;

      public event NewDataSet.TblManRicRowChangeEventHandler TblManRicRowChanging;

      public event NewDataSet.TblManRicRowChangeEventHandler TblManRicRowDeleted;

      public event NewDataSet.TblManRicRowChangeEventHandler TblManRicRowDeleting;

      public void AddTblManRicRow(NewDataSet.TblManRicRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblManRicRow AddTblManRicRow(
        Decimal IdEq,
        Decimal WR_ID,
        DateTime DATA_WR,
        Decimal WO_ID,
        DateTime PIANIFICATA,
        DateTime COMPLETATA,
        string STATO,
        string DESCRIZIONE,
        string ADDETTO,
        string MANUTENZIONE)
      {
        NewDataSet.TblManRicRow tblManRicRow = (NewDataSet.TblManRicRow) this.NewRow();
        tblManRicRow.ItemArray = new object[10]
        {
          (object) IdEq,
          (object) WR_ID,
          (object) DATA_WR,
          (object) WO_ID,
          (object) PIANIFICATA,
          (object) COMPLETATA,
          (object) STATO,
          (object) DESCRIZIONE,
          (object) ADDETTO,
          (object) MANUTENZIONE
        };
        this.Rows.Add((DataRow) tblManRicRow);
        return tblManRicRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblManRicDataTable tblManRicDataTable = (NewDataSet.TblManRicDataTable) base.Clone();
        tblManRicDataTable.InitVars();
        return (DataTable) tblManRicDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblManRicDataTable();

      internal void InitVars()
      {
        this.columnIdEq = this.Columns["IdEq"];
        this.columnWR_ID = this.Columns["WR_ID"];
        this.columnDATA_WR = this.Columns["DATA_WR"];
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnPIANIFICATA = this.Columns["PIANIFICATA"];
        this.columnCOMPLETATA = this.Columns["COMPLETATA"];
        this.columnSTATO = this.Columns["STATO"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
        this.columnADDETTO = this.Columns["ADDETTO"];
        this.columnMANUTENZIONE = this.Columns["MANUTENZIONE"];
      }

      private void InitClass()
      {
        this.columnIdEq = new DataColumn("IdEq", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEq);
        this.columnWR_ID = new DataColumn("WR_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID);
        this.columnDATA_WR = new DataColumn("DATA_WR", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATA_WR);
        this.columnWO_ID = new DataColumn("WO_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnPIANIFICATA = new DataColumn("PIANIFICATA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPIANIFICATA);
        this.columnCOMPLETATA = new DataColumn("COMPLETATA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOMPLETATA);
        this.columnSTATO = new DataColumn("STATO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATO);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnADDETTO = new DataColumn("ADDETTO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnADDETTO);
        this.columnMANUTENZIONE = new DataColumn("MANUTENZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMANUTENZIONE);
      }

      public NewDataSet.TblManRicRow NewTblManRicRow() => (NewDataSet.TblManRicRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblManRicRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblManRicRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblManRicRowChanged == null)
          return;
        this.TblManRicRowChanged((object) this, new NewDataSet.TblManRicRowChangeEvent((NewDataSet.TblManRicRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblManRicRowChanging == null)
          return;
        this.TblManRicRowChanging((object) this, new NewDataSet.TblManRicRowChangeEvent((NewDataSet.TblManRicRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblManRicRowDeleted == null)
          return;
        this.TblManRicRowDeleted((object) this, new NewDataSet.TblManRicRowChangeEvent((NewDataSet.TblManRicRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblManRicRowDeleting == null)
          return;
        this.TblManRicRowDeleting((object) this, new NewDataSet.TblManRicRowChangeEvent((NewDataSet.TblManRicRow) e.Row, e.Action));
      }

      public void RemoveTblManRicRow(NewDataSet.TblManRicRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblManRicRow : DataRow
    {
      private NewDataSet.TblManRicDataTable tableTblManRic;

      internal TblManRicRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblManRic = (NewDataSet.TblManRicDataTable) this.Table;

      public Decimal IdEq
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManRic.IdEqColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.IdEqColumn] = (object) value;
      }

      public Decimal WR_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManRic.WR_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.WR_IDColumn] = (object) value;
      }

      public DateTime DATA_WR
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManRic.DATA_WRColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.DATA_WRColumn] = (object) value;
      }

      public Decimal WO_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManRic.WO_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.WO_IDColumn] = (object) value;
      }

      public DateTime PIANIFICATA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManRic.PIANIFICATAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.PIANIFICATAColumn] = (object) value;
      }

      public DateTime COMPLETATA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManRic.COMPLETATAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.COMPLETATAColumn] = (object) value;
      }

      public string STATO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManRic.STATOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.STATOColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManRic.DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.DESCRIZIONEColumn] = (object) value;
      }

      public string ADDETTO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManRic.ADDETTOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.ADDETTOColumn] = (object) value;
      }

      public string MANUTENZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManRic.MANUTENZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManRic.MANUTENZIONEColumn] = (object) value;
      }

      public bool IsIdEqNull() => this.IsNull(this.tableTblManRic.IdEqColumn);

      public void SetIdEqNull() => this[this.tableTblManRic.IdEqColumn] = Convert.DBNull;

      public bool IsWR_IDNull() => this.IsNull(this.tableTblManRic.WR_IDColumn);

      public void SetWR_IDNull() => this[this.tableTblManRic.WR_IDColumn] = Convert.DBNull;

      public bool IsDATA_WRNull() => this.IsNull(this.tableTblManRic.DATA_WRColumn);

      public void SetDATA_WRNull() => this[this.tableTblManRic.DATA_WRColumn] = Convert.DBNull;

      public bool IsWO_IDNull() => this.IsNull(this.tableTblManRic.WO_IDColumn);

      public void SetWO_IDNull() => this[this.tableTblManRic.WO_IDColumn] = Convert.DBNull;

      public bool IsPIANIFICATANull() => this.IsNull(this.tableTblManRic.PIANIFICATAColumn);

      public void SetPIANIFICATANull() => this[this.tableTblManRic.PIANIFICATAColumn] = Convert.DBNull;

      public bool IsCOMPLETATANull() => this.IsNull(this.tableTblManRic.COMPLETATAColumn);

      public void SetCOMPLETATANull() => this[this.tableTblManRic.COMPLETATAColumn] = Convert.DBNull;

      public bool IsSTATONull() => this.IsNull(this.tableTblManRic.STATOColumn);

      public void SetSTATONull() => this[this.tableTblManRic.STATOColumn] = Convert.DBNull;

      public bool IsDESCRIZIONENull() => this.IsNull(this.tableTblManRic.DESCRIZIONEColumn);

      public void SetDESCRIZIONENull() => this[this.tableTblManRic.DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsADDETTONull() => this.IsNull(this.tableTblManRic.ADDETTOColumn);

      public void SetADDETTONull() => this[this.tableTblManRic.ADDETTOColumn] = Convert.DBNull;

      public bool IsMANUTENZIONENull() => this.IsNull(this.tableTblManRic.MANUTENZIONEColumn);

      public void SetMANUTENZIONENull() => this[this.tableTblManRic.MANUTENZIONEColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblManRicRowChangeEvent : EventArgs
    {
      private NewDataSet.TblManRicRow eventRow;
      private DataRowAction eventAction;

      public TblManRicRowChangeEvent(NewDataSet.TblManRicRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblManRicRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblManProgDataTable : DataTable, IEnumerable
    {
      private DataColumn columnIdEq;
      private DataColumn columnWR_ID;
      private DataColumn columnDATA_WR;
      private DataColumn columnWO_ID;
      private DataColumn columnPIANIFICATA;
      private DataColumn columnCOMPLETATA;
      private DataColumn columnSTATO;
      private DataColumn columnDESCRIZIONE;
      private DataColumn columnADDETTO;
      private DataColumn columnMANUTENZIONE;

      internal TblManProgDataTable()
        : base("TblManProg")
        => this.InitClass();

      internal TblManProgDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn IdEqColumn => this.columnIdEq;

      internal DataColumn WR_IDColumn => this.columnWR_ID;

      internal DataColumn DATA_WRColumn => this.columnDATA_WR;

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn PIANIFICATAColumn => this.columnPIANIFICATA;

      internal DataColumn COMPLETATAColumn => this.columnCOMPLETATA;

      internal DataColumn STATOColumn => this.columnSTATO;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      internal DataColumn ADDETTOColumn => this.columnADDETTO;

      internal DataColumn MANUTENZIONEColumn => this.columnMANUTENZIONE;

      public NewDataSet.TblManProgRow this[int index] => (NewDataSet.TblManProgRow) this.Rows[index];

      public event NewDataSet.TblManProgRowChangeEventHandler TblManProgRowChanged;

      public event NewDataSet.TblManProgRowChangeEventHandler TblManProgRowChanging;

      public event NewDataSet.TblManProgRowChangeEventHandler TblManProgRowDeleted;

      public event NewDataSet.TblManProgRowChangeEventHandler TblManProgRowDeleting;

      public void AddTblManProgRow(NewDataSet.TblManProgRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblManProgRow AddTblManProgRow(
        Decimal IdEq,
        Decimal WR_ID,
        DateTime DATA_WR,
        Decimal WO_ID,
        DateTime PIANIFICATA,
        DateTime COMPLETATA,
        string STATO,
        string DESCRIZIONE,
        string ADDETTO,
        string MANUTENZIONE)
      {
        NewDataSet.TblManProgRow tblManProgRow = (NewDataSet.TblManProgRow) this.NewRow();
        tblManProgRow.ItemArray = new object[10]
        {
          (object) IdEq,
          (object) WR_ID,
          (object) DATA_WR,
          (object) WO_ID,
          (object) PIANIFICATA,
          (object) COMPLETATA,
          (object) STATO,
          (object) DESCRIZIONE,
          (object) ADDETTO,
          (object) MANUTENZIONE
        };
        this.Rows.Add((DataRow) tblManProgRow);
        return tblManProgRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblManProgDataTable manProgDataTable = (NewDataSet.TblManProgDataTable) base.Clone();
        manProgDataTable.InitVars();
        return (DataTable) manProgDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblManProgDataTable();

      internal void InitVars()
      {
        this.columnIdEq = this.Columns["IdEq"];
        this.columnWR_ID = this.Columns["WR_ID"];
        this.columnDATA_WR = this.Columns["DATA_WR"];
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnPIANIFICATA = this.Columns["PIANIFICATA"];
        this.columnCOMPLETATA = this.Columns["COMPLETATA"];
        this.columnSTATO = this.Columns["STATO"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
        this.columnADDETTO = this.Columns["ADDETTO"];
        this.columnMANUTENZIONE = this.Columns["MANUTENZIONE"];
      }

      private void InitClass()
      {
        this.columnIdEq = new DataColumn("IdEq", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEq);
        this.columnWR_ID = new DataColumn("WR_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID);
        this.columnDATA_WR = new DataColumn("DATA_WR", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATA_WR);
        this.columnWO_ID = new DataColumn("WO_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnPIANIFICATA = new DataColumn("PIANIFICATA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPIANIFICATA);
        this.columnCOMPLETATA = new DataColumn("COMPLETATA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOMPLETATA);
        this.columnSTATO = new DataColumn("STATO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATO);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnADDETTO = new DataColumn("ADDETTO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnADDETTO);
        this.columnMANUTENZIONE = new DataColumn("MANUTENZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMANUTENZIONE);
      }

      public NewDataSet.TblManProgRow NewTblManProgRow() => (NewDataSet.TblManProgRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblManProgRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblManProgRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblManProgRowChanged == null)
          return;
        this.TblManProgRowChanged((object) this, new NewDataSet.TblManProgRowChangeEvent((NewDataSet.TblManProgRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblManProgRowChanging == null)
          return;
        this.TblManProgRowChanging((object) this, new NewDataSet.TblManProgRowChangeEvent((NewDataSet.TblManProgRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblManProgRowDeleted == null)
          return;
        this.TblManProgRowDeleted((object) this, new NewDataSet.TblManProgRowChangeEvent((NewDataSet.TblManProgRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblManProgRowDeleting == null)
          return;
        this.TblManProgRowDeleting((object) this, new NewDataSet.TblManProgRowChangeEvent((NewDataSet.TblManProgRow) e.Row, e.Action));
      }

      public void RemoveTblManProgRow(NewDataSet.TblManProgRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblManProgRow : DataRow
    {
      private NewDataSet.TblManProgDataTable tableTblManProg;

      internal TblManProgRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblManProg = (NewDataSet.TblManProgDataTable) this.Table;

      public Decimal IdEq
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManProg.IdEqColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.IdEqColumn] = (object) value;
      }

      public Decimal WR_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManProg.WR_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.WR_IDColumn] = (object) value;
      }

      public DateTime DATA_WR
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManProg.DATA_WRColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.DATA_WRColumn] = (object) value;
      }

      public Decimal WO_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManProg.WO_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.WO_IDColumn] = (object) value;
      }

      public DateTime PIANIFICATA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManProg.PIANIFICATAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.PIANIFICATAColumn] = (object) value;
      }

      public DateTime COMPLETATA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManProg.COMPLETATAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.COMPLETATAColumn] = (object) value;
      }

      public string STATO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManProg.STATOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.STATOColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManProg.DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.DESCRIZIONEColumn] = (object) value;
      }

      public string ADDETTO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManProg.ADDETTOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.ADDETTOColumn] = (object) value;
      }

      public string MANUTENZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManProg.MANUTENZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManProg.MANUTENZIONEColumn] = (object) value;
      }

      public bool IsIdEqNull() => this.IsNull(this.tableTblManProg.IdEqColumn);

      public void SetIdEqNull() => this[this.tableTblManProg.IdEqColumn] = Convert.DBNull;

      public bool IsWR_IDNull() => this.IsNull(this.tableTblManProg.WR_IDColumn);

      public void SetWR_IDNull() => this[this.tableTblManProg.WR_IDColumn] = Convert.DBNull;

      public bool IsDATA_WRNull() => this.IsNull(this.tableTblManProg.DATA_WRColumn);

      public void SetDATA_WRNull() => this[this.tableTblManProg.DATA_WRColumn] = Convert.DBNull;

      public bool IsWO_IDNull() => this.IsNull(this.tableTblManProg.WO_IDColumn);

      public void SetWO_IDNull() => this[this.tableTblManProg.WO_IDColumn] = Convert.DBNull;

      public bool IsPIANIFICATANull() => this.IsNull(this.tableTblManProg.PIANIFICATAColumn);

      public void SetPIANIFICATANull() => this[this.tableTblManProg.PIANIFICATAColumn] = Convert.DBNull;

      public bool IsCOMPLETATANull() => this.IsNull(this.tableTblManProg.COMPLETATAColumn);

      public void SetCOMPLETATANull() => this[this.tableTblManProg.COMPLETATAColumn] = Convert.DBNull;

      public bool IsSTATONull() => this.IsNull(this.tableTblManProg.STATOColumn);

      public void SetSTATONull() => this[this.tableTblManProg.STATOColumn] = Convert.DBNull;

      public bool IsDESCRIZIONENull() => this.IsNull(this.tableTblManProg.DESCRIZIONEColumn);

      public void SetDESCRIZIONENull() => this[this.tableTblManProg.DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsADDETTONull() => this.IsNull(this.tableTblManProg.ADDETTOColumn);

      public void SetADDETTONull() => this[this.tableTblManProg.ADDETTOColumn] = Convert.DBNull;

      public bool IsMANUTENZIONENull() => this.IsNull(this.tableTblManProg.MANUTENZIONEColumn);

      public void SetMANUTENZIONENull() => this[this.tableTblManProg.MANUTENZIONEColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblManProgRowChangeEvent : EventArgs
    {
      private NewDataSet.TblManProgRow eventRow;
      private DataRowAction eventAction;

      public TblManProgRowChangeEvent(NewDataSet.TblManProgRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblManProgRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblManStraDataTable : DataTable, IEnumerable
    {
      private DataColumn columnIdEq;
      private DataColumn columnWR_ID;
      private DataColumn columnDATA_WR;
      private DataColumn columnWO_ID;
      private DataColumn columnPIANIFICATA;
      private DataColumn columnCOMPLETATA;
      private DataColumn columnSTATO;
      private DataColumn columnDESCRIZIONE;
      private DataColumn columnADDETTO;
      private DataColumn columnMANUTENZIONE;

      internal TblManStraDataTable()
        : base("TblManStra")
        => this.InitClass();

      internal TblManStraDataTable(DataTable table)
        : base(table.TableName)
      {
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
        this.DisplayExpression = table.DisplayExpression;
      }

      [Browsable(false)]
      public int Count => this.Rows.Count;

      internal DataColumn IdEqColumn => this.columnIdEq;

      internal DataColumn WR_IDColumn => this.columnWR_ID;

      internal DataColumn DATA_WRColumn => this.columnDATA_WR;

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn PIANIFICATAColumn => this.columnPIANIFICATA;

      internal DataColumn COMPLETATAColumn => this.columnCOMPLETATA;

      internal DataColumn STATOColumn => this.columnSTATO;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      internal DataColumn ADDETTOColumn => this.columnADDETTO;

      internal DataColumn MANUTENZIONEColumn => this.columnMANUTENZIONE;

      public NewDataSet.TblManStraRow this[int index] => (NewDataSet.TblManStraRow) this.Rows[index];

      public event NewDataSet.TblManStraRowChangeEventHandler TblManStraRowChanged;

      public event NewDataSet.TblManStraRowChangeEventHandler TblManStraRowChanging;

      public event NewDataSet.TblManStraRowChangeEventHandler TblManStraRowDeleted;

      public event NewDataSet.TblManStraRowChangeEventHandler TblManStraRowDeleting;

      public void AddTblManStraRow(NewDataSet.TblManStraRow row) => this.Rows.Add((DataRow) row);

      public NewDataSet.TblManStraRow AddTblManStraRow(
        Decimal IdEq,
        Decimal WR_ID,
        DateTime DATA_WR,
        Decimal WO_ID,
        DateTime PIANIFICATA,
        DateTime COMPLETATA,
        string STATO,
        string DESCRIZIONE,
        string ADDETTO,
        string MANUTENZIONE)
      {
        NewDataSet.TblManStraRow tblManStraRow = (NewDataSet.TblManStraRow) this.NewRow();
        tblManStraRow.ItemArray = new object[10]
        {
          (object) IdEq,
          (object) WR_ID,
          (object) DATA_WR,
          (object) WO_ID,
          (object) PIANIFICATA,
          (object) COMPLETATA,
          (object) STATO,
          (object) DESCRIZIONE,
          (object) ADDETTO,
          (object) MANUTENZIONE
        };
        this.Rows.Add((DataRow) tblManStraRow);
        return tblManStraRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        NewDataSet.TblManStraDataTable manStraDataTable = (NewDataSet.TblManStraDataTable) base.Clone();
        manStraDataTable.InitVars();
        return (DataTable) manStraDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new NewDataSet.TblManStraDataTable();

      internal void InitVars()
      {
        this.columnIdEq = this.Columns["IdEq"];
        this.columnWR_ID = this.Columns["WR_ID"];
        this.columnDATA_WR = this.Columns["DATA_WR"];
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnPIANIFICATA = this.Columns["PIANIFICATA"];
        this.columnCOMPLETATA = this.Columns["COMPLETATA"];
        this.columnSTATO = this.Columns["STATO"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
        this.columnADDETTO = this.Columns["ADDETTO"];
        this.columnMANUTENZIONE = this.Columns["MANUTENZIONE"];
      }

      private void InitClass()
      {
        this.columnIdEq = new DataColumn("IdEq", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdEq);
        this.columnWR_ID = new DataColumn("WR_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID);
        this.columnDATA_WR = new DataColumn("DATA_WR", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATA_WR);
        this.columnWO_ID = new DataColumn("WO_ID", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnPIANIFICATA = new DataColumn("PIANIFICATA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPIANIFICATA);
        this.columnCOMPLETATA = new DataColumn("COMPLETATA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOMPLETATA);
        this.columnSTATO = new DataColumn("STATO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATO);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnADDETTO = new DataColumn("ADDETTO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnADDETTO);
        this.columnMANUTENZIONE = new DataColumn("MANUTENZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMANUTENZIONE);
      }

      public NewDataSet.TblManStraRow NewTblManStraRow() => (NewDataSet.TblManStraRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new NewDataSet.TblManStraRow(builder);

      protected override Type GetRowType() => typeof (NewDataSet.TblManStraRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblManStraRowChanged == null)
          return;
        this.TblManStraRowChanged((object) this, new NewDataSet.TblManStraRowChangeEvent((NewDataSet.TblManStraRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblManStraRowChanging == null)
          return;
        this.TblManStraRowChanging((object) this, new NewDataSet.TblManStraRowChangeEvent((NewDataSet.TblManStraRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblManStraRowDeleted == null)
          return;
        this.TblManStraRowDeleted((object) this, new NewDataSet.TblManStraRowChangeEvent((NewDataSet.TblManStraRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblManStraRowDeleting == null)
          return;
        this.TblManStraRowDeleting((object) this, new NewDataSet.TblManStraRowChangeEvent((NewDataSet.TblManStraRow) e.Row, e.Action));
      }

      public void RemoveTblManStraRow(NewDataSet.TblManStraRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblManStraRow : DataRow
    {
      private NewDataSet.TblManStraDataTable tableTblManStra;

      internal TblManStraRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblManStra = (NewDataSet.TblManStraDataTable) this.Table;

      public Decimal IdEq
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManStra.IdEqColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.IdEqColumn] = (object) value;
      }

      public Decimal WR_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManStra.WR_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.WR_IDColumn] = (object) value;
      }

      public DateTime DATA_WR
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManStra.DATA_WRColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.DATA_WRColumn] = (object) value;
      }

      public Decimal WO_ID
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableTblManStra.WO_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.WO_IDColumn] = (object) value;
      }

      public DateTime PIANIFICATA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManStra.PIANIFICATAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.PIANIFICATAColumn] = (object) value;
      }

      public DateTime COMPLETATA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTblManStra.COMPLETATAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.COMPLETATAColumn] = (object) value;
      }

      public string STATO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManStra.STATOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.STATOColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManStra.DESCRIZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.DESCRIZIONEColumn] = (object) value;
      }

      public string ADDETTO
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManStra.ADDETTOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.ADDETTOColumn] = (object) value;
      }

      public string MANUTENZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tableTblManStra.MANUTENZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Impossibile ottenere un valore perché è DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblManStra.MANUTENZIONEColumn] = (object) value;
      }

      public bool IsIdEqNull() => this.IsNull(this.tableTblManStra.IdEqColumn);

      public void SetIdEqNull() => this[this.tableTblManStra.IdEqColumn] = Convert.DBNull;

      public bool IsWR_IDNull() => this.IsNull(this.tableTblManStra.WR_IDColumn);

      public void SetWR_IDNull() => this[this.tableTblManStra.WR_IDColumn] = Convert.DBNull;

      public bool IsDATA_WRNull() => this.IsNull(this.tableTblManStra.DATA_WRColumn);

      public void SetDATA_WRNull() => this[this.tableTblManStra.DATA_WRColumn] = Convert.DBNull;

      public bool IsWO_IDNull() => this.IsNull(this.tableTblManStra.WO_IDColumn);

      public void SetWO_IDNull() => this[this.tableTblManStra.WO_IDColumn] = Convert.DBNull;

      public bool IsPIANIFICATANull() => this.IsNull(this.tableTblManStra.PIANIFICATAColumn);

      public void SetPIANIFICATANull() => this[this.tableTblManStra.PIANIFICATAColumn] = Convert.DBNull;

      public bool IsCOMPLETATANull() => this.IsNull(this.tableTblManStra.COMPLETATAColumn);

      public void SetCOMPLETATANull() => this[this.tableTblManStra.COMPLETATAColumn] = Convert.DBNull;

      public bool IsSTATONull() => this.IsNull(this.tableTblManStra.STATOColumn);

      public void SetSTATONull() => this[this.tableTblManStra.STATOColumn] = Convert.DBNull;

      public bool IsDESCRIZIONENull() => this.IsNull(this.tableTblManStra.DESCRIZIONEColumn);

      public void SetDESCRIZIONENull() => this[this.tableTblManStra.DESCRIZIONEColumn] = Convert.DBNull;

      public bool IsADDETTONull() => this.IsNull(this.tableTblManStra.ADDETTOColumn);

      public void SetADDETTONull() => this[this.tableTblManStra.ADDETTOColumn] = Convert.DBNull;

      public bool IsMANUTENZIONENull() => this.IsNull(this.tableTblManStra.MANUTENZIONEColumn);

      public void SetMANUTENZIONENull() => this[this.tableTblManStra.MANUTENZIONEColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblManStraRowChangeEvent : EventArgs
    {
      private NewDataSet.TblManStraRow eventRow;
      private DataRowAction eventAction;

      public TblManStraRowChangeEvent(NewDataSet.TblManStraRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public NewDataSet.TblManStraRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }
  }
}
