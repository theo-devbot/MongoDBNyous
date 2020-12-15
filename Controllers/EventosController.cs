using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBNyous.Domains;
using MongoDBNyous.Interfaces;
using MongoDBNyous.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBNyous.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventoRepository _eventoRepository;

        public EventosController(EventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public ActionResult<List<EventoDomain>> Get()
        {
            try
            {
                return _eventoRepository.Listar();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<List<EventoDomain>> GetById(string id)
        {
            try
            {
                var evento = _eventoRepository.BuscarPorId(id);
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<EventoDomain> Create(EventoDomain evento)
        {
            try
            {
                _eventoRepository.Adicionar(evento);
                return Ok(evento);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<EventoDomain> Delete(string id)
        {
            try
            {
                _eventoRepository.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, EventoDomain evento)
        {
            try
            {
                evento.Id = id;
                _eventoRepository.Atualizar(id, evento);
                return Ok(evento);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}