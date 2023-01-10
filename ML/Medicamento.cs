using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Medicamento
    {
        public int IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaCaducidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public Proveedor Proveedor { get; set; }
        public List<Object> Medicamentos { get; set; }
    }
}
