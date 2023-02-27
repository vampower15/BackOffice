using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOffice officeData; //
        public OfficeController (IOffice office)
        {
            officeData = office;
        }

        [HttpGet("All")]
        public async Task<IActionResult> OfficeAll()
        {
            try
            {
                var names = await officeData.GetOfficeAllAsync();
                return Ok(names);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }          
        }

        [HttpGet("ByID")]
        public async Task<IActionResult> OfficeById(int id)
        {       
            try
            {
                var name = await officeData.GetOfficeByIdAsync(id);
                if (name == null)
                    return NotFound();

                return Ok(name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertOffcie(OfficeModel model)
        {
            try
            {
                await officeData.InsertOfficeAsync(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateOffice(int id, OfficeModel model)
        {
            try
            {
                var name = await officeData.GetOfficeByIdAsync(id);
                if (name == null)
                    return NotFound();

                await officeData.UpdateOfficeAsync(name.IdOf, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOffice(int id)
        {
            try
            {
                var name = await officeData.GetOfficeByIdAsync(id);
                if (name == null)
                    return NotFound();

                await officeData.DeleteOfficeAsync(name.IdOf);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
