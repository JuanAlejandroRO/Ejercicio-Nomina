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

        // =========================================
        // NUEVO (Pantalla principal)
        // =========================================
        public IActionResult Index()
        {
            return View(new Employee
            {
                Date = DateTime.Today
            });
        }

        // Guardar nuevo empleado
        [HttpPost]
        public IActionResult Guardar(Employee employee)
        {
            if (!ModelState.IsValid)
                return View("Index", employee);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            var result = _service.Calculate(employee);

            return View("Result", result);
        }

        // =========================================
        // BUSCAR
        // =========================================
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarResultado(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                ViewBag.Message = "Empleado no encontrado";
                return View("Buscar");
            }

            var resultado = _service.Calculate(employee);

            ViewBag.Resultado = resultado;

            return View("Buscar", employee);
        }

        // =========================================
        // EDITAR
        // =========================================
        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CargarEditar(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                ViewBag.Message = "Empleado no encontrado";
                return View("Editar");
            }

            var resultado = _service.Calculate(employee);
            ViewBag.Resultado = resultado;

            return View("Editar", employee);
        }

        [HttpPost]
        public IActionResult Actualizar(Employee employee)
        {
            if (!ModelState.IsValid)
                return View("Editar", employee);

            _context.Employees.Update(employee);
            _context.SaveChanges();

            var resultado = _service.Calculate(employee);

            return View("Result", resultado);
        }

        // =========================================
        // ELIMINAR
        // =========================================
        public IActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmarEliminar(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                ViewBag.Message = "Empleado no encontrado";
                return View("Eliminar");
            }

            var resultado = _service.Calculate(employee);
            ViewBag.Resultado = resultado;

            return View("Eliminar", employee);
        }

        [HttpPost]
        public IActionResult EliminarDefinitivo(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // =========================================
        // CALCULAR NÓMINA
        // =========================================
        [HttpPost]
        public IActionResult Calculate(Employee employee)
        {
            var result = _service.Calculate(employee);
            return View("Result", result);
        }
    }
}