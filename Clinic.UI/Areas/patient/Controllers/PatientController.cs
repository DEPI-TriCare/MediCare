using Clinic.Application.Contracts.AppointmentContracts;
using Clinic.Application.Contracts.PatientContract;
using Clinic.Application.Contracts.UserContract;
using Clinic.Application.DTOs.PatientDTOs;
using Clinic.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Clinic.UI.Areas.patient.Controllers
{
    [Area("patient")]
    [Authorize(Roles="Patient")]
    public class PatientController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public PatientController(IPatientService patientService, IUserService userService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _userService = userService;
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Details(int pageNumber = 1 , int pageSize = 5)
        {
            var patientId = await _patientService.GetPatientId();

            if (patientId == Guid.Empty)
            {
                return RedirectToAction("Add");
            }

            var result = await _patientService.GetPatientDetails(patientId);
            ViewBag.lstAppointments = await _appointmentService.GetPatientAppointments(patientId, pageNumber, pageSize);
            return View(result);
        }

        public async Task<IActionResult> Add()
        {
            var patientId = await _patientService.GetPatientId();

            if (patientId != Guid.Empty)
            {
                return RedirectToAction("Details");
            }

            var patient = new PatientDTO();

            ViewBag.lstGenders = new SelectList(Enum.GetValues(typeof(Gender)));
            ViewBag.lstBloodTypes = new SelectList(Enum.GetValues(typeof(BloodType)));

            patient.UserId = _userService.GetLoggedInUser().ToString();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(PatientDTO patientDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.lstGenders = new SelectList(Enum.GetValues(typeof(Gender)));
                ViewBag.lstBloodTypes = new SelectList(Enum.GetValues(typeof(BloodType)));

                return View("Add", patientDTO);
            }

            if (patientDTO.Id == Guid.Empty)
            {
                var result = await _patientService.AddPatient(patientDTO);

                if (!result.Item1)
                {
                    ViewBag.lstGenders = new SelectList(Enum.GetValues(typeof(Gender)));
                    ViewBag.lstBloodTypes = new SelectList(Enum.GetValues(typeof(BloodType)));
                    ModelState.AddModelError("", "Failed to add patient.");
                    return View("Edit", patientDTO);
                }
            }

            return RedirectToAction("Details");
        }
    }
}


