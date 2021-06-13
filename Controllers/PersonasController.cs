using FilemanagerDemo.Aplicacion.Models;
using FilemanagerDemo.Controllers.RequestModels;
using FilemanagerDemo.DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilemanagerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        private ILogger<PersonasController> _logger;
        private readonly IPersonasStoredFunctions PersonasReader;
        public PersonasController(IPersonasStoredFunctions personasReader, ILogger<PersonasController> logger)
        {
            PersonasReader = personasReader;
            _logger = logger;
        }

        /// <summary>
        /// Devuelve una lista completa de personas almacenadas en la Base de Datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(PersonasReader.GetPersonas());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">El identificador del usuario</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation($"Controller: Personas, action: GetByID");
            return Ok();
        }

        /// <summary>
        /// Crear una nueva Persona
        /// </summary>
        /// <remarks>
        ///Sample request:
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        /// </remarks>
        /// <param name="persona"></param>
        /// <returns>applicattion/json</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult Post([FromBody] PersonaForCreation persona, [FromQuery] RequestInfo adicionalInfo)
        {
            return Ok();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            return Ok();
        }

        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
