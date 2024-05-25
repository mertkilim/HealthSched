using HealthSched.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.Models.Concrete
{
    public class Doctor : BaseEntity
    {
        public string FullName { get { return DoctorName + " " + DoctorSurname; } }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? PoliclinicId { get; set; }
        public Policlinic Policlinic { get; set; }
        public int? TitleId { get; set; }
        public Title Title { get; set; }
        public ICollection<DateTime>? WorkingHours { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
