using Microsoft.EntityFrameworkCore;
using QueroNotaFiscal.Models;

namespace QueroNotaFiscal.Database.Repository.FiscalNote
{
    public class FiscalNoteRepository : IFiscalNoteRepository
    {
        private readonly AppDbContext _context;
        public FiscalNoteRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(FiscalNoteEntity fiscalNote)
        {
            await _context.FiscalNotes.AddAsync(fiscalNote);
        }

        public async Task<IEnumerable<FiscalNoteEntity>> GetAllAsync()
        {
            var fiscalNotes = await _context.FiscalNotes.ToListAsync();
            return fiscalNotes;
        }

        public async Task<FiscalNoteEntity> GetByIssuingCNPJAsync(string cnpj)
        {
           var fiscalNote = await _context.FiscalNotes.FirstOrDefaultAsync(f => f.CNPJIssuing == cnpj);

           return fiscalNote;
        }

        public Task<FiscalNoteEntity?> GetByIdAsync(int fiscalNoteId)
        {
            var fiscalNote = _context.FiscalNotes
                .FirstOrDefaultAsync(f => f.FiscalNoteId == fiscalNoteId);
            return fiscalNote;
        }

        public Task UpdateAsync(FiscalNoteEntity fiscalNote)
        {
            var existingFiscalNote = _context.FiscalNotes
                .FirstOrDefaultAsync(f => f.FiscalNoteId == fiscalNote.FiscalNoteId);
            if (existingFiscalNote == null)
            {
                throw new InvalidOperationException("Nota fiscal não encontrada");
            }
            _context.FiscalNotes.Update(fiscalNote);
            return Task.CompletedTask;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
