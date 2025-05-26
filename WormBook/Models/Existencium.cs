using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Existencium
{
    public int CodigoInterno { get; set; }

    public int Existencia { get; set; }

    public int Codigosucursal { get; set; }

    public virtual Producto CodigointernoNavigation { get; set; } = null!;

    public virtual Sucursal CodigosucursalNavigation { get; set; } = null!;
}
