// Decompiled with JetBrains decompiler
// Type: TheSite.SchemiXSD.DsPianoMp
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
  [DebuggerStepThrough]
  [ToolboxItem(true)]
  [DesignerCategory("code")]
  [Serializable]
  public class DsPianoMp : DataSet
  {
    private DsPianoMp.TblMainDataTable tableTblMain;
    private DsPianoMp.TblPassiDataTable tableTblPassi;

    public DsPianoMp()
    {
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }

    protected DsPianoMp(SerializationInfo info, StreamingContext context)
    {
      string s = (string) info.GetValue("XmlSchema", typeof (string));
      if (s != null)
      {
        DataSet dataSet = new DataSet();
        dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        if (dataSet.Tables[nameof (TblMain)] != null)
          this.Tables.Add((DataTable) new DsPianoMp.TblMainDataTable(dataSet.Tables[nameof (TblMain)]));
        if (dataSet.Tables[nameof (TblPassi)] != null)
          this.Tables.Add((DataTable) new DsPianoMp.TblPassiDataTable(dataSet.Tables[nameof (TblPassi)]));
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
    public DsPianoMp.TblMainDataTable TblMain => this.tableTblMain;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Browsable(false)]
    public DsPianoMp.TblPassiDataTable TblPassi => this.tableTblPassi;

    public override DataSet Clone()
    {
      DsPianoMp dsPianoMp = (DsPianoMp) base.Clone();
      dsPianoMp.InitVars();
      return (DataSet) dsPianoMp;
    }

    protected override bool ShouldSerializeTables() => false;

    protected override bool ShouldSerializeRelations() => false;

    protected override void ReadXmlSerializable(XmlReader reader)
    {
      this.Reset();
      DataSet dataSet = new DataSet();
      int num = (int) dataSet.ReadXml(reader);
      if (dataSet.Tables["TblMain"] != null)
        this.Tables.Add((DataTable) new DsPianoMp.TblMainDataTable(dataSet.Tables["TblMain"]));
      if (dataSet.Tables["TblPassi"] != null)
        this.Tables.Add((DataTable) new DsPianoMp.TblPassiDataTable(dataSet.Tables["TblPassi"]));
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
      this.tableTblMain = (DsPianoMp.TblMainDataTable) this.Tables["TblMain"];
      if (this.tableTblMain != null)
        this.tableTblMain.InitVars();
      this.tableTblPassi = (DsPianoMp.TblPassiDataTable) this.Tables["TblPassi"];
      if (this.tableTblPassi == null)
        return;
      this.tableTblPassi.InitVars();
    }

    private void InitClass()
    {
      this.DataSetName = nameof (DsPianoMp);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/DsPianoMp.xsd";
      this.Locale = new CultureInfo("it-IT");
      this.CaseSensitive = false;
      this.EnforceConstraints = true;
      this.tableTblMain = new DsPianoMp.TblMainDataTable();
      this.Tables.Add((DataTable) this.tableTblMain);
      this.tableTblPassi = new DsPianoMp.TblPassiDataTable();
      this.Tables.Add((DataTable) this.tableTblPassi);
    }

    private bool ShouldSerializeTblMain() => false;

    private bool ShouldSerializeTblPassi() => false;

    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    public delegate void TblMainRowChangeEventHandler(
      object sender,
      DsPianoMp.TblMainRowChangeEvent e);

    public delegate void TblPassiRowChangeEventHandler(
      object sender,
      DsPianoMp.TblPassiRowChangeEvent e);

    [DebuggerStepThrough]
    public class TblMainDataTable : DataTable, IEnumerable
    {
      private DataColumn columnNOME_EDIFICIO;
      private DataColumn columnINDIRIZZO;
      private DataColumn columnCODICE_EDIFICIO;
      private DataColumn columnID_EDIFICIO;
      private DataColumn columnMESE;
      private DataColumn columnANNO;
      private DataColumn columnMESE_ESTESO;
      private DataColumn columnSERVIZIO;
      private DataColumn columnID_SERVIZIO;
      private DataColumn columnID_PMP;
      private DataColumn columnPROCEDURA_MANUTENZIONE;
      private DataColumn columnID_CLASSE_ELEMENTO;
      private DataColumn columnCODICE_ELEMENTO;
      private DataColumn columnCLASSE_ELEMENTO;
      private DataColumn columnPIANO;
      private DataColumn columnORDINE_PIANO;

      internal TblMainDataTable()
        : base("TblMain")
        => this.InitClass();

      internal TblMainDataTable(DataTable table)
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

      internal DataColumn NOME_EDIFICIOColumn => this.columnNOME_EDIFICIO;

      internal DataColumn INDIRIZZOColumn => this.columnINDIRIZZO;

      internal DataColumn CODICE_EDIFICIOColumn => this.columnCODICE_EDIFICIO;

      internal DataColumn ID_EDIFICIOColumn => this.columnID_EDIFICIO;

      internal DataColumn MESEColumn => this.columnMESE;

      internal DataColumn ANNOColumn => this.columnANNO;

      internal DataColumn MESE_ESTESOColumn => this.columnMESE_ESTESO;

      internal DataColumn SERVIZIOColumn => this.columnSERVIZIO;

      internal DataColumn ID_SERVIZIOColumn => this.columnID_SERVIZIO;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      internal DataColumn PROCEDURA_MANUTENZIONEColumn => this.columnPROCEDURA_MANUTENZIONE;

      internal DataColumn ID_CLASSE_ELEMENTOColumn => this.columnID_CLASSE_ELEMENTO;

      internal DataColumn CODICE_ELEMENTOColumn => this.columnCODICE_ELEMENTO;

      internal DataColumn CLASSE_ELEMENTOColumn => this.columnCLASSE_ELEMENTO;

      internal DataColumn PIANOColumn => this.columnPIANO;

      internal DataColumn ORDINE_PIANOColumn => this.columnORDINE_PIANO;

      public DsPianoMp.TblMainRow this[int index] => (DsPianoMp.TblMainRow) this.Rows[index];

      public event DsPianoMp.TblMainRowChangeEventHandler TblMainRowChanged;

      public event DsPianoMp.TblMainRowChangeEventHandler TblMainRowChanging;

      public event DsPianoMp.TblMainRowChangeEventHandler TblMainRowDeleted;

      public event DsPianoMp.TblMainRowChangeEventHandler TblMainRowDeleting;

      public void AddTblMainRow(DsPianoMp.TblMainRow row) => this.Rows.Add((DataRow) row);

      public DsPianoMp.TblMainRow AddTblMainRow(
        string NOME_EDIFICIO,
        string INDIRIZZO,
        string CODICE_EDIFICIO,
        long ID_EDIFICIO,
        string MESE,
        string ANNO,
        string MESE_ESTESO,
        string SERVIZIO,
        long ID_SERVIZIO,
        long ID_PMP,
        string PROCEDURA_MANUTENZIONE,
        long ID_CLASSE_ELEMENTO,
        string CODICE_ELEMENTO,
        string CLASSE_ELEMENTO,
        string PIANO,
        long ORDINE_PIANO)
      {
        DsPianoMp.TblMainRow tblMainRow = (DsPianoMp.TblMainRow) this.NewRow();
        tblMainRow.ItemArray = new object[16]
        {
          (object) NOME_EDIFICIO,
          (object) INDIRIZZO,
          (object) CODICE_EDIFICIO,
          (object) ID_EDIFICIO,
          (object) MESE,
          (object) ANNO,
          (object) MESE_ESTESO,
          (object) SERVIZIO,
          (object) ID_SERVIZIO,
          (object) ID_PMP,
          (object) PROCEDURA_MANUTENZIONE,
          (object) ID_CLASSE_ELEMENTO,
          (object) CODICE_ELEMENTO,
          (object) CLASSE_ELEMENTO,
          (object) PIANO,
          (object) ORDINE_PIANO
        };
        this.Rows.Add((DataRow) tblMainRow);
        return tblMainRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsPianoMp.TblMainDataTable tblMainDataTable = (DsPianoMp.TblMainDataTable) base.Clone();
        tblMainDataTable.InitVars();
        return (DataTable) tblMainDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsPianoMp.TblMainDataTable();

      internal void InitVars()
      {
        this.columnNOME_EDIFICIO = this.Columns["NOME_EDIFICIO"];
        this.columnINDIRIZZO = this.Columns["INDIRIZZO"];
        this.columnCODICE_EDIFICIO = this.Columns["CODICE_EDIFICIO"];
        this.columnID_EDIFICIO = this.Columns["ID_EDIFICIO"];
        this.columnMESE = this.Columns["MESE"];
        this.columnANNO = this.Columns["ANNO"];
        this.columnMESE_ESTESO = this.Columns["MESE_ESTESO"];
        this.columnSERVIZIO = this.Columns["SERVIZIO"];
        this.columnID_SERVIZIO = this.Columns["ID_SERVIZIO"];
        this.columnID_PMP = this.Columns["ID_PMP"];
        this.columnPROCEDURA_MANUTENZIONE = this.Columns["PROCEDURA_MANUTENZIONE"];
        this.columnID_CLASSE_ELEMENTO = this.Columns["ID_CLASSE_ELEMENTO"];
        this.columnCODICE_ELEMENTO = this.Columns["CODICE_ELEMENTO"];
        this.columnCLASSE_ELEMENTO = this.Columns["CLASSE_ELEMENTO"];
        this.columnPIANO = this.Columns["PIANO"];
        this.columnORDINE_PIANO = this.Columns["ORDINE_PIANO"];
      }

      private void InitClass()
      {
        this.columnNOME_EDIFICIO = new DataColumn("NOME_EDIFICIO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNOME_EDIFICIO);
        this.columnINDIRIZZO = new DataColumn("INDIRIZZO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnINDIRIZZO);
        this.columnCODICE_EDIFICIO = new DataColumn("CODICE_EDIFICIO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCODICE_EDIFICIO);
        this.columnID_EDIFICIO = new DataColumn("ID_EDIFICIO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_EDIFICIO);
        this.columnMESE = new DataColumn("MESE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMESE);
        this.columnANNO = new DataColumn("ANNO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnANNO);
        this.columnMESE_ESTESO = new DataColumn("MESE_ESTESO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMESE_ESTESO);
        this.columnSERVIZIO = new DataColumn("SERVIZIO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSERVIZIO);
        this.columnID_SERVIZIO = new DataColumn("ID_SERVIZIO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_SERVIZIO);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnPROCEDURA_MANUTENZIONE = new DataColumn("PROCEDURA_MANUTENZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPROCEDURA_MANUTENZIONE);
        this.columnID_CLASSE_ELEMENTO = new DataColumn("ID_CLASSE_ELEMENTO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_CLASSE_ELEMENTO);
        this.columnCODICE_ELEMENTO = new DataColumn("CODICE_ELEMENTO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCODICE_ELEMENTO);
        this.columnCLASSE_ELEMENTO = new DataColumn("CLASSE_ELEMENTO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCLASSE_ELEMENTO);
        this.columnPIANO = new DataColumn("PIANO", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPIANO);
        this.columnORDINE_PIANO = new DataColumn("ORDINE_PIANO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnORDINE_PIANO);
        this.columnNOME_EDIFICIO.AllowDBNull = false;
        this.columnINDIRIZZO.AllowDBNull = false;
        this.columnCODICE_EDIFICIO.AllowDBNull = false;
        this.columnID_EDIFICIO.AllowDBNull = false;
        this.columnMESE.AllowDBNull = false;
        this.columnANNO.AllowDBNull = false;
        this.columnMESE_ESTESO.AllowDBNull = false;
        this.columnSERVIZIO.AllowDBNull = false;
        this.columnID_SERVIZIO.AllowDBNull = false;
        this.columnID_PMP.AllowDBNull = false;
        this.columnPROCEDURA_MANUTENZIONE.AllowDBNull = false;
        this.columnID_CLASSE_ELEMENTO.AllowDBNull = false;
        this.columnCODICE_ELEMENTO.AllowDBNull = false;
        this.columnCLASSE_ELEMENTO.AllowDBNull = false;
        this.columnPIANO.AllowDBNull = false;
        this.columnORDINE_PIANO.AllowDBNull = false;
      }

      public DsPianoMp.TblMainRow NewTblMainRow() => (DsPianoMp.TblMainRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsPianoMp.TblMainRow(builder);

      protected override Type GetRowType() => typeof (DsPianoMp.TblMainRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblMainRowChanged == null)
          return;
        this.TblMainRowChanged((object) this, new DsPianoMp.TblMainRowChangeEvent((DsPianoMp.TblMainRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblMainRowChanging == null)
          return;
        this.TblMainRowChanging((object) this, new DsPianoMp.TblMainRowChangeEvent((DsPianoMp.TblMainRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblMainRowDeleted == null)
          return;
        this.TblMainRowDeleted((object) this, new DsPianoMp.TblMainRowChangeEvent((DsPianoMp.TblMainRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblMainRowDeleting == null)
          return;
        this.TblMainRowDeleting((object) this, new DsPianoMp.TblMainRowChangeEvent((DsPianoMp.TblMainRow) e.Row, e.Action));
      }

      public void RemoveTblMainRow(DsPianoMp.TblMainRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblMainRow : DataRow
    {
      private DsPianoMp.TblMainDataTable tableTblMain;

      internal TblMainRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblMain = (DsPianoMp.TblMainDataTable) this.Table;

      public string NOME_EDIFICIO
      {
        get => (string) this[this.tableTblMain.NOME_EDIFICIOColumn];
        set => this[this.tableTblMain.NOME_EDIFICIOColumn] = (object) value;
      }

      public string INDIRIZZO
      {
        get => (string) this[this.tableTblMain.INDIRIZZOColumn];
        set => this[this.tableTblMain.INDIRIZZOColumn] = (object) value;
      }

      public string CODICE_EDIFICIO
      {
        get => (string) this[this.tableTblMain.CODICE_EDIFICIOColumn];
        set => this[this.tableTblMain.CODICE_EDIFICIOColumn] = (object) value;
      }

      public long ID_EDIFICIO
      {
        get => (long) this[this.tableTblMain.ID_EDIFICIOColumn];
        set => this[this.tableTblMain.ID_EDIFICIOColumn] = (object) value;
      }

      public string MESE
      {
        get => (string) this[this.tableTblMain.MESEColumn];
        set => this[this.tableTblMain.MESEColumn] = (object) value;
      }

      public string ANNO
      {
        get => (string) this[this.tableTblMain.ANNOColumn];
        set => this[this.tableTblMain.ANNOColumn] = (object) value;
      }

      public string MESE_ESTESO
      {
        get => (string) this[this.tableTblMain.MESE_ESTESOColumn];
        set => this[this.tableTblMain.MESE_ESTESOColumn] = (object) value;
      }

      public string SERVIZIO
      {
        get => (string) this[this.tableTblMain.SERVIZIOColumn];
        set => this[this.tableTblMain.SERVIZIOColumn] = (object) value;
      }

      public long ID_SERVIZIO
      {
        get => (long) this[this.tableTblMain.ID_SERVIZIOColumn];
        set => this[this.tableTblMain.ID_SERVIZIOColumn] = (object) value;
      }

      public long ID_PMP
      {
        get => (long) this[this.tableTblMain.ID_PMPColumn];
        set => this[this.tableTblMain.ID_PMPColumn] = (object) value;
      }

      public string PROCEDURA_MANUTENZIONE
      {
        get => (string) this[this.tableTblMain.PROCEDURA_MANUTENZIONEColumn];
        set => this[this.tableTblMain.PROCEDURA_MANUTENZIONEColumn] = (object) value;
      }

      public long ID_CLASSE_ELEMENTO
      {
        get => (long) this[this.tableTblMain.ID_CLASSE_ELEMENTOColumn];
        set => this[this.tableTblMain.ID_CLASSE_ELEMENTOColumn] = (object) value;
      }

      public string CODICE_ELEMENTO
      {
        get => (string) this[this.tableTblMain.CODICE_ELEMENTOColumn];
        set => this[this.tableTblMain.CODICE_ELEMENTOColumn] = (object) value;
      }

      public string CLASSE_ELEMENTO
      {
        get => (string) this[this.tableTblMain.CLASSE_ELEMENTOColumn];
        set => this[this.tableTblMain.CLASSE_ELEMENTOColumn] = (object) value;
      }

      public string PIANO
      {
        get => (string) this[this.tableTblMain.PIANOColumn];
        set => this[this.tableTblMain.PIANOColumn] = (object) value;
      }

      public long ORDINE_PIANO
      {
        get => (long) this[this.tableTblMain.ORDINE_PIANOColumn];
        set => this[this.tableTblMain.ORDINE_PIANOColumn] = (object) value;
      }
    }

    [DebuggerStepThrough]
    public class TblMainRowChangeEvent : EventArgs
    {
      private DsPianoMp.TblMainRow eventRow;
      private DataRowAction eventAction;

      public TblMainRowChangeEvent(DsPianoMp.TblMainRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsPianoMp.TblMainRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }

    [DebuggerStepThrough]
    public class TblPassiDataTable : DataTable, IEnumerable
    {
      private DataColumn columnISTRUZIONE;
      private DataColumn columnPASSO;
      private DataColumn columnID_PMP;

      internal TblPassiDataTable()
        : base("TblPassi")
        => this.InitClass();

      internal TblPassiDataTable(DataTable table)
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

      internal DataColumn ISTRUZIONEColumn => this.columnISTRUZIONE;

      internal DataColumn PASSOColumn => this.columnPASSO;

      internal DataColumn ID_PMPColumn => this.columnID_PMP;

      public DsPianoMp.TblPassiRow this[int index] => (DsPianoMp.TblPassiRow) this.Rows[index];

      public event DsPianoMp.TblPassiRowChangeEventHandler TblPassiRowChanged;

      public event DsPianoMp.TblPassiRowChangeEventHandler TblPassiRowChanging;

      public event DsPianoMp.TblPassiRowChangeEventHandler TblPassiRowDeleted;

      public event DsPianoMp.TblPassiRowChangeEventHandler TblPassiRowDeleting;

      public void AddTblPassiRow(DsPianoMp.TblPassiRow row) => this.Rows.Add((DataRow) row);

      public DsPianoMp.TblPassiRow AddTblPassiRow(
        string ISTRUZIONE,
        long PASSO,
        long ID_PMP)
      {
        DsPianoMp.TblPassiRow tblPassiRow = (DsPianoMp.TblPassiRow) this.NewRow();
        tblPassiRow.ItemArray = new object[3]
        {
          (object) ISTRUZIONE,
          (object) PASSO,
          (object) ID_PMP
        };
        this.Rows.Add((DataRow) tblPassiRow);
        return tblPassiRow;
      }

      public IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

      public override DataTable Clone()
      {
        DsPianoMp.TblPassiDataTable tblPassiDataTable = (DsPianoMp.TblPassiDataTable) base.Clone();
        tblPassiDataTable.InitVars();
        return (DataTable) tblPassiDataTable;
      }

      protected override DataTable CreateInstance() => (DataTable) new DsPianoMp.TblPassiDataTable();

      internal void InitVars()
      {
        this.columnISTRUZIONE = this.Columns["ISTRUZIONE"];
        this.columnPASSO = this.Columns["PASSO"];
        this.columnID_PMP = this.Columns["ID_PMP"];
      }

      private void InitClass()
      {
        this.columnISTRUZIONE = new DataColumn("ISTRUZIONE", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnISTRUZIONE);
        this.columnPASSO = new DataColumn("PASSO", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPASSO);
        this.columnID_PMP = new DataColumn("ID_PMP", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID_PMP);
        this.columnISTRUZIONE.AllowDBNull = false;
        this.columnPASSO.AllowDBNull = false;
        this.columnID_PMP.AllowDBNull = false;
      }

      public DsPianoMp.TblPassiRow NewTblPassiRow() => (DsPianoMp.TblPassiRow) this.NewRow();

      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new DsPianoMp.TblPassiRow(builder);

      protected override Type GetRowType() => typeof (DsPianoMp.TblPassiRow);

      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TblPassiRowChanged == null)
          return;
        this.TblPassiRowChanged((object) this, new DsPianoMp.TblPassiRowChangeEvent((DsPianoMp.TblPassiRow) e.Row, e.Action));
      }

      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TblPassiRowChanging == null)
          return;
        this.TblPassiRowChanging((object) this, new DsPianoMp.TblPassiRowChangeEvent((DsPianoMp.TblPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TblPassiRowDeleted == null)
          return;
        this.TblPassiRowDeleted((object) this, new DsPianoMp.TblPassiRowChangeEvent((DsPianoMp.TblPassiRow) e.Row, e.Action));
      }

      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TblPassiRowDeleting == null)
          return;
        this.TblPassiRowDeleting((object) this, new DsPianoMp.TblPassiRowChangeEvent((DsPianoMp.TblPassiRow) e.Row, e.Action));
      }

      public void RemoveTblPassiRow(DsPianoMp.TblPassiRow row) => this.Rows.Remove((DataRow) row);
    }

    [DebuggerStepThrough]
    public class TblPassiRow : DataRow
    {
      private DsPianoMp.TblPassiDataTable tableTblPassi;

      internal TblPassiRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTblPassi = (DsPianoMp.TblPassiDataTable) this.Table;

      public string ISTRUZIONE
      {
        get => (string) this[this.tableTblPassi.ISTRUZIONEColumn];
        set => this[this.tableTblPassi.ISTRUZIONEColumn] = (object) value;
      }

      public long PASSO
      {
        get => (long) this[this.tableTblPassi.PASSOColumn];
        set => this[this.tableTblPassi.PASSOColumn] = (object) value;
      }

      public long ID_PMP
      {
        get => (long) this[this.tableTblPassi.ID_PMPColumn];
        set => this[this.tableTblPassi.ID_PMPColumn] = (object) value;
      }
    }

    [DebuggerStepThrough]
    public class TblPassiRowChangeEvent : EventArgs
    {
      private DsPianoMp.TblPassiRow eventRow;
      private DataRowAction eventAction;

      public TblPassiRowChangeEvent(DsPianoMp.TblPassiRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      public DsPianoMp.TblPassiRow Row => this.eventRow;

      public DataRowAction Action => this.eventAction;
    }
  }
}
