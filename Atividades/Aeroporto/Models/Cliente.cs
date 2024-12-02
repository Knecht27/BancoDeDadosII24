using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NomeCliente { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public string? Passagem { get; set; }

    public string? Sexo { get; set; }

    public string? Cpf { get; set; }

    public virtual ICollection<Passagem> Passagems { get; set; } = new List<Passagem>();
}
