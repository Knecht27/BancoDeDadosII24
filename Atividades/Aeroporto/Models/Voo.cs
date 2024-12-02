using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Voo
{
    public int IdVoo { get; set; }

    public int? Partida { get; set; }

    public int? Destino { get; set; }

    public DateTime? PrevistoDecolagem { get; set; }

    public DateTime? PrevistoPouso { get; set; }

    public DateTime? TempoDecolagem { get; set; }

    public DateTime? TempoPouso { get; set; }

    public int? Aeronave { get; set; }

    public virtual Aeronave? AeronaveNavigation { get; set; }

    public virtual Aeroporto? DestinoNavigation { get; set; }

    public virtual Aeroporto? PartidaNavigation { get; set; }

    public virtual ICollection<Passagem> Passagems { get; set; } = new List<Passagem>();
}
