using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Envio
{
    public int Guiaenvio { get; set; }

    public int Numcajas { get; set; }

    public int Sucursaldestino { get; set; }

    public int Sucursalorigen { get; set; }

    public virtual ICollection<Productosenviado> Productosenviados { get; set; } = new List<Productosenviado>();

    public virtual Sucursal SucursaldestinoNavigation { get; set; } = null!;

    public virtual Sucursal SucursalorigenNavigation { get; set; } = null!;
}
