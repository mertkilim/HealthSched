using HealthSched.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.DoctorDTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get { return (DoctorName + " " + DoctorSurname); } }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? PoliclinicId { get; set; }
        public int? TitleId { get; set; }
        public ICollection<DateTime>? WorkingHours { get; set; }
        public ICollection<int> PatientIds { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
