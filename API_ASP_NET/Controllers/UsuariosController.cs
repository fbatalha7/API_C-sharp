using APP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using API.Services.Validators;
using System.Net;
using APP.Domain.Interfaces;
using FluentValidation.Validators;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace API_ASP_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosService<Usuarios> _usuariosService;
        private IUsuariosRepository<Usuarios> _usuariosRepository;
        public UsuariosController(IUsuariosService<Usuarios> usuariosService, IUsuariosRepository<Usuarios> usuariosRepository)
        {
            _usuariosService = usuariosService;
            _usuariosRepository = usuariosRepository;
        }

        // GET: api/Usuarios/GetUsuarios
        [HttpGet("GetUsuarios")]
        public IActionResult Get()
        {
            return Execute(() => _usuariosService.SelectAll());
        }

        //GET api/Usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            return Execute(() => _usuariosService.SelectById(id));
        }

        // POST api/Usuarios/InsertUser
        [HttpPost("InsertUsuario")]
        public IActionResult InsertUser([FromBody] Usuarios user)
        {
            if (user == null)
                return NotFound();

            _usuariosRepository.ProcessRequests(user.ChannelType);

            ValidationExistId(user);

            return Execute(() => _usuariosService.Insert<UsuarioValidator>(user));
        }

        //// PUT api/<UsuariosController>/5
        [HttpPut("UpdateUsuario")]
        public IActionResult UpdateUsuario([FromBody] Usuarios user)
        {
            if (user == null)
                return NotFound();

            _usuariosRepository.ProcessRequests(user.ChannelType);

            return Execute(() => _usuariosService.Update<UsuarioValidator>(user));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                var a = ex.Errors;
                string errors = string.Empty;
                foreach (var error in a)
                {
                    if (error != null)
                    {
                        errors += error.ErrorMessage + "\n";
                    }
                }
                return BadRequest(errors);
                //return StatusCode((int)HttpStatusCode.InternalServerError, ex.GetBaseException().Message);
            }
        }

        private void ValidationExistId(Usuarios user)
        {
            List<Usuarios> ListaUsuarios = _usuariosService.SelectAll().ToList();

            user.Id = _usuariosRepository.GenerateId(ListaUsuarios);
        }

      
    }


}

