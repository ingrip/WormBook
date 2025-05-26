using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Pedidoespecial
{
    public int Numpedido { get; set; }

    public DateTime Fechapedido { get; set; }

    public int Cantidadpedida { get; set; }

    public string Estado { get; set; } = null!;

    public int CodigoInterno { get; set; }

    public int Codigosucursal { get; set; }

    public int Idcliente { get; set; }

    public virtual Producto CodigoInternoNavigation { get; set; } = null!;

    public virtual Sucursal CodigosucursalNavigation { get; set; } = null!;

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual ICollection<Productosenviado> Productosenviados { get; set; } = new List<Productosenviado>();
}
