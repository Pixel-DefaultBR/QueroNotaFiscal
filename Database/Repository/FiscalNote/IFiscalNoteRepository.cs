using QueroNotaFiscal.Models;

namespace QueroNotaFiscal.Database.Repository.FiscalNote
{
    public interface IFiscalNoteRepository
    {
        Task AddAsync(FiscalNoteEntity fiscalNote);
        Task UpdateAsync(FiscalNoteEntity fiscalNote);
        Task<FiscalNoteEntity?> GetByIdAsync(int fiscalNoteId);
        Task<IEnumerable<FiscalNoteEntity>> GetAllAsync();
        Task<FiscalNoteEntity> GetByIssuingCNPJAsync(string cnpj);
        Task CommitAsync();
    }
}
