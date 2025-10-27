using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    public class PatientController : Controller
    {
        private readonly FirebaseService _firebase;

        public PatientController(FirebaseService firebase)
        {
            _firebase = firebase;
        }

        // GET: Patient/Index
        public async Task<IActionResult> Index()
        {
            var patients = await _firebase.GetAllAsync<Patient>("Patients");
            return View(patients);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.PatientId = "P" + DateTime.Now.Ticks.ToString().Substring(8);
                patient.RegisteredDate = DateTime.Now;

                var result = await _firebase.SaveAsync("Patients", patient.PatientId, patient);

                if (result)
                {
                    TempData["Success"] = "Patient registered successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Failed to register patient. Please try again.";
                }
            }

            return View(patient);
        }

        // GET: Patient/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var patient = await _firebase.GetByIdAsync<Patient>("Patients", id);
            
            if (patient == null)
                return NotFound();

            return View(patient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Patient patient)
        {
            if (id != patient.PatientId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _firebase.UpdateAsync("Patients", id, patient);

                if (result)
                {
                    TempData["Success"] = "Patient updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Failed to update patient. Please try again.";
                }
            }

            return View(patient);
        }

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var patient = await _firebase.GetByIdAsync<Patient>("Patients", id);
            
            if (patient == null)
                return NotFound();

            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _firebase.DeleteAsync("Patients", id);

            if (result)
            {
                TempData["Success"] = "Patient deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete patient. Please try again.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}