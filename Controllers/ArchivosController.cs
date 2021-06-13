using FilemanagerDemo.Aplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FilemanagerDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArchivosController : ControllerBase
    {
        private readonly LocalFileStorageOptions FileStorage;
        public ArchivosController(IOptions<LocalFileStorageOptions> fileStorage)
        {
            FileStorage = fileStorage.Value ?? throw new ArgumentNullException(nameof(fileStorage));
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Directory.EnumerateFiles(Path.Combine(FileStorage.BaseDirectory, "dotnet/randomfiles"))
                .Select(str => new FileInfo(str).Name);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult Post()
        {
            return Accepted();
        }

        /// <summary>
        /// Almacena un archivo y devuelve 
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("dotnet", "randomfiles");
                var pathToSave = Path.Combine(FileStorage.BaseDirectory, folderName);
                if (!Directory.Exists(pathToSave)) Directory.CreateDirectory(pathToSave);
                if (file.Length > 0)
                {
                    // var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileName = Guid.NewGuid().ToString();
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Borra el archivo con el GUID especificado
        /// </summary>
        /// <param name="FileGuid" value="5f1e9426-46d7-4323-a733-a61b768acdca"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("{FileGuid}")]
        public ActionResult Delete(string FileGuid)
        {
            if (System.IO.File.Exists(Path.Combine(FileStorage.BaseDirectory, "dotnet/randomfiles", FileGuid)))
            {
                return Ok();
            }
            return NotFound("¡Archivo no encontrado!");
        }
    }
}
