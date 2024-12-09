using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; } 
        public int Edad { get; set; }
        public string CorreoElectronico { get; set; }
        public List<object> empleados { get; set; }
        public ML.Area Area { get; set; }
    }
}
