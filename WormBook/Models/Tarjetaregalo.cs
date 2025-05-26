using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Tarjetaregalo
{
    public int CodigoInterno { get; set; }

    public int Saldo { get; set; }

    public virtual Producto CodigoInternoNavigation { get; set; } = null!;
}
