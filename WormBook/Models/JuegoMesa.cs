using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Juegomesa
{
    public int Codigointerno { get; set; }

    public string Nombre { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string URL { get; set; } = null!;
    public virtual Producto CodigointernoNavigation { get; set; } = null!;
}
