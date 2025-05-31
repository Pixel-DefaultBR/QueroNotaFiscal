using QueroNotaFiscal.DTOS;
using QueroNotaFiscal.Models;
using QueroNotaFiscal.Models.Requests;
using QueroNotaFiscal.Models.Response;

namespace QueroNotaFiscal.Services.FiscalNote
{
    public interface IFiscalNotesService
    {
        Task<Result<bool>> AddAsync(FiscalNoteRequest request);
        Task<Result<bool>> UpdateAsync(FiscalNoteRequest request);
        Task<Result<bool>> DeleteAsync(int fiscalNoteId);
        Task<Result<FiscalNoteDto?>> GetByIdAsync(int fiscalNoteId);
        Task<Result<IEnumerable<FiscalNoteDto>>> GetAllAsync();
    }
}
