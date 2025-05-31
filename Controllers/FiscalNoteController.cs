using Microsoft.AspNetCore.Mvc;
using QueroNotaFiscal.Services.FiscalNote;
using QueroNotaFiscal.Models.Requests;

namespace QueroNotaFiscal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FiscalNoteController : ControllerBase
    {
        private readonly IFiscalNotesService _fiscalNotesService;

        public FiscalNoteController(IFiscalNotesService fiscalNotesService)
        {
            _fiscalNotesService = fiscalNotesService;
        }

        [HttpGet("fiscalnotes")]
        public async Task<IActionResult> GetFiscalNotes()
        {
            var result = await _fiscalNotesService.GetAllAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
            return Ok(result);
        }

        [HttpPost("fiscalnote")]
        public async Task<IActionResult> AddFiscalNote([FromBody] FiscalNoteRequest request)
        {
            var result = await _fiscalNotesService.AddAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }

            return Ok(new { Message = "Nota fiscal adicionada com sucesso." });
        }

        [HttpPut("fiscalnote/{fiscalNoteId}")]
        public async Task<IActionResult> UpdateFiscalNote(int fiscalNoteId, [FromBody] FiscalNoteRequest request)
        {
            var result = await _fiscalNotesService.UpdateAsync(fiscalNoteId, request);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
            return Ok(new { Message = "Nota fiscal atualizada com sucesso." });
        }

        [HttpDelete("fiscalnote/{fiscalNoteId}")]
        public async Task<IActionResult> DeleteFiscalNote(int fiscalNoteId)
        {
            var result = await _fiscalNotesService.DeleteAsync(fiscalNoteId);
            if (!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
            return Ok(new { Message = "Nota fiscal excluída com sucesso." });
        }
    }
}
