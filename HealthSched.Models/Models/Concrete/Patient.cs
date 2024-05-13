using HealthSched.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.Models.Concrete
{
    public class Patient : BaseEntity
    {
        public string FullName { get { return PatientName + " " + PatientSurname; } }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string IdentificationNumber { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        private DateTime _BirthDate;
        public DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
                CalculateAge();
            }
        }
        public int Age { get; private set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Policlinic> Policlinics { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        private void CalculateAge()
        {
            int age = DateTime.Today.Year - _BirthDate.Year;

            if (_BirthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            Age = age;
        }
    }
}
