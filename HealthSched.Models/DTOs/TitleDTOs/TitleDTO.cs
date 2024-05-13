using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.DTOs.TitleDTOs
{
    public class TitleDTO
    {
        public int Id { get; set; }
        public string TitleName { get; set; }
        public ICollection<int>? DoctorIds { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
