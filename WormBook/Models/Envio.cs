using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WormBook.Models;

public partial class Envio
{
    public long Guiaenvio { get; set; }

    public int Numcajas { get; set; }

    public string Destino { get; set; }

    public long Sucursalorigen { get; set; }
    public long Telefono { get; set;}
}
