using HealthSched.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.AppointmentDTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? PoliclinicId { get; set; }
        public DateTime? Time { get; set; }
        public bool isComplete { get; set; } = false;
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
