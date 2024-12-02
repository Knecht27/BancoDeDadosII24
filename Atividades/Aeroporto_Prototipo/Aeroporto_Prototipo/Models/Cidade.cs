using System;
using System.Collections.Generic;

namespace Aeroporto_Prototipo.Models;

public partial class Cidade
{
    public int IdCidade { get; set; }

    public string? Cidade1 { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public string? Sigla { get; set; }

    public virtual ICollection<Aeroporto> Aeroportos { get; set; } = new List<Aeroporto>();
}
