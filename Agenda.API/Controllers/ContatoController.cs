using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Agenda.API.Models.Contatos;
using AgendaADONet.Classes;
using AgendaADONet.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        // GET: api/Contato
        [HttpGet]
        public IActionResult Get()
        {
            ContatoDAO contatoDao = new ContatoDAO();

            DataTable contato = contatoDao.GetContatos();

            return Ok(JsonSerialize(contato));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            ContatoDAO contatoDao = new ContatoDAO();
            DataTable contato = contatoDao.GetContato(id);

            return Ok(JsonSerialize(contato));
        }

        [HttpPost]
        public IActionResult InsertContato([FromBody]InsertContatoRequest request)
        {
            ContatoDAO contatoDao = new ContatoDAO();
            Contato contato = new Contato();

            // DE - PARA
            contato.Email = request.Email;
            contato.Nome = request.Nome;
            contato.Telefone = request.Telefone;
            contatoDao.Inserir(contato);

            return Ok();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteContato(int id)
        {
            ContatoDAO contatoDao = new ContatoDAO();
            contatoDao.Excluir(id);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContato([FromBody]UpdateContatoRequest request)
        {
            ContatoDAO contatoDao = new ContatoDAO();
            Contato contato = new Contato();
            contato.Id = request.ID;
            contato.Email = request.Email;
            contato.Nome = request.Nome;
            contato.Telefone = request.Telefone;

            contatoDao.Atualizar(contato);
            return Ok();
        }


        //[HttpDelete("{id:int}")] 

        private string JsonSerialize(object value)
        {
            var settings = new JsonSerializerSettings

            {
                Converters = new List<JsonConverter>(),
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
            };
            string json = JsonConvert.SerializeObject(value, settings);

            return json;
        }
    }
}
