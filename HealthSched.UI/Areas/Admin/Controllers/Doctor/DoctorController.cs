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

namespace HealthSched.UI.Areas.Admin.Controllers.Doctor
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DoctorController : Controller
    {
        private readonly SqlServerDbContext _context;

        public DoctorController(SqlServerDbContext context)
        {
            _context = context;
        }


    }
}
