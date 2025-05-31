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

        public async Task UpdateAsync(int fiscalNoteId, FiscalNoteEntity fiscalNote)
        {
            var existingFiscalNote = await _context.FiscalNotes
                .FirstOrDefaultAsync(f => f.FiscalNoteId == fiscalNoteId);

            existingFiscalNote.FiscalNoteNumber = fiscalNote.FiscalNoteNumber;
            existingFiscalNote.TotalValue = fiscalNote.TotalValue;
            existingFiscalNote.CNPJIssuing = fiscalNote.CNPJIssuing;
            existingFiscalNote.CNPJRecipent = fiscalNote.CNPJRecipent;

            _context.FiscalNotes.Update(existingFiscalNote);
        }


        public async Task DeleteAsync(int fiscalNoteId)
        {
            var fiscalNote = await _context.FiscalNotes
                .FirstOrDefaultAsync(f => f.FiscalNoteId == fiscalNoteId);

            _context.FiscalNotes.Remove(fiscalNote);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
