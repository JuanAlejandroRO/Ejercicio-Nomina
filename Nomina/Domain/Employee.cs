namespace Nomina.Domain
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
        Externo
    }

    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public Role Role { get; set; }
        public EmployeeType Type { get; set; }

        public DateTime Date { get; set; }

        public int HoursWorked { get; set; }
        public int Deliveries { get; set; }

        public bool CoveredShift { get; set; }
        public Role? CoveredRole { get; set; }
    }
}