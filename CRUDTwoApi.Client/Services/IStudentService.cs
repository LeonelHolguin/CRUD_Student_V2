using CRUDTwoApi.Shared;

namespace CRUDTwoApi.Client.Services
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllStudent();
        Task<StudentDTO> GetStudent(int id);
        Task<bool> InsertStudent(StudentDTO student);
        Task<bool> UpdateStudent(StudentDTO student);
        Task<bool> DeleteStudent(int id);
        Task<bool> SaveHandle(StudentDTO student);
    }
}
