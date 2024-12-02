using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Aeroporto
{
    public int IdAeroporto { get; set; }

    public string? Nome { get; set; }

    public int? Cidade { get; set; }

    public string? Cnpj { get; set; }

    public string? Sigla { get; set; }

    public virtual Cidade? CidadeNavigation { get; set; }

    public virtual ICollection<Passagem> PassagemAeroportoDecolagemNavigations { get; set; } = new List<Passagem>();

    public virtual ICollection<Passagem> PassagemAeroportoPousoNavigations { get; set; } = new List<Passagem>();

    public virtual ICollection<Voo> VooDestinoNavigations { get; set; } = new List<Voo>();

    public virtual ICollection<Voo> VooPartidaNavigations { get; set; } = new List<Voo>();
}
