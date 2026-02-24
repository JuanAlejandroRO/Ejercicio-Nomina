namespace EjercicioNomina.Domain
{
    public enum Role
    {
        Chofer,
        Cargador,
        Auxiliar
    }

    public enum EmployeeType
    {
        Interno,
        Subcontratado
    }

    public class Employee
    {
        public required string Name { get; set; }
        public Role Role { get; set; }
        public EmployeeType Type { get; set; }
        public int HoursWorked { get; set; }
        public int Deliveries { get; set; }
        public Role? CoveredRole { get; set; }
    }
}