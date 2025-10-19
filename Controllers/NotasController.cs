using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TakeNote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly Services.NotasServices _notasServices;

        public NotasController(Services.NotasServices notasServices)
        {
            _notasServices = notasServices;
        }

        [HttpGet]
        public async Task<IActionResult> ListarNotas()
        {
            var nota = await _notasServices.ListarNotasAsync();
            return Ok(nota);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarNotasPorId(Guid id)
        {
            var nota = await _notasServices.ListarNotaPorIdAsync(id);
            return Ok(nota);
        }

        [HttpPost]
        public async Task<IActionResult> CriarNota([FromBody] Models.Nota novaNota)
        {
            var nota = await _notasServices.CriarNotaAsync(novaNota);
            return CreatedAtAction(nameof(ListarNotasPorId), new { id = nota.Id }, nota);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarNota(Guid id, [FromBody] Models.Nota novaNota)
        {
            var nota = await _notasServices.AtualizarNotaAsync(id, novaNota);
            return Ok(nota);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarNota(Guid id)
        {
            await _notasServices.DeletarNotaAsync(id);
            return NoContent();
        }
    }
}