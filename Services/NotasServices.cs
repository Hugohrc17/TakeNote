using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TakeNote.Services
{
    public class NotasServices
    {
        private readonly Data.ApplicationDbContext _context;

        public NotasServices(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Nota>> ListarNotasAsync()
        {
            return await _context.Notas.ToListAsync();
        }

        public async Task<Models.Nota> ListarNotaPorIdAsync(Guid id)
        {
            var nota = await _context.Notas.FindAsync(id);

            if (nota == null)
            {
                throw new Exception("Nota não encontrada.");
            }

            return nota;
        }

        public async Task<Models.Nota> CriarNotaAsync(Models.Nota novaNota)
        {
            novaNota.Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(novaNota.Titulo))
            {
                novaNota.Titulo = "Sem Título";
            }

            _context.Notas.Add(novaNota);
            await _context.SaveChangesAsync();

            return novaNota;
        }

        public async Task<Models.Nota> AtualizarNotaAsync(Guid id, Models.Nota novaNota)
        {
            var notaExistente = await _context.Notas.FindAsync(id);

            if (notaExistente == null)
            {
                throw new Exception("Nota não encontrada.");
            }

            notaExistente.Titulo = novaNota.Titulo;
            notaExistente.Conteudo = novaNota.Conteudo;
            
            await _context.SaveChangesAsync();

            return notaExistente;
        }
        
        public async Task<bool> DeletarNotaAsync(Guid id)
        {
            var notaExistente = await _context.Notas.FindAsync(id);

            if (notaExistente == null)
            {
                return false;
            }

            _context.Notas.Remove(notaExistente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
