using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Productosenviado
{
    public int CodigoInterno { get; set; }

    public int Guiaenvio { get; set; }

    public int Cantidadenviada { get; set; }
    public virtual Producto CodigoInternoNavigation { get; set; } = null!;

    public virtual Envio GuiaenvioNavigation { get; set; } = null!;
}
