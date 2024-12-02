using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Passagem
{
    public int IdPassagem { get; set; }

    public int? NumeroPassagem { get; set; }

    public int? ClientePassagem { get; set; }

    public int? VooNum { get; set; }

    public int? Poltrona { get; set; }

    public int? AeroportoDecolagem { get; set; }

    public int? AeroportoPouso { get; set; }

    public virtual Aeroporto? AeroportoDecolagemNavigation { get; set; }

    public virtual Aeroporto? AeroportoPousoNavigation { get; set; }

    public virtual Cliente? ClientePassagemNavigation { get; set; }

    public virtual Poltrona? PoltronaNavigation { get; set; }

    public virtual Voo? VooNumNavigation { get; set; }
}
