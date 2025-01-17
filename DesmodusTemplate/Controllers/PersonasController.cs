﻿using DesmodusTemplate.DTOs.Persona;
using DesmodusTemplate.LogicServices;
using Microsoft.AspNetCore.Mvc;

namespace DesmodusTemplate.Controllers
{
    [ApiController] //Validaciones automaticas respecto a los datos recividos
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaLS personaLS;

        public PersonasController(PersonaLS personaLS) {
            this.personaLS = personaLS;
        }
        [HttpGet]
        public async Task<ActionResult<List<DTO_Persona>>> GetListPersonas()
        {
            try
            {
                var data = await personaLS.GetListPersonas();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
    }
}
