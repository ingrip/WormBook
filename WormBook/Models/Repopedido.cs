using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Repopedido
{
    public int Numrepo { get; set; }

    public int Codigosucursal { get; set; }

    public DateTime Fechapedido { get; set; }

    public virtual Sucursal CodigosucursalNavigation { get; set; } = null!;

    public virtual ICollection<Repodetalle> Repodetalles { get; set; } = new List<Repodetalle>();
}
