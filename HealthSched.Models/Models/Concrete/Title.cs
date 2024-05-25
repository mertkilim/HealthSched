using HealthSched.Models.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.Models.Models.Concrete
{
    public class Title : BaseEntity
    {
        public string TitleName { get; set; }
        public ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();
    }
}
