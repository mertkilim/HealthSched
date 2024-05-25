using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using HealthSched.DAL.Repositories.Abstract;
using HealthSched.Models.Models.Concrete;
using HealthSched.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthSched.UI.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;

        public ContactController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {
            if (contact == null)
            {
                _notyfService.Error("İletişim talebi gönderilemedi.Bilgilerinizi kontrol ediniz veya daha sonra tekrar deneyiniz.");
                return RedirectToAction("Index");
            }
            else
            {
                await _unitOfWork.Contact.AddAsync(contact);
                _notyfService.Success("İletişim talebiniz iletildi.En kısa sürede dönüş yapılacaktır.");
                return RedirectToAction("Index");
            }

        }
    }
}
