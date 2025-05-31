using Microsoft.AspNetCore.Mvc;
using QueroNotaFiscal.Services.FiscalNote;

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

        [HttpGet]
        public async Task<IActionResult> GetFiscalNotes()
        {
            var result = await _fiscalNotesService.GetAllAsync();
            if(!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFiscalNote([FromBody] Models.Requests.FiscalNoteRequest request)
        {
            var result = await _fiscalNotesService.AddAsync(request);

            if(!result.IsSuccess)
            {
                return BadRequest(new { Message = result.ErrorMessage });
            }

            return Ok(new { Message = "Nota fiscal adicionada com sucesso." });
        }
    }
}
