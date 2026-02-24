using Microsoft.AspNetCore.Mvc;
using EjercicioNomina.Domain;
using EjercicioNomina.Application;

namespace EjercicioNomina.Controllers
{
    public class PayrollController : Controller
    {
        private readonly PayrollService _service = new PayrollService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(Employee employee)
        {
            var result = _service.Calculate(employee);
            return View("Result", result);
        }
    }
}