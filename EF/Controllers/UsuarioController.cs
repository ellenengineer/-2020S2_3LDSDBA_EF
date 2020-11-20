using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF.Models;
using EF.Aplicacao;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF.Controllers
{
    [Route("fapen/login1")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private INFONEWContext _contexto;

        public UsuarioController(INFONEWContext contexto)
        {
            _contexto = contexto;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public string Post([FromBody] Login usr)
        {
            UsuarioAplicacao usuApp = new UsuarioAplicacao(_contexto);
           var usuarioLogado = usuApp.GetUserByLogin(usr.Login1, usr.Senha);

            if(usuarioLogado != null)
            {
                return "Usuario Logado";
            }
            else
            {
                return "Login ou senha invalidos";
            }


        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Login login)
        {
            UsuarioAplicacao usuApp = new UsuarioAplicacao(_contexto);
            if (login.Id> 0)
            {
                usuApp.AtualizarCliente(login);
            }
            else
            {
                usuApp.InserirCliente(login);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
