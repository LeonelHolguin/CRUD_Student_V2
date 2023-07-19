using CRUDTwoApi.Shared;
using Newtonsoft.Json;

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

        public async Task<List<CareerDTO>> GetAllCareer()
        {
            List<CareerDTO> CareerList = new List<CareerDTO>();

            var response = await _Client.GetAsync(_Client.BaseAddress + "/Get");

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CareerDTO>>(json);

                CareerList = result!;
            }

            return CareerList;
        }

        public Task<CareerDTO> GetCareer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertCareer(CareerDTO career)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCareer(CareerDTO career)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveHandle(CareerDTO career)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCareer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
