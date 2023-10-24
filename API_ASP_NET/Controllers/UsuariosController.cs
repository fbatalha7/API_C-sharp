using APP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using API.Services.Validators;
using System.Net;
using APP.Domain.Interfaces;
using FluentValidation.Validators;
using System.Xml;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API_ASP_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
      
        private List<Usuarios>? _dados;
        private IUsuariosService<Usuarios> _usuariosService;
        public UsuariosController(IUsuariosService<Usuarios> usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // GET: api/Usuarios/GetUsuarios
        [HttpGet("GetUsuarios")]
        public IActionResult Get()
        {
            try
            {
                 _dados = _usuariosService.SelectAll().ToList();

                return Ok(_dados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //GET api/Usuarios/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Usuario = _usuariosService.SelectById(id);

                return Ok(Usuario);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/Usuarios/InsertUser
        [HttpPost("InsertUsuario")]
        public IActionResult InsertUser([FromBody] Usuarios user)
        {
            if (user == null)
                return NotFound();

            List<Usuarios> ListaUsuarios = _usuariosService.SelectAll().ToList();
            var Exist =  ListaUsuarios.Exists(x=>x.Id == user.Id);

            if (Exist)
                user.Id += 1000;

            return Execute(() => _usuariosService.Insert<UsuarioValidator>(user));
        }

        //// PUT api/<UsuariosController>/5
        [HttpPut("UpdateUsuario")]
        public IActionResult UpdateUsuario([FromBody] Usuarios user)
        {
            if (user == null)
                return NotFound();

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


      
    }
}

