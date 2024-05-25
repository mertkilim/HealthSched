using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.Models.Models.Concrete;

namespace HealthSched.UI.Areas.Admin.Controllers.Doctor
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly SqlServerDbContext _context;

        public DoctorController(SqlServerDbContext context)
        {
            _context = context;
        }


    }
}
