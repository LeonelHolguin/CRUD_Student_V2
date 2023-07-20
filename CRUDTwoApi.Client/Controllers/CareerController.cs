using CRUDTwoApi.Client.Services;
using CRUDTwoApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CRUDTwoApi.Client.Controllers
{
    public class CareerController : Controller
    {
        private readonly ICareerService _careerService;

        public CareerController(ICareerService careerService)
        {
            _careerService = careerService;
        }

        public async Task<IActionResult> Index()
        {
            List<CareerDTO> careerList = await _careerService.GetAllCareers();
            return View(careerList);

        }

        public async Task<IActionResult> Details(int id)
        {
            CareerDTO careerModel = new CareerDTO();

            if (id != 0)
                careerModel = await _careerService.GetCareer(id);

            return View(careerModel);
        }


        [HttpPost]
        public async Task<IActionResult> SaveChanges(CareerDTO career)
        {
            bool response = await _careerService.SaveHandle(career);

            if (response)
                return RedirectToAction("Index");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _careerService.DeleteCareer(id);

            if (response)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}
