using QueroNotaFiscal.Database.Repository.FiscalNote;
using QueroNotaFiscal.DTOS;
using QueroNotaFiscal.Models.Requests;
using QueroNotaFiscal.Models.Response;
using QueroNotaFiscal.Utils;

namespace QueroNotaFiscal.Services.FiscalNote
{
    public class FiscalNotesService : IFiscalNotesService
    {
        private readonly IFiscalNoteRepository _fiscalNoteRepository;
        public FiscalNotesService(IFiscalNoteRepository fiscalNoteRepository)
        {
            _fiscalNoteRepository = fiscalNoteRepository ?? throw new ArgumentNullException(nameof(fiscalNoteRepository));
        }

        public async Task<Result<bool>> AddAsync(FiscalNoteRequest request)
        {

            string randomFiscalNoteNumber = GenerateFiscalNumber.GenerateNumber();

            var fiscalNoteExists = await _fiscalNoteRepository.GetByIssuingCNPJAsync(request.CNPJIssuing);

            if (fiscalNoteExists != null && fiscalNoteExists.FiscalNoteNumber == randomFiscalNoteNumber)
            {
                return Result<bool>.Failure("Nota fiscal já cadastrada para o CNPJ de emissão informado.");
            }

            var fiscalNoteEntity = new FiscalNoteEntity(
                $"N-{randomFiscalNoteNumber}",
                request.TotalValue,
                request.CNPJIssuing,
                request.CNPJRecipient
            );

            await _fiscalNoteRepository.AddAsync(fiscalNoteEntity);
            await _fiscalNoteRepository.CommitAsync();

            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> DeleteAsync(int fiscalNoteId)
        {
            var fiscalNote = await _fiscalNoteRepository.GetByIdAsync(fiscalNoteId);
            if (fiscalNote == null)
            {
                return Result<bool>.Failure("Nota fiscal não encontrada.");
            }

            await _fiscalNoteRepository.DeleteAsync(fiscalNoteId);
            await _fiscalNoteRepository.CommitAsync();

            return Result<bool>.Success(true);
        }

        public async Task<Result<IEnumerable<FiscalNoteDto>>> GetAllAsync()
        {
            var fiscalNotes = await _fiscalNoteRepository.GetAllAsync();

            var fiscalNoteResponse = fiscalNotes.Select(f => new FiscalNoteDto
            {
                FiscalNoteNumber = f.FiscalNoteNumber,
                TotalValue = f.TotalValue,
                CNPJIssuing = f.CNPJIssuing,
                CNPJRecipent = f.CNPJRecipent
            });

            return Result<IEnumerable<FiscalNoteDto>>.Success(fiscalNoteResponse);
        }

        public Task<Result<FiscalNoteDto?>> GetByIdAsync(int fiscalNoteId)
        {
            throw new NotImplementedException();
        }
 
        public async Task<Result<bool>> UpdateAsync(int fiscalNoteId, FiscalNoteRequest request)
        {
            var fiscalNote = await _fiscalNoteRepository.GetByIdAsync(fiscalNoteId);
            var fiscalNoteNumber = fiscalNote.FiscalNoteNumber;

            if (fiscalNote == null)
            {
                return Result<bool>.Failure("Nota fiscal não encontrada.");
            }

            await _fiscalNoteRepository.UpdateAsync(fiscalNoteId, new FiscalNoteEntity(
                $"N-{fiscalNote}",
                request.TotalValue,
                request.CNPJIssuing,
                request.CNPJRecipient
            ));

            await _fiscalNoteRepository.CommitAsync();
            return Result<bool>.Success(true);
        }
    }
}
