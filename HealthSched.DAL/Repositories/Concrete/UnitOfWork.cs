using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerDbContext _context;

        public IAppointmentRepository Appointment { get; private set; }

        public IDoctorRepository Doctor { get; private set; }

        public IPatientRepository Patient { get; private set; }

        public IPoliclinicRepository Policlinic { get; private set; }

        public ITitleRepository Title { get; private set; }

        public IContactRepository Contact { get; private set; }

        public UnitOfWork( SqlServerDbContext context)
        {
            _context = context;
            Appointment = new AppointmentRepository(_context);
            Doctor = new DoctorRepository(_context);
            Patient = new PatientRepository(_context);
            Title = new TitleRepository(_context);
            Policlinic = new PoliclinicRepository(_context);
            Contact = new ContactRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
