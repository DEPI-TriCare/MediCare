using Clinic.Application.Contracts.DoctorContract;
using Clinic.Application.Contracts.SpecializationContract;
using Clinic.Application.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Clinic.UI.Areas.patient.Controllers
{
    [Area("patient")]
    [Authorize(Roles ="Patient")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ISpecializationService _specializationService;

        public DoctorController(IDoctorService doctorService, ISpecializationService specializationService)
        {
            _doctorService = doctorService;
            _specializationService = specializationService;
        }

        public async Task<IActionResult> Index(SearchDoctor search, int pageNumber = 1, int pageSize = 10)
        {
            ViewBag.lstSpecializations = await _specializationService.GetAll();
            var result = await _doctorService.SearchDoctors(search, pageNumber, pageSize);
            return View(result);
        }

        public async Task<IActionResult> Details(Guid Id)
        {
            var result = await _doctorService.GetDoctorDetails(Id);

            if (result == null)
            {
                return NotFound("Doctor Not Found");
            }

            return View(result);
        }
    }
}

