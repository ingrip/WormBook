using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Repodetalle
{
    public int CodigoInterno { get; set; }

    public int Numrepo { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto CodigoInternoNavigation { get; set; } = null!;

    public virtual Repopedido NumrepoNavigation { get; set; } = null!;
}
