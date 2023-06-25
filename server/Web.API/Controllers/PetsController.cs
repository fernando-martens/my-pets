using Microsoft.AspNetCore.Mvc;
using Web.Business.Interfaces;
using Web.Models.DTO;

namespace Web.API.Controllers
{

    public class PetsController : BaseController
    {

        private readonly IPetsBusiness petsBusiness;

        public PetsController(IPetsBusiness petsBusiness)
        {
            this.petsBusiness = petsBusiness;
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] PetDTO dto)
        {
            petsBusiness.Insert(dto);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] PetDTO dto)
        {
            petsBusiness.Update(dto);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(petsBusiness.GetAll());
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromBody] PetDTO dto)
        {
            petsBusiness.Delete(dto);
            return Ok();
        }

    }

}