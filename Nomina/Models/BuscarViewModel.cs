using Nomina.Domain;
using Nomina.Application;

namespace Nomina.Models
{
    public class BuscarViewModel
    {
        public Employee? Employee { get; set; }
        public PayrollResult? Resultado { get; set; }
        public string? Message { get; set; }
    }
}