using AutoMapper;
using QueroNotaFiscal.DTOS;
using QueroNotaFiscal.Models;
using QueroNotaFiscal.Models.Requests;

namespace QueroNotaFiscal.Mappers
{
    public class FiscalNoteMapper : Profile
    {
        public FiscalNoteMapper()
        {
            // Entidade => DTO de Resposta
            CreateMap<FiscalNoteEntity, FiscalNoteDto>();

            // DTO de Request => Entidade
            CreateMap<FiscalNoteRequest, FiscalNoteEntity>();
        }
    }
}
