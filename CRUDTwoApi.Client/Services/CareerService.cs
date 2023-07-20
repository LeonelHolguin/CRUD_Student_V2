using CRUDTwoApi.Shared;
using Newtonsoft.Json;
using System.Text;

namespace CRUDTwoApi.Client.Services
{
    public class CareerService : ICareerService
    {
        private readonly HttpClient _Client;
        Uri BaseAddress = new Uri("http://localhost:5183/api/Career");

        public CareerService()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = BaseAddress;
        }

        public async Task<List<CareerDTO>> GetAllCareers()
        {
            List<CareerDTO> CareerList = new List<CareerDTO>();

            var result = await _Client.GetFromJsonAsync<List<CareerDTO>>(_Client.BaseAddress + "/Get");

            if(result != null)
                CareerList = result!;

            return CareerList;
        }

        public async Task<CareerDTO> GetCareer(int id)
        {
            CareerDTO Career = new CareerDTO();

            var result = await _Client.GetFromJsonAsync<CareerDTO>(_Client.BaseAddress + $"/Get/{id}");

            if (result != null)
                Career = result!;

            return Career;
        }

        public async Task<bool> InsertCareer(CareerDTO career)
        {
            var response = await _Client.PostAsJsonAsync(_Client.BaseAddress + "/Post", career);
          
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCareer(CareerDTO career)
        {
            var response = await _Client.PutAsJsonAsync(_Client.BaseAddress + $"/Put/{career.CareerId}", career);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> SaveHandle(CareerDTO career)
        {
            if (career.CareerId > 0)
                return await UpdateCareer(career);
            else
                return await InsertCareer(career);
        }

        public async Task<bool> DeleteCareer(int id)
        {
            var response = await _Client.DeleteAsync(_Client.BaseAddress + $"/Delete/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
