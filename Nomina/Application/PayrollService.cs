using Nomina.Domain;

namespace Nomina.Application
{
    public class PayrollService
    {
        private const decimal BaseHourlyRate = 30m;
        private const decimal DeliveryPayment = 5m;

        public PayrollResult Calculate(Employee employee)
        {
            decimal baseSalary = employee.HoursWorked * BaseHourlyRate;

            decimal bonusPerHour = GetBonus(employee);
            decimal bonus = employee.HoursWorked * bonusPerHour;

            decimal deliveriesPayment = employee.Deliveries * DeliveryPayment;

            decimal grossSalary = baseSalary + bonus + deliveriesPayment;

            decimal vouchers = 0;
            if (employee.Type == EmployeeType.Interno)
                vouchers = grossSalary * 0.04m;

            decimal isr = grossSalary * 0.09m;

            if (grossSalary > 16000)
                isr += grossSalary * 0.03m;

            decimal netSalary = grossSalary - isr;

            return new PayrollResult
            {
                GrossSalary = grossSalary,
                ISR = isr,
                Vouchers = vouchers,
                NetSalary = netSalary
            };
        }

        private decimal GetBonus(Employee employee)
        {
            if (employee.CoveredShift && employee.CoveredRole.HasValue)
            {
                return employee.CoveredRole switch
                {
                    Role.Chofer => 10m,
                    Role.Cargador => 5m,
                    _ => 0m
                };
            }

            return employee.Role switch
            {
                Role.Chofer => 10m,
                Role.Cargador => 5m,
                _ => 0m
            };
        }
    }

    public class PayrollResult
    {
        public decimal GrossSalary { get; set; }
        public decimal ISR { get; set; }
        public decimal Vouchers { get; set; }
        public decimal NetSalary { get; set; }
    }
}