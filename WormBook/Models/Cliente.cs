using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Cliente
{
    public int Telefono { get; set; }

    public required string Nombre { get; set; }

    public required string Apellido { get; set; }

}
