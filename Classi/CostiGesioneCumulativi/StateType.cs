// Decompiled with JetBrains decompiler
// Type: TheSite.Classi.CostiGesioneCumulativi.StateType
// Assembly: ME, Version=1.0.3728.28568, Culture=neutral, PublicKeyToken=null
// MVID: C29CC0F3-9682-4F13-A7DC-CF27C967E605
// Assembly location: C:\SIR_LAVORO\ME.dll

namespace TheSite.Classi.CostiGesioneCumulativi
{
  public enum StateType
  {
    RichiestaInAttesaDiEmissione = 1,
    AssegnatoOrdineLavoro = 2,
    AccorpataInAltraRichiesta = 3,
    AttivitaCompletata = 4,
    EmessaComeStraordinaria = 5,
    EmessaInLavorazione = 6,
    RichiestaRifiutata = 7,
    EmessaMaSospesa = 8,
    AutorizzatoDalCliente = 9,
    Approvata = 10, // 0x0000000A
    EmessaMaSospesaPerInaccessibilita = 11, // 0x0000000B
    EmessaMaSospesaPerApprovviggionamento = 12, // 0x0000000C
    EmessaMaSospesaPerInterventoSpecialistico = 13, // 0x0000000D
    EmessaMaSospesaDalCommittente = 14, // 0x0000000E
    RichiestaSospesa = 15, // 0x0000000F
    Archiviata = 16, // 0x00000010
  }
}
