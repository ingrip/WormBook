using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Pedidoespecial> Pedidoespecials { get; set; } = new List<Pedidoespecial>();
}
