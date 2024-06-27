using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.Models.Models.Concrete;
using HealthSched.Utility;
using Microsoft.AspNetCore.Authorization;
using HealthSched.DAL.Repositories.Abstract;
using AspNetCoreHero.ToastNotification.Abstractions;
using HealthSched.Models.DTOs.DoctorDTOs;
using HealthSched.Models.DTOs.Doctor;

namespace HealthSched.UI.Areas.Admin.Controllers.Doctor
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;  

        public DoctorController(IUnitOfWork unitOfWork,INotyfService notyfService)
        {
            _notyfService = notyfService;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IActionResult> Index () 
        {
            var docObjList = await _unitOfWork.Doctor.GetAllAsync();
            _notyfService.Success("Doktor listesi görüntüleniyor.");
            return View(docObjList);
        }

        public IActionResult Create ()
        {
            CreateDoctorDTO doctorDTO = new CreateDoctorDTO();
            return View(doctorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create (CreateDoctorDTO doctorDTO)
        {
            if (ModelState.IsValid)
            {
                HealthSched.Models.Models.Concrete.Doctor doc = new()
                {
                    DoctorName = doctorDTO.DoctorName,
                    DoctorSurname = doctorDTO.DoctorSurname,
                    Email = doctorDTO.Email,
                    IdentificationNumber = doctorDTO.IdentificationNumber,
                    Password = doctorDTO.Password,
                    PhoneNumber = doctorDTO.PhoneNumber
                };
                try
                {
                    var result = await _unitOfWork.Doctor.AddAsync(doc);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _notyfService.Error("Doktor Oluşturulamadı.");
                    return View();
                }

                _notyfService.Success("Kayıt Oluşturuldu.");
                return RedirectToAction("Index");
            }

            return View(doctorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
            {
                return BadRequest("ID boş olamaz.");
            }

            var doc = await _unitOfWork.Doctor.GetByIdAsync(id);

            if (doc == null)
            {
                return NotFound("İlgili Id'ye bağlı kayıt bulunamadı.");
            }

            await _unitOfWork.Doctor.DeleteAsync(doc);
            _notyfService.Success("Kayıt Silindi.");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return BadRequest("Id boş olamaz.");
            }

            var doc = await _unitOfWork.Doctor.GetByIdAsync(id);

            if(doc == null)
            {
                return NotFound("İlgili Id'ye bağlı kayıt bulunamadı.");
            }

            return View(doc);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (UpdateDoctorDTO doctorDTO)
        {
            if (!ModelState.IsValid)
            {
                var doc = await _unitOfWork.Doctor.GetAsync(x => x.Id == doctorDTO.Id);

                doc.Id = doctorDTO.Id;
                doc.UpdatedDate = DateTime.UtcNow.AddHours(3);
                doc.DoctorName = doctorDTO.DoctorName;
                doc.DoctorSurname = doctorDTO.DoctorSurname;
                doc.PhoneNumber = doctorDTO.PhoneNumber;
                doc.Email = doctorDTO.Email;
                doc.isDeleted = false;
                doc.Password = doctorDTO.Password;
                doc.TitleId = doctorDTO.TitleId;

                await _unitOfWork.Doctor.UpdateAsync(doc);
                _notyfService.Success("Başarılı!");
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> GetPoliclinics()
        {
            return View();
        }

        public async Task<IActionResult> GetPatients()
        {
            return View();
        }



    }
}
