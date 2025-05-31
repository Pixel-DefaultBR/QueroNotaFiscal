using QueroNotaFiscal.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QueroNotaFiscal.Models.Requests
{
    public class FiscalNoteRequest
    {
        [Required(ErrorMessage = "´Valor da nota é obrigatorio.")]
        public decimal TotalValue { get; set; }
        
        [Required(ErrorMessage = "CNPJ do emissor é obrigatória.")]
        [CNPJValidation(ErrorMessage = "CNPJ do emissor está no formato inválido.")]
        public string CNPJIssuing { get; set; }
        [Required(ErrorMessage = "CNPJ do destinatário é obrigatório.")]
        [CNPJValidation(ErrorMessage = "CNPJ do destinatário está no formato inválido.")]
        public string CNPJRecipient { get; set; }
    }
}
