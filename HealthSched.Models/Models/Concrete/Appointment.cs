using HealthSched.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.Models.Concrete
{
    public class Appointment :  BaseEntity
    {
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int? PoliclinicId { get; set; }
        public Policlinic Policlinic { get; set; }
        public DateTime? Time { get; set; }
        public bool isCompleted { get; set; } = false;
    }
}
