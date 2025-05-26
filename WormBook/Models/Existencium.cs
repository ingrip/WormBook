using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WormBook.Models;

public partial class Existencium
{
    public int CodigoInterno { get; set; }

    public int Existencia { get; set; }

    public int Codigosucursal { get; set; }
    [JsonIgnore]
    public virtual Producto CodigointernoNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Sucursal CodigosucursalNavigation { get; set; } = null!;
}
