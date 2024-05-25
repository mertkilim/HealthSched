using HealthSched.Models.DTOs.Appointment;
using HealthSched.Models.DTOs.AppointmentDTOs;
using HealthSched.Models.DTOs.DoctorDTOs;
using HealthSched.Models.Models.Concrete;

namespace HealthSched.UI.Models
{
    public class AppointmentViewModel
    {
        public Appointment ServerAppointment { get; set; }
        public AppointmentDTO ClientAppointment { get; set; }
        public CreateAppointmentDTO CreateAppointment { get; set; }
        public UpdateAppointmentDTO UpdateApointment { get; set; }
        public IEnumerable<Appointment> ServerAppointments { get; set; }
        public IEnumerable<AppointmentDTO> ClientAppointments { get; set; }
        public  IEnumerable<DoctorDTO> Doctors { get; set; }
    }
}
