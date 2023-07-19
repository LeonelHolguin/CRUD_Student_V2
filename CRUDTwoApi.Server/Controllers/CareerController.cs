using CRUDTwoApi.Server.Models;
using CRUDTwoApi.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDTwoApi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        private readonly CrudMvcContext _context;

        public CareerController(CrudMvcContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllCareers()
        {
            var CareerList =  new List<CareerDTO>();

            try
            {
                foreach(var item  in await _context.Careers.ToListAsync()) 
                {
                    CareerList.Add(new CareerDTO
                    {
                        CareerId = item.CareerId,
                        CareerName = item.CareerName,
                    });
                }

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(CareerList);
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetCareer(int id)
        {
            var CareerDTO = new CareerDTO();

            try
            {
                var CareerDb = await _context.Careers.FindAsync(id);

                if(CareerDb != null)
                {
                    CareerDTO.CareerId = CareerDb.CareerId;
                    CareerDTO.CareerName = CareerDb.CareerName;
                }
                else
                {
                    return NotFound("Career not found");
                }
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(CareerDTO);
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> InsertCareer(CareerDTO career)
        {
            var CareerDb = new Career();

            try
            {

                CareerDb.CareerId = career.CareerId;
                CareerDb.CareerName = career.CareerName;


                _context.Careers.Add(CareerDb);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", CareerDb);
        }



        [HttpPut]
        [Route("Put/{id}")]
        public async Task<IActionResult> UpdateCareer(CareerDTO career, int id)
        {

            try
            {
                var CareerDb = await _context.Careers.FindAsync(id);

                if(CareerDb != null)
                {
                    CareerDb.CareerId = career.CareerId;
                    CareerDb.CareerName = career.CareerName;

                    _context.Careers.Update(CareerDb);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound("Career not found");
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
        public async Task<IActionResult> DeleteCareer(int id)
        {
            try
            {
                var CareerDb = await _context.Careers.FindAsync(id);

                if (CareerDb != null)
                {
                    _context.Careers.Remove(CareerDb);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound("Career not found");
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
