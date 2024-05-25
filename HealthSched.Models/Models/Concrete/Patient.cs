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
        public string Password { get; set; }
        public DateTime BirthDate{ get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Policlinic> Policlinics { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
