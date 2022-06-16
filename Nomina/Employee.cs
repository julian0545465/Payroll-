
namespace Nomina
{
    internal class Employee
    {

        private string _DocumentId;
        private string _Name;
        private string _LastName;
        private double _Salary;
        private double _WorkedDays;
        private double _TotalAccrued;
        private double _AuxTransport;
        private double _Health;
        private double _Pension;

        public string DocumentId { get => _DocumentId; set => _DocumentId = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public double Salary { get => _Salary; set => _Salary = value; }
        public double WorkedDays { get => _WorkedDays; set => _WorkedDays = value; }
        public double TotalAccrued { get => _TotalAccrued; set => _TotalAccrued = value; }
        public double AuxTransport { get => _AuxTransport; set => _AuxTransport = value; }
        public double Health { get => _Health; set => _Health = value; }
        public double Pension { get => _Pension; set => _Pension = value; }
       
    }
}
