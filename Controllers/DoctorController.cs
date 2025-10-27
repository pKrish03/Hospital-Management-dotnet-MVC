using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    public class DoctorController : Controller
    {
        private readonly FirebaseService _firebase;

        public DoctorController(FirebaseService firebase)
        {
            _firebase = firebase;
        }

        // GET: Doctor/Index
        public async Task<IActionResult> Index()
        {
            var doctors = await _firebase.GetAllAsync<Doctor>("Doctors");
            return View(doctors);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.DoctorId = "D" + DateTime.Now.Ticks.ToString().Substring(8);
                doctor.JoinedDate = DateTime.Now;

                var result = await _firebase.SaveAsync("Doctors", doctor.DoctorId, doctor);

                if (result)
                {
                    TempData["Success"] = "Doctor added successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Failed to add doctor. Please try again.";
                }
            }

            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var doctor = await _firebase.GetByIdAsync<Doctor>("Doctors", id);
            
            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Doctor doctor)
        {
            if (id != doctor.DoctorId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var result = await _firebase.UpdateAsync("Doctors", id, doctor);

                if (result)
                {
                    TempData["Success"] = "Doctor updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Failed to update doctor. Please try again.";
                }
            }

            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var doctor = await _firebase.GetByIdAsync<Doctor>("Doctors", id);
            
            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _firebase.DeleteAsync("Doctors", id);

            if (result)
            {
                TempData["Success"] = "Doctor deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete doctor. Please try again.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}