using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Envio
{
    public int Guiaenvio { get; set; }

    public int Numcajas { get; set; }

<<<<<<< HEAD
    public string Destino { get; set; }
=======
    public int Destino { get; set; }
>>>>>>> ec87565b3460f9e39768066ab5adff8d0af70ced

    public int Sucursalorigen { get; set; }

    public virtual ICollection<Productosenviado> Productosenviados { get; set; } = new List<Productosenviado>();

    public virtual Sucursal SucursaldestinoNavigation { get; set; } = null!;

    public virtual Sucursal SucursalorigenNavigation { get; set; } = null!;
}
