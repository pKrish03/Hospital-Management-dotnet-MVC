using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly FirebaseService _firebase;

        public AppointmentController(FirebaseService firebase)
        {
            _firebase = firebase;
        }

        // GET: Appointment/Index
        public async Task<IActionResult> Index()
        {
            var appointments = await _firebase.GetAllAsync<Appointment>("Appointments");
            return View(appointments);
        }

        // GET: Appointment/Create
        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.AppointmentId = "A" + DateTime.Now.Ticks.ToString().Substring(8);
                appointment.CreatedDate = DateTime.Now;
                appointment.Status = "Scheduled";

                // Get patient and doctor names
                var patient = await _firebase.GetByIdAsync<Patient>("Patients", appointment.PatientId);
                var doctor = await _firebase.GetByIdAsync<Doctor>("Doctors", appointment.DoctorId);

                if (patient != null)
                    appointment.PatientName = patient.Name;
                
                if (doctor != null)
                    appointment.DoctorName = doctor.Name;

                var result = await _firebase.SaveAsync("Appointments", appointment.AppointmentId, appointment);

                if (result)
                {
                    TempData["Success"] = "Appointment scheduled successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Failed to schedule appointment. Please try again.";
                }
            }

            await LoadDropdowns();
            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var appointment = await _firebase.GetByIdAsync<Appointment>("Appointments", id);
            
            if (appointment == null)
                return NotFound();

            await LoadDropdowns();
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Get patient and doctor names
                var patient = await _firebase.GetByIdAsync<Patient>("Patients", appointment.PatientId);
                var doctor = await _firebase.GetByIdAsync<Doctor>("Doctors", appointment.DoctorId);

                if (patient != null)
                    appointment.PatientName = patient.Name;
                
                if (doctor != null)
                    appointment.DoctorName = doctor.Name;

                var result = await _firebase.UpdateAsync("Appointments", id, appointment);

                if (result)
                {
                    TempData["Success"] = "Appointment updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Failed to update appointment. Please try again.";
                }
            }

            await LoadDropdowns();
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var appointment = await _firebase.GetByIdAsync<Appointment>("Appointments", id);
            
            if (appointment == null)
                return NotFound();

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _firebase.DeleteAsync("Appointments", id);

            if (result)
            {
                TempData["Success"] = "Appointment deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete appointment. Please try again.";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadDropdowns()
        {
            var patients = await _firebase.GetAllAsync<Patient>("Patients");
            var doctors = await _firebase.GetAllAsync<Doctor>("Doctors");

            ViewBag.Patients = new SelectList(patients, "PatientId", "Name");
            ViewBag.Doctors = new SelectList(doctors, "DoctorId", "Name");
        }
    }
}