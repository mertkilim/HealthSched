using HealthSched.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HealthSched.UI.Areas.Admin.Controllers.Patient
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var objTitleList = await _unitOfWork.Patient.GetAllAsync();
            return View(objTitleList);
        }
    }
}
