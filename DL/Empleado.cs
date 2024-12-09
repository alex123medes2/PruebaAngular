using System;
using System.Collections.Generic;

namespace DL;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public int Edad { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public int IdArea { get; set; }

    public virtual Area IdAreaNavigation { get; set; } = null!;
}
