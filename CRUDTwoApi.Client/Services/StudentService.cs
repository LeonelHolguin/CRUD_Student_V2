using CRUDTwoApi.Shared;
using Newtonsoft.Json;
using System.Text;

namespace CRUDTwoApi.Client.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _Client;
        Uri BaseAddress = new Uri("http://localhost:5183/api/Student");

        public StudentService()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = BaseAddress;
        }

        public async Task<List<StudentDTO>> GetAllStudent()
        {
            List<StudentDTO> StudentList = new List<StudentDTO>();

            var result = await _Client.GetFromJsonAsync<List<StudentDTO>>(_Client.BaseAddress + "/Get");

            if (result != null)
                StudentList = result!;

            return StudentList;
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            StudentDTO Student = new StudentDTO();

            var result = await _Client.GetFromJsonAsync<StudentDTO>(_Client.BaseAddress + $"/Get/{id}");

            if (result != null)
                Student = result!;

            return Student;
        }

        public async Task<bool> InsertStudent(StudentDTO student)
        {
            var response = await _Client.PostAsJsonAsync(_Client.BaseAddress + "/Post", student);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateStudent(StudentDTO student)
        {
            var response = await _Client.PutAsJsonAsync(_Client.BaseAddress + $"/Put/{student.StudentId}", student);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SaveHandle(StudentDTO student)
        {
            if (student.StudentId > 0)
                return await UpdateStudent(student);
            else
                return await InsertStudent(student);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var response = await _Client.DeleteAsync(_Client.BaseAddress + $"/Delete/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
