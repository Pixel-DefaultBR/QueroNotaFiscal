using QueroNotaFiscal.Models;

namespace QueroNotaFiscal.Database.Repository.FiscalNote
{
    public interface IFiscalNoteRepository
    {
        Task AddAsync(FiscalNoteEntity fiscalNote);
        Task UpdateAsync(int fiscalNoteId, FiscalNoteEntity fiscalNote);
        Task DeleteAsync(int fiscalNoteId);
        Task<FiscalNoteEntity?> GetByIdAsync(int fiscalNoteId);
        Task<IEnumerable<FiscalNoteEntity>> GetAllAsync();
        Task<FiscalNoteEntity> GetByIssuingCNPJAsync(string cnpj);
        Task CommitAsync();
    }
}
