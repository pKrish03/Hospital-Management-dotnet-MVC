using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;
using System.Diagnostics;

namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FirebaseService _firebase;

        public HomeController(ILogger<HomeController> logger, FirebaseService firebase)
        {
            _logger = logger;
            _firebase = firebase;
        }

        public async Task<IActionResult> Index()
        {
            // Get statistics for dashboard
            var patients = await _firebase.GetAllAsync<Patient>("Patients");
            var doctors = await _firebase.GetAllAsync<Doctor>("Doctors");
            var appointments = await _firebase.GetAllAsync<Appointment>("Appointments");

            ViewBag.PatientCount = patients.Count;
            ViewBag.DoctorCount = doctors.Count;
            ViewBag.AppointmentCount = appointments.Count;
            ViewBag.TodayAppointments = appointments.Count(a => a.AppointmentDate.Date == DateTime.Today);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}   