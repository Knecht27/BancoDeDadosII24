using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class ModeloAeronave
{
    public int IdModelo { get; set; }

    public string? NomeModelo { get; set; }

    public int? AnoModelo { get; set; }

    public int? CapacidadePoltronas { get; set; }

    public int? CapacidadeCombustivel { get; set; }

    public virtual ICollection<Aeronave> Aeronaves { get; set; } = new List<Aeronave>();
}
