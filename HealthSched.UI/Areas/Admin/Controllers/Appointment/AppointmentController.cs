using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.Models.Models.Concrete;
using HealthSched.DAL.Repositories.Abstract;

namespace HealthSched.UI.Areas.Admin.Controllers.Appointment
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
