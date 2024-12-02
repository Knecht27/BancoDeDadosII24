using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Piloto
{
    public int IdPiloto { get; set; }

    public string? NomePiloto { get; set; }

    public string? Cpf { get; set; }

    public DateOnly? Nascimento { get; set; }

    public int? NumCertificacao { get; set; }

    public virtual ICollection<Aeronave> Aeronaves { get; set; } = new List<Aeronave>();
}
