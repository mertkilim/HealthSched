using AspNetCoreHero.ToastNotification.Abstractions;
using HealthSched.DAL.Repositories.Abstract;
using HealthSched.UI.Models;
using HealthSched.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthSched.UI.Areas.Admin.Controllers.Contact
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;

        public ContactController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }

        [HttpPost]
        public async Task<IActionResult> Call(int? id)
        {
            if (id == null)
            {
                return BadRequest("ID boş olamaz.");
            }

            var cont = await _unitOfWork.Contact.GetByIdAsync(id);

            if (cont == null)
            {
                return NotFound("İlgili id'ye bağlı kayıt bulunamadı.");
            }

            await _unitOfWork.Contact.DeleteAsync(cont);
            _notyfService.Success("İletişime Geçildi.");
            return RedirectToAction("Contact");
        }

        public async Task<IActionResult> Contact()
        {
            var contacts = await _unitOfWork.Contact.GetAllAsync();
            var contactViewModel = new ContactViewModel
            {
                Contacts = contacts,
            };
            return View(contactViewModel);
        }
    }
}
