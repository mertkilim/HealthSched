using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.Models.Models.Concrete;
using HealthSched.Models.DTOs.TitleDTOs;
using HealthSched.DAL.Repositories.Abstract;
using AspNetCoreHero.ToastNotification.Abstractions;
using HealthSched.DAL.Repositories.Concrete;
using HealthSched.Models.DTOs.PoliclinicDTOs;
using HealthSched.Utility;
using Microsoft.AspNetCore.Authorization;

namespace HealthSched.UI.Areas.Admin.Controllers.Policlinic
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class PoliclinicController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;

        public PoliclinicController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var objPoliclinicList = await _unitOfWork.Policlinic.GetAllAsync();

            _notyfService.Success("Poliklinik listesi görüntüleniyor.");
            return View(objPoliclinicList);
        }

        public IActionResult Create()
        {
            CreatePoliclinicDTO insertVM = new CreatePoliclinicDTO();
            return View(insertVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePoliclinicDTO policlinicModel)
        {
            if (ModelState.IsValid)
            {
                HealthSched.Models.Models.Concrete.Policlinic pol = new()
                {
                    PoliclinicName = policlinicModel.PoliclinicName,
                };
                try
                {
                    var result = await _unitOfWork.Policlinic.AddAsync(pol);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _notyfService.Error("Kullanıcı Oluşturulamadı.");
                    return View();
                }

                _notyfService.Success("Kayıt Oluşturuldu.");
                return RedirectToAction("Index");
            }

            return View(policlinicModel);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("ID boş olamaz.");
            }

            var policlinic = await _unitOfWork.Policlinic.GetByIdAsync(id);

            if (policlinic == null)
            {
                return NotFound("İlgili id'ye bağlı kayıt bulunamadı.");
            }

            await _unitOfWork.Policlinic.DeleteAsync(policlinic);
            _notyfService.Success("Kayıt Silindi.");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("Id boş olamaz");
            }

            var policlinic = await _unitOfWork.Policlinic.GetByIdAsync(id);

            if (policlinic == null)
            {
                return NotFound("İlgili id'ye bağlı kayıt bulunamadı.");
            }
            return View(policlinic);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePoliclinicDTO policlinic)
        {
            if (ModelState.IsValid)
            {
                var pol = await _unitOfWork.Policlinic.GetAsync(x => x.Id == policlinic.Id);

                pol.Id = policlinic.Id;
                pol.UpdatedDate = DateTime.UtcNow.AddHours(3);
                pol.PoliclinicName = policlinic.PoliclinicName;
                pol.isDeleted = false;

                await _unitOfWork.Policlinic.UpdateAsync(pol);
                _notyfService.Success("Başarılı");
                return RedirectToAction("Index");

                //await _unitOfWork.Policlinic.UpdateAsync(policlinic);
                //_notyfService.Success("Düzenleme İşlemi başarılı");
                //return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> GetDoctors(int? id)
        {
            if (id == null)
            {
                return NotFound("Id boş olamaz");
            }

            var pol = await _unitOfWork.Policlinic.GetAsync(x => x.Id == id, "Policlinics");

            if (pol == null)
            {
                return NotFound("Kayıtlı poliklinik bulunamadı.");
            }
            return View(pol);
        }

    }
}
