using Microsoft.AspNetCore.Mvc;
using Nomina.Application;
using Nomina.Domain;
using Nomina.Infrastructure;

namespace Nomina.Controllers
{
    public class PayrollController : Controller
    {
        private readonly NominaDbContext _context;
        private readonly PayrollService _service;

        public PayrollController(NominaDbContext context)
        {
            _context = context;
            _service = new PayrollService();
        }

        //  Cargar vista vacía
        public IActionResult Index()
        {
            return View(new Employee());
        }

        //  NUEVO (solo limpia formulario)
        public IActionResult Nuevo()
        {
            return RedirectToAction("Index");
        }

        //  GUARDAR (Nuevo o Modificar)
        [HttpPost]
        public IActionResult Guardar(Employee employee)
        {
            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
                _context.Employees.Update(employee);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //  BUSCAR
        public IActionResult Buscar(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
                return RedirectToAction("Index");

            return View("Index", employee);
        }

        //  ELIMINAR
        public IActionResult Eliminar(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //  CALCULAR
        [HttpPost]
        public IActionResult Calculate(Employee employee)
        {
            var result = _service.Calculate(employee);
            return View("Result", result);
        }
    }
}