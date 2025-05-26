using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Juegomesa
{
    public int CodigoInterno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Marca { get; set; } = null!;
    public string? URL { get; set; }
    public virtual Producto CodigoInternoNavigation { get; set; } = null!;
}
