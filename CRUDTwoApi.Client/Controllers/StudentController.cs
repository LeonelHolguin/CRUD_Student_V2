using CRUDTwoApi.Client.Services;
using CRUDTwoApi.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CRUDTwoApi.Client.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICareerService _careerService;

        public StudentController(IStudentService studentService, ICareerService careerService)
        {
            _studentService = studentService;
            _careerService = careerService;
        }

        public async Task<IActionResult> Index()
        {
            List<StudentDTO> studentList = await _studentService.GetAllStudent();
            return View(studentList);

        }

        public async Task<IActionResult> Details(int id)
        {
            List<CareerDTO> careerList = await _careerService.GetAllCareers(); 
            StudentDTO studentModel = new StudentDTO();

            studentModel.CareerList = careerList;

            if(id != 0)
                studentModel = await _studentService.GetStudent(id);
                studentModel.CareerList = careerList;


            return View(studentModel);
        }


        [HttpPost]
        public async Task<IActionResult> SaveChanges(StudentDTO student)
        {
            bool response = await _studentService.SaveHandle(student);

            if(response)
                return RedirectToAction("Index");
            else
                return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _studentService.DeleteStudent(id);

            if (response)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}
