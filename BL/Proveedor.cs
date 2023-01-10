using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Proveedor
    {
        public static ML.Resultado GetAll()
        {
            ML.Resultado resultado = new ML.Resultado();

            try
            {
                using (DL.JgonzalezFarmaciaContext context = new DL.JgonzalezFarmaciaContext())
                {
                    var query = context.Proveedors.FromSqlRaw("ProveedorGetAll").ToList();

                    if (query != null | query.Count > 0)
                    {
                        resultado.Objetos = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();

                            proveedor.IdProveedor = item.IdProveedor;
                            proveedor.Nombre = item.Nombre;

                            resultado.Objetos.Add(proveedor);
                        }

                        resultado.Estado = true;
                    }
                    else
                    {
                        resultado.Estado=false;
                        resultado.Mensaje = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Estado = false;
                resultado.Excepcion = ex;
                resultado.Mensaje = ex.Message;
            }

            return resultado;
        }
    }
}
