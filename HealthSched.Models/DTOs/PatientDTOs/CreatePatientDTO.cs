using HealthSched.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.Patient
{
    public class CreatePatientDTO
    {
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string IdentificationNumber { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate {  get; set; }
    }
}
