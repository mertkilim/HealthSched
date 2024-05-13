using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.Doctor
{
    public class UpdateDoctorDTO
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? PoliclinicId { get; set; }
        public int? TitleId { get; set; }
        public ICollection<DateTime>? WorkingHours { get; set; }
    }
}
