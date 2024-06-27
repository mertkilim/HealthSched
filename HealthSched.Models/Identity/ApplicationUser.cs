using HealthSched.Models.Models.Concrete;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HealthSched.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        
        public string FullName { get { return PatientName + " " + PatientSurname; } }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string PatientSurname { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

    }
}
