using System;
using System.Collections.Generic;

namespace DL;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Stock { get; set; }

    public int? IdProveedor { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public string Proveedor { get; set; }
}
