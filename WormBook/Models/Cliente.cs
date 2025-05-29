using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Cliente
{
    public long Telefono { get; set; }

    public required string Nombre { get; set; }

    public required string Apellido { get; set; }

}
