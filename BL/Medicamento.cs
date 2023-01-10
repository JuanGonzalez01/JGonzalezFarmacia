using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Medicamento
    {
        public static ML.Resultado GetAll()
        {
            ML.Resultado resultado = new ML.Resultado();

            try
            {
                using (DL.JgonzalezFarmaciaContext context = new DL.JgonzalezFarmaciaContext())
                {
                    var query = context.Medicamentos.FromSqlRaw("MedicamentoGetAll").ToList();

                    if (query != null | query.Count > 0)
                    {
                        resultado.Objetos = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Medicamento medicamento = new ML.Medicamento();

                            medicamento.IdMedicamento = item.IdMedicamento;
                            medicamento.Nombre = item.Nombre;
                            medicamento.Descripcion = item.Descripcion;
                            medicamento.FechaCaducidad = item.FechaCaducidad.ToString();
                            medicamento.PrecioUnitario = item.PrecioUnitario.Value;
                            medicamento.Stock = item.Stock.Value;

                            medicamento.Proveedor = new ML.Proveedor();
                            medicamento.Proveedor.IdProveedor = item.IdProveedor.Value;
                            medicamento.Proveedor.Nombre = item.Proveedor;

                            resultado.Objetos.Add(medicamento);
                        }

                        resultado.Estado = true;
                    }
                    else
                    {
                        resultado.Estado = false;
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

        public static ML.Resultado GetById(int idMedicamento)
        {
            ML.Resultado resultado = new ML.Resultado();

            try
            {
                using (DL.JgonzalezFarmaciaContext context = new DL.JgonzalezFarmaciaContext())
                {
                    var query = context.Medicamentos.FromSqlRaw($"MedicamentoGetById {idMedicamento}").AsEnumerable().FirstOrDefault();

                    if (query != null)
                    {
                        ML.Medicamento medicamento = new ML.Medicamento();

                        medicamento.IdMedicamento = query.IdMedicamento;
                        medicamento.Nombre = query.Nombre;
                        medicamento.Descripcion = query.Descripcion;
                        medicamento.FechaCaducidad = query.FechaCaducidad.ToString();
                        medicamento.PrecioUnitario = query.PrecioUnitario.Value;
                        medicamento.Stock = query.Stock.Value;

                        medicamento.Proveedor = new ML.Proveedor();
                        medicamento.Proveedor.IdProveedor = query.IdProveedor.Value;
                        medicamento.Proveedor.Nombre = query.Proveedor;

                        resultado.Objeto = medicamento;
                        resultado.Estado = true;
                    }
                    else
                    {
                        resultado.Estado = false;
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

        public static ML.Resultado Add(ML.Medicamento medicamento)
        {
            ML.Resultado resultado = new ML.Resultado();

            try
            {
                using (DL.JgonzalezFarmaciaContext context = new DL.JgonzalezFarmaciaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"MedicamentoAdd '{medicamento.Nombre}', '{medicamento.Descripcion}', '{medicamento.FechaCaducidad}', {medicamento.PrecioUnitario}, {medicamento.Stock}, {medicamento.Proveedor.IdProveedor}");

                    if (query != null | query > 0)
                    {
                        resultado.Estado = true;
                    }
                    else
                    {
                        resultado.Estado = false;
                        resultado.Mensaje = "No se agregaron registros.";
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

        public static ML.Resultado Update(ML.Medicamento medicamento)
        {
            ML.Resultado resultado = new ML.Resultado();

            try
            {
                using (DL.JgonzalezFarmaciaContext context = new DL.JgonzalezFarmaciaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"MedicamentoUpdate {medicamento.IdMedicamento} '{medicamento.Nombre}', '{medicamento.Descripcion}', '{medicamento.FechaCaducidad}', {medicamento.PrecioUnitario}, {medicamento.Stock}, {medicamento.Proveedor.IdProveedor}");

                    if (query != null | query > 0)
                    {
                        resultado.Estado = true;
                    }
                    else
                    {
                        resultado.Estado = false;
                        resultado.Mensaje = "No se modificaron registros.";
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

        public static ML.Resultado Delete(int idMedicamento)
        {
            ML.Resultado resultado = new ML.Resultado();

            try
            {
                using (DL.JgonzalezFarmaciaContext context = new DL.JgonzalezFarmaciaContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"MedicamentoDelete {idMedicamento}");

                    if (query != null | query > 0)
                    {
                        resultado.Estado = true;
                    }
                    else
                    {
                        resultado.Estado = false;
                        resultado.Mensaje = "No se eliminaron registros.";
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
