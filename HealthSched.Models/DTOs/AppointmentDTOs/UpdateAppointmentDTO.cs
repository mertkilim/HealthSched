using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.Appointment
{
    public class UpdateAppointmentDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? PoliclinicId { get; set; }
        public DateTime? Time { get; set; }
        public bool isComplete { get; set; } = false;
    }
}
