using HealthSched.Models.DTOs.TitleDTOs;
using HealthSched.Models.Models.Concrete;

namespace HealthSched.UI.Models
{
    public class TitleViewModel
    {
        public Title Title { get; set; }
        public IEnumerable<Title> Titles { get; set; }
    }
}
