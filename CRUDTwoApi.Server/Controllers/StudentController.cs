using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDTwoApi.Server.Models;
using CRUDTwoApi.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUDTwoApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CrudMvcContext _context;

        public StudentController(CrudMvcContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllStudents()
        {
            var StudentList =  new List<StudentDTO>();

            try
            {
                foreach(var item  in await _context.Students.Include(c => c.StudentCareer).ToListAsync()) 
                {
                    StudentList.Add(new StudentDTO
                    {
                        StudentId = item.StudentId,
                        StudentFirstName = item.StudentFirstName,
                        StudentLastName = item.StudentLastName,
                        StudentCareerId = item.StudentCareerId,
                        StudentAdmissionDate = item.StudentAdmissionDate,
                        RegisterDate = item.RegisterDate,
                        Career = new CareerDTO
                        {
                            CareerId = item.StudentCareer!.CareerId,
                            CareerName = item.StudentCareer.CareerName,
                        }
                    });
                }

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(StudentList);
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var StudentDTO = new StudentDTO();

            try
            {
                var studentDb = await _context.Students.FindAsync(id);

                if(studentDb != null)
                {
                    StudentDTO.StudentId = studentDb.StudentId;
                    StudentDTO.StudentFirstName = studentDb.StudentFirstName;
                    StudentDTO.StudentLastName = studentDb.StudentLastName;
                    StudentDTO.StudentCareerId = studentDb.StudentCareerId;
                    StudentDTO.StudentAdmissionDate = studentDb.StudentAdmissionDate;
                    StudentDTO.RegisterDate = studentDb.RegisterDate;
                }
                else
                {
                    return NotFound("Student not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(StudentDTO);
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> InsertStudent(StudentDTO student)
        {
            var StudentDb = new Student();

            try
            {
                StudentDb.StudentId = student.StudentId;
                StudentDb.StudentFirstName = student.StudentFirstName;
                StudentDb.StudentLastName = student.StudentLastName;
                StudentDb.StudentCareerId = student.StudentCareerId;
                StudentDb.StudentAdmissionDate = student.StudentAdmissionDate;
                StudentDb.RegisterDate = student.RegisterDate;   
                
                _context.Students.Add(StudentDb);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", StudentDb);
        }


        [HttpPut]
        [Route("Put/{id}")]
        public async Task<IActionResult> UpdateStudent(StudentDTO student, int id)
        {

            try
            {
                var studentDb = await _context.Students.FindAsync(id);

                if (studentDb != null)
                {
                    studentDb.StudentId = student.StudentId;
                    studentDb.StudentFirstName = student.StudentFirstName;
                    studentDb.StudentLastName = student.StudentLastName;
                    studentDb.StudentCareerId = student.StudentCareerId;
                    studentDb.StudentAdmissionDate = student.StudentAdmissionDate;
                    studentDb.RegisterDate = student.RegisterDate;

                    _context.Students.Update(studentDb);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    return NotFound("Student not found");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentDb = await _context.Students.FindAsync(id);

                if (studentDb != null)
                {
                    _context.Students.Remove(studentDb);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    return NotFound("Student not found");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
