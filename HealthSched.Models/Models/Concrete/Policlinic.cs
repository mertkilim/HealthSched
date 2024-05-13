using HealthSched.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.Models.Concrete
{
    public class Policlinic : BaseEntity
    {
        public string PoliclinicName { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
