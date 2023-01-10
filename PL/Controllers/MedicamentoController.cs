using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MedicamentoController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Resultado resultado = BL.Medicamento.GetAll();

            return View(resultado);
        }

        public IActionResult Form(int idMedicamento)
        {
            ML.Medicamento medicamento = new ML.Medicamento();
            ML.Resultado resultPro = BL.Proveedor.GetAll();

            if (idMedicamento != 0)
            {
                medicamento = (ML.Medicamento)BL.Medicamento.GetById(idMedicamento).Objeto;
            }

            medicamento.Proveedor.Proveedores = resultPro.Objetos;

            return View(medicamento);
        }

    }
}
