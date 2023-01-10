using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Resultado
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public Exception Excepcion { get; set; }
        public List<Object> Objetos { get; set; }
        public Object Objeto { get; set; }
    }
}
