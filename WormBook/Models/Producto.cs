using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Producto
{
    public int CodigoInterno { get; set; }

    public int? Precio { get; set; }

    public string? Codigobarras { get; set; }

    public virtual ICollection<Existencium> Existencia { get; set; } = new List<Existencium>();

    public virtual Juegomesa? Juegomesa { get; set; }

    public virtual Libro? Libro { get; set; }
    public virtual ICollection<Productosenviado> Productosenviados { get; set; } = new List<Productosenviado>();

    public virtual ICollection<Productovendido> Productovendidos { get; set; } = new List<Productovendido>();

}
