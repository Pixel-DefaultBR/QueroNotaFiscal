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

            CreateMap<FiscalNoteEntity, FiscalNoteDto>();

            CreateMap<FiscalNoteRequest, FiscalNoteEntity>();
        }
    }
}
