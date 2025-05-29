using System;
using System.Collections.Generic;

namespace WormBook.Models;

public partial class Libro
{
    public int CodigoInterno { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public string? Editorial { get; set; }

    public virtual Producto CodigoInternoNavigation { get; set; } = null!;

    public string URL { get; set; } = null!;

}
