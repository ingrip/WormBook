using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Sucursal
{
    public int Codigosucursal { get; set; }

    public string Nombresucursal { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public string Telefonosucursal { get; set; } = null!;

    public virtual ICollection<Existencium> Existencia { get; set; } = new List<Existencium>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
