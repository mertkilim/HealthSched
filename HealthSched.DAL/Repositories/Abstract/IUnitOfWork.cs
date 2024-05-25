using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        public IAppointmentRepository Appointment { get; }
        public IDoctorRepository Doctor { get; }
        public IPatientRepository Patient { get; }
        public IPoliclinicRepository Policlinic { get; }
        public ITitleRepository Title { get; }
        public IContactRepository Contact { get; }

        void Save();
    }
}
