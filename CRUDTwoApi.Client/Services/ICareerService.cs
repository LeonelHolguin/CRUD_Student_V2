using CRUDTwoApi.Shared;

namespace CRUDTwoApi.Client.Services
{
    public interface ICareerService
    {
        Task<List<CareerDTO>> GetAllCareer();
        Task<CareerDTO> GetCareer(int id);
        Task<bool> InsertCareer(CareerDTO career);
        Task<bool> UpdateCareer(CareerDTO career);
        Task<bool> DeleteCareer(int id);
        Task<bool> SaveHandle(CareerDTO career);

    }
}
