using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.Appointment
{
    public class CreateAppointmentDTO
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? PoliclinicId { get; set; }
        public DateTime? Time { get; set; }
    }
}
