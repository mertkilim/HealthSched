using HealthSched.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.PatientDTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FullName { get { return (PatientName + " " + PatientSurname); } }
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
        public ICollection<int>? AppointmentIds { get; set; }
        public ICollection<int> PoliclinicIds { get; set; }
        public ICollection<int> DoctorIds { get; set; }
        public bool isDeleted { get; set; } = false;
        private void CalculateAge()
        {
            int age = (DateTime.Today.Year) - (_BirthDate.Year);

            if (_BirthDate.Date > DateTime.Today.AddYears(-age))
                age--;

            Age = age;
        }
    }
}
