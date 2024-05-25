using HealthSched.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.Models.Concrete
{
    public class Contact : BaseEntity
    {
        [Required(ErrorMessage ="Ad Soyad alanı zorunludur.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon numarası alanı zorunludur.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        public string Message { get; set; }
    }
}
