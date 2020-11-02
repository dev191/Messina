// Decompiled with JetBrains decompiler
// Type: TheSite.SchemiXSD.DsRptMpLocali
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
  [ToolboxItem(true)]
  [DesignerCategory("code")]
  [DebuggerStepThrough]
  [Serializable]
  public class DsRptMpLocali : DataSet
  {
    private DsRptMpLocali.tblMainDataTable tabletblMain;
    private DsRptMpLocali.tblPassiDataTable tabletblPassi;
    private DsRptMpLocali.TblDetRdlDataTable tableTblDetRdl;
    private DsRptMpLocali.TblDetRdlEstesaDataTable tableTblDetRdlEstesa;
    private DsRptMpLocali.tblAllRptDataTable tabletblAllRpt;
    private DsRptMpLocali.TblLeggendaPassiDataTable tableTblLeggendaPassi;
    private DsRptMpLocali.tblLeggendaStatusDataTable tabletblLeggendaStatus;

    public DsRptMpLocali()
    {
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    protected DsRptMpLocali(SerializationInfo info, StreamingContext context)
    {
      string s = (string) info.GetValue("XmlSchema", typeof (string));
      if (s != null)
      {
        DataSet dataSet = new DataSet();
        dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        if (dataSet.Tables[nameof (tblMain)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.tblMainDataTable(dataSet.Tables[nameof (tblMain)]));
        if (dataSet.Tables[nameof (tblPassi)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.tblPassiDataTable(dataSet.Tables[nameof (tblPassi)]));
        if (dataSet.Tables[nameof (TblDetRdl)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.TblDetRdlDataTable(dataSet.Tables[nameof (TblDetRdl)]));
        if (dataSet.Tables[nameof (TblDetRdlEstesa)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.TblDetRdlEstesaDataTable(dataSet.Tables[nameof (TblDetRdlEstesa)]));
        if (dataSet.Tables[nameof (tblAllRpt)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.tblAllRptDataTable(dataSet.Tables[nameof (tblAllRpt)]));
        if (dataSet.Tables[nameof (TblLeggendaPassi)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.TblLeggendaPassiDataTable(dataSet.Tables[nameof (TblLeggendaPassi)]));
        if (dataSet.Tables[nameof (tblLeggendaStatus)] != null)
          this.Tables.Add((DataTable) new DsRptMpLocali.tblLeggendaStatusDataTable(dataSet.Tables[nameof (tblLeggendaStatus)]));
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DsRptMpLocali.tblMainDataTable tblMain => this.tabletblMain;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DsRptMpLocali.tblPassiDataTable tblPassi => this.tabletblPassi;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DsRptMpLocali.TblDetRdlDataTable TblDetRdl => this.tableTblDetRdl;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DsRptMpLocali.TblDetRdlEstesaDataTable TblDetRdlEstesa => this.tableTblDetRdlEstesa;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DsRptMpLocali.tblAllRptDataTable tblAllRpt => this.tabletblAllRpt;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DsRptMpLocali.TblLeggendaPassiDataTable TblLeggendaPassi => this.tableTblLeggendaPassi;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public DsRptMpLocali.tblLeggendaStatusDataTable tblLeggendaStatus => this.tabletblLeggendaStatus;

    public override DataSet Clone()
    {
      DsRptMpLocali dsRptMpLocali = (DsRptMpLocali) base.Clone();
      dsRptMpLocali.InitVars();
      return (DataSet) dsRptMpLocali;
    }

    protected override bool ShouldSerializeTables() => false;

    protected override bool ShouldSerializeRelations() => false;

    protected override void ReadXmlSerializable(XmlReader reader)
    {
      this.Reset();
      DataSet dataSet = new DataSet();
      int num = (int) dataSet.ReadXml(reader);
      if (dataSet.Tables["tblMain"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.tblMainDataTable(dataSet.Tables["tblMain"]));
      if (dataSet.Tables["tblPassi"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.tblPassiDataTable(dataSet.Tables["tblPassi"]));
      if (dataSet.Tables["TblDetRdl"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.TblDetRdlDataTable(dataSet.Tables["TblDetRdl"]));
      if (dataSet.Tables["TblDetRdlEstesa"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.TblDetRdlEstesaDataTable(dataSet.Tables["TblDetRdlEstesa"]));
      if (dataSet.Tables["tblAllRpt"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.tblAllRptDataTable(dataSet.Tables["tblAllRpt"]));
      if (dataSet.Tables["TblLeggendaPassi"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.TblLeggendaPassiDataTable(dataSet.Tables["TblLeggendaPassi"]));
      if (dataSet.Tables["tblLeggendaStatus"] != null)
        this.Tables.Add((DataTable) new DsRptMpLocali.tblLeggendaStatusDataTable(dataSet.Tables["tblLeggendaStatus"]));
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
      this.tabletblMain = (DsRptMpLocali.tblMainDataTable) this.Tables["tblMain"];
      if (this.tabletblMain != null)
        this.tabletblMain.InitVars();
      this.tabletblPassi = (DsRptMpLocali.tblPassiDataTable) this.Tables["tblPassi"];
      if (this.tabletblPassi != null)
        this.tabletblPassi.InitVars();
      this.tableTblDetRdl = (DsRptMpLocali.TblDetRdlDataTable) this.Tables["TblDetRdl"];
      if (this.tableTblDetRdl != null)
        this.tableTblDetRdl.InitVars();
      this.tableTblDetRdlEstesa = (DsRptMpLocali.TblDetRdlEstesaDataTable) this.Tables["TblDetRdlEstesa"];
      if (this.tableTblDetRdlEstesa != null)
        this.tableTblDetRdlEstesa.InitVars();
      this.tabletblAllRpt = (DsRptMpLocali.tblAllRptDataTable) this.Tables["tblAllRpt"];
      if (this.tabletblAllRpt != null)
        this.tabletblAllRpt.InitVars();
      this.tableTblLeggendaPassi = (DsRptMpLocali.TblLeggendaPassiDataTable) this.Tables["TblLeggendaPassi"];
      if (this.tableTblLeggendaPassi != null)
        this.tableTblLeggendaPassi.InitVars();
      this.tabletblLeggendaStatus = (DsRptMpLocali.tblLeggendaStatusDataTable) this.Tables["tblLeggendaStatus"];
      if (this.tabletblLeggendaStatus == null)
        return;
      this.tabletblLeggendaStatus.InitVars();
    }

    private void InitClass()
    {
      this.DataSetName = nameof (DsRptMpLocali);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/DsRptMpLocali.xsd";
      this.Locale = new CultureInfo("it-IT");
      this.CaseSensitive = false;
      this.EnforceConstraints = true;
      this.tabletblMain = new DsRptMpLocali.tblMainDataTable();
      this.Tables.Add((DataTable) this.tabletblMain);
      this.tabletblPassi = new DsRptMpLocali.tblPassiDataTable();
      this.Tables.Add((DataTable) this.tabletblPassi);
      this.tableTblDetRdl = new DsRptMpLocali.TblDetRdlDataTable();
      this.Tables.Add((DataTable) this.tableTblDetRdl);
      this.tableTblDetRdlEstesa = new DsRptMpLocali.TblDetRdlEstesaDataTable();
      this.Tables.Add((DataTable) this.tableTblDetRdlEstesa);
      this.tabletblAllRpt = new DsRptMpLocali.tblAllRptDataTable();
      this.Tables.Add((DataTable) this.tabletblAllRpt);
      this.tableTblLeggendaPassi = new DsRptMpLocali.TblLeggendaPassiDataTable();
      this.Tables.Add((DataTable) this.tableTblLeggendaPassi);
      this.tabletblLeggendaStatus = new DsRptMpLocali.tblLeggendaStatusDataTable();
      this.Tables.Add((DataTable) this.tabletblLeggendaStatus);
    }

    private bool ShouldSerializetblMain() => false;

    private bool ShouldSerializetblPassi() => false;

    private bool ShouldSerializeTblDetRdl() => false;

    private bool ShouldSerializeTblDetRdlEstesa() => false;

    private bool ShouldSerializetblAllRpt() => false;

    private bool ShouldSerializeTblLeggendaPassi() => false;

    private bool ShouldSerializetblLeggendaStatus() => false;

    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    public delegate void tblMainRowChangeEventHandler(
      object sender,
      DsRptMpLocali.tblMainRowChangeEvent e);

    public delegate void tblPassiRowChangeEventHandler(
      object sender,
      DsRptMpLocali.tblPassiRowChangeEvent e);

    public delegate void TblDetRdlRowChangeEventHandler(
      object sender,
      DsRptMpLocali.TblDetRdlRowChangeEvent e);

    public delegate void TblDetRdlEstesaRowChangeEventHandler(
      object sender,
      DsRptMpLocali.TblDetRdlEstesaRowChangeEvent e);

    public delegate void tblAllRptRowChangeEventHandler(
      object sender,
      DsRptMpLocali.tblAllRptRowChangeEvent e);

    public delegate void TblLeggendaPassiRowChangeEventHandler(
      object sender,
      DsRptMpLocali.TblLeggendaPassiRowChangeEvent e);

    public delegate void tblLeggendaStatusRowChangeEventHandler(
      object sender,
      DsRptMpLocali.tblLeggendaStatusRowChangeEvent e);

    [DebuggerStepThrough]
    public class tblMainDataTable : DataTable, IEnumerable
    {
      private DataColumn columnWO_ID;
      private DataColumn columnDESC_BL_ESTESA;
      private DataColumn columnNOMECOGNOME;
      private DataColumn columnDATA_SCADENZA;
      private DataColumn columnSERVIZIO;
      private DataColumn columnDITTA;
      private DataColumn columnCOD_PROCEDURA;
      private DataColumn columnCOD_FREQ;
      private DataColumn columnDESC_PROCEDURA;
      private DataColumn columnID_PMP;

      internal tblMainDataTable()
        : base("tblMain")
        => this.InitClass();

      internal tblMainDataTable(DataTable table)
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

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn DESC_BL_ESTESAColumn => this.columnDESC_BL_ESTESA;

      internal DataColumn NOMECOGNOMEColumn => this.columnNOMECOGNOME;

      internal DataColumn DATA_SCADENZAColumn => this.columnDATA_SCADENZA;

      internal DataColumn SERVIZIOColumn => this.columnSERVIZIO;

      internal DataColumn DITTAColumn => this.columnDITTA;

      internal DataColumn COD_PROCEDURAColumn => this.columnCOD_PROCEDURA;

      internal DataColumn COD_FREQColumn => this.columnCOD_FREQ;

      internal DataColumn DESC_PROCEDURAColumn => this.columnDESC_PROCEDURA;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      public DsRptMpLocali.tblMainRow this[int index] => (DsRptMpLocali.tblMainRow) this.Rows[index];

      public event DsRptMpLocali.tblMainRowChangeEventHandler tblMainRowChanged;

      public event DsRptMpLocali.tblMainRowChangeEventHandler tblMainRowChanging;

      public event DsRptMpLocali.tblMainRowChangeEventHandler tblMainRowDeleted;

      public event DsRptMpLocali.tblMainRowChangeEventHandler tblMainRowDeleting;

      public void AddtblMainRow(DsRptMpLocali.tblMainRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.tblMainRow AddtblMainRow(
        long WO_ID,
        string DESC_BL_ESTESA,
        string NOMECOGNOME,
        string DATA_SCADENZA,
        string SERVIZIO,
        string DITTA,
        string COD_PROCEDURA,
        string COD_FREQ,
        string DESC_PROCEDURA,
        long ID_PMP)
      {
        DsRptMpLocali.tblMainRow tblMainRow = (DsRptMpLocali.tblMainRow) this.NewRow();
        tblMainRow.ItemArray = new object[10]
        {
          (object) WO_ID,
          (object) DESC_BL_ESTESA,
          (object) NOMECOGNOME,
          (object) DATA_SCADENZA,
          (object) SERVIZIO,
          (object) DITTA,
          (object) COD_PROCEDURA,
          (object) COD_FREQ,
          (object) DESC_PROCEDURA,
          (object) ID_PMP
        };
        this.Rows.Add((DataRow) tblMainRow);
        return tblMainRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.tblMainDataTable tblMainDataTable = (DsRptMpLocali.tblMainDataTable) base.Clone();
        tblMainDataTable.InitVars();
        return (DataTable) tblMainDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.tblMainDataTable();

      internal void InitVars()
      {
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnDESC_BL_ESTESA = this.Columns["DESC_BL_ESTESA"];
        this.columnNOMECOGNOME = this.Columns["NOMECOGNOME"];
        this.columnDATA_SCADENZA = this.Columns["DATA_SCADENZA"];
        this.columnSERVIZIO = this.Columns["SERVIZIO"];
        this.columnDITTA = this.Columns["DITTA"];
        this.columnCOD_PROCEDURA = this.Columns["COD_PROCEDURA"];
        this.columnCOD_FREQ = this.Columns["COD_FREQ"];
        this.columnDESC_PROCEDURA = this.Columns["DESC_PROCEDURA"];
        this.columnID_PMP = this.Columns["ID_PMP"];
      }

      private void InitClass()
      {
        this.columnWO_ID = new DataColumn("WO_ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnDESC_BL_ESTESA = new DataColumn("DESC_BL_ESTESA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_BL_ESTESA);
        this.columnNOMECOGNOME = new DataColumn("NOMECOGNOME", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNOMECOGNOME);
        this.columnDATA_SCADENZA = new DataColumn("DATA_SCADENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATA_SCADENZA);
        this.columnSERVIZIO = new DataColumn("SERVIZIO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSERVIZIO);
        this.columnDITTA = new DataColumn("DITTA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDITTA);
        this.columnCOD_PROCEDURA = new DataColumn("COD_PROCEDURA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOD_PROCEDURA);
        this.columnCOD_FREQ = new DataColumn("COD_FREQ", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOD_FREQ);
        this.columnDESC_PROCEDURA = new DataColumn("DESC_PROCEDURA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_PROCEDURA);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnWO_ID.AllowDBNull = false;
        this.columnDESC_BL_ESTESA.AllowDBNull = false;
        this.columnNOMECOGNOME.AllowDBNull = false;
        this.columnDATA_SCADENZA.AllowDBNull = false;
        this.columnSERVIZIO.AllowDBNull = false;
        this.columnDITTA.AllowDBNull = false;
        this.columnCOD_PROCEDURA.AllowDBNull = false;
        this.columnDESC_PROCEDURA.AllowDBNull = false;
      }

      public DsRptMpLocali.tblMainRow NewtblMainRow() => (DsRptMpLocali.tblMainRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.tblMainRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.tblMainRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblMainRowChanged == null)
          return;
        this.tblMainRowChanged((object) this, new DsRptMpLocali.tblMainRowChangeEvent((DsRptMpLocali.tblMainRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblMainRowChanging == null)
          return;
        this.tblMainRowChanging((object) this, new DsRptMpLocali.tblMainRowChangeEvent((DsRptMpLocali.tblMainRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblMainRowDeleted == null)
          return;
        this.tblMainRowDeleted((object) this, new DsRptMpLocali.tblMainRowChangeEvent((DsRptMpLocali.tblMainRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblMainRowDeleting == null)
          return;
        this.tblMainRowDeleting((object) this, new DsRptMpLocali.tblMainRowChangeEvent((DsRptMpLocali.tblMainRow) e.Row, e.Action));
      }

      public void RemovetblMainRow(DsRptMpLocali.tblMainRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class tblMainRow : DataRow
    {
      private DsRptMpLocali.tblMainDataTable tabletblMain;

      internal tblMainRow(DataRowBuilder rb)
        : base(rb)
        => this.tabletblMain = (DsRptMpLocali.tblMainDataTable) this.Table;

      public long WO_ID
      {
        get => (long) this[this.tabletblMain.WO_IDColumn];
        set => this[this.tabletblMain.WO_IDColumn] = (object) value;
      }

      public string DESC_BL_ESTESA
      {
        get => (string) this[this.tabletblMain.DESC_BL_ESTESAColumn];
        set => this[this.tabletblMain.DESC_BL_ESTESAColumn] = (object) value;
      }

      public string NOMECOGNOME
      {
        get => (string) this[this.tabletblMain.NOMECOGNOMEColumn];
        set => this[this.tabletblMain.NOMECOGNOMEColumn] = (object) value;
      }

      public string DATA_SCADENZA
      {
        get => (string) this[this.tabletblMain.DATA_SCADENZAColumn];
        set => this[this.tabletblMain.DATA_SCADENZAColumn] = (object) value;
      }

      public string SERVIZIO
      {
        get => (string) this[this.tabletblMain.SERVIZIOColumn];
        set => this[this.tabletblMain.SERVIZIOColumn] = (object) value;
      }

      public string DITTA
      {
        get => (string) this[this.tabletblMain.DITTAColumn];
        set => this[this.tabletblMain.DITTAColumn] = (object) value;
      }

      public string COD_PROCEDURA
      {
        get => (string) this[this.tabletblMain.COD_PROCEDURAColumn];
        set => this[this.tabletblMain.COD_PROCEDURAColumn] = (object) value;
      }

      public string COD_FREQ
      {
        get
        {
          try
          {
            return (string) this[this.tabletblMain.COD_FREQColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblMain.COD_FREQColumn] = (object) value;
      }

      public string DESC_PROCEDURA
      {
        get => (string) this[this.tabletblMain.DESC_PROCEDURAColumn];
        set => this[this.tabletblMain.DESC_PROCEDURAColumn] = (object) value;
      }

      public long ID_PMP
      {
        get
        {
          try
          {
            return (long) this[this.tabletblMain.ID_PMPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblMain.ID_PMPColumn] = (object) value;
      }

      public bool IsCOD_FREQNull() => this.IsNull(this.tabletblMain.COD_FREQColumn);

      public void SetCOD_FREQNull() => this[this.tabletblMain.COD_FREQColumn] = Convert.DBNull;

      public bool IsID_PMPNull() => this.IsNull(this.tabletblMain.ID_PMPColumn);

      public void SetID_PMPNull() => this[this.tabletblMain.ID_PMPColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class tblMainRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.tblMainRow eventRow;
      private DataRowAction eventAction;

      public tblMainRowChangeEvent(DsRptMpLocali.tblMainRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.tblMainRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class tblPassiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnWO_ID;
      private DataColumn columnID_PMP;
      private DataColumn columnPASSO;
      private DataColumn columnISTRUZIONE;

      internal tblPassiDataTable()
        : base("tblPassi")
        => this.InitClass();

      internal tblPassiDataTable(DataTable table)
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

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      internal DataColumn PASSOColumn => this.columnPASSO;

      internal DataColumn ISTRUZIONEColumn => this.columnISTRUZIONE;

      public DsRptMpLocali.tblPassiRow this[int index] => (DsRptMpLocali.tblPassiRow) this.Rows[index];

      public event DsRptMpLocali.tblPassiRowChangeEventHandler tblPassiRowChanged;

      public event DsRptMpLocali.tblPassiRowChangeEventHandler tblPassiRowChanging;

      public event DsRptMpLocali.tblPassiRowChangeEventHandler tblPassiRowDeleted;

      public event DsRptMpLocali.tblPassiRowChangeEventHandler tblPassiRowDeleting;

      public void AddtblPassiRow(DsRptMpLocali.tblPassiRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.tblPassiRow AddtblPassiRow(
        long WO_ID,
        long ID_PMP,
        long PASSO,
        string ISTRUZIONE)
      {
        DsRptMpLocali.tblPassiRow tblPassiRow = (DsRptMpLocali.tblPassiRow) this.NewRow();
        tblPassiRow.ItemArray = new object[4]
        {
          (object) WO_ID,
          (object) ID_PMP,
          (object) PASSO,
          (object) ISTRUZIONE
        };
        this.Rows.Add((DataRow) tblPassiRow);
        return tblPassiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.tblPassiDataTable tblPassiDataTable = (DsRptMpLocali.tblPassiDataTable) base.Clone();
        tblPassiDataTable.InitVars();
        return (DataTable) tblPassiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.tblPassiDataTable();

      internal void InitVars()
      {
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnID_PMP = this.Columns["ID_PMP"];
        this.columnPASSO = this.Columns["PASSO"];
        this.columnISTRUZIONE = this.Columns["ISTRUZIONE"];
      }

      private void InitClass()
      {
        this.columnWO_ID = new DataColumn("WO_ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnPASSO = new DataColumn("PASSO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPASSO);
        this.columnISTRUZIONE = new DataColumn("ISTRUZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnISTRUZIONE);
      }

      public DsRptMpLocali.tblPassiRow NewtblPassiRow() => (DsRptMpLocali.tblPassiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.tblPassiRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.tblPassiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblPassiRowChanged == null)
          return;
        this.tblPassiRowChanged((object) this, new DsRptMpLocali.tblPassiRowChangeEvent((DsRptMpLocali.tblPassiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblPassiRowChanging == null)
          return;
        this.tblPassiRowChanging((object) this, new DsRptMpLocali.tblPassiRowChangeEvent((DsRptMpLocali.tblPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblPassiRowDeleted == null)
          return;
        this.tblPassiRowDeleted((object) this, new DsRptMpLocali.tblPassiRowChangeEvent((DsRptMpLocali.tblPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblPassiRowDeleting == null)
          return;
        this.tblPassiRowDeleting((object) this, new DsRptMpLocali.tblPassiRowChangeEvent((DsRptMpLocali.tblPassiRow) e.Row, e.Action));
      }

      public void RemovetblPassiRow(DsRptMpLocali.tblPassiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class tblPassiRow : DataRow
    {
      private DsRptMpLocali.tblPassiDataTable tabletblPassi;

      internal tblPassiRow(DataRowBuilder rb)
        : base(rb)
        => this.tabletblPassi = (DsRptMpLocali.tblPassiDataTable) this.Table;

      public long WO_ID
      {
        get
        {
          try
          {
            return (long) this[this.tabletblPassi.WO_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblPassi.WO_IDColumn] = (object) value;
      }

      public long ID_PMP
      {
        get
        {
          try
          {
            return (long) this[this.tabletblPassi.ID_PMPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblPassi.ID_PMPColumn] = (object) value;
      }

      public long PASSO
      {
        get
        {
          try
          {
            return (long) this[this.tabletblPassi.PASSOColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblPassi.PASSOColumn] = (object) value;
      }

      public string ISTRUZIONE
      {
        get
        {
          try
          {
            return (string) this[this.tabletblPassi.ISTRUZIONEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblPassi.ISTRUZIONEColumn] = (object) value;
      }

      public bool IsWO_IDNull() => this.IsNull(this.tabletblPassi.WO_IDColumn);

      public void SetWO_IDNull() => this[this.tabletblPassi.WO_IDColumn] = Convert.DBNull;

      public bool IsID_PMPNull() => this.IsNull(this.tabletblPassi.ID_PMPColumn);

      public void SetID_PMPNull() => this[this.tabletblPassi.ID_PMPColumn] = Convert.DBNull;

      public bool IsPASSONull() => this.IsNull(this.tabletblPassi.PASSOColumn);

      public void SetPASSONull() => this[this.tabletblPassi.PASSOColumn] = Convert.DBNull;

      public bool IsISTRUZIONENull() => this.IsNull(this.tabletblPassi.ISTRUZIONEColumn);

      public void SetISTRUZIONENull() => this[this.tabletblPassi.ISTRUZIONEColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class tblPassiRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.tblPassiRow eventRow;
      private DataRowAction eventAction;

      public tblPassiRowChangeEvent(DsRptMpLocali.tblPassiRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.tblPassiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblDetRdlDataTable : DataTable, IEnumerable
    {
      private DataColumn columnWO_ID;
      private DataColumn columnID_PMP;
      private DataColumn columnDESC_EQSTD;
      private DataColumn columnWR_ID;
      private DataColumn columnFL_ID;
      private DataColumn columnEQ_ID;
      private DataColumn columnRM_ID;
      private DataColumn columnSTATUS;

      internal TblDetRdlDataTable()
        : base("TblDetRdl")
        => this.InitClass();

      internal TblDetRdlDataTable(DataTable table)
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

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      internal DataColumn DESC_EQSTDColumn => this.columnDESC_EQSTD;

      internal DataColumn WR_IDColumn => this.columnWR_ID;

      internal DataColumn FL_IDColumn => this.columnFL_ID;

      internal DataColumn EQ_IDColumn => this.columnEQ_ID;

      internal DataColumn RM_IDColumn => this.columnRM_ID;

      internal DataColumn STATUSColumn => this.columnSTATUS;

      public DsRptMpLocali.TblDetRdlRow this[int index] => (DsRptMpLocali.TblDetRdlRow) this.Rows[index];

      public event DsRptMpLocali.TblDetRdlRowChangeEventHandler TblDetRdlRowChanged;

      public event DsRptMpLocali.TblDetRdlRowChangeEventHandler TblDetRdlRowChanging;

      public event DsRptMpLocali.TblDetRdlRowChangeEventHandler TblDetRdlRowDeleted;

      public event DsRptMpLocali.TblDetRdlRowChangeEventHandler TblDetRdlRowDeleting;

      public void AddTblDetRdlRow(DsRptMpLocali.TblDetRdlRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.TblDetRdlRow AddTblDetRdlRow(
        long WO_ID,
        long ID_PMP,
        string DESC_EQSTD,
        string WR_ID,
        string FL_ID,
        string EQ_ID,
        string RM_ID,
        string STATUS)
      {
        DsRptMpLocali.TblDetRdlRow tblDetRdlRow = (DsRptMpLocali.TblDetRdlRow) this.NewRow();
        tblDetRdlRow.ItemArray = new object[8]
        {
          (object) WO_ID,
          (object) ID_PMP,
          (object) DESC_EQSTD,
          (object) WR_ID,
          (object) FL_ID,
          (object) EQ_ID,
          (object) RM_ID,
          (object) STATUS
        };
        this.Rows.Add((DataRow) tblDetRdlRow);
        return tblDetRdlRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.TblDetRdlDataTable tblDetRdlDataTable = (DsRptMpLocali.TblDetRdlDataTable) base.Clone();
        tblDetRdlDataTable.InitVars();
        return (DataTable) tblDetRdlDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.TblDetRdlDataTable();

      internal void InitVars()
      {
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnID_PMP = this.Columns["ID_PMP"];
        this.columnDESC_EQSTD = this.Columns["DESC_EQSTD"];
        this.columnWR_ID = this.Columns["WR_ID"];
        this.columnFL_ID = this.Columns["FL_ID"];
        this.columnEQ_ID = this.Columns["EQ_ID"];
        this.columnRM_ID = this.Columns["RM_ID"];
        this.columnSTATUS = this.Columns["STATUS"];
      }

      private void InitClass()
      {
        this.columnWO_ID = new DataColumn("WO_ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnDESC_EQSTD = new DataColumn("DESC_EQSTD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_EQSTD);
        this.columnWR_ID = new DataColumn("WR_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID);
        this.columnFL_ID = new DataColumn("FL_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFL_ID);
        this.columnEQ_ID = new DataColumn("EQ_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID);
        this.columnRM_ID = new DataColumn("RM_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRM_ID);
        this.columnSTATUS = new DataColumn("STATUS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATUS);
        this.columnID_PMP.AllowDBNull = false;
        this.columnDESC_EQSTD.AllowDBNull = false;
        this.columnWR_ID.AllowDBNull = false;
        this.columnFL_ID.AllowDBNull = false;
        this.columnEQ_ID.AllowDBNull = false;
        this.columnRM_ID.AllowDBNull = false;
        this.columnSTATUS.AllowDBNull = false;
      }

      public DsRptMpLocali.TblDetRdlRow NewTblDetRdlRow() => (DsRptMpLocali.TblDetRdlRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.TblDetRdlRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.TblDetRdlRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblDetRdlRowChanged == null)
          return;
        this.TblDetRdlRowChanged((object) this, new DsRptMpLocali.TblDetRdlRowChangeEvent((DsRptMpLocali.TblDetRdlRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblDetRdlRowChanging == null)
          return;
        this.TblDetRdlRowChanging((object) this, new DsRptMpLocali.TblDetRdlRowChangeEvent((DsRptMpLocali.TblDetRdlRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblDetRdlRowDeleted == null)
          return;
        this.TblDetRdlRowDeleted((object) this, new DsRptMpLocali.TblDetRdlRowChangeEvent((DsRptMpLocali.TblDetRdlRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblDetRdlRowDeleting == null)
          return;
        this.TblDetRdlRowDeleting((object) this, new DsRptMpLocali.TblDetRdlRowChangeEvent((DsRptMpLocali.TblDetRdlRow) e.Row, e.Action));
      }

      public void RemoveTblDetRdlRow(DsRptMpLocali.TblDetRdlRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblDetRdlRow : DataRow
    {
      private DsRptMpLocali.TblDetRdlDataTable tableTblDetRdl;

      internal TblDetRdlRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblDetRdl = (DsRptMpLocali.TblDetRdlDataTable) this.Table;

      public long WO_ID
      {
        get
        {
          try
          {
            return (long) this[this.tableTblDetRdl.WO_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdl.WO_IDColumn] = (object) value;
      }

      public long ID_PMP
      {
        get => (long) this[this.tableTblDetRdl.ID_PMPColumn];
        set => this[this.tableTblDetRdl.ID_PMPColumn] = (object) value;
      }

      public string DESC_EQSTD
      {
        get => (string) this[this.tableTblDetRdl.DESC_EQSTDColumn];
        set => this[this.tableTblDetRdl.DESC_EQSTDColumn] = (object) value;
      }

      public string WR_ID
      {
        get => (string) this[this.tableTblDetRdl.WR_IDColumn];
        set => this[this.tableTblDetRdl.WR_IDColumn] = (object) value;
      }

      public string FL_ID
      {
        get => (string) this[this.tableTblDetRdl.FL_IDColumn];
        set => this[this.tableTblDetRdl.FL_IDColumn] = (object) value;
      }

      public string EQ_ID
      {
        get => (string) this[this.tableTblDetRdl.EQ_IDColumn];
        set => this[this.tableTblDetRdl.EQ_IDColumn] = (object) value;
      }

      public string RM_ID
      {
        get => (string) this[this.tableTblDetRdl.RM_IDColumn];
        set => this[this.tableTblDetRdl.RM_IDColumn] = (object) value;
      }

      public string STATUS
      {
        get => (string) this[this.tableTblDetRdl.STATUSColumn];
        set => this[this.tableTblDetRdl.STATUSColumn] = (object) value;
      }

      public bool IsWO_IDNull() => this.IsNull(this.tableTblDetRdl.WO_IDColumn);

      public void SetWO_IDNull() => this[this.tableTblDetRdl.WO_IDColumn] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblDetRdlRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.TblDetRdlRow eventRow;
      private DataRowAction eventAction;

      public TblDetRdlRowChangeEvent(DsRptMpLocali.TblDetRdlRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.TblDetRdlRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblDetRdlEstesaDataTable : DataTable, IEnumerable
    {
      private DataColumn columnWO_ID;
      private DataColumn columnID_PMP;
      private DataColumn columnDESC_EQSTD;
      private DataColumn columnWR_ID0;
      private DataColumn columnFL_ID0;
      private DataColumn columnEQ_ID0;
      private DataColumn columnRM_ID0;
      private DataColumn columnSTATUS0;
      private DataColumn columnWR_ID1;
      private DataColumn columnFL_ID1;
      private DataColumn columnEQ_ID1;
      private DataColumn columnRM_ID1;
      private DataColumn columnSTATUS1;

      internal TblDetRdlEstesaDataTable()
        : base("TblDetRdlEstesa")
        => this.InitClass();

      internal TblDetRdlEstesaDataTable(DataTable table)
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

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      internal DataColumn DESC_EQSTDColumn => this.columnDESC_EQSTD;

      internal DataColumn WR_ID0Column => this.columnWR_ID0;

      internal DataColumn FL_ID0Column => this.columnFL_ID0;

      internal DataColumn EQ_ID0Column => this.columnEQ_ID0;

      internal DataColumn RM_ID0Column => this.columnRM_ID0;

      internal DataColumn STATUS0Column => this.columnSTATUS0;

      internal DataColumn WR_ID1Column => this.columnWR_ID1;

      internal DataColumn FL_ID1Column => this.columnFL_ID1;

      internal DataColumn EQ_ID1Column => this.columnEQ_ID1;

      internal DataColumn RM_ID1Column => this.columnRM_ID1;

      internal DataColumn STATUS1Column => this.columnSTATUS1;

      public DsRptMpLocali.TblDetRdlEstesaRow this[int index] => (DsRptMpLocali.TblDetRdlEstesaRow) this.Rows[index];

      public event DsRptMpLocali.TblDetRdlEstesaRowChangeEventHandler TblDetRdlEstesaRowChanged;

      public event DsRptMpLocali.TblDetRdlEstesaRowChangeEventHandler TblDetRdlEstesaRowChanging;

      public event DsRptMpLocali.TblDetRdlEstesaRowChangeEventHandler TblDetRdlEstesaRowDeleted;

      public event DsRptMpLocali.TblDetRdlEstesaRowChangeEventHandler TblDetRdlEstesaRowDeleting;

      public void AddTblDetRdlEstesaRow(DsRptMpLocali.TblDetRdlEstesaRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.TblDetRdlEstesaRow AddTblDetRdlEstesaRow(
        long WO_ID,
        long ID_PMP,
        string DESC_EQSTD,
        string WR_ID0,
        string FL_ID0,
        string EQ_ID0,
        string RM_ID0,
        string STATUS0,
        string WR_ID1,
        string FL_ID1,
        string EQ_ID1,
        string RM_ID1,
        string STATUS1)
      {
        DsRptMpLocali.TblDetRdlEstesaRow tblDetRdlEstesaRow = (DsRptMpLocali.TblDetRdlEstesaRow) this.NewRow();
        tblDetRdlEstesaRow.ItemArray = new object[13]
        {
          (object) WO_ID,
          (object) ID_PMP,
          (object) DESC_EQSTD,
          (object) WR_ID0,
          (object) FL_ID0,
          (object) EQ_ID0,
          (object) RM_ID0,
          (object) STATUS0,
          (object) WR_ID1,
          (object) FL_ID1,
          (object) EQ_ID1,
          (object) RM_ID1,
          (object) STATUS1
        };
        this.Rows.Add((DataRow) tblDetRdlEstesaRow);
        return tblDetRdlEstesaRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.TblDetRdlEstesaDataTable rdlEstesaDataTable = (DsRptMpLocali.TblDetRdlEstesaDataTable) base.Clone();
        rdlEstesaDataTable.InitVars();
        return (DataTable) rdlEstesaDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.TblDetRdlEstesaDataTable();

      internal void InitVars()
      {
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnID_PMP = this.Columns["ID_PMP"];
        this.columnDESC_EQSTD = this.Columns["DESC_EQSTD"];
        this.columnWR_ID0 = this.Columns["WR_ID0"];
        this.columnFL_ID0 = this.Columns["FL_ID0"];
        this.columnEQ_ID0 = this.Columns["EQ_ID0"];
        this.columnRM_ID0 = this.Columns["RM_ID0"];
        this.columnSTATUS0 = this.Columns["STATUS0"];
        this.columnWR_ID1 = this.Columns["WR_ID1"];
        this.columnFL_ID1 = this.Columns["FL_ID1"];
        this.columnEQ_ID1 = this.Columns["EQ_ID1"];
        this.columnRM_ID1 = this.Columns["RM_ID1"];
        this.columnSTATUS1 = this.Columns["STATUS1"];
      }

      private void InitClass()
      {
        this.columnWO_ID = new DataColumn("WO_ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnDESC_EQSTD = new DataColumn("DESC_EQSTD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_EQSTD);
        this.columnWR_ID0 = new DataColumn("WR_ID0", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID0);
        this.columnFL_ID0 = new DataColumn("FL_ID0", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFL_ID0);
        this.columnEQ_ID0 = new DataColumn("EQ_ID0", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID0);
        this.columnRM_ID0 = new DataColumn("RM_ID0", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRM_ID0);
        this.columnSTATUS0 = new DataColumn("STATUS0", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATUS0);
        this.columnWR_ID1 = new DataColumn("WR_ID1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID1);
        this.columnFL_ID1 = new DataColumn("FL_ID1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFL_ID1);
        this.columnEQ_ID1 = new DataColumn("EQ_ID1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID1);
        this.columnRM_ID1 = new DataColumn("RM_ID1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRM_ID1);
        this.columnSTATUS1 = new DataColumn("STATUS1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATUS1);
        this.columnID_PMP.AllowDBNull = false;
        this.columnDESC_EQSTD.AllowDBNull = false;
        this.columnWR_ID0.AllowDBNull = false;
        this.columnFL_ID0.AllowDBNull = false;
        this.columnEQ_ID0.AllowDBNull = false;
        this.columnRM_ID0.AllowDBNull = false;
      }

      public DsRptMpLocali.TblDetRdlEstesaRow NewTblDetRdlEstesaRow() => (DsRptMpLocali.TblDetRdlEstesaRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.TblDetRdlEstesaRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.TblDetRdlEstesaRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblDetRdlEstesaRowChanged == null)
          return;
        this.TblDetRdlEstesaRowChanged((object) this, new DsRptMpLocali.TblDetRdlEstesaRowChangeEvent((DsRptMpLocali.TblDetRdlEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblDetRdlEstesaRowChanging == null)
          return;
        this.TblDetRdlEstesaRowChanging((object) this, new DsRptMpLocali.TblDetRdlEstesaRowChangeEvent((DsRptMpLocali.TblDetRdlEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblDetRdlEstesaRowDeleted == null)
          return;
        this.TblDetRdlEstesaRowDeleted((object) this, new DsRptMpLocali.TblDetRdlEstesaRowChangeEvent((DsRptMpLocali.TblDetRdlEstesaRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblDetRdlEstesaRowDeleting == null)
          return;
        this.TblDetRdlEstesaRowDeleting((object) this, new DsRptMpLocali.TblDetRdlEstesaRowChangeEvent((DsRptMpLocali.TblDetRdlEstesaRow) e.Row, e.Action));
      }

      public void RemoveTblDetRdlEstesaRow(DsRptMpLocali.TblDetRdlEstesaRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblDetRdlEstesaRow : DataRow
    {
      private DsRptMpLocali.TblDetRdlEstesaDataTable tableTblDetRdlEstesa;

      internal TblDetRdlEstesaRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblDetRdlEstesa = (DsRptMpLocali.TblDetRdlEstesaDataTable) this.Table;

      public long WO_ID
      {
        get
        {
          try
          {
            return (long) this[this.tableTblDetRdlEstesa.WO_IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.WO_IDColumn] = (object) value;
      }

      public long ID_PMP
      {
        get => (long) this[this.tableTblDetRdlEstesa.ID_PMPColumn];
        set => this[this.tableTblDetRdlEstesa.ID_PMPColumn] = (object) value;
      }

      public string DESC_EQSTD
      {
        get => (string) this[this.tableTblDetRdlEstesa.DESC_EQSTDColumn];
        set => this[this.tableTblDetRdlEstesa.DESC_EQSTDColumn] = (object) value;
      }

      public string WR_ID0
      {
        get => (string) this[this.tableTblDetRdlEstesa.WR_ID0Column];
        set => this[this.tableTblDetRdlEstesa.WR_ID0Column] = (object) value;
      }

      public string FL_ID0
      {
        get => (string) this[this.tableTblDetRdlEstesa.FL_ID0Column];
        set => this[this.tableTblDetRdlEstesa.FL_ID0Column] = (object) value;
      }

      public string EQ_ID0
      {
        get => (string) this[this.tableTblDetRdlEstesa.EQ_ID0Column];
        set => this[this.tableTblDetRdlEstesa.EQ_ID0Column] = (object) value;
      }

      public string RM_ID0
      {
        get => (string) this[this.tableTblDetRdlEstesa.RM_ID0Column];
        set => this[this.tableTblDetRdlEstesa.RM_ID0Column] = (object) value;
      }

      public string STATUS0
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDetRdlEstesa.STATUS0Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.STATUS0Column] = (object) value;
      }

      public string WR_ID1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDetRdlEstesa.WR_ID1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.WR_ID1Column] = (object) value;
      }

      public string FL_ID1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDetRdlEstesa.FL_ID1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.FL_ID1Column] = (object) value;
      }

      public string EQ_ID1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDetRdlEstesa.EQ_ID1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.EQ_ID1Column] = (object) value;
      }

      public string RM_ID1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDetRdlEstesa.RM_ID1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.RM_ID1Column] = (object) value;
      }

      public string STATUS1
      {
        get
        {
          try
          {
            return (string) this[this.tableTblDetRdlEstesa.STATUS1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("Cannot get value because it is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTblDetRdlEstesa.STATUS1Column] = (object) value;
      }

      public bool IsWO_IDNull() => this.IsNull(this.tableTblDetRdlEstesa.WO_IDColumn);

      public void SetWO_IDNull() => this[this.tableTblDetRdlEstesa.WO_IDColumn] = Convert.DBNull;

      public bool IsSTATUS0Null() => this.IsNull(this.tableTblDetRdlEstesa.STATUS0Column);

      public void SetSTATUS0Null() => this[this.tableTblDetRdlEstesa.STATUS0Column] = Convert.DBNull;

      public bool IsWR_ID1Null() => this.IsNull(this.tableTblDetRdlEstesa.WR_ID1Column);

      public void SetWR_ID1Null() => this[this.tableTblDetRdlEstesa.WR_ID1Column] = Convert.DBNull;

      public bool IsFL_ID1Null() => this.IsNull(this.tableTblDetRdlEstesa.FL_ID1Column);

      public void SetFL_ID1Null() => this[this.tableTblDetRdlEstesa.FL_ID1Column] = Convert.DBNull;

      public bool IsEQ_ID1Null() => this.IsNull(this.tableTblDetRdlEstesa.EQ_ID1Column);

      public void SetEQ_ID1Null() => this[this.tableTblDetRdlEstesa.EQ_ID1Column] = Convert.DBNull;

      public bool IsRM_ID1Null() => this.IsNull(this.tableTblDetRdlEstesa.RM_ID1Column);

      public void SetRM_ID1Null() => this[this.tableTblDetRdlEstesa.RM_ID1Column] = Convert.DBNull;

      public bool IsSTATUS1Null() => this.IsNull(this.tableTblDetRdlEstesa.STATUS1Column);

      public void SetSTATUS1Null() => this[this.tableTblDetRdlEstesa.STATUS1Column] = Convert.DBNull;
    }

    [DebuggerStepThrough]
    public class TblDetRdlEstesaRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.TblDetRdlEstesaRow eventRow;
      private DataRowAction eventAction;

      public TblDetRdlEstesaRowChangeEvent(
        DsRptMpLocali.TblDetRdlEstesaRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.TblDetRdlEstesaRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class tblAllRptDataTable : DataTable, IEnumerable
    {
      private DataColumn columnWO_ID;
      private DataColumn columnWR_ID;
      private DataColumn columnDESC_BL_ESTESA;
      private DataColumn columnNOMECOGNOME;
      private DataColumn columnDATA_SCADENZA;
      private DataColumn columnSERVIZIO;
      private DataColumn columnDITTA;
      private DataColumn columnCOD_PROCEDURA;
      private DataColumn columnCOD_FREQ;
      private DataColumn columnDESC_PROCEDURA;
      private DataColumn columnID_PMP;
      private DataColumn columnISTRUZIONE;
      private DataColumn columnPASSO;
      private DataColumn columnDESC_EQSTD;
      private DataColumn columnFL_ID;
      private DataColumn columnEQ_ID;
      private DataColumn columnRM_ID;
      private DataColumn columnSTATUS;

      internal tblAllRptDataTable()
        : base("tblAllRpt")
        => this.InitClass();

      internal tblAllRptDataTable(DataTable table)
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

      internal DataColumn WO_IDColumn => this.columnWO_ID;

      internal DataColumn WR_IDColumn => this.columnWR_ID;

      internal DataColumn DESC_BL_ESTESAColumn => this.columnDESC_BL_ESTESA;

      internal DataColumn NOMECOGNOMEColumn => this.columnNOMECOGNOME;

      internal DataColumn DATA_SCADENZAColumn => this.columnDATA_SCADENZA;

      internal DataColumn SERVIZIOColumn => this.columnSERVIZIO;

      internal DataColumn DITTAColumn => this.columnDITTA;

      internal DataColumn COD_PROCEDURAColumn => this.columnCOD_PROCEDURA;

      internal DataColumn COD_FREQColumn => this.columnCOD_FREQ;

      internal DataColumn DESC_PROCEDURAColumn => this.columnDESC_PROCEDURA;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      internal DataColumn ISTRUZIONEColumn => this.columnISTRUZIONE;

      internal DataColumn PASSOColumn => this.columnPASSO;

      internal DataColumn DESC_EQSTDColumn => this.columnDESC_EQSTD;

      internal DataColumn FL_IDColumn => this.columnFL_ID;

      internal DataColumn EQ_IDColumn => this.columnEQ_ID;

      internal DataColumn RM_IDColumn => this.columnRM_ID;

      internal DataColumn STATUSColumn => this.columnSTATUS;

      public DsRptMpLocali.tblAllRptRow this[int index] => (DsRptMpLocali.tblAllRptRow) this.Rows[index];

      public event DsRptMpLocali.tblAllRptRowChangeEventHandler tblAllRptRowChanged;

      public event DsRptMpLocali.tblAllRptRowChangeEventHandler tblAllRptRowChanging;

      public event DsRptMpLocali.tblAllRptRowChangeEventHandler tblAllRptRowDeleted;

      public event DsRptMpLocali.tblAllRptRowChangeEventHandler tblAllRptRowDeleting;

      public void AddtblAllRptRow(DsRptMpLocali.tblAllRptRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.tblAllRptRow AddtblAllRptRow(
        long WO_ID,
        long WR_ID,
        string DESC_BL_ESTESA,
        string NOMECOGNOME,
        string DATA_SCADENZA,
        string SERVIZIO,
        string DITTA,
        string COD_PROCEDURA,
        string COD_FREQ,
        string DESC_PROCEDURA,
        long ID_PMP,
        string ISTRUZIONE,
        long PASSO,
        string DESC_EQSTD,
        string FL_ID,
        string EQ_ID,
        string RM_ID,
        string STATUS)
      {
        DsRptMpLocali.tblAllRptRow tblAllRptRow = (DsRptMpLocali.tblAllRptRow) this.NewRow();
        tblAllRptRow.ItemArray = new object[18]
        {
          (object) WO_ID,
          (object) WR_ID,
          (object) DESC_BL_ESTESA,
          (object) NOMECOGNOME,
          (object) DATA_SCADENZA,
          (object) SERVIZIO,
          (object) DITTA,
          (object) COD_PROCEDURA,
          (object) COD_FREQ,
          (object) DESC_PROCEDURA,
          (object) ID_PMP,
          (object) ISTRUZIONE,
          (object) PASSO,
          (object) DESC_EQSTD,
          (object) FL_ID,
          (object) EQ_ID,
          (object) RM_ID,
          (object) STATUS
        };
        this.Rows.Add((DataRow) tblAllRptRow);
        return tblAllRptRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.tblAllRptDataTable tblAllRptDataTable = (DsRptMpLocali.tblAllRptDataTable) base.Clone();
        tblAllRptDataTable.InitVars();
        return (DataTable) tblAllRptDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.tblAllRptDataTable();

      internal void InitVars()
      {
        this.columnWO_ID = this.Columns["WO_ID"];
        this.columnWR_ID = this.Columns["WR_ID"];
        this.columnDESC_BL_ESTESA = this.Columns["DESC_BL_ESTESA"];
        this.columnNOMECOGNOME = this.Columns["NOMECOGNOME"];
        this.columnDATA_SCADENZA = this.Columns["DATA_SCADENZA"];
        this.columnSERVIZIO = this.Columns["SERVIZIO"];
        this.columnDITTA = this.Columns["DITTA"];
        this.columnCOD_PROCEDURA = this.Columns["COD_PROCEDURA"];
        this.columnCOD_FREQ = this.Columns["COD_FREQ"];
        this.columnDESC_PROCEDURA = this.Columns["DESC_PROCEDURA"];
        this.columnID_PMP = this.Columns["ID_PMP"];
        this.columnISTRUZIONE = this.Columns["ISTRUZIONE"];
        this.columnPASSO = this.Columns["PASSO"];
        this.columnDESC_EQSTD = this.Columns["DESC_EQSTD"];
        this.columnFL_ID = this.Columns["FL_ID"];
        this.columnEQ_ID = this.Columns["EQ_ID"];
        this.columnRM_ID = this.Columns["RM_ID"];
        this.columnSTATUS = this.Columns["STATUS"];
      }

      private void InitClass()
      {
        this.columnWO_ID = new DataColumn("WO_ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWO_ID);
        this.columnWR_ID = new DataColumn("WR_ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWR_ID);
        this.columnDESC_BL_ESTESA = new DataColumn("DESC_BL_ESTESA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_BL_ESTESA);
        this.columnNOMECOGNOME = new DataColumn("NOMECOGNOME", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNOMECOGNOME);
        this.columnDATA_SCADENZA = new DataColumn("DATA_SCADENZA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDATA_SCADENZA);
        this.columnSERVIZIO = new DataColumn("SERVIZIO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSERVIZIO);
        this.columnDITTA = new DataColumn("DITTA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDITTA);
        this.columnCOD_PROCEDURA = new DataColumn("COD_PROCEDURA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOD_PROCEDURA);
        this.columnCOD_FREQ = new DataColumn("COD_FREQ", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCOD_FREQ);
        this.columnDESC_PROCEDURA = new DataColumn("DESC_PROCEDURA", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_PROCEDURA);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnISTRUZIONE = new DataColumn("ISTRUZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnISTRUZIONE);
        this.columnPASSO = new DataColumn("PASSO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPASSO);
        this.columnDESC_EQSTD = new DataColumn("DESC_EQSTD", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESC_EQSTD);
        this.columnFL_ID = new DataColumn("FL_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFL_ID);
        this.columnEQ_ID = new DataColumn("EQ_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEQ_ID);
        this.columnRM_ID = new DataColumn("RM_ID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRM_ID);
        this.columnSTATUS = new DataColumn("STATUS", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSTATUS);
        this.columnWO_ID.AllowDBNull = false;
        this.columnWR_ID.AllowDBNull = false;
        this.columnDESC_BL_ESTESA.AllowDBNull = false;
        this.columnNOMECOGNOME.AllowDBNull = false;
        this.columnDATA_SCADENZA.AllowDBNull = false;
        this.columnSERVIZIO.AllowDBNull = false;
        this.columnDITTA.AllowDBNull = false;
        this.columnCOD_PROCEDURA.AllowDBNull = false;
        this.columnCOD_FREQ.AllowDBNull = false;
        this.columnDESC_PROCEDURA.AllowDBNull = false;
        this.columnID_PMP.AllowDBNull = false;
        this.columnISTRUZIONE.AllowDBNull = false;
        this.columnPASSO.AllowDBNull = false;
        this.columnDESC_EQSTD.AllowDBNull = false;
        this.columnFL_ID.AllowDBNull = false;
        this.columnEQ_ID.AllowDBNull = false;
        this.columnRM_ID.AllowDBNull = false;
        this.columnSTATUS.AllowDBNull = false;
      }

      public DsRptMpLocali.tblAllRptRow NewtblAllRptRow() => (DsRptMpLocali.tblAllRptRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.tblAllRptRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.tblAllRptRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblAllRptRowChanged == null)
          return;
        this.tblAllRptRowChanged((object) this, new DsRptMpLocali.tblAllRptRowChangeEvent((DsRptMpLocali.tblAllRptRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblAllRptRowChanging == null)
          return;
        this.tblAllRptRowChanging((object) this, new DsRptMpLocali.tblAllRptRowChangeEvent((DsRptMpLocali.tblAllRptRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblAllRptRowDeleted == null)
          return;
        this.tblAllRptRowDeleted((object) this, new DsRptMpLocali.tblAllRptRowChangeEvent((DsRptMpLocali.tblAllRptRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblAllRptRowDeleting == null)
          return;
        this.tblAllRptRowDeleting((object) this, new DsRptMpLocali.tblAllRptRowChangeEvent((DsRptMpLocali.tblAllRptRow) e.Row, e.Action));
      }

      public void RemovetblAllRptRow(DsRptMpLocali.tblAllRptRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class tblAllRptRow : DataRow
    {
      private DsRptMpLocali.tblAllRptDataTable tabletblAllRpt;

      internal tblAllRptRow(DataRowBuilder rb)
        : base(rb)
        => this.tabletblAllRpt = (DsRptMpLocali.tblAllRptDataTable) this.Table;

      public long WO_ID
      {
        get => (long) this[this.tabletblAllRpt.WO_IDColumn];
        set => this[this.tabletblAllRpt.WO_IDColumn] = (object) value;
      }

      public long WR_ID
      {
        get => (long) this[this.tabletblAllRpt.WR_IDColumn];
        set => this[this.tabletblAllRpt.WR_IDColumn] = (object) value;
      }

      public string DESC_BL_ESTESA
      {
        get => (string) this[this.tabletblAllRpt.DESC_BL_ESTESAColumn];
        set => this[this.tabletblAllRpt.DESC_BL_ESTESAColumn] = (object) value;
      }

      public string NOMECOGNOME
      {
        get => (string) this[this.tabletblAllRpt.NOMECOGNOMEColumn];
        set => this[this.tabletblAllRpt.NOMECOGNOMEColumn] = (object) value;
      }

      public string DATA_SCADENZA
      {
        get => (string) this[this.tabletblAllRpt.DATA_SCADENZAColumn];
        set => this[this.tabletblAllRpt.DATA_SCADENZAColumn] = (object) value;
      }

      public string SERVIZIO
      {
        get => (string) this[this.tabletblAllRpt.SERVIZIOColumn];
        set => this[this.tabletblAllRpt.SERVIZIOColumn] = (object) value;
      }

      public string DITTA
      {
        get => (string) this[this.tabletblAllRpt.DITTAColumn];
        set => this[this.tabletblAllRpt.DITTAColumn] = (object) value;
      }

      public string COD_PROCEDURA
      {
        get => (string) this[this.tabletblAllRpt.COD_PROCEDURAColumn];
        set => this[this.tabletblAllRpt.COD_PROCEDURAColumn] = (object) value;
      }

      public string COD_FREQ
      {
        get => (string) this[this.tabletblAllRpt.COD_FREQColumn];
        set => this[this.tabletblAllRpt.COD_FREQColumn] = (object) value;
      }

      public string DESC_PROCEDURA
      {
        get => (string) this[this.tabletblAllRpt.DESC_PROCEDURAColumn];
        set => this[this.tabletblAllRpt.DESC_PROCEDURAColumn] = (object) value;
      }

      public long ID_PMP
      {
        get => (long) this[this.tabletblAllRpt.ID_PMPColumn];
        set => this[this.tabletblAllRpt.ID_PMPColumn] = (object) value;
      }

      public string ISTRUZIONE
      {
        get => (string) this[this.tabletblAllRpt.ISTRUZIONEColumn];
        set => this[this.tabletblAllRpt.ISTRUZIONEColumn] = (object) value;
      }

      public long PASSO
      {
        get => (long) this[this.tabletblAllRpt.PASSOColumn];
        set => this[this.tabletblAllRpt.PASSOColumn] = (object) value;
      }

      public string DESC_EQSTD
      {
        get => (string) this[this.tabletblAllRpt.DESC_EQSTDColumn];
        set => this[this.tabletblAllRpt.DESC_EQSTDColumn] = (object) value;
      }

      public string FL_ID
      {
        get => (string) this[this.tabletblAllRpt.FL_IDColumn];
        set => this[this.tabletblAllRpt.FL_IDColumn] = (object) value;
      }

      public string EQ_ID
      {
        get => (string) this[this.tabletblAllRpt.EQ_IDColumn];
        set => this[this.tabletblAllRpt.EQ_IDColumn] = (object) value;
      }

      public string RM_ID
      {
        get => (string) this[this.tabletblAllRpt.RM_IDColumn];
        set => this[this.tabletblAllRpt.RM_IDColumn] = (object) value;
      }

      public string STATUS
      {
        get => (string) this[this.tabletblAllRpt.STATUSColumn];
        set => this[this.tabletblAllRpt.STATUSColumn] = (object) value;
      }
    }

    [DebuggerStepThrough]
    public class tblAllRptRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.tblAllRptRow eventRow;
      private DataRowAction eventAction;

      public tblAllRptRowChangeEvent(DsRptMpLocali.tblAllRptRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.tblAllRptRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblLeggendaPassiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnCODICE;
      private DataColumn columnDESCRIZIONE;

      internal TblLeggendaPassiDataTable()
        : base("TblLeggendaPassi")
        => this.InitClass();

      internal TblLeggendaPassiDataTable(DataTable table)
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

      internal DataColumn CODICEColumn => this.columnCODICE;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      public DsRptMpLocali.TblLeggendaPassiRow this[int index] => (DsRptMpLocali.TblLeggendaPassiRow) this.Rows[index];

      public event DsRptMpLocali.TblLeggendaPassiRowChangeEventHandler TblLeggendaPassiRowChanged;

      public event DsRptMpLocali.TblLeggendaPassiRowChangeEventHandler TblLeggendaPassiRowChanging;

      public event DsRptMpLocali.TblLeggendaPassiRowChangeEventHandler TblLeggendaPassiRowDeleted;

      public event DsRptMpLocali.TblLeggendaPassiRowChangeEventHandler TblLeggendaPassiRowDeleting;

      public void AddTblLeggendaPassiRow(DsRptMpLocali.TblLeggendaPassiRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.TblLeggendaPassiRow AddTblLeggendaPassiRow(
        string CODICE,
        string DESCRIZIONE)
      {
        DsRptMpLocali.TblLeggendaPassiRow leggendaPassiRow = (DsRptMpLocali.TblLeggendaPassiRow) this.NewRow();
        leggendaPassiRow.ItemArray = new object[2]
        {
          (object) CODICE,
          (object) DESCRIZIONE
        };
        this.Rows.Add((DataRow) leggendaPassiRow);
        return leggendaPassiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.TblLeggendaPassiDataTable leggendaPassiDataTable = (DsRptMpLocali.TblLeggendaPassiDataTable) base.Clone();
        leggendaPassiDataTable.InitVars();
        return (DataTable) leggendaPassiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.TblLeggendaPassiDataTable();

      internal void InitVars()
      {
        this.columnCODICE = this.Columns["CODICE"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
      }

      private void InitClass()
      {
        this.columnCODICE = new DataColumn("CODICE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCODICE);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnCODICE.AllowDBNull = false;
        this.columnDESCRIZIONE.AllowDBNull = false;
      }

      public DsRptMpLocali.TblLeggendaPassiRow NewTblLeggendaPassiRow() => (DsRptMpLocali.TblLeggendaPassiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.TblLeggendaPassiRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.TblLeggendaPassiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblLeggendaPassiRowChanged == null)
          return;
        this.TblLeggendaPassiRowChanged((object) this, new DsRptMpLocali.TblLeggendaPassiRowChangeEvent((DsRptMpLocali.TblLeggendaPassiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblLeggendaPassiRowChanging == null)
          return;
        this.TblLeggendaPassiRowChanging((object) this, new DsRptMpLocali.TblLeggendaPassiRowChangeEvent((DsRptMpLocali.TblLeggendaPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblLeggendaPassiRowDeleted == null)
          return;
        this.TblLeggendaPassiRowDeleted((object) this, new DsRptMpLocali.TblLeggendaPassiRowChangeEvent((DsRptMpLocali.TblLeggendaPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblLeggendaPassiRowDeleting == null)
          return;
        this.TblLeggendaPassiRowDeleting((object) this, new DsRptMpLocali.TblLeggendaPassiRowChangeEvent((DsRptMpLocali.TblLeggendaPassiRow) e.Row, e.Action));
      }

      public void RemoveTblLeggendaPassiRow(DsRptMpLocali.TblLeggendaPassiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblLeggendaPassiRow : DataRow
    {
      private DsRptMpLocali.TblLeggendaPassiDataTable tableTblLeggendaPassi;

      internal TblLeggendaPassiRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblLeggendaPassi = (DsRptMpLocali.TblLeggendaPassiDataTable) this.Table;

      public string CODICE
      {
        get => (string) this[this.tableTblLeggendaPassi.CODICEColumn];
        set => this[this.tableTblLeggendaPassi.CODICEColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get => (string) this[this.tableTblLeggendaPassi.DESCRIZIONEColumn];
        set => this[this.tableTblLeggendaPassi.DESCRIZIONEColumn] = (object) value;
      }
    }

    [DebuggerStepThrough]
    public class TblLeggendaPassiRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.TblLeggendaPassiRow eventRow;
      private DataRowAction eventAction;

      public TblLeggendaPassiRowChangeEvent(
        DsRptMpLocali.TblLeggendaPassiRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.TblLeggendaPassiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class tblLeggendaStatusDataTable : DataTable, IEnumerable
    {
      private DataColumn columnCODICE;
      private DataColumn columnDESCRIZIONE;

      internal tblLeggendaStatusDataTable()
        : base("tblLeggendaStatus")
        => this.InitClass();

      internal tblLeggendaStatusDataTable(DataTable table)
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

      internal DataColumn CODICEColumn => this.columnCODICE;

      internal DataColumn DESCRIZIONEColumn => this.columnDESCRIZIONE;

      public DsRptMpLocali.tblLeggendaStatusRow this[int index] => (DsRptMpLocali.tblLeggendaStatusRow) this.Rows[index];

      public event DsRptMpLocali.tblLeggendaStatusRowChangeEventHandler tblLeggendaStatusRowChanged;

      public event DsRptMpLocali.tblLeggendaStatusRowChangeEventHandler tblLeggendaStatusRowChanging;

      public event DsRptMpLocali.tblLeggendaStatusRowChangeEventHandler tblLeggendaStatusRowDeleted;

      public event DsRptMpLocali.tblLeggendaStatusRowChangeEventHandler tblLeggendaStatusRowDeleting;

      public void AddtblLeggendaStatusRow(DsRptMpLocali.tblLeggendaStatusRow row) => this.Rows.Add((DataRow) row);

      public DsRptMpLocali.tblLeggendaStatusRow AddtblLeggendaStatusRow(
        string CODICE,
        string DESCRIZIONE)
      {
        DsRptMpLocali.tblLeggendaStatusRow leggendaStatusRow = (DsRptMpLocali.tblLeggendaStatusRow) this.NewRow();
        leggendaStatusRow.ItemArray = new object[2]
        {
          (object) CODICE,
          (object) DESCRIZIONE
        };
        this.Rows.Add((DataRow) leggendaStatusRow);
        return leggendaStatusRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsRptMpLocali.tblLeggendaStatusDataTable leggendaStatusDataTable = (DsRptMpLocali.tblLeggendaStatusDataTable) base.Clone();
        leggendaStatusDataTable.InitVars();
        return (DataTable) leggendaStatusDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsRptMpLocali.tblLeggendaStatusDataTable();

      internal void InitVars()
      {
        this.columnCODICE = this.Columns["CODICE"];
        this.columnDESCRIZIONE = this.Columns["DESCRIZIONE"];
      }

      private void InitClass()
      {
        this.columnCODICE = new DataColumn("CODICE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCODICE);
        this.columnDESCRIZIONE = new DataColumn("DESCRIZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDESCRIZIONE);
        this.columnCODICE.AllowDBNull = false;
        this.columnDESCRIZIONE.AllowDBNull = false;
      }

      public DsRptMpLocali.tblLeggendaStatusRow NewtblLeggendaStatusRow() => (DsRptMpLocali.tblLeggendaStatusRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsRptMpLocali.tblLeggendaStatusRow(builder);

      protected override Type GetRowType() => typeof (DsRptMpLocali.tblLeggendaStatusRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblLeggendaStatusRowChanged == null)
          return;
        this.tblLeggendaStatusRowChanged((object) this, new DsRptMpLocali.tblLeggendaStatusRowChangeEvent((DsRptMpLocali.tblLeggendaStatusRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblLeggendaStatusRowChanging == null)
          return;
        this.tblLeggendaStatusRowChanging((object) this, new DsRptMpLocali.tblLeggendaStatusRowChangeEvent((DsRptMpLocali.tblLeggendaStatusRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblLeggendaStatusRowDeleted == null)
          return;
        this.tblLeggendaStatusRowDeleted((object) this, new DsRptMpLocali.tblLeggendaStatusRowChangeEvent((DsRptMpLocali.tblLeggendaStatusRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblLeggendaStatusRowDeleting == null)
          return;
        this.tblLeggendaStatusRowDeleting((object) this, new DsRptMpLocali.tblLeggendaStatusRowChangeEvent((DsRptMpLocali.tblLeggendaStatusRow) e.Row, e.Action));
      }

      public void RemovetblLeggendaStatusRow(DsRptMpLocali.tblLeggendaStatusRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class tblLeggendaStatusRow : DataRow
    {
      private DsRptMpLocali.tblLeggendaStatusDataTable tabletblLeggendaStatus;

      internal tblLeggendaStatusRow(DataRowBuilder rb)
        : base(rb)
        => this.tabletblLeggendaStatus = (DsRptMpLocali.tblLeggendaStatusDataTable) this.Table;

      public string CODICE
      {
        get => (string) this[this.tabletblLeggendaStatus.CODICEColumn];
        set => this[this.tabletblLeggendaStatus.CODICEColumn] = (object) value;
      }

      public string DESCRIZIONE
      {
        get => (string) this[this.tabletblLeggendaStatus.DESCRIZIONEColumn];
        set => this[this.tabletblLeggendaStatus.DESCRIZIONEColumn] = (object) value;
      }
    }

    [DebuggerStepThrough]
    public class tblLeggendaStatusRowChangeEvent : EventArgs
    {
      private DsRptMpLocali.tblLeggendaStatusRow eventRow;
      private DataRowAction eventAction;

      public tblLeggendaStatusRowChangeEvent(
        DsRptMpLocali.tblLeggendaStatusRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsRptMpLocali.tblLeggendaStatusRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }
  }
}
