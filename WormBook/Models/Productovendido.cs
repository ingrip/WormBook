using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Productovendido
{
    public int CodigoInterno { get; set; }

    public int Numventa { get; set; }

    public int Cantidadvendida { get; set; }

    public virtual Producto CodigoInternoNavigation { get; set; } = null!;

    public virtual Ventum NumventaNavigation { get; set; } = null!;
}
