namespace QueroNotaFiscal.DTOS
{
    public class FiscalNoteDto
    {
        public string FiscalNoteNumber { get; set; }
        public decimal TotalValue { get; set; }
        public string CNPJIssuing { get; set; }
        public string CNPJRecipent { get; set; }
    }
}
