using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Ventum
{
    public int Numventa { get; set; }

    public int? Total { get; set; }

    public DateTime? Fechacompra { get; set; }

    public int Codigosucursal { get; set; }

    public virtual Sucursal CodigosucursalNavigation { get; set; } = null!;

    public virtual ICollection<Productovendido> Productovendidos { get; set; } = new List<Productovendido>();
}
