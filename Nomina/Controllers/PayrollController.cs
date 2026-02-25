using Microsoft.AspNetCore.Mvc;
using Nomina.Application;
using Nomina.Domain;

namespace Nomina.Controllers
{
    public class PayrollController : Controller
    {
        private readonly PayrollService _service = new PayrollService();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nuevo()
        {
            return View("Index");
        }

        public IActionResult Buscar(int id)
        {
            return View("Index");
        }

        public IActionResult Modificar(Employee employee)
        {
            return View("Index");
        }

        public IActionResult Eliminar(int id)
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Calculate(Employee employee)
        {
            var result = _service.Calculate(employee);
            return View("Result", result);
        }
    }
}