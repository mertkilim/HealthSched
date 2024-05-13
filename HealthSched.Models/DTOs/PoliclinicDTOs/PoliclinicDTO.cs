using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.PoliclinicDTOs
{
    public class PoliclinicDTO
    {
        public int Id { get; set; }
        public string PoliclinicName { get; set; }
        public ICollection<int>? DoctorIds { get; set; }
        public ICollection<int>? AppointmentIds { get; set; }
        public ICollection<int> PatientIds { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
