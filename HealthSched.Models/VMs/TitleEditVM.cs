using HealthSched.Models.Models.Concrete;

namespace HealthSched.UI.Models
{
    public class TitleEditVM
    {
        public Title? Title { get; set; }
        public IEnumerable<Title>? Titles { get; set; }
    }
}
