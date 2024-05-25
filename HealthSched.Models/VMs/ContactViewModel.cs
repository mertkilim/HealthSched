using HealthSched.Models.Models.Concrete;

namespace HealthSched.UI.Models
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
