using AspNetCoreHero.ToastNotification.Abstractions;
using HealthSched.DAL.Repositories.Abstract;
using HealthSched.Models.DTOs.TitleDTOs;
using HealthSched.Models.Models.Concrete;
using HealthSched.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HealthSched.UI.Areas.Admin.Controllers.Title
{
    [Area("Admin")]
    public class TitleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyfService;

        public TitleController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var objTitleList = await _unitOfWork.Title.GetAllAsync();

            _notyfService.Success("Title listesi görüntüleniyor.");
            return View(objTitleList);
        }

        public IActionResult Create()
        {
            CreateTitleDTO insertVM = new CreateTitleDTO();
            return View(insertVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTitleDTO titleModel)
        {
            if (ModelState.IsValid)
            {
                HealthSched.Models.Models.Concrete.Title title = new()
                {
                    TitleName = titleModel.TitleName,
                };
                try
                {
                    var result = await _unitOfWork.Title.AddAsync(title);
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

            return View(titleModel);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("ID boş olamaz.");
            }

            var title = await _unitOfWork.Title.GetByIdAsync(id);

            if (title == null)
            {
                return NotFound("İlgili id'ye bağlı kayıt bulunamadı.");
            }

            await _unitOfWork.Title.DeleteAsync(title);
            _notyfService.Success("Kayıt Silindi.");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("Id boş olamaz");
            }

            var title = await _unitOfWork.Title.GetByIdAsync(id);

            if (title == null)
            {
                return NotFound("İlgili id'ye bağlı kayıt bulunamadı.");
            }
            return View(title);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HealthSched.Models.DTOs.TitleDTOs.UpdateTitleDTO updateTitleDTO)
        {
            if (ModelState.IsValid)
            {
                var title = await _unitOfWork.Title.GetAsync(x => x.Id == updateTitleDTO.Id);

                title.Id = updateTitleDTO.Id;
                title.UpdatedDate = DateTime.UtcNow.AddHours(3);
                title.TitleName = updateTitleDTO.TitleName;
                title.isDeleted = false; 

                await _unitOfWork.Title.UpdateAsync(title);
                _notyfService.Success("Başarılı");
                return RedirectToAction("Index");


                //await _unitOfWork.Title.UpdateAsync(title);
                //title.UpdatedDate = DateTime.Now;
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

            var title = await _unitOfWork.Title.GetAsync(x => x.Id == id, "Doctors");

            if (title == null)
            {
                return NotFound("Kayıtlı doktor bulunamadı.");
            }
            return View(title);
        }

    }
}
