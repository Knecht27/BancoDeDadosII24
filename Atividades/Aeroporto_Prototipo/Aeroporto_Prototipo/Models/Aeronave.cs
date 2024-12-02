using System;
using System.Collections.Generic;

namespace Aeroporto_Prototipo.Models;

public partial class Aeronave
{
    public int IdAeronave { get; set; }

    public string? NomeAeronave { get; set; }

    public bool? Ativo { get; set; }

    public int? ModeloAeronave { get; set; }

    public int? Piloto { get; set; }

    public virtual ModeloAeronave? ModeloAeronaveNavigation { get; set; }

    public virtual Piloto? PilotoNavigation { get; set; }

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
