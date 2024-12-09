using System;
using System.Collections.Generic;

namespace DL;

public partial class Area
{
    public int IdArea { get; set; }

    public string NombreArea { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
